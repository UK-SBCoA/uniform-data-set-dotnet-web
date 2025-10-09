using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Submission;
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
        public async Task<IActionResult> OnPostRenderExportModalAsync(List<int> packetId)
        {
            if (packetId == null || !packetId.Any())
                return NotFound();

            var selectedPackets = new List<Packet>();
            foreach (var id in packetId)
            {
                var packet = await _packetService.GetPacketWithForms(User.Identity?.Name, id);
                selectedPackets.Add(packet);
            }
            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial("_ExportModal", selectedPackets);
        }

    }
}
