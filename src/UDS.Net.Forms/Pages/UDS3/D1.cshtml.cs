using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class D1Model : FormPageModel
    {
        [BindProperty]
        public D1 D1 { get; set; } = default!;

        public List<RadioListItem> DiagnosisMethodListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("A single clinician", "1"),
            new RadioListItem("A formal consensus panel", "2"),
            new RadioListItem("Other (e.g., two or more clinicians or other informal group", "3")
        };

        public List<RadioListItem> NormalCognitionListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (continue to question 3)", "0"),
            new RadioListItem("Yes (skip to question 6)", "1")
        };

        public List<RadioListItem> DementiaListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 5)", "0"),
            new RadioListItem("Yes (continue to question 4)", "1")
        };

        public List<RadioListItem> PPASyndromeListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Meets criteria for semantic PPA", "1"),
            new RadioListItem("Meets criteria for logopenic PPA", "2"),
            new RadioListItem("Meets criteria for nonfluent/agrammatic PPA", "3"),
            new RadioListItem("PPA other/not otherwise specified", "4")
        };

        public List<RadioListItem> SimpleNoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> FindingsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown/not assessed", "8")
        };

        public List<RadioListItem> MutationListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown/not assessed", "9")
        };

        public List<RadioListItem> OtherMutationListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes (specify)", "1"),
            new RadioListItem("Unknown/not assessed", "9")
        };

        public List<RadioListItem> EtiologyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Primary", "1"),
            new RadioListItem("Contributing", "2"),
            new RadioListItem("Non-contributing", "3")
        };

        public List<RadioListItem> FTLDListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Tauopathy", "1"),
            new RadioListItem("TDP-43 proteinopathy", "2"),
            new RadioListItem("Other (specify)", "3"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ImagingListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown; no relevant imaging data available", "9")
        };

        public List<RadioListItem> SimpleListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> CNSListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Benign", "1"),
            new RadioListItem("Malignant", "2")
        };

        public List<RadioListItem> DepressionListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Untreated", "0"),
            new RadioListItem("Treated with medication and/or counseling", "1")
        };

        public D1Model(IVisitService visitService) : base(visitService, "D1")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                D1 = (D1)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(int id)
        {
            /*
             * ValidationContext describes any member on which validation is performed. It also enables
             * custom validation to be added through any service that implements the IServiceProvider
             * interface.
             */
            foreach (var result in D1.Validate(new ValidationContext(D1, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"D1.{memberName}", result.ErrorMessage);
            }

            // if model is attempting to be completed, validation against domain form rules and visit rules
            // if not validates, return with errors

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(D1);

                await base.OnPost(id); // checks for domain-level business rules validation
            }

            var visit = await _visitService.GetByIdWithForm("", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}
