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

        public Dictionary<string, UIBehavior> NORMCOGBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A1.DEMENTED")
                },
                InstructionalMessage = "Continue to question 3"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.HISPORX")
                },
                InstructionalMessage = "Skip to question 6"
            } },
        };

        public Dictionary<string, UIBehavior> DEMENTEDBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.AMNDEM"),
                    new UIDisableAttribute("D1.PCA"),
                    new UIDisableAttribute("D1.PPASYN"),
                    new UIDisableAttribute("D1.FTDSYN"),
                    new UIDisableAttribute("D1.LBDSYN"),
                    new UIDisableAttribute("D1.NAMNDEM")
                },
                InstructionalMessage = "Skip to question 5"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A1.AMNDEM"),
                    new UIEnableAttribute("D1.PCA"),
                    new UIEnableAttribute("D1.PPASYN"),
                    new UIEnableAttribute("D1.FTDSYN"),
                    new UIEnableAttribute("D1.LBDSYN"),
                    new UIEnableAttribute("D1.NAMNDEM")
                },
                InstructionalMessage = "Continue to question 4"
            } },
        };

        // TODO PPASYN checkbox enabling / disabled ui behavior for radio button group


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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D1 = (D1)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = D1; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(D1); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
