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
    public class T1Model : FormPageModel
    {
        [BindProperty]
        public T1 T1 { get; set; } = default!;
        public T1Model(IVisitService visitService) : base(visitService, "T1")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
