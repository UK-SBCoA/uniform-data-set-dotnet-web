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

        public Dictionary<string, UIBehavior> MMSECOMPBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.MMSEREAS"),
                    new UIDisableAttribute("C1.MMSELOC"),
                    new UIDisableAttribute("C1.MMSELAN"),
                    new UIDisableAttribute("C1.MMSELANX"),
                    new UIDisableAttribute("C1.MMSEVIS"),
                    new UIDisableAttribute("C1.MMSEHEAR"),
                    new UIDisableAttribute("C1.MMSEORDA"),
                    new UIDisableAttribute("C1.MMSEORLO"),
                    new UIDisableAttribute("C1.PENTAGON"),
                    new UIDisableAttribute("C1.MMSE")
                },
                InstructionalMessage = "skip to question 2a"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("C1.MMSEREAS"),
                    new UIEnableAttribute("C1.MMSELOC"),
                    new UIEnableAttribute("C1.MMSELAN"),
                    new UIEnableAttribute("C1.MMSELANX"),
                    new UIEnableAttribute("C1.MMSEVIS"),
                    new UIEnableAttribute("C1.MMSEHEAR"),
                    new UIEnableAttribute("C1.MMSEORDA"),
                    new UIEnableAttribute("C1.MMSEORLO"),
                    new UIEnableAttribute("C1.PENTAGON"),
                    new UIEnableAttribute("C1.MMSE")
                },
                InstructionalMessage = "continue to question 1b"
            } }
        };

        public Dictionary<string, UIBehavior> MMSELANBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C1.MMSELANX")} },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C1.MMSELANX")} },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("C1.MMSELANX")} }
        };

        public Dictionary<string, UIBehavior> NPSYLANBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C1.NPSYLANX")} },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C1.NPSYLANX")} },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("C1.NPSYLANX")} }
        };

        public UIRangeToggle DIGIFBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 12,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.DIGIFLEN"),
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 6a."
            }
        };

        public UIRangeToggle DIGIBBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 12,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.DIGIBLEN"),
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 7a."
            }
        };

        public UIRangeToggle TRAILABehavior = new UIRangeToggle
        {
            Low = 0,
            High = 150,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.TRAILARR"),
                    new UIEnableAttribute("C1.TRAILALI")
                },
                InstructionalMessage = "if test not completed, enter reason code, 995-998, and skip to question 8b."
            }
        };

        public UIRangeToggle TRAILBBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 300,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.TRAILBRR"),
                    new UIEnableAttribute("C1.TRAILBLI")
                },
                InstructionalMessage = "if test not completed, enter reason code, 995-998, and skip to question 9a."
            }
        };

        public UIRangeToggle MEMUNITSBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 25,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.MEMTIME")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 10a."
            }
        };

        public UIRangeToggle UDSBENTDBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 17,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.UDSBENRS")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 11a."
            }
        };

        public UIRangeToggle UDSVERFCBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 40,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.UDSVERFN"),
                    new UIEnableAttribute("C1.UDSVERNF")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 12d."
            }
        };

        public UIRangeToggle UDSVERLCBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 40,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C1.UDSVERLR"),
                    new UIEnableAttribute("C1.UDSVERLN"),
                    new UIEnableAttribute("C1.UDSVERTN"),
                    new UIEnableAttribute("C1.UDSVERTE"),
                    new UIEnableAttribute("C1.UDSVERTI")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 13a."
            }
        };

        public C1Model(IVisitService visitService) : base(visitService, "C1")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                C1 = (C1)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = C1; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(C1); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
