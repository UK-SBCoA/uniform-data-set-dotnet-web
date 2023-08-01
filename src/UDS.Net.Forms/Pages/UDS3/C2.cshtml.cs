using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class C2Model : FormPageModel
    {
        [BindProperty]
        public C2 C2 { get; set; } = default!;

        //public List<SelectListItem> ReasonCodeListItems { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem("Physical problem", "95"),
        //    new SelectListItem("Cognitive/behavior problem", "96"),
        //    new SelectListItem("Other problem", "97"),
        //    new SelectListItem("Verbal refusal", "98")
        //};

        public List<RadioListItem> SimpleNoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> MoCACompletedListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 2a)", "0"),
            new RadioListItem("Yes (continue to question 1b)", "1")
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

        //public Dictionary<string, UIBehavior> MOCACOMPBehavior = new Dictionary<string, UIBehavior>
        //{
        //    { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.MOCAREAS")} }, // "skip to question 2a"
        //    { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("C2.MOCAREAS")} } // "continue to question 1b"
        //};

        public Dictionary<string, UIBehavior> MOCACOMPBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.MOCAREAS"),
                    new UIDisableAttribute("C2.MOCALOC"),
                    new UIDisableAttribute("C2.MOCALAN"),
                    new UIDisableAttribute("C2.MOCAVIS"),
                    new UIDisableAttribute("C2.MOCAHEAR"),
                    new UIDisableAttribute("C2.MOCATOTS"),
                    new UIDisableAttribute("C2.MOCATRAI"),
                    new UIDisableAttribute("C2.MOCACUBE"),
                    new UIDisableAttribute("C2.MOCACLOC"),
                    new UIDisableAttribute("C2.MOCACLON"),
                    new UIDisableAttribute("C2.MOCACLOH"),
                    new UIDisableAttribute("C2.MOCANAMI"),
                    new UIDisableAttribute("C2.MOCAREGI"),
                    new UIDisableAttribute("C2.MOCADIGI"),
                    new UIDisableAttribute("C2.MOCALETT"),
                    new UIDisableAttribute("C2.MOCASER7"),
                    new UIDisableAttribute("C2.MOCAREPE"),
                    new UIDisableAttribute("C2.MOCAFLUE"),
                    new UIDisableAttribute("C2.MOCAABST"),
                    new UIDisableAttribute("C2.MOCARECN"),
                    new UIDisableAttribute("C2.MOCARECC"),
                    new UIDisableAttribute("C2.MOCARECR"),
                    new UIDisableAttribute("C2.MOCAORDT"),
                    new UIDisableAttribute("C2.MOCAORMO"),
                    new UIDisableAttribute("C2.MOCAORYR"),
                    new UIDisableAttribute("C2.MOCAORDY"),
                    new UIDisableAttribute("C2.MOCAORPL"),
                    new UIDisableAttribute("C2.MOCAORCT")
                },
                InstructionalMessage = "skip to question 2a"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("C2.MOCAREAS"),
                    new UIEnableAttribute("C2.MOCALOC"),
                    new UIEnableAttribute("C2.MOCALAN"),
                    new UIEnableAttribute("C2.MOCAVIS"),
                    new UIEnableAttribute("C2.MOCAHEAR"),
                    new UIEnableAttribute("C2.MOCATOTS"),
                    new UIEnableAttribute("C2.MOCATRAI"),
                    new UIEnableAttribute("C2.MOCACUBE"),
                    new UIEnableAttribute("C2.MOCACLOC"),
                    new UIEnableAttribute("C2.MOCACLON"),
                    new UIEnableAttribute("C2.MOCACLOH"),
                    new UIEnableAttribute("C2.MOCANAMI"),
                    new UIEnableAttribute("C2.MOCAREGI"),
                    new UIEnableAttribute("C2.MOCADIGI"),
                    new UIEnableAttribute("C2.MOCALETT"),
                    new UIEnableAttribute("C2.MOCASER7"),
                    new UIEnableAttribute("C2.MOCAREPE"),
                    new UIEnableAttribute("C2.MOCAFLUE"),
                    new UIEnableAttribute("C2.MOCAABST"),
                    new UIEnableAttribute("C2.MOCARECN"),
                    new UIEnableAttribute("C2.MOCARECC"),
                    new UIEnableAttribute("C2.MOCARECR"),
                    new UIEnableAttribute("C2.MOCAORDT"),
                    new UIEnableAttribute("C2.MOCAORMO"),
                    new UIEnableAttribute("C2.MOCAORYR"),
                    new UIEnableAttribute("C2.MOCAORDY"),
                    new UIEnableAttribute("C2.MOCAORPL"),
                    new UIEnableAttribute("C2.MOCAORCT")
                },
                InstructionalMessage = "continue to question 1b"
            } }
        };

        public Dictionary<string, UIBehavior> MOCALANBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.MOCALANX")} },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.MOCALANX")} },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("C2.MOCALANX")} }
        };

        public Dictionary<string, UIBehavior> NPSYLANBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.NPSYLANX")} },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.NPSYLANX")} },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("C2.NPSYLANX")} }
        };

        public Dictionary<string, UIBehavior> CRAFTVRSBehavior = new Dictionary<string, UIBehavior>
        {
            { "0-44", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.CRAFTURS"),
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 4a"
            } },
            { "95-98", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("C2.CRAFTURS"),
                }
            } }
        };

        //public Dictionary<string, UIBehavior> UDSVERLCBehavior = new Dictionary<string, UIBehavior>
        //{
        //    { "0-40", new UIBehavior {
        //        PropertyAttributes = new List<UIPropertyAttributes>
        //        {
        //            new UIEnableAttribute("C2.UDSVERLR"),
        //            new UIEnableAttribute("C2.UDSVERLN"),
        //            new UIEnableAttribute("C2.UDSVERTN"),
        //            new UIEnableAttribute("C2.UDSVERTE"),
        //            new UIEnableAttribute("C2.UDSVERTI")
        //        },
        //        InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 4a"
        //    } }
        //};

        public UIRangeToggle UDSVERLCBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 40,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.UDSVERLR"),
                    new UIEnableAttribute("C2.UDSVERLN"),
                    new UIEnableAttribute("C2.UDSVERTN"),
                    new UIEnableAttribute("C2.UDSVERTE"),
                    new UIEnableAttribute("C2.UDSVERTI")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 4a"
            }
        };

        public C2Model(IVisitService visitService) : base(visitService, "C2")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                C2 = (C2)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = C2; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(C2); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
