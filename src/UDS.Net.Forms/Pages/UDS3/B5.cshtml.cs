using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class B5Model : FormPageModel
    {
        [BindProperty]
        public B5 B5 { get; set; } = default!;
        public B5Model(IVisitService visitService) : base(visitService, "B5")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
