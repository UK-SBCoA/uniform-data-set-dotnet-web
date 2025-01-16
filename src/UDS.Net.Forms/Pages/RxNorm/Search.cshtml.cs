using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UDS.Net.Forms.Pages.RxNorm
{
    public class SearchModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; } = 0;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
                Id = id.Value;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            return Page();
        }
    }
}
