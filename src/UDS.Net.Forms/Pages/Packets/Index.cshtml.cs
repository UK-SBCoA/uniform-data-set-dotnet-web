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

        public FilterModel Filter;

        public IndexModel(IPacketService packetService)
        {
            _packetService = packetService;
        }

        public async Task<IActionResult> OnGetAsync(string[] filter, int pageSize = 10, int pageIndex = 1, string search = "")
        {
            var allowedStatuses = new List<PacketStatus>
            {
                PacketStatus.Finalized,
                PacketStatus.Submitted,
                PacketStatus.FailedErrorChecks,
                PacketStatus.PassedErrorChecks
            };

            var allStatusNames = allowedStatuses.Select(s => s.ToString()).ToList();
            var selectedStatusNames = filter?.ToList() ?? new List<string>();

            Filter = new FilterModel(allStatusNames, selectedStatusNames);

            var selectedStatuses = Filter.SelectedItems.Any()
                ? Filter.SelectedItems
                    .Select(s => Enum.TryParse<PacketStatus>(s, out var parsed) ? (PacketStatus?)parsed : null)
                    .Where(s => s.HasValue && allowedStatuses.Contains(s.Value))
                    .Select(s => s.Value)
                    .ToList()
                : allowedStatuses;

            var packets = await _packetService.List(User.Identity.Name, selectedStatuses, pageSize, pageIndex);
            int total = await _packetService.Count(User.Identity.Name, selectedStatuses);

            Packets = packets.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
        public async Task<IActionResult> OnPostRenderExportModalAsync(List<int> packetId)
        {
            if (packetId == null || !packetId.Any())
                return NotFound();

            var selectedPackets = new List<PacketModel>();
            foreach (var id in packetId)
            {
                var packet = await _packetService.GetPacketWithForms(User.Identity?.Name, id);
                selectedPackets.Add(packet.ToVM());
            }
            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial("_ExportModal", selectedPackets);
        }

    }
}
