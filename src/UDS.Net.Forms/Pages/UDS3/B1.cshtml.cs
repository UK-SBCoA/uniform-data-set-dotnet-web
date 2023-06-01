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
    public class B1Model : FormPageModel
    {
        [BindProperty]
        public B1 B1 { get; set; } = default!;
        public B1Model(IVisitService visitService) : base(visitService, "B1")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
