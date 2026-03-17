using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

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
                                //DEVNOTE: Trim message to avoid 500+ character truncade error
                                Message = record.Message.Length > 500 ? record.Message[..497] + "..." : record.Message,
                                Ptid = record.Ptid,
                                Visitnum = record.Visitnum,
                                Approved = record.Approved,
                                ImportedBy = User.Identity.Name
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
            var testNewRoute = await _packetService.UpdateMultiplePacketsSubmissionsErrors(User.Identity.Name, PacketSubmissionErrors.ToDomain());

            return RedirectToPage("/Packets/Index");
        }
    }
}
