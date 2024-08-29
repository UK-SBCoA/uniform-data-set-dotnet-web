using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class ExportModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IPacketSubmissionService _packetSubmissionService;
        protected readonly IParticipationService _participationService;

        public bool Processed { get; set; } = false;

        public ExportModel(IVisitService visitService, IPacketSubmissionService packetSubmissionService, IParticipationService participationService)
        {
            _visitService = visitService;
            _packetSubmissionService = packetSubmissionService;
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
                return NotFound();

            // TODO use temporal tables to get the data at that point in time of the submission
            var packetSubmission = await _packetSubmissionService.GetById(User.Identity.Name, id);

            var visit = await _visitService.GetById(User.Identity.Name, packetSubmission.VisitId);

            var participant = await _participationService.GetById(User.Identity.Name, visit.ParticipationId);

            var vm = packetSubmission.ToVM();

            string filename = vm.GetFileName(participant.LegacyId, visit.VISIT_DATE);

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);

            using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, true))
            {
                csv.WriteRecords(visit.Forms);
            }

            Processed = true;

            memoryStream.Position = 0;
            Response.Headers["Content-Disposition"] = $"attachment; {filename}";
            return File(memoryStream, "text/csv", filename);
        }
    }
}

