﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
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

        //public UIRangeToggle VNTTOTWDBehavior = new UIRangeToggle
        //{
        //    Low = 0,
        //    High = 50,
        //    UIBehavior = new UIBehavior
        //    {
        //        PropertyAttributes = new List<UIPropertyAttributes>
        //        {
        //            new UIEnableAttribute("C2.VNTPCNC")
        //        },
        //        InstructionalMessage = "If test was not completed, enter reason code, 95-98. If test was skipped\nbecause optional, enter 88, and SKIP TO QUESTION 12b."
        //    }
        //};
        public UIRangeToggle OTRAILABehavior = new UIRangeToggle
        {
            Low = 0,
            High = 100,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.OTRLARR"),
                    new UIEnableAttribute("C2.OTRLALI")

                },
                InstructionalMessage = "If test was not completed, enter reason code, 995-998. If test was skipped because optional, enter 888, and SKIP TO QUESTION 7b."
            }
        };

        public UIRangeToggle OTRAILBBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 300,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.OTRLBRR"),
                    new UIEnableAttribute("C2.OTRLBLI")

                },
                InstructionalMessage = "If test was not completed, enter reason code, 995-998. If test was skipped because\noptional, enter 888, and SKIP TO QUESTION 8a."
            }
        };

        public UIRangeToggle REY1RECBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 15,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.REY1INT"),
                    new UIEnableAttribute("C2.REY2REC"),
                    new UIEnableAttribute("C2.REY2INT"),
                    new UIEnableAttribute("C2.REY3REC"),
                    new UIEnableAttribute("C2.REY3INT"),
                    new UIEnableAttribute("C2.REY4REC"),
                    new UIEnableAttribute("C2.REY4INT"),
                    new UIEnableAttribute("C2.REY5REC"),
                    new UIEnableAttribute("C2.REY5INT"),
                    new UIEnableAttribute("C2.REY6REC"),
                    new UIEnableAttribute("C2.REY6INT")

                },
                InstructionalMessage = "If test was not completed, enter reason code, 95-98. If test was skipped because optional or not available in Spanish translation, enter 88, and SKIP TO QUESTION 5a."
            }
        };

        public UIRangeToggle REYDRECBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 15,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.REYDINT"),
                    new UIEnableAttribute("C2.REYTCOR"),
                    new UIEnableAttribute("C2.REYFPOS")
                },
                InstructionalMessage = "If test not completed, enter reason code, 95-98. If test was skipped because optional or\nnot available in Spanish translation, enter 88, and SKIP TO QUESTION 12a."
            }
        };

        public List<RadioListItem> RESPVALListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Very valid, probably accurate indication of participant’s cognitive abilities (END FORM HERE)", "1"),
            new RadioListItem("Questionably valid, possibly inaccurate indication of participant’s cognitive abilities (CONTINUE)", "2"),
            new RadioListItem("Invalid, probably inaccurate indication of participant’s cognitive abilities (CONTINUE)", "3")
        };

        public Dictionary<string, UIBehavior> RESPVALBehavior = new Dictionary<string, UIBehavior>
        {
             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("C2.RESPHEAR"),
                    new UIDisableAttribute("C2.RESPDIST"),
                    new UIDisableAttribute("C2.RESPINTR"),
                    new UIDisableAttribute("C2.RESPDISN"),
                    new UIDisableAttribute("C2.RESPFATG"),
                    new UIDisableAttribute("C2.RESPEMOT"),
                    new UIDisableAttribute("C2.RESPASST"),
                    new UIDisableAttribute("C2.RESPOTH")
                },
                InstructionalMessage = "End form here."
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("C2.RESPHEAR"),
                    new UIEnableAttribute("C2.RESPDIST"),
                    new UIEnableAttribute("C2.RESPINTR"),
                    new UIEnableAttribute("C2.RESPDISN"),
                    new UIEnableAttribute("C2.RESPFATG"),
                    new UIEnableAttribute("C2.RESPEMOT"),
                    new UIEnableAttribute("C2.RESPASST"),
                    new UIEnableAttribute("C2.RESPOTH")
                },
                InstructionalMessage = "continue to question 14b"
            } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("C2.RESPHEAR"),
                    new UIEnableAttribute("C2.RESPDIST"),
                    new UIEnableAttribute("C2.RESPINTR"),
                    new UIEnableAttribute("C2.RESPDISN"),
                    new UIEnableAttribute("C2.RESPFATG"),
                    new UIEnableAttribute("C2.RESPEMOT"),
                    new UIEnableAttribute("C2.RESPASST"),
                    new UIEnableAttribute("C2.RESPOTH")
                },
                InstructionalMessage = "continue to question 14b"
            } }
        };

        public List<RadioListItem> ModeOfCommunication { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Telephone", "1"),
            new RadioListItem("Video-assisted conference", "2"),
            new RadioListItem("Some combination of the two", "3")
        };

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

        public UIRangeToggle UDSVERFCBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 40,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.UDSVERFN"),
                    new UIEnableAttribute("C2.UDSVERNF")
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
                    new UIEnableAttribute("C2.UDSVERLR"),
                    new UIEnableAttribute("C2.UDSVERLN"),
                    new UIEnableAttribute("C2.UDSVERTN"),
                    new UIEnableAttribute("C2.UDSVERTE"),
                    new UIEnableAttribute("C2.UDSVERTI")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 13a."
            }
        };

        public List<RadioListItem> VERBALTESTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Rey AVLT (COMPLETE SECTIONS 12 & 13, SKIP SECTIONS 14 & 15)", "1"),
            new RadioListItem("CERAD (SKIP TO SECTION 14)", "2"),

        };

        public List<RadioListItem> REYMETHODListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("List shown", "1"),
            new RadioListItem("List read", "2"),

        };

        public UIRangeToggle MINTTOTSBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 32,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.MINTTOTW"),
                    new UIEnableAttribute("C2.MINTSCNG"),
                    new UIEnableAttribute("C2.MINTSCNC"),
                    new UIEnableAttribute("C2.MINTPCNG"),
                    new UIEnableAttribute("C2.MINTPCNC")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 12a."
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
                    new UIEnableAttribute("C2.UDSBENRS")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 11a."
            }
        };

        public UIRangeToggle CRAFTDVRBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 44,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.CRAFTDRE"),
                    new UIEnableAttribute("C2.CRAFTDTI"),
                    new UIEnableAttribute("C2.CRAFTCUE")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 10a."
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
                    new UIEnableAttribute("C2.TRAILARR"),
                    new UIEnableAttribute("C2.TRAILALI")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 8b."
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
                    new UIEnableAttribute("C2.TRAILBRR"),
                    new UIEnableAttribute("C2.TRAILBLI")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 9a."
            }
        };

        public UIRangeToggle DIGBACCTBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 14,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.DIGBACLS")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 7a."
            }
        };

        public UIRangeToggle DIGFORCTBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 14,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.DIGFORSL")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 6a."
            }
        };

        public UIRangeToggle CRAFTVRSBehavior = new UIRangeToggle
        {
            Low = 0,
            High = 44,
            UIBehavior = new UIBehavior
            {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.CRAFTURS")
                },
                InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 4a."
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
