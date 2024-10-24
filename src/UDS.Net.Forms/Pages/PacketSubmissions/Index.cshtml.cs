using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class IndexModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        public PacketModel Packet { get; set; }

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

        public IndexModel(IParticipationService participationService, IPacketService packetService) : base()
        {
            _participationService = participationService;
            _packetService = packetService;
        }

        public async Task<IActionResult> OnGetAsync(int? packetId = null, int pageSize = 10, int pageIndex = 1)
        {
            if (packetId.HasValue)
            {
                var packet = await _packetService.GetById(User.Identity.Name, packetId.Value);

                if (packet == null)
                    return NotFound();

                var participation = await _participationService.GetById("", packet.ParticipationId);

                if (participation == null)
                    return NotFound();

                Packet = packet.ToVM();

                Packet.Participation = participation.ToVM();
            }
            else
            {
            }

            return Page();
        }
    }
}

