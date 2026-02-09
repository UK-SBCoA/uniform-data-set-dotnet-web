using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Models;

namespace UDS.Net.Forms.Pages.BulkErrorSubmission
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }
        public List<NACCErrorModel> PacketSubmissionErrors { get; set; } = new List<NACCErrorModel>();
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}
