using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Globalization;
using System.Net.Sockets;
using System.Text.Json;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Pages.Participations;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.BulkErrorImport
{
    public class CreateModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;
        public IFormFile? ErrorFileUpload { get; set; }
        [BindProperty]
        public List<NACCErrorModel> PacketImportErrors { get; set; } = new List<NACCErrorModel>();
        public CreateModel(IVisitService visitService, IParticipationService participationService, IPacketService packetService)
        {
            _visitService = visitService;
            _participationService = participationService;
            _packetService = packetService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDisplayBulkSubmission()
        {
            if (ErrorFileUpload == null)
            {
                ModelState.AddModelError("ErrorFileUpload", "File not found");

                return Page();
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            int rowIndex = 0;

            //Setting page size to 999 to retrieve all packets by status
            IEnumerable<Visit> submittedPackets = await _visitService.ListByStatus(User.Identity.Name, 999, 1, [PacketStatus.Submitted.ToString()]);

            //Initialize tuple for storing legacyId and visitnum matches from a submittedPackets
            var legacyIdToVisitnum = new List<(string legacyId, int visitNum)>();

            foreach (var submittedPacket in submittedPackets)
            {
                //DEVNOTE: NACC PTID from error file will be the same as the legacy ID for a participation.
                var participation = await _participationService.GetById(User.Identity.Name, submittedPacket.ParticipationId);

                if (participation != null)
                {
                    if (!string.IsNullOrEmpty(participation.LegacyId) && submittedPacket.VISITNUM > 0)
                    {
                        //Need to have legacyId and participationId to compare to the NACCErrors
                        legacyIdToVisitnum.Add((participation.LegacyId, submittedPacket.VISITNUM));
                    }
                }
            }

            using (var stream = ErrorFileUpload.OpenReadStream())
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, config))
            {
                try
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<NACCErrorModel>();

                        //DEVNOTE: Record must match to a PTID and Visitnum of a submitted packet from legacyIdToVisitnum dictionary
                        var legacyIdToVisitnumItem = legacyIdToVisitnum?.Where(lv => lv.legacyId == record.Ptid && lv.visitNum == int.Parse(record.Visitnum)).FirstOrDefault();

                        if (legacyIdToVisitnumItem != null && record.Approved.ToLower() == "false")
                        {
                            NACCErrorModel newPacketSubmissionError = new NACCErrorModel
                            {
                                Type = record.Type,
                                Code = record.Code,
                                Location = record.Location,
                                File = record.File,
                                Value = record.Value,
                                //DEVNOTE: Trim message to avoid 500+ character truncade error
                                Message = record.Message.Length > 500 ? record.Message[..497] + "..." : record.Message,
                                Ptid = record.Ptid,
                                Visitnum = record.Visitnum,
                                Approved = record.Approved
                            };

                            PacketImportErrors.Add(newPacketSubmissionError);
                        }

                        rowIndex++;
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ErrorFileUpload", "An error reading the file has occured");

                    return Page();
                }
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostConfirmBulkSubmission()
        {
            var packetsToUpdate = new List<Packet>();

            //Setting page size to 999 to retrieve all packets of status due to pagination
            List<Packet> submittedPackets = await _packetService.List(User.Identity.Name, [PacketStatus.Submitted], 999);

            List<Participation> submittedPacketParticipations = await RetrieveParticipations(submittedPackets);

            foreach (var errorGroup in PacketImportErrors.GroupBy(p => p.Ptid))
            {
                //Each error in the error group must have a participation, if not then expect an error
                Participation groupParticipation = submittedPacketParticipations.Where(p => p.LegacyId == errorGroup.Key).FirstOrDefault();

                //will need to allow updating of previous visits as well, so get all visitNumbers for PTID number
                List<int> groupVisitNumbers = errorGroup.Select(e => int.Parse(e.Visitnum)).Distinct().ToList();

                foreach (var visitNumber in groupVisitNumbers)
                {
                    Packet packet = submittedPackets.Where(p => p.ParticipationId == groupParticipation?.Id && p.VISITNUM == visitNumber).First();

                    if (packet.TryUpdateStatus(PacketStatus.FailedErrorChecks))
                    {
                        packet.UpdateStatus(PacketStatus.FailedErrorChecks);

                        packet.Submissions.Last().Errors = CreatePacketSubmissionErrors(errorGroup, packet);

                        packet.Submissions.Last().ErrorCount = packet.Submissions.Last().Errors.Count;
                        
                        packetsToUpdate.Add(packet);
                    }
                }
            }

            List<Packet> updatedPackets = await _packetService.UpdateMultiplePacketsSubmissionsErrors(User.Identity.Name, packetsToUpdate);

            //DEVNOTE: Create post import information using return from updatedPackets

            string importStatus = "success";
            //DEVNOTE: Packets updated and errors imported
            var importDetails = new List<string>();
            //DEVNOTE: Details on import errors
            var errorDetails = new List<string>();

            var errorsToUpdate = 0;
            var errorsUpdated = 0;

            importDetails.Add($"Packets Updated: {updatedPackets.Count()} / {packetsToUpdate.Count()}");

            for (var i = 0; i < packetsToUpdate.Count(); i++)
            {
                errorsToUpdate += packetsToUpdate[i].Submissions.Last().Errors.Count();

                var packetUpdated = updatedPackets.Where(up => up.Id == packetsToUpdate[i].Id).FirstOrDefault();

                if (packetUpdated != null)
                {
                    //DEVNOTE: Get packet submission that was updated
                    var submissionUpdated = packetUpdated.Submissions.Where(p => p.Id == packetsToUpdate[i].Submissions.Last().Id).FirstOrDefault();

                    if (submissionUpdated != null)
                    {
                        errorsUpdated += submissionUpdated.Errors.Count();
                    }
                    else
                    {
                        //DEVNOTE: If packet was fond, but submission was not updated
                        errorDetails.Add($"[ Participation Id: {packetsToUpdate[i].ParticipationId} | Visit Number: {packetsToUpdate[i].VISITNUM} ] Packet submission could not be updated. Errors not imported");
                    }
                }
                else
                {
                    //DEVNOTE: If packet was not updated
                    errorDetails.Add($"[ Participation Id: {packetsToUpdate[i].ParticipationId} | Visit Number: {packetsToUpdate[i].VISITNUM} ] Packet could not be updated. Errors not imported");
                }
            }

            importDetails.Add($"Errors Imported: {errorsUpdated} / {errorsToUpdate}");

            if (updatedPackets.Count() != packetsToUpdate.Count()) importStatus = "fail";

            if (errorsUpdated != errorsToUpdate) importStatus = "fail";

            //DEVNOTE: set temp data for view
            TempData["importStatus"] = importStatus;

            if (importStatus == "fail")
            {
                TempData["errorDetails"] = JsonSerializer.Serialize(errorDetails);
            }

            if (importDetails.Count() > 0)
            {
                TempData["importDetails"] = JsonSerializer.Serialize(importDetails);
            }

            return RedirectToPage("/Packets/Index");
        }

        private async Task<List<Participation>> RetrieveParticipations(IEnumerable<Packet> packets)
        {
            List<Participation> participations = new List<Participation>();

            foreach (var packet in packets)
            {
                participations.Add(await _participationService.GetById(User.Identity.Name, packet.ParticipationId));
            }

            return participations;
        }

        private List<PacketSubmissionError> CreatePacketSubmissionErrors(IGrouping<string, NACCErrorModel> errorGroup, Packet packet)
        {
            List<PacketSubmissionError> packetSubmissionErrors = new List<PacketSubmissionError>();

            foreach (var error in errorGroup)
            {
                if (int.Parse(error.Visitnum) == packet.VISITNUM)
                {
                    packetSubmissionErrors.Add(new PacketSubmissionError
                    (
                        id: 0,
                        packetSubmissionId: packet.Submissions.Last().Id,
                        formKind: error.Code.Split("-")[0].ToUpper(),
                        message: error.Message,
                        assignedTo: packet.CreatedBy,
                        level: GetErrorLevel(error.Type),
                        status: PacketSubmissionErrorStatus.Pending,
                        statusChangedBy: null,
                        createdAt: DateTime.Now,
                        createdBy: User.Identity.Name,
                        modifiedBy: null,
                        deletedBy: null,
                        isDeleted: false,
                        location: error.Location?.ToUpper(),
                        value: error.Value
                    ));
                }
            }

            return packetSubmissionErrors;
        }

        //DEVNOTE: Copied from the packetSubmissionError/Create.cshtml.cs
        private static PacketSubmissionErrorLevel GetErrorLevel(string errorType)
        {
            if (errorType.Trim().ToLower() == "alert")
            {
                return PacketSubmissionErrorLevel.Information;
            }
            else if (errorType.Trim().ToLower() == "error")
            {
                return PacketSubmissionErrorLevel.Error;
            }

            //return information as default
            return PacketSubmissionErrorLevel.Information;
        }
    }
}
