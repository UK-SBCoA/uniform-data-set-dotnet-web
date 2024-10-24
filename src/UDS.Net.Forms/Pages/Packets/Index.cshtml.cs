using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.Packets
{
    public class IndexModel : PageModel
    {
        private readonly IPacketService _packetService;

        public IList<PacketModel>? Packets { get; set; }

        public IndexModel(IPacketService packetService)
        {
            _packetService = packetService;
        }

        public async Task<IActionResult> OnGetAsync(int pageSize = 10, int pageIndex = 1)
        {
            List<PacketStatus> statuses = new List<PacketStatus>
            {
                PacketStatus.Finalized
            };

            var packets = await _packetService.List(User.Identity.Name, statuses, pageSize, pageIndex);

            Packets = packets.Select(p => p.ToVM()).ToList();

            return Page();
        }
    }
}
