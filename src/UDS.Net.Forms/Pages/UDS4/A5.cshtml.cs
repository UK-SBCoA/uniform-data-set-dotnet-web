﻿using System;
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
    /// <summary>
    /// Only collected during initial visits
    /// </summary>
    public class A5Model : FormPageModel
    {
        [BindProperty]
        public A5 A5 { get; set; } = default!;

        public List<RadioListItem> TOBAC100ListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 1F)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION 1F)", "9")
        };


        public Dictionary<string, UIBehavior> TOBAC100UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.SMOKYRS"),
                new UIDisableAttribute("A5.PACKSPER"),
                new UIDisableAttribute("A5.QUITSMOK"),
            },
            InstructionalMessage = "skip to question 1F"

            } },
            { "1", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.SMOKYRS"),
                new UIEnableAttribute("A5.PACKSPER"),
                new UIEnableAttribute("A5.QUITSMOK"),
            },
            } },

            { "9", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                new UIDisableAttribute("A5.SMOKYRS"),
                new UIDisableAttribute("A5.PACKSPER"),
                new UIDisableAttribute("A5.QUITSMOK"),
                },
            InstructionalMessage = "skip to question 1F"
            } }
        };

        public List<RadioListItem> ALCOCCASListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 2A)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION 2A)", "9")
        };

        public Dictionary<string, UIBehavior> ALCOCCASUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.ALCFREQ") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.ALCFREQ") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.ALCFREQ") } }
        };

        public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ConditionsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Recent/active", "1"),
            new RadioListItem("Remote/inactive", "2"),
            new RadioListItem("Unknown", "9")
        };

        public Dictionary<string, UIBehavior> CVHATTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.HATTMULT"),
                new UIDisableAttribute("A5.HATTYEAR"),
            },
            InstructionalMessage = "skip to question 2B"

            } },

            { "1", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.HATTMULT"),
                new UIEnableAttribute("A5.HATTYEAR"),
            },
            } },

            { "2", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.HATTMULT"),
                new UIEnableAttribute("A5.HATTYEAR"),
            },
            } },

            { "9", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.HATTMULT"),
                new UIDisableAttribute("A5.HATTYEAR"),
            },
            InstructionalMessage = "skip to question 2B"

            } }
        };
        public Dictionary<string, UIBehavior> CVOTHRUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.CVOTHRX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.CVOTHRX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.CVOTHRX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.CVOTHRX") } }
        };

        public Dictionary<string, UIBehavior> CBSTROKEUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.STROKMUL"),
                new UIDisableAttribute("A5.STROKYR"),
            },
            InstructionalMessage = "skip to question 3B"

            } },

            { "1", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.STROKMUL"),
                new UIEnableAttribute("A5.STROKYR"),
            },

            } },

            { "2", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.STROKMUL"),
                new UIEnableAttribute("A5.STROKYR"),
            },

            } },

            { "9", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.STROKMUL"),
                new UIDisableAttribute("A5.STROKYR"),
            },
            InstructionalMessage = "skip to question 3B"

            } }
            };


        public Dictionary<string, UIBehavior> CBTIAUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.TIAMULT"),
                new UIDisableAttribute("A5.TIAYEAR"),
            },
            InstructionalMessage = "skip to question 4A"

            } },

            { "1", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.TIAMULT"),
                new UIEnableAttribute("A5.TIAYEAR"),
            },

            } },

            { "2", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.TIAMULT"),
                new UIEnableAttribute("A5.TIAYEAR"),
            },

            } },

            { "9", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.TIAMULT"),
                new UIDisableAttribute("A5.TIAYEAR"),
            },
            InstructionalMessage = "skip to question 4A"

            } }
            };

        public Dictionary<string, UIBehavior> TBIUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.TBIBRIEF"),
                new UIDisableAttribute("A5.TBIEXTEN"),
                new UIDisableAttribute("A5.TBIWOLOS"),
                new UIDisableAttribute("A5.TBIYEAR")
            },
            InstructionalMessage = "skip to question 5A"

            } },

            { "1", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.TBIBRIEF"),
                new UIEnableAttribute("A5.TBIEXTEN"),
                new UIEnableAttribute("A5.TBIWOLOS"),
                new UIEnableAttribute("A5.TBIYEAR")
            },

            } },

            { "2", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.TBIBRIEF"),
                new UIEnableAttribute("A5.TBIEXTEN"),
                new UIEnableAttribute("A5.TBIWOLOS"),
                new UIEnableAttribute("A5.TBIYEAR")
            },

            } },

            { "9", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.TBIBRIEF"),
                new UIDisableAttribute("A5.TBIEXTEN"),
                new UIDisableAttribute("A5.TBIWOLOS"),
                new UIDisableAttribute("A5.TBIYEAR")
            },
            InstructionalMessage = "skip to question 5A"

            } }
            };

        public Dictionary<string, UIBehavior> DIABETESUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.DIABTYPE") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.DIABTYPE") } },
            { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.DIABTYPE") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.DIABTYPE") } }
        };

        public Dictionary<string, UIBehavior> ARTHRITUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.ARTHTYPE"),
                new UIDisableAttribute("A5.ARTHTYPX"),
                new UIDisableAttribute("A5.ARTHUPEX"),
                new UIDisableAttribute("A5.ARTHLOEX"),
                new UIDisableAttribute("A5.ARTHSPIN"),
                new UIDisableAttribute("A5.ARTHUNK")
            },
            InstructionalMessage = "skip to question 5G"

            } },

            { "1", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.ARTHTYPE"),
                new UIEnableAttribute("A5.ARTHTYPX"),
                new UIEnableAttribute("A5.ARTHUPEX"),
                new UIEnableAttribute("A5.ARTHLOEX"),
                new UIEnableAttribute("A5.ARTHSPIN"),
                new UIEnableAttribute("A5.ARTHUNK")
            },

            } },

            { "2", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5.ARTHTYPE"),
                new UIEnableAttribute("A5.ARTHTYPX"),
                new UIEnableAttribute("A5.ARTHUPEX"),
                new UIEnableAttribute("A5.ARTHLOEX"),
                new UIEnableAttribute("A5.ARTHSPIN"),
                new UIEnableAttribute("A5.ARTHUNK")
            },

            } },

            { "9", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5.ARTHTYPE"),
                new UIDisableAttribute("A5.ARTHTYPX"),
                new UIDisableAttribute("A5.ARTHUPEX"),
                new UIDisableAttribute("A5.ARTHLOEX"),
                new UIDisableAttribute("A5.ARTHSPIN"),
                new UIDisableAttribute("A5.ARTHUNK")
            },
            InstructionalMessage = "skip to question 5A"

            } }
            };

        public Dictionary<string, UIBehavior> ARTHTYPEUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.ARTHTYPX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.ARTHTYPX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.ARTHTYPX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.ARTHTYPX") } }
        };

        public Dictionary<string, UIBehavior> OTHSLEEPUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.OTHSLEEX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.OTHSLEEX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.OTHSLEEX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.OTHSLEEX") } }
        };

        public Dictionary<string, UIBehavior> ABUSOTHRUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.ABUSX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.ABUSX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.ABUSX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.ABUSX") } }
        };

        public Dictionary<string, UIBehavior> PSYCDISUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.PSYCDISX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.PSYCDISX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5.PSYCDISX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5.PSYCDISX") } }
        };
        public List<RadioListItem> ConditionsLimitedListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Recent/active", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SmokingFrequencyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("1 cigarette to less than 1/2 pack", "1"),
            new RadioListItem("1/2 pack to less than 1 pack", "2"),
            new RadioListItem("1 pack to less than 1 1/2 packs", "3"),
            new RadioListItem("1 1/2 packs to less than 2 packs", "4"),
            new RadioListItem("2 packs or more", "5"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> RecentAlcoholUseListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 2a)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9 (skip to question 2a)")
        };

        public List<RadioListItem> AlcoholUseFrequencyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Less than once a month", "0"),
            new RadioListItem("About once a month", "1"),
            new RadioListItem("About once a week", "2"),
            new RadioListItem("A few times a week", "3"),
            new RadioListItem("Daily or almost daily", "4"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> TBIFrequencyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Single", "1"),
            new RadioListItem("Repeated/multiple", "2"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> DiabetesTypeListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Type 1", "1"),
            new RadioListItem("Type 2", "2"),
            new RadioListItem("Other type (diabetes insipidus, latent automimmune diabetes/type 1.5, gestational diabetes)", "3"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ArthritisListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Rheumatoid","1"),
            new RadioListItem("Osteoarthritis","2"),
            new RadioListItem("Other (specify)","3"),
            new RadioListItem("Unknown","9"),
        };

        public A5Model(IVisitService visitService) : base(visitService, "A5")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A5 = (A5)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = A5; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A5); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
