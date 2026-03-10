using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.MilestonesSubmissionErrors
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }
        [BindProperty]
        public int MilestoneId { get; set; }
        public List<NACCErrorModel> M1SubmissionErrors { get; set; } = new List<NACCErrorModel>();
        public IActionResult OnGet(int milestoneId)
        {
            MilestoneId = milestoneId;
            return Page();
        }
    }
}
