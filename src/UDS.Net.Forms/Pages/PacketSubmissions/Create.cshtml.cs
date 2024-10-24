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
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        [BindProperty]
        public PacketSubmissionModel? PacketSubmission { get; set; }

        public PacketModel? Packet { get; set; }

        public string PageTitle
        {
            get
            {
                if (Packet != null)
                {
                    return $"Participant {Packet.Participation.LegacyId} Visit {Packet.VISITNUM} Packet Submissions";
                }
                return "";
            }
        }

        public CreateModel(IParticipationService participationService, IPacketService packetService)
        {
            _participationService = participationService;
            _packetService = packetService;
        }

        public async Task<IActionResult> OnGetAsync(int? visitId)
        {
            if (visitId == null || visitId == 0)
                return NotFound();

            var packet = await _packetService.GetById("", visitId.Value);

            if (packet == null)
                return NotFound();

            var participation = await _participationService.GetById("", packet.ParticipationId);

            if (participation == null)
                return NotFound();

            Packet = packet.ToVM();

            Packet.Participation = participation.ToVM();

            PacketSubmission = new PacketSubmissionModel
            {
                VisitId = packet.Id,
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
                await _packetService.Update(User.Identity.IsAuthenticated ? User.Identity.Name : "Username", Packet.ToEntity());
            }
            catch (Exception ex)
            {
            }
            return RedirectToPage("./Index", new { VisitId = PacketSubmission.VisitId });
        }
    }
}

