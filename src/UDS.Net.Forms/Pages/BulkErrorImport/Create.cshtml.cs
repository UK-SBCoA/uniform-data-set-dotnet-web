using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Models;
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
        public List<BulkErrorSubmissionItem> SubmissionErrors { get; set; } = new List<BulkErrorSubmissionItem>();
        public List<BulkErrorImportItem> PacketsToDisplay { get; set; } = new List<BulkErrorImportItem>();
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
        public async Task<IActionResult> OnPostDisplayBulkImport()
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

            //page size to 999 to retrieve maximum packets by status
            //var submittedPackets = await _visitService.ListByStatus(User.Identity.Name, 999, 1, [PacketStatus.Submitted.ToString()]);

            //DEVNOTE: Using the _packetService list method instead so I can include packetsubmissionerrors later on
            var submittedPackets = await _packetService.List(User.Identity.Name, [PacketStatus.Submitted], 999);

            //Initialize tuple for storing legacyId and visitnum paring of each submitted packet
            var legacyIdVisitnumPairs = new List<(string legacyId, int visitNum)>();

            foreach (var packet in submittedPackets)
            {
                //DEVNOTE: what if we just add the participation directly to the submitted packet? 
                packet.Participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

                //DEVNOTE: NACC PTID from error file will be the same as the legacy ID for a matching participation.
                //var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

                //if (!string.IsNullOrEmpty(participation.LegacyId) && packet.VISITNUM > 0)
                //{
                //    legacyIdVisitnumPairs.Add((participation.LegacyId, packet.VISITNUM));
                //}
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

                        //DEVNOTE: Temporary name
                        var matchedSubmittedPacketForError = submittedPackets.FirstOrDefault(packet => packet.Participation.LegacyId == record.Ptid && packet.VISITNUM == int.Parse(record.Visitnum));
                        //var matchedLegacyIdVisitnumPair = legacyIdVisitnumPairs?.Where(pair => pair.legacyId == record.Ptid && pair.visitNum == int.Parse(record.Visitnum)).FirstOrDefault();

                        //if (!string.IsNullOrEmpty(matchedLegacyIdVisitnumPair?.legacyId) && record.Approved.ToLower() == "false")
                        //DEVNOTE: check for matchedSubmittedPacketForError was found isntead of using the legacy id / visitnum tuple
                        if (matchedSubmittedPacketForError != null && record.Approved.ToLower() == "false")
                        {
                            //DEVNOTE:
                            //Here I am already matching nacc errors to packets with legacyId and approved.
                            //Maybe I can just create the packetSubmission error here to connect for the view
                            //NACCErrorModel newNACCError = new NACCErrorModel
                            //{
                            //    Type = record.Type,
                            //    Code = record.Code,
                            //    Location = record.Location,
                            //    File = record.File,
                            //    Value = record.Value,
                            //    //DEVNOTE: Trim message to avoid 500+ character truncade error
                            //    Message = record.Message.Length > 500 ? record.Message[..497] + "..." : record.Message,
                            //    Ptid = record.Ptid,
                            //    Visitnum = record.Visitnum,
                            //    Approved = record.Approved
                            //};

                            //NACCSubmissionErrors.Add(newNACCError);

                            //DEVNOTE: Get the most recent submission to update
                            var matchedSubmittedPacketSubmission = matchedSubmittedPacketForError.Submissions.Last();

                            matchedSubmittedPacketSubmission.Errors.Add(new PacketSubmissionError
                            (
                                id: 0,
                                packetSubmissionId: matchedSubmittedPacketForError.Submissions.Last().Id,
                                formKind: record.Code.Split("-")[0].ToUpper(),
                                message: record.Message,
                                assignedTo: matchedSubmittedPacketForError.CreatedBy,
                                level: GetErrorLevel(record.Type),
                                status: PacketSubmissionErrorStatus.Pending,
                                statusChangedBy: null,
                                createdAt: DateTime.Now,
                                createdBy: User.Identity.Name,
                                modifiedBy: null,
                                deletedBy: null,
                                isDeleted: false,
                                location: record.Location?.ToUpper(),
                                value: record.Value
                            ));

                            
                            matchedSubmittedPacketSubmission.ErrorCount = matchedSubmittedPacketSubmission.ErrorCount == null ? 1 : matchedSubmittedPacketSubmission.ErrorCount += 1;
                        }
                    }

                    //DEVNOTE: Changing to use list of bulkErrorDiplayItemModel
                    //SubmittedPacketsToUpdate = submittedPackets;

                    foreach (var packet in submittedPackets)
                    {
                        //PacketsToUpdate.Add(singlePacket);
                        var newBulkErrorImportItem = new BulkErrorImportItem
                        {
                            PacketToImport = packet,
                            ConfirmImport = false
                        };

                        PacketsToDisplay.Add(newBulkErrorImportItem);
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
        public async Task<IActionResult> OnPostConfirmBulkImport()
        {
            //DEVNOTE: recieve submission errors from display view, use that to save new sumbmissions on packets INSTEAD using NACC errors to gather data as before

            var packetsToUpdate = new List<Packet>();

            ////Setting page size to 999 to retrieve all packets of status due to pagination
            //var submittedPackets = await _packetService.List(User.Identity.Name, [PacketStatus.Submitted], 999);

            //var submittedPacketParticipations = await GetParticipationsFromPackets(submittedPackets);

            //foreach (var errorGroup in NACCSubmissionErrors.GroupBy(p => p.Ptid))
            //{
            //    //All errors from the NACC error file must have a participation. If not, then expect an error.
            //    var participationForGroup = submittedPacketParticipations.Where(p => p.LegacyId == errorGroup.Key).First();

            //    //Allow updating of previous visit numbers, so get all unique visit numbers for a PTID grouping of the NACC errors
            //    var groupVisitNumbers = errorGroup.Select(e => int.Parse(e.Visitnum)).Distinct().ToList();

            //    foreach (var visitNumber in groupVisitNumbers)
            //    {
            //        var matchingPacket = submittedPackets.Where(p => p.ParticipationId == participationForGroup.Id && p.VISITNUM == visitNumber).First();

            //        if (matchingPacket.TryUpdateStatus(PacketStatus.FailedErrorChecks))
            //        {
            //            matchingPacket.UpdateStatus(PacketStatus.FailedErrorChecks);

            //            var submission = matchingPacket.Submissions.Last();

            //            submission.Errors = CreatePacketSubmissionErrors(errorGroup, matchingPacket);
            //            submission.ErrorCount = submission.Errors.Count;

            //            packetsToUpdate.Add(matchingPacket);
            //        }
            //    }
            //}

            //List<Packet> updatedPacketsReturned = await _packetService.UpdateMultiplePacketsSubmissionsErrors(User.Identity.Name, SubmittedPacketsToUpdate);

            return RedirectToPage("/Packets/Index");
        }

        private async Task<List<Participation>> GetParticipationsFromPackets(IEnumerable<Packet> packets)
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
