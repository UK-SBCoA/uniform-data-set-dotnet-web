using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class ExportModel : PageModel
    {
        private readonly IExportService _exportService;
        private readonly IPacketService _packetService;
        private readonly IParticipationService _participationService;
        private readonly IVisitService _visitService;

        public ExportModel(IExportService exportService, IPacketService packetService, IParticipationService participationService, IVisitService visitService)
        {
            _exportService = exportService;
            _packetService = packetService;
            _participationService = participationService;
            _visitService = visitService;
        }

        public virtual async Task<IActionResult> OnGetAsync(int packetId)
        {
            var username = User.Identity.Name;
            //DEVNOTE: Call Export service and return csv file using packet Id
            //DEVNOTE: Error check for return data
            PacketExportItemModel newPacketExportItem = new PacketExportItemModel()
            {
                Packet = await _packetService.GetPacketWithForms(username, packetId),
                PreviousVisit = null,
                CountOfVisits = 0
            };

            newPacketExportItem.Packet.Participation = await _participationService.GetById(username, newPacketExportItem.Packet.ParticipationId);
            newPacketExportItem.CountOfVisits = await _visitService.GetVisitCountByVersion(username, newPacketExportItem.Packet.ParticipationId, "4.0.0");

            //DEVNOTE: Copying D1 date from export service. May want to pull this data from appsettings for both locations
            newPacketExportItem.IncludeD1cColumns = newPacketExportItem.Packet.VISIT_DATE >= new DateTime(2026, 7, 14);

            //DEVNOTE: This could have even more conditionals for checking for specific forms
            if (newPacketExportItem.Packet.VISITNUM >= newPacketExportItem.CountOfVisits && newPacketExportItem.CountOfVisits > 1)
            {
                newPacketExportItem.PreviousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(username, newPacketExportItem.Packet.ParticipationId, newPacketExportItem.Packet.VISITNUM - 1, newPacketExportItem.Packet.PACKET.ToString());
            }

            var csv = await _exportService.ConvertPacketToCSV(newPacketExportItem, User.Identity.Name);

            //DEVNOTE: temporary file name
            return File(csv, "text/csv", "testfile.csv");
        }

        public virtual async Task<IActionResult> OnPostExportMultiplePackets(int[] packetIds)
        {
            var csv = await _exportService.BulkConvertPacketsToCSV(packetIds, User.Identity.Name);

            return File(csv, "text/csv", "bulktestfile.csv");
        }
    }
}

