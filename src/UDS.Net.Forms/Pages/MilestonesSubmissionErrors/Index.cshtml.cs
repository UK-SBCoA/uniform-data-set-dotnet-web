using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;

namespace UDS.Net.Forms.Pages.MilestonesSubmissionErrors
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }
        public List<NACCErrorModel> M1SubmissionErrors { get; set; } = new List<NACCErrorModel>();
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}
