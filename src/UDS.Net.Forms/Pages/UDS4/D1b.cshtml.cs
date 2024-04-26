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
    public class D1bModel : FormPageModel
    {
        [BindProperty]
        public D1b D1b { get; set; } = default!;

        public D1bModel(IVisitService visitService) : base(visitService, "D1b")
        {
        }

        public List<RadioListItem> BIOMARKDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 12)", "0"),
            new RadioListItem("Yes (CONTINUE TO QUESTION 2)", "1")
        };

        public List<RadioListItem> FLUIDBIOMListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 5)", "0"),
            new RadioListItem("Yes, only blood-based biomarkers were used (CONTINUE TO QUESTION 3, and SKIP QUESTIONS 4 – 4d)", "1"),
            new RadioListItem("Yes, only CSF-based biomarkers were used (SKIP TO QUESTION 4)", "2"),
            new RadioListItem("Yes, both blood- and CSF-based biomarkers were used", "3")
        };

        public List<RadioListItem> FindingsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Indeterminate", "9")
        };

        public List<RadioListItem> IMAGINGDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 6b)", "0"),
            new RadioListItem("Yes, only PET/SPECT imaging was used (CONTINUE TO QUESTION 6, and SKIP QUESTIONS 7 – 7a3f)", "1"),
            new RadioListItem("Yes, only MR imaging was used (SKIP TO QUESTION 7)", "2"),
            new RadioListItem("Yes, both PET/SPECT and MR imaging were used", "3")
        };

        public List<RadioListItem> PETDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 8)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> FDGPETDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 6c)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> DATSCANDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> TRACOTHDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 7a)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> STRUCTDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 8)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> OTHBIOMListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 11)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> AUTDOMMUTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown/Not disclosed", "2")
        };

        public List<RadioListItem> EtiologyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Primary", "1"),
            new RadioListItem("Contributing", "2"),
            new RadioListItem("Non-contributing", "3")
        };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D1b = (D1b)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = D1b; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(D1b); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
