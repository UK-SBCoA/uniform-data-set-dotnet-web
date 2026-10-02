using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class ExportModel : PageModel
    {
        private readonly IExportService _exportService;

        public ExportModel(IExportService exportService)
        {
            _exportService = exportService;
        }

        public async Task<IActionResult> OnGetAsync(int packetId)
        {
            //DEVNOTE: Call Export service and return csv file using packet Id
            //DEVNOTE: Error check for return data
            var csv = await _exportService.ConvertPacketToCSV(packetId, User.Identity.Name);

            //DEVNOTE: temporary file name
            return File(csv, "text/csv", "testfile.csv");
        }

        public async Task<IActionResult> OnPostExportMultiplePackets(int[] packetIds)
        {
            var csv = await _exportService.BulkConvertPacketsToCSV(packetIds, User.Identity.Name);

            return File(csv, "text/csv", "bulktestfile.csv");
        }
    }
}

