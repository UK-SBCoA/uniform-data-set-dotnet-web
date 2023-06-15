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
    public class B6Model : FormPageModel
    {
        [BindProperty]
        public B6 B6 { get; set; } = default!;

        public List<RadioListItem> DisagreeIncreasesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "0"),
            new RadioListItem("No", "1"),
            new RadioListItem("Did not answer", "9")
        };

        public List<RadioListItem> AgreeIncreasesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "1"),
            new RadioListItem("No", "0"),
            new RadioListItem("Did not answer", "9")
        };

        public B6Model(IVisitService visitService) : base(visitService, "B6")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
