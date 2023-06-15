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
    public class D2Model : FormPageModel
    {
        [BindProperty]
        public D2 D2 { get; set; } = default!;

        public List<RadioListItem> CancerListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 2)", "0"),
            new RadioListItem("Yes, primary/non-metastatic", "1"),
            new RadioListItem("Yes, metastatic", "2"),
            new RadioListItem("Not assessed (skip to question 2)", "8")
        };

        public List<RadioListItem> DiabetesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes, Type I", "1"),
            new RadioListItem("Yes, Type II", "2"),
            new RadioListItem("Yes, other type (diabetes insipidus, latent autoimmune diabetes/type 1.5, gestational diabetes)", "3"),
            new RadioListItem("Not assessed or unknown", "8")
        };

        public List<RadioListItem> SimpleListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Not assessed", "8")
        };

        public List<RadioListItem> ArthritisListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Rheumatoid", "1"),
            new RadioListItem("Osteoarthritis", "2"),
            new RadioListItem("Other (specify)", "3"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> NoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> ListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("", "")
        };

        public D2Model(IVisitService visitService) : base(visitService, "D2")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
