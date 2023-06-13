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
    public class B4Model : FormPageModel
    {
        [BindProperty]
        public B4 B4 { get; set; } = default!;

        public List<RadioListItem> ImpairmentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("None", "0"),
            new RadioListItem("Questionable", "0.5"),
            new RadioListItem("Mild", "1"),
            new RadioListItem("Moderate", "2"),
            new RadioListItem("Severe", "3"),
        };

        public List<RadioListItem> ImpairmentSimpleListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("None", "0"),
            new RadioListItem("Mild", "1"),
            new RadioListItem("Moderate", "2"),
            new RadioListItem("Severe", "3"),
        };

        public B4Model(IVisitService visitService) : base(visitService, "B4")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
