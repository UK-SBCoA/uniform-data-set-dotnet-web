using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Models.PageModels
{
    public class PacketPageModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        [BindProperty]
        public PacketModel? Packet { get; set; }

        public string PageTitle
        {
            get
            {
                if (Packet != null)
                {
                    return $"Participant {Packet.Participation.LegacyId} Visit {Packet.VISITNUM} Packet Submission";
                }
                return "";
            }
        }

        public PacketPageModel(IParticipationService participationService, IPacketService packetService) : base()
        {
            _participationService = participationService;
            _packetService = packetService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var packet = await _packetService.GetById("", id.Value);

            if (packet == null)
                return NotFound();


            var participation = await _participationService.GetById("", packet.ParticipationId);

            if (participation == null)
                return NotFound();

            Packet = packet.ToVM();

            Packet.Participation = participation.ToVM();

            return Page();
        }
    }
}

