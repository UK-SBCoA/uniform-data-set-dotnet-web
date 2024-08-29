using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Services;

namespace UDS.Net.Forms.Models.PageModels
{
    public class PacketSubmissionPageModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IPacketSubmissionService _packetSubmissionService;

        [BindProperty]
        public PacketSubmissionModel? PacketSubmission { get; set; }

        public VisitModel? Visit { get; set; }

        public PacketSubmissionPageModel(IVisitService visitService, IPacketSubmissionService packetSubmissionService) : base()
        {
            _visitService = visitService;
            _packetSubmissionService = packetSubmissionService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var packetSubmission = await _packetSubmissionService.GetById("", id.Value);

            if (packetSubmission == null)
                return NotFound();

            PacketSubmission = packetSubmission.ToVM();

            var visit = await _visitService.GetById("", packetSubmission.VisitId);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}

