using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class D1aModel : FormPageModel
    {

        [BindProperty]
        public D1a D1a { get; set; } = default!;

        public D1aModel(IVisitService visitService) : base(visitService, "D1a")
        {
        }

        public List<RadioListItem> DiagnosisMethodListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Single clinician", "1"),
            new RadioListItem("Formal consensus panel", "2"),
            new RadioListItem("Other (e.g., two or more clinicians or other informal group", "3")
        };

        public List<RadioListItem> NORMCOGListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 3)", "0"),
            new RadioListItem("Yes (CONTINUE TO QUESTION 2a) ", "1")

        };

        public List<RadioListItem> SCDListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (END FORM HERE)", "0"),
            new RadioListItem("Yes", "1")

        };

        public List<RadioListItem> SCDDXCONFListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (END FORM HERE)", "0"),
            new RadioListItem("Yes (END FORM HERE)", "1")

        };

        public List<RadioListItem> DEMENTEDListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (CONTINUE TO QUESTION 4)", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 6a)", "1")

        };

        public List<RadioListItem> MCIListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (CONTINUE TO QUESTION 5)", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 6a)", "1")

        };

        public List<RadioListItem> IMPNOMCIListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 7)", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 7)", "1")

        };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D1a = (D1a)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = D1a; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(D1a); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}