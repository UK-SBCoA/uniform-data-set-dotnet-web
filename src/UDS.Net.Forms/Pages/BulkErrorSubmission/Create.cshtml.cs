using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Collections.Generic;
using System.Text.Json;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;
using UDS.Net.Forms.Models.Imports;

namespace UDS.Net.Forms.Pages.BulkErrorSubmission
{
    public class CreateModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;
        public IFormFile? ErrorFileUpload { get; set; }
        [BindProperty]
        public List<NACCErrorModel> PacketSubmissionErrors { get; set; } = new List<NACCErrorModel>();
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

            var legacyIdToVisitnum = new List<LegacyIdToVisitnumModel>();

            foreach (var submittedPacket in submittedPackets)
            {
                //DEVNOTE: NACC PTID from error file will be the same as the legacy ID for a participation.
                var participation = await _participationService.GetById(User.Identity.Name, submittedPacket.ParticipationId);

                if (participation != null)
                {
                    if (!string.IsNullOrEmpty(participation.LegacyId) && submittedPacket.VISITNUM > 0)
                    {
                        //Need to have legacyId and participationId to compare to the NACCErrors
                        legacyIdToVisitnum.Add(new LegacyIdToVisitnumModel
                        {
                            legacyId = participation.LegacyId,
                            VisitNumber = submittedPacket.VISITNUM
                        });
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
                        var legacyIdToVisitnumItem = legacyIdToVisitnum?.Where(lv => lv.legacyId == record.Ptid && lv.VisitNumber == int.Parse(record.Visitnum)).FirstOrDefault();

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

                            PacketSubmissionErrors.Add(newPacketSubmissionError);
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
            List<Packet> packetsToUpdate = new List<Packet>();

            //Setting page size to 999 to retrieve all packets by status
            IEnumerable<Visit> submittedPackets = await _visitService.ListByStatus(User.Identity.Name, 999, 1, [PacketStatus.Submitted.ToString()]);

            var submittedParticipationList = new List<Participation>();

            foreach (var packet in submittedPackets)
            {
                var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

                if (participation != null)
                {
                    submittedParticipationList.Add(participation);
                }
            }

            var packetSubmissionErrorsGrouped = PacketSubmissionErrors.GroupBy(p => p.Ptid);

            foreach (var errorGroup in packetSubmissionErrorsGrouped)
            {
                var groupPtid = errorGroup.ElementAt(0).Ptid;

                var groupParticipation = submittedParticipationList.Where(p => p.LegacyId == groupPtid).FirstOrDefault();

                //account for different visits, loop through each visit
                var visitGroups = errorGroup.Select(e => int.Parse(e.Visitnum)).Distinct().ToList();

                foreach (var visitNumber in visitGroups)
                {
                    var groupVisit = submittedPackets.Where(p => p.ParticipationId == groupParticipation?.Id && p.VISITNUM == visitNumber).FirstOrDefault();

                    if (groupVisit != null)
                    {
                        var groupPacket = await _packetService.GetById(User.Identity.Name, groupVisit.Id);

                        var groupSubmission = groupPacket?.Submissions.Where(s => s.ErrorCount == null).FirstOrDefault();

                        List<PacketSubmissionError> groupPacketSubmissionErrors = new List<PacketSubmissionError>();

                        if (groupPacket != null && groupSubmission != null)
                        {
                            foreach (var error in errorGroup)
                            {
                                //DEVNOTE: visitnum in NACCError is currently a string. Should this be changed?
                                if (int.Parse(error.Visitnum) == visitNumber)
                                {
                                    PacketSubmissionError newPacketSubmissionError = new PacketSubmissionError(
                                    id: 0,
                                    packetSubmissionId: groupSubmission.Id,
                                    formKind: error.Code.Split("-")[0].ToUpper(),
                                    message: error.Message,
                                    assignedTo: groupPacket.CreatedBy,
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
                                );

                                    groupPacketSubmissionErrors.Add(newPacketSubmissionError);
                                }
                            }

                            //Add submission errors to group packet, update count, and update status
                            groupSubmission.ErrorCount = groupPacketSubmissionErrors.Count;
                            groupSubmission.Errors = groupPacketSubmissionErrors;

                            if (groupPacket.TryUpdateStatus(PacketStatus.FailedErrorChecks))
                            {
                                groupPacket.UpdateStatus(PacketStatus.FailedErrorChecks);

                                packetsToUpdate.Add(groupPacket);
                            }
                        }
                    }
                }
            }

            var updatedPackets = await _packetService.UpdateMultiplePacketsSubmissionsErrors(User.Identity.Name, packetsToUpdate);

            //DEVNOTE: Begin checking results to make update info 

            string importStatus = "success";
            //array of packets update count and error update count
            var importDetails = new List<string>();
            var errorDetails = new List<string>();

            var errorsToUpdate = 0;
            var errorsUpdated = 0;

            importDetails.Add($"Packets Updated: {updatedPackets.Count()} / {packetsToUpdate.Count()}");

            for (var i = 0; i < packetsToUpdate.Count(); i++)
            {
                errorsToUpdate += packetsToUpdate[i].Submissions.Last().Errors.Count();

                //DEVNOTE: Need to retrieve updated packet manually, in case less were updated than to be updated

                //Get packet that was updated
                var packetUpdated = updatedPackets.Where(up => up.Id == packetsToUpdate[i].Id).FirstOrDefault();
                if (packetUpdated != null)
                {
                    //Get packet submission that was updated
                    var submissionUpdated = packetUpdated.Submissions.Where(p => p.Id == packetsToUpdate[i].Submissions.Last().Id).FirstOrDefault();

                    if (submissionUpdated != null)
                    {
                        //if it exists, add to errorsUpdated count
                        errorsUpdated += submissionUpdated.Errors.Count();
                    }
                    else
                    {
                        errorDetails.Add($"[PacketId: {packetsToUpdate[i].Id}] Packet submission could not be updated. Errors not imported");
                    }
                }
                else
                {
                    errorDetails.Add($"[PacketId: {packetsToUpdate[i].Id}] Packet could not be updated. Errors not imported");
                }
            }

            importDetails.Add($"Errors Imported: {errorsUpdated} / {errorsToUpdate}");

            //check for false import status
            if (updatedPackets.Count() != packetsToUpdate.Count()) importStatus = "fail";
            if (errorsUpdated != errorsToUpdate) importStatus = "fail";

            if (!string.IsNullOrEmpty(importStatus))
            {
                TempData["importStatus"] = importStatus;

                if (importStatus == "fail")
                {
                    TempData["errorDetails"] = JsonSerializer.Serialize(errorDetails);
                }
            }

            if (importDetails.Count() > 0)
            {
                TempData["importDetails"] = JsonSerializer.Serialize(importDetails);
            }

            //End update info

            return RedirectToPage("/Packets/Index");
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
