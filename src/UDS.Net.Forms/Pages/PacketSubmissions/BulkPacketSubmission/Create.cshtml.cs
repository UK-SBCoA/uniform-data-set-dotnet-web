using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;
using System.Globalization;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.PacketSubmissions.BulkPacketSubmission
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

            //NACC PTID from error file will be the same as the legacy ID for a participation
            var legacyIdsFromPackets = new List<string>();

            foreach (var submittedPacket in submittedPackets)
            {
                var participation = await _participationService.GetById(User.Identity.Name, submittedPacket.ParticipationId);
                var legacyId = participation?.LegacyId;

                if (legacyId != null)
                {
                    legacyIdsFromPackets.Add(legacyId);
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

                        //NACC PTID from error file must have a matching legacy ID in participation tbl or the participation does not exist
                        if (record.Approved.ToLower() == "false" && legacyIdsFromPackets.Contains(record.Ptid))
                        {
                            NACCErrorModel newPacketSubmissionError = new NACCErrorModel
                            {
                                Type = record.Type,
                                Code = record.Code,
                                Location = record.Location,
                                File = record.File,
                                Value = record.Value,
                                Message = record.Message,
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

                var groupVisit = submittedPackets.Where(p => p.ParticipationId == groupParticipation?.Id).FirstOrDefault();

                if (groupVisit != null)
                {
                    var groupPacket = await _packetService.GetById(User.Identity.Name, groupVisit.Id);

                    var groupSubmission = groupPacket?.Submissions.Where(s => s.ErrorCount == null).FirstOrDefault();

                    List<PacketSubmissionError> groupPacketSubmissionErrors = new List<PacketSubmissionError>();

                    if (groupPacket != null && groupSubmission != null)
                    {
                        foreach (var error in errorGroup)
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

                        if (groupPacket.TryUpdateStatus(PacketStatus.FailedErrorChecks))
                        {
                            groupPacket.UpdateStatus(PacketStatus.FailedErrorChecks);

                            await _packetService.UpdatePacketSubmissionErrors(User.Identity.Name, groupPacket, groupSubmission.Id, groupPacketSubmissionErrors);
                        }
                    }
                }
            }

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
