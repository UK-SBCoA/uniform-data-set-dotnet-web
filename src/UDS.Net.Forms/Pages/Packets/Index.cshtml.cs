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

        public PacketsPaginatedModel Packets { get; set; } = new PacketsPaginatedModel();

        public IndexModel(IPacketService packetService)
        {
            _packetService = packetService;
        }

        [BindProperty]
        public List<int> SelectedPackets { get; set; } = new List<int>();

        public async Task<IActionResult> OnGetAsync(int pageSize = 10, int pageIndex = 1, string search = "")
        {
            List<PacketStatus> statuses = new List<PacketStatus>
            {
                PacketStatus.Finalized,
                PacketStatus.Submitted,
                PacketStatus.FailedErrorChecks,
                PacketStatus.PassedErrorChecks
            };

            var packets = await _packetService.List(User.Identity.Name, statuses, pageSize, pageIndex);

            int total = await _packetService.Count(User.Identity.Name, statuses);

            Packets = packets.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
