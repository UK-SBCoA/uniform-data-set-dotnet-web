using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class B7Model : FormPageModel
    {
        [BindProperty]
        public B7 B7 { get; set; } = default!;

        public List<RadioListItem> ListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Not applicable (e.g., never did)", "8"),
            new RadioListItem("Normal", "0"),
            new RadioListItem("Has difficulty, but does by self", "1"),
            new RadioListItem("Requires assistance", "2"),
            new RadioListItem("Dependent", "3"),
            new RadioListItem("Unknown", "9")
        };

        public B7Model(IVisitService visitService) : base(visitService, "B7")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
