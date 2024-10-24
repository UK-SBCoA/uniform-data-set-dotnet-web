using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Services;

namespace UDS.Net.Forms.Models.PageModels
{
    public class PacketPageModel : PageModel
    {
        protected readonly IPacketService _packetService;

        [BindProperty]
        public PacketModel? Packet { get; set; }

        public PacketPageModel(IPacketService packetService) : base()
        {
            _packetService = packetService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var packet = await _packetService.GetById("", id.Value);

            if (packet == null)
                return NotFound();

            Packet = packet.ToVM();

            return Page();
        }
    }
}

