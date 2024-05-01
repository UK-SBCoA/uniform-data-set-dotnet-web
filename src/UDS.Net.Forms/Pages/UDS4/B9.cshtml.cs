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
    public class B9Model : FormPageModel
    {
        [BindProperty]
        public B9 B9 { get; set; } = default!;

        public List<RadioListItem> MemoryDeclineListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Could not be assessed/participant is too impaired", "8")
        };

        public List<RadioListItem> InformantMemoryDeclineListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("There is no co-participant", "8")
        };

        public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> BasicYesNoOtherListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
        };

        public List<RadioListItem> ModeOfOnsetItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gradual", "1"),
            new RadioListItem("Subacute", "2"),
            new RadioListItem("Abrupt", "3"),
            new RadioListItem("Other (SPECIFY)", "4"),
            new RadioListItem("Unknown", "99"),
        };

        public List<RadioListItem> MOMOPARKListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 18)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION 18)", "9")
        };

        public List<RadioListItem> MOMOALSListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 19)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION 19)", "9")
        };

        //public Dictionary<string, UIBehavior> MOMOALSUIBehavior = new Dictionary<string, UIBehavior>
        //{
        //    {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.ALSAGE"), InstructionalMessage ="Skip to question 19" } },
        //    {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.ALSAGE") } },
        //    {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.ALSAGE"), InstructionalMessage ="Skip to question 19" } }

        //};
        //public Dictionary<string, UIBehavior> MOMOPARKUIBehavior = new Dictionary<string, UIBehavior>
        //{
        //    {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.PARKAGE"), InstructionalMessage = "Skip to question 18"} },
        //    {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.PARKAGE") } },
        //    {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.PARKAGE"), InstructionalMessage ="Skip to question 18" } }

        //};
        //public Dictionary<string, UIBehavior> BEHVHALLUIBehavior = new Dictionary<string, UIBehavior>
        //{
        //     { "0", new UIBehavior {
        //        PropertyAttributes = new List<UIPropertyAttributes>
        //        {

        //            new UIDisableAttribute("B9.BEVWELL"),
        //            new UIDisableAttribute("B9.BEVHAGO"),
        //        },
        //        InstructionalMessage = "Skip to question 9C2"
        //     } },

        //     { "1", new UIBehavior {
        //        PropertyAttributes = new List<UIPropertyAttributes>
        //        {

        //            new UIEnableAttribute("B9.BEVWELL"),
        //        },
        //     } },

        //        { "9", new UIBehavior {
        //        PropertyAttributes = new List<UIPropertyAttributes>
        //        {

        //            new UIDisableAttribute("B9.BEVWELL"),
        //            new UIDisableAttribute("B9.BEVHAGO"),
        //        },
        //        InstructionalMessage = "Skip to question 9C2"
        //     } },
        //};
        //public Dictionary<string, UIBehavior> BEVWELLUIBehavior = new Dictionary<string, UIBehavior>
        //{
        //    {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEVHAGO") } },
        //    {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEVHAGO") } },
        //    {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEVHAGO") } }

        //};
        //public Dictionary<string, UIBehavior> BEREMUIBehavior = new Dictionary<string, UIBehavior>
        //{
        //    {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEREMAGO") } },
        //    {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEREMAGO") } },
        //    {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEREMAGO") } }
        //};

        //public Dictionary<string, UIBehavior> BEOTHRUIBehavior = new Dictionary<string, UIBehavior>
        //{
        //    {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEOTHRX") } },
        //    {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEOTHRX") } },
        //    {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEOTHRX") } }
        //};

        //public Dictionary<string, UIBehavior> COGFLUCUIBehavior = new Dictionary<string, UIBehavior>
        //{
        //    {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFLAGO") } },
        //    {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.COGFLAGO") } },
        //    {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFLAGO") } }
        //};

        public List<RadioListItem> DECCLINListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (END FORM HERE)", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> DECCLCOGListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 11)", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> DECCLBEListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 14)", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> DECCLMOTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 19)", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> COURSEListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gradually progressive", "1"),
            new RadioListItem("Stepwise", "2"),
            new RadioListItem("Static", "3"),
            new RadioListItem("Fluctuating", "4"),
            new RadioListItem("Improved", "5"),
            new RadioListItem("Not applicable", "6"),
            new RadioListItem("Unknown", "9"),
        };

        public List<RadioListItem> FRSTCHGListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Cognition", "1"),
            new RadioListItem("Behavior", "2"),
            new RadioListItem("Motor function", "3"),
            new RadioListItem("Not applicable", "8"),
            new RadioListItem("Unknown", "9")
        };

        public Dictionary<string, UIBehavior> COGOTHRUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGOTHRX") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.COGOTHRX") } }
        };

        public Dictionary<string, UIBehavior> COGMODEUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.COGMODEX")
                }
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.COGMODEX")
                }
             } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.COGMODEX")
                }
             } },
            { "4", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.COGMODEX")
                }
            } },
            { "99", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.COGMODEX")
                }
            } },
        };

        public Dictionary<string, UIBehavior> DECCLCOGUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.COGMEM"),
                    new UIDisableAttribute("B9.COGORI"),
                    new UIDisableAttribute("B9.COGJUDG"),
                    new UIDisableAttribute("B9.COGLANG"),
                    new UIDisableAttribute("B9.COGVIS"),
                    new UIDisableAttribute("B9.COGATTN"),
                    new UIDisableAttribute("B9.COGFLUC"),
                    new UIDisableAttribute("B9.COGOTHR"),
                    new UIDisableAttribute("B9.COGAGE"),
                    new UIDisableAttribute("B9.COGMODE"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.COGMEM"),
                    new UIEnableAttribute("B9.COGORI"),
                    new UIEnableAttribute("B9.COGJUDG"),
                    new UIEnableAttribute("B9.COGLANG"),
                    new UIEnableAttribute("B9.COGVIS"),
                    new UIEnableAttribute("B9.COGATTN"),
                    new UIEnableAttribute("B9.COGFLUC"),
                    new UIEnableAttribute("B9.COGOTHR"),
                    new UIEnableAttribute("B9.COGAGE"),
                    new UIEnableAttribute("B9.COGMODE"),
                }
             } },
        };

        public Dictionary<string, UIBehavior> DECCLBEUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEAPAHTY"),
                    new UIDisableAttribute("B9.BEDEP"),
                    new UIDisableAttribute("B9.BEANX"),
                    new UIDisableAttribute("B9.BEEUPH"),
                    new UIDisableAttribute("B9.BEIRRIT"),
                    new UIDisableAttribute("B9.BEAGIT"),
                    new UIDisableAttribute("B9.BEVHALL"),
                    new UIDisableAttribute("B9.BEAHALL"),
                    new UIDisableAttribute("B9.BEDEL"),
                    new UIDisableAttribute("B9.BEAGGRS"),
                    new UIDisableAttribute("B9.PSYCHAGE"),
                    new UIDisableAttribute("B9.BEDISIN"),
                    new UIDisableAttribute("B9.BEPERCH"),
                    new UIDisableAttribute("B9.BEEMPATH"),
                    new UIDisableAttribute("B9.BEOBCOM"),
                    new UIDisableAttribute("B9.BEANGER"),
                    new UIDisableAttribute("B9.BESUBAB"),
                    new UIDisableAttribute("B9.PERCHAGE"),
                    new UIDisableAttribute("B9.BEREM"),
                    new UIDisableAttribute("B9.BEOTHR"),
                    new UIDisableAttribute("B9.BEMODE"),
                    new UIDisableAttribute("B9.BEHAGE"),
                    new UIDisableAttribute("B9.BEAPATHY")
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.BEAPAHTY"),
                    new UIEnableAttribute("B9.BEDEP"),
                    new UIEnableAttribute("B9.BEANX"),
                    new UIEnableAttribute("B9.BEEUPH"),
                    new UIEnableAttribute("B9.BEIRRIT"),
                    new UIEnableAttribute("B9.BEAGIT"),
                    new UIEnableAttribute("B9.BEVHALL"),
                    new UIEnableAttribute("B9.BEAHALL"),
                    new UIEnableAttribute("B9.BEDEL"),
                    new UIEnableAttribute("B9.BEAGGRS"),
                    new UIEnableAttribute("B9.PSYCHAGE"),
                    new UIEnableAttribute("B9.BEDISIN"),
                    new UIEnableAttribute("B9.BEPERCH"),
                    new UIEnableAttribute("B9.BEEMPATH"),
                    new UIEnableAttribute("B9.BEOBCOM"),
                    new UIEnableAttribute("B9.BEANGER"),
                    new UIEnableAttribute("B9.BESUBAB"),
                    new UIEnableAttribute("B9.PERCHAGE"),
                    new UIEnableAttribute("B9.BEREM"),
                    new UIEnableAttribute("B9.BEOTHR"),
                    new UIEnableAttribute("B9.BEMODE"),
                    new UIEnableAttribute("B9.BEHAGE"),
                    new UIEnableAttribute("B9.BEAPATHY")
                }
             } },
        };

        public Dictionary<string, UIBehavior> BESUBABUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.ALCUSE"),
                    new UIDisableAttribute("B9.SEDUSE"),
                    new UIDisableAttribute("B9.OPIATEUSE"),
                    new UIDisableAttribute("B9.COCAINEUSE"),
                    new UIDisableAttribute("B9.OTHSUBUSE"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.ALCUSE"),
                    new UIEnableAttribute("B9.SEDUSE"),
                    new UIEnableAttribute("B9.OPIATEUSE"),
                    new UIEnableAttribute("B9.COCAINEUSE"),
                    new UIEnableAttribute("B9.OTHSUBUSE"),
                }
             } },
        };

        public Dictionary<string, UIBehavior> BEVHALLUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEVPATT"),
                    new UIDisableAttribute("B9.BEVWELL"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.BEVPATT"),
                    new UIEnableAttribute("B9.BEVWELL"),
                }
             } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEVPATT"),
                    new UIDisableAttribute("B9.BEVWELL"),
                }
             } },
        };

        public Dictionary<string, UIBehavior> BEAHALLUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEAHSIMP"),
                    new UIDisableAttribute("B9.BEAHCOMP"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.BEAHSIMP"),
                    new UIEnableAttribute("B9.BEAHCOMP"),
                }
             } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEAHSIMP"),
                    new UIDisableAttribute("B9.BEAHCOMP"),
                }
             } },
        };

        public Dictionary<string, UIBehavior> BEREMUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEREMAGO"),
                    new UIDisableAttribute("B9.BEREMCONF"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.BEREMAGO"),
                    new UIEnableAttribute("B9.BEREMCONF"),
                }
             } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEREMAGO"),
                    new UIDisableAttribute("B9.BEREMCONF"),
                }
             } },
        };

        public Dictionary<string, UIBehavior> BEOTHRUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEOTHRX"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.BEOTHRX"),
                }
             } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEOTHRX"),
                }
             } },
        };

        public Dictionary<string, UIBehavior> BEMODEUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEMODEX")
                }
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEMODEX")
                }
             } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEMODEX")
                }
             } },
            { "4", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.BEMODEX")
                }
            } },
            { "99", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.BEMODEX")
                }
            } },
        };

        public Dictionary<string, UIBehavior> MOMODEUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.MOMODEX")
                }
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.MOMODEX")
                }
             } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.MOMODEX")
                }
             } },
            { "4", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.MOMODEX")
                }
            } },
            { "99", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.MOMODEX")
                }
            } },
        };

        public Dictionary<string, UIBehavior> DECCLINUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.DECCLCOG"),
                    new UIDisableAttribute("B9.COGMODE"),
                    new UIDisableAttribute("B9.DECCLBE"),
                    new UIDisableAttribute("B9.DECCLBE"),
                    new UIDisableAttribute("B9.DECCLMOT"),
                    new UIDisableAttribute("B9.MOMODE"),
                    new UIDisableAttribute("B9.MOMOPARK"),
                    new UIDisableAttribute("B9.MOMOALS"),
                    new UIDisableAttribute("B9.COURSE"),
                    new UIDisableAttribute("B9.FRSTCHG"),
                    new UIDisableAttribute("B9.BEAPATHY")
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.DECCLCOG"),
                    new UIEnableAttribute("B9.COGMODE"),
                    new UIEnableAttribute("B9.DECCLBE"),
                    new UIEnableAttribute("B9.DECCLBE"),
                    new UIEnableAttribute("B9.DECCLMOT"),
                    new UIEnableAttribute("B9.MOMODE"),
                    new UIEnableAttribute("B9.MOMOPARK"),
                    new UIEnableAttribute("B9.MOMOALS"),
                    new UIEnableAttribute("B9.COURSE"),
                    new UIEnableAttribute("B9.FRSTCHG"),
                    new UIEnableAttribute("B9.BEAPATHY")
                }
             } },
        };

        public Dictionary<string, UIBehavior> DECCLMOTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B9.MOGAIT"),
                    new UIDisableAttribute("B9.MOFALLS"),
                    new UIDisableAttribute("B9.MOSLOW"),
                    new UIDisableAttribute("B9.MOTREM"),
                    new UIDisableAttribute("B9.MOLIMB"),
                    new UIDisableAttribute("B9.MOFACE"),
                    new UIDisableAttribute("B9.MOSPEECH"),
                    new UIDisableAttribute("B9.MOTORAGE"),
                    new UIDisableAttribute("B9.MOMODE"),
                    new UIDisableAttribute("B9.MOMOPARK"),
                    new UIDisableAttribute("B9.MOMOALS"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.MOGAIT"),
                    new UIEnableAttribute("B9.MOFALLS"),
                    new UIEnableAttribute("B9.MOSLOW"),
                    new UIEnableAttribute("B9.MOTREM"),
                    new UIEnableAttribute("B9.MOLIMB"),
                    new UIEnableAttribute("B9.MOFACE"),
                    new UIEnableAttribute("B9.MOSPEECH"),
                    new UIEnableAttribute("B9.MOTORAGE"),
                    new UIEnableAttribute("B9.MOMODE"),
                    new UIEnableAttribute("B9.MOMOPARK"),
                    new UIEnableAttribute("B9.MOMOALS"),
                }
             } },
        };

        public B9Model(IVisitService visitService) : base(visitService, "B9")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B9 = (B9)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = B9; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(B9); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
