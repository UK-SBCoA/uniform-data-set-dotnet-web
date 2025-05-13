using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
namespace UDS.Net.Forms.Pages.PacketSubmissionErrors
{
    public class CreateModel : PageModel
    {
        List<PacketSubmissionErrorModel> packetSubmissionErrors = new List<PacketSubmissionErrorModel>();

        public IActionResult OnGet()
        {
            var test = "test";

            return Page();
        }
    }
}

