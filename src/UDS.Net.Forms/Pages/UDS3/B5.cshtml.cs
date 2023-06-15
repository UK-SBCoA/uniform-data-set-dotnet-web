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
    public class B5Model : FormPageModel
    {
        [BindProperty]
        public B5 B5 { get; set; } = default!;

        public List<RadioListItem> CoparticipantListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Spouse", "1"),
            new RadioListItem("Child", "2"),
            new RadioListItem("Other", "3")
        };

        public List<RadioListItem> SymptomPresentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "1"),
            new RadioListItem("No", "0"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SeverityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Mild", "1"),
            new RadioListItem("Mod", "2"),
            new RadioListItem("Severe", "3"),
            new RadioListItem("Unknown", "9"),
        };

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
