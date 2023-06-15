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
    public class C1Model : FormPageModel
    {
        [BindProperty]
        public C1 C1 { get; set; } = default!;

        public List<RadioListItem> SimpleNoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> MMSECompletedListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 2a)", "0"),
            new RadioListItem("Yes (continue to question 1a)", "1")
        };

        public List<RadioListItem> LocationListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("In ADC/clinic", "1"),
            new RadioListItem("In home", "2"),
            new RadioListItem("In person - other", "3")
        };

        public List<RadioListItem> LanguageListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("English", "1"),
            new RadioListItem("Spanish", "2"),
            new RadioListItem("Other (specify)", "3")
        };

        public List<RadioListItem> OverallListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Better than normal for age", "1"),
            new RadioListItem("Normal for age", "2"),
            new RadioListItem("One or two test scores are abnormal", "3"),
            new RadioListItem("Three or more scores are abnormal or lower than expected", "4"),
            new RadioListItem("Clinician unable to render opinion", "0")
        };

        public C1Model(IVisitService visitService) : base(visitService, "C1")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
