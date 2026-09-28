using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Overrides.CsvHelper;
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
            var csv = await _exportService.ConvertPacketToCSV(packetId, User.Identity.Name);

            //Begin file dowload in browser without changing views
            //return File(memoryStream, "text/csv", filename);

            return null;
        }
    }
}

