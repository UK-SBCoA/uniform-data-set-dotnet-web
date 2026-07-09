using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;
using System.Globalization;
using System.Text.RegularExpressions;
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
        //DEVNOTE: for the confirm logic, rename the type for better naming
        public List<BulkImportConfirmItem> BulkErrorSubmissionItems { get; set; } = new List<BulkImportConfirmItem>();
        public List<Packet> RemainingSubmittedPackets { get; set; } = new List<Packet>(); 
        //DEVNOTE: for the display logic rename the type for better naming
        public List<BulkImportDisplayItem> PacketsToDisplay { get; set; } = new List<BulkImportDisplayItem>();
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

            var submittedPackets = await _packetService.List(User.Identity.Name, [PacketStatus.Submitted], 999);

            //Initialize tuple for storing legacyId and visitnum paring of each submitted packet
            var legacyIdVisitnumPairs = new List<(string legacyId, int visitNum)>();

            foreach (var packet in submittedPackets)
            {
                packet.Participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);
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

                        if (matchedSubmittedPacketForError != null && record.Approved.ToLower() == "false")
                        {
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

                    foreach (var packet in submittedPackets)
                    {
                        var newImportDisplayItem = new BulkImportDisplayItem
                        {
                            PacketToImport = packet
                        };

                        PacketsToDisplay.Add(newImportDisplayItem);
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
            var packetsToUpdate = new List<Packet>();

            ////Setting page size to 999 to retrieve all packets of status due to pagination
            var submittedPackets = await _packetService.List(User.Identity.Name, [PacketStatus.Submitted], 999);

            var confirmedBulkErrorSubmissionItems = BulkErrorSubmissionItems.Where(i => i.ConfirmImport).ToList();

            foreach (var bulkSubmissionItemGroup in confirmedBulkErrorSubmissionItems.GroupBy(s => s.SubmissionErrors[0].PacketSubmissionId))
            {
                //bulkSubmissionItemGroup.Key == PacketSubmissionId
                var matchedPacket = submittedPackets.Where(p => p.Submissions.Any(s => s.Id == bulkSubmissionItemGroup.Key)).FirstOrDefault();

                var matchedActiveSubmission = matchedPacket?.Submissions.Last();

                if (matchedActiveSubmission != null && matchedPacket != null)
                {
                    //DEVNOTE: Check for if status is null 
                    var updatedStatus = bulkSubmissionItemGroup.Select(group => group.PacketStatus).FirstOrDefault();

                    if (matchedPacket.TryUpdateStatus(updatedStatus))
                    {
                        matchedPacket.UpdateStatus(updatedStatus);

                        matchedActiveSubmission.Errors = CreatePacketSubmissionErrors(bulkSubmissionItemGroup, matchedActiveSubmission);

                        //Update packet error count
                        matchedActiveSubmission.ErrorCount = matchedActiveSubmission.Errors.Count;

                        packetsToUpdate.Add(matchedPacket);
                    }
                }
            }

            //run the API update method on the updated packets list
            List<Packet> updatedPacketsReturned = await _packetService.UpdateMultiplePacketsSubmissionsErrors(User.Identity.Name, packetsToUpdate);

            return Partial("_postImportView", new BulkImportConfirmViewModel
            {
                UpdatedPackets = updatedPacketsReturned,
                RemainingSubmittedPackets = submittedPackets.ExceptBy(updatedPacketsReturned.Select(u => u.Id), s => s.Id).ToList()
            });
        }

        private List<PacketSubmissionError> CreatePacketSubmissionErrors(IGrouping<int, BulkImportConfirmItem> bulkSubmissionItemGroup, PacketSubmission matchedActiveSubmission)
        {
            var newPacketSubmissionErrors = new List<PacketSubmissionError>();

            foreach (var item in bulkSubmissionItemGroup.SelectMany(e => e.SubmissionErrors))
            {
                //DEVNOTE: currently creating a new object. Using submission error because submission error Model domain object doesn't have a null constructor to initialize
                newPacketSubmissionErrors.Add(new PacketSubmissionError
                (
                    id: 0,
                    packetSubmissionId: matchedActiveSubmission.Id,
                    formKind: item.FormKind,
                    message: item.Message,
                    assignedTo: item.AssignedTo,
                    level: item.Level,
                    status: item.Status,
                    statusChangedBy: item.StatusChangedBy,
                    createdAt: item.CreatedAt,
                    createdBy: item.CreatedBy,
                    modifiedBy: item.ModifiedBy,
                    deletedBy: item.DeletedBy,
                    isDeleted: item.IsDeleted,
                    location: item.Location,
                    value: item.Value
                ));
            }

            return newPacketSubmissionErrors;
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

            return PacketSubmissionErrorLevel.Information;
        }
    }
}
