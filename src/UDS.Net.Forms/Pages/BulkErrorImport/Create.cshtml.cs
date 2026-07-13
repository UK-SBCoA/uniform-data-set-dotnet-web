using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;
using System.Globalization;
using System.Text.RegularExpressions;
using UDS.Net.Forms.Extensions;
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
        public List<BulkImportConfirmItem> BulkImportConfirmItems { get; set; } = new List<BulkImportConfirmItem>();
        public List<BulkImportDisplayItem> BulkImportDisplayItems { get; set; } = new List<BulkImportDisplayItem>();
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

            //Initialize tuple for storing legacyId and visitnum pairing of each submitted packet
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

                        var matchedPacket = submittedPackets.FirstOrDefault(packet => packet.Participation.LegacyId == record.Ptid && packet.VISITNUM == int.Parse(record.Visitnum));

                        if (matchedPacket != null && record.Approved.ToLower() == "false")
                        {
                            var matchedPacketActiveSubmission = matchedPacket.Submissions.Last();

                            matchedPacketActiveSubmission.Errors.Add(new PacketSubmissionError
                            (
                                id: 0,
                                packetSubmissionId: matchedPacket.Submissions.Last().Id,
                                formKind: record.Code.Split("-")[0].ToUpper(),
                                message: record.Message,
                                assignedTo: matchedPacket.CreatedBy,
                                level: GetErrorLevel(record.Type),
                                status: PacketSubmissionErrorStatus.Pending,
                                statusChangedBy: User.Identity.Name,
                                createdAt: DateTime.Now,
                                createdBy: User.Identity.Name,
                                modifiedBy: User.Identity.Name,
                                deletedBy: null,
                                isDeleted: false,
                                location: record.Location?.ToUpper(),
                                value: record.Value
                            ));

                            
                            matchedPacketActiveSubmission.ErrorCount = matchedPacketActiveSubmission.ErrorCount == null ? 1 : matchedPacketActiveSubmission.ErrorCount += 1;
                        }
                    }

                    foreach (var packet in submittedPackets)
                    {
                        var newImportDisplayItem = new BulkImportDisplayItem
                        {
                            PacketToImport = packet
                        };

                        BulkImportDisplayItems.Add(newImportDisplayItem);
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

            var confirmedSubmissionErrors = BulkImportConfirmItems.Where(i => i.ConfirmImport).ToList();

            //Submission Errors in a BulkImportConfirmItem will share a packetSubmissionId, so we only grab the first submissionError in the list
            foreach (var submissionErrorGroup in confirmedSubmissionErrors.GroupBy(s => s.SubmissionErrors[0].PacketSubmissionId))
            {
                var matchedPacket = submittedPackets.Where(p => p.Submissions.Any(s => s.Id == submissionErrorGroup.Key)).FirstOrDefault();

                var matchedActiveSubmission = matchedPacket?.Submissions.Last();

                if (matchedActiveSubmission != null && matchedPacket != null)
                {
                    var updatedStatus = submissionErrorGroup.Select(group => group.PacketStatus).FirstOrDefault();

                    if (matchedPacket.TryUpdateStatus(updatedStatus))
                    {
                        matchedPacket.UpdateStatus(updatedStatus);

                        matchedActiveSubmission.Errors = submissionErrorGroup
                            .SelectMany(e => e.SubmissionErrors.ToEntity()
                                .Select(error =>
                                {
                                    error.PacketSubmissionId = matchedActiveSubmission.Id;
                                    return error;
                                })
                            ).ToList();

                        matchedActiveSubmission.ErrorCount = matchedActiveSubmission.Errors.Count;

                        packetsToUpdate.Add(matchedPacket);
                    }
                }
            }

            List<Packet> updatedPacketsReturned = await _packetService.UpdateMultiplePacketsSubmissionsErrors(User.Identity.Name, packetsToUpdate);

            return Partial("_ImportConfirm", new BulkImportConfirmViewModel
            {
                UpdatedPackets = updatedPacketsReturned,
                UnmodifiedPackets = submittedPackets.ExceptBy(updatedPacketsReturned.Select(u => u.Id), s => s.Id).ToList()
            });
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
