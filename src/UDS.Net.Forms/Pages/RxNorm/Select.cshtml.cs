using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UDS.Net.Forms.Pages.RxNorm
{
    public class SelectModel : PageModel
    {
        public async Task<IActionResult> OnGet(int id, string searchTerm)
        {
            var test = "";
            return Page();
        }
    }
}
