using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class CreateModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        protected readonly IPacketSubmissionService _packetSubmissionService;

        [BindProperty]
        public PacketSubmissionModel? PacketSubmission { get; set; }

        public VisitModel? Visit { get; set; }

        public string PageTitle
        {
            get
            {
                if (Visit != null)
                {
                    return $"Participant {Visit.Participation.LegacyId} Visit {Visit.VISITNUM} Packet Submissions";
                }
                return "";
            }
        }

        public CreateModel(IVisitService visitService, IParticipationService participationService, IPacketSubmissionService packetSubmissionService)
        {
            _visitService = visitService;
            _participationService = participationService;
            _packetSubmissionService = packetSubmissionService;
        }

        public async Task<IActionResult> OnGetAsync(int? visitId)
        {
            if (visitId == null || visitId == 0)
                return NotFound();

            var visit = await _visitService.GetById("", visitId.Value);

            if (visit == null)
                return NotFound();

            var participation = await _participationService.GetById("", visit.ParticipationId);

            if (participation == null)
                return NotFound();

            Visit = visit.ToVM();

            Visit.Participation = participation.ToVM();

            PacketSubmission = new PacketSubmissionModel
            {
                VisitId = visit.Id,
                SubmissionDate = DateTime.Now,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Username"
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                // TODO add isn't working yet
                await _packetSubmissionService.Add(User.Identity.IsAuthenticated ? User.Identity.Name : "Username", PacketSubmission.ToEntity());
            }
            catch (Exception ex)
            {
            }
            return RedirectToPage("./Index", new { VisitId = PacketSubmission.VisitId });
        }
    }
}

