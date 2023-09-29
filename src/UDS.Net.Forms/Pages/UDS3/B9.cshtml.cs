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
    public class B9Model : FormPageModel
    {
        [BindProperty]
        public B9 B9 { get; set; } = default!;

        public List<RadioListItem> MemoryDeclineListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Could not be assessed/subject is too impaired", "8")
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

        public Dictionary<string, UIBehavior> MOMOALSUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.ALSAGE") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.ALSAGE") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.ALSAGE") } }

        };
        public Dictionary<string, UIBehavior> MOMOPARKUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.PARKAGE") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.PARKAGE") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.PARKAGE") } }

        };
        public Dictionary<string, UIBehavior> BEHVHALLUIBehavior = new Dictionary<string, UIBehavior>
        {
             { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("B9.BEVWELL"),
                    new UIDisableAttribute("B9.BEVHAGO"),
                },
                InstructionalMessage = "Skip to question 9C2"
             } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("B9.BEVWELL"),
                },
             } },

                { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("B9.BEVWELL"),
                    new UIDisableAttribute("B9.BEVHAGO"),
                },
                InstructionalMessage = "Skip to question 9C2"
             } },
        };
        public Dictionary<string, UIBehavior> BEVWELLUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEVHAGO") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEVHAGO") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEVHAGO") } }

        };
        public Dictionary<string, UIBehavior> BEREMUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEREMAGO") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEREMAGO") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEREMAGO") } }
        };

        public Dictionary<string, UIBehavior> BEOTHRUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEOTHRX") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEOTHRX") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEOTHRX") } }
        };

        public Dictionary<string, UIBehavior> COGFLUCUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFLAGO") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.COGFLAGO") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFLAGO") } }
        };

        public List<RadioListItem> SimpleYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };
        public Dictionary<string, UIBehavior> DECCLMOTUIBehavior = new Dictionary<string, UIBehavior>
        {
             { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("B9.MOGAIT"),
                    new UIDisableAttribute("B9.MOFALLS"),
                    new UIDisableAttribute("B9.MOTREM"),
                    new UIDisableAttribute("B9.MOSLOW"),
                    new UIDisableAttribute("B9.MOFRST"),
                    new UIDisableAttribute("B9.MOMODE"),
                    new UIDisableAttribute("B9.MOMODEX"),
                    new UIDisableAttribute("B9.MOMOPARK"),
                    new UIDisableAttribute("B9.PARKAGE"),
                    new UIDisableAttribute("B9.MOMOALS"),
                    new UIDisableAttribute("B9.ALSAGE"),
                    new UIDisableAttribute("B9.MOAGE"),
                },
                InstructionalMessage = "Skip to question 20"
            } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("B9.MOGAIT"),
                    new UIEnableAttribute("B9.MOFALLS"),
                    new UIEnableAttribute("B9.MOTREM"),
                    new UIEnableAttribute("B9.MOSLOW"),
                    new UIEnableAttribute("B9.MOFRST"),
                    new UIEnableAttribute("B9.MOMODE"),
                    new UIEnableAttribute("B9.MOMODEX"),
                    new UIEnableAttribute("B9.MOMOPARK"),
                    new UIEnableAttribute("B9.PARKAGE"),
                    new UIEnableAttribute("B9.MOMOALS"),
                    new UIEnableAttribute("B9.ALSAGE"),
                    new UIEnableAttribute("B9.MOAGE"),
                },

            } }
        };
        public Dictionary<string, UIBehavior> COGOTHRUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGOTHRX") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.COGOTHRX") } }
        };
        public Dictionary<string, UIBehavior> DECCLOGUIBehavior = new Dictionary<string, UIBehavior>
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
                    new UIDisableAttribute("B9.COGFLAGO"),
                    new UIDisableAttribute("B9.COGOTHR"),
                    new UIDisableAttribute("B9.COGOTHRX"),
                    new UIDisableAttribute("B9.COGFPRED"),
                    new UIDisableAttribute("B9.COGFPREX"),
                    new UIDisableAttribute("B9.COGMODE"),
                    new UIDisableAttribute("B9.COGMODEX"),
                    new UIDisableAttribute("B9.DECAGE")
                },
                InstructionalMessage = "Skip to question 8"
            } },

            {"1", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.COGMEM"),
                    new UIEnableAttribute("B9.COGORI"),
                    new UIEnableAttribute("B9.COGJUDG"),
                    new UIEnableAttribute("B9.COGLANG"),
                    new UIEnableAttribute("B9.COGVIS"),
                    new UIEnableAttribute("B9.COGATTN"),
                    new UIEnableAttribute("B9.COGFLUC"),
                    new UIEnableAttribute("B9.COGFLAGO"),
                    new UIEnableAttribute("B9.COGOTHR"),
                    new UIEnableAttribute("B9.COGOTHRX"),
                    new UIEnableAttribute("B9.COGFPRED"),
                    new UIEnableAttribute("B9.COGFPREX"),
                    new UIEnableAttribute("B9.COGMODE"),
                    new UIEnableAttribute("B9.COGMODEX"),
                    new UIEnableAttribute("B9.DECAGE")
                },
                InstructionalMessage = "Continue to question 4A"
            } }
            };

        public Dictionary<string, UIBehavior> DECCLBEUIBehavior = new Dictionary<string, UIBehavior>
        {
             { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("B9.BEAPATHY"),
                    new UIDisableAttribute("B9.BEDEP"),
                    new UIDisableAttribute("B9.BEVHALL"),
                    new UIDisableAttribute("B9.BEVWELL"),
                    new UIDisableAttribute("B9.BEVHAGO"),
                    new UIDisableAttribute("B9.BEAHALL"),
                    new UIDisableAttribute("B9.BEDEL"),
                    new UIDisableAttribute("B9.BEDISIN"),
                    new UIDisableAttribute("B9.BEIRRIT"),
                    new UIDisableAttribute("B9.BEAGIT"),
                    new UIDisableAttribute("B9.BEPERCH"),
                    new UIDisableAttribute("B9.BEREM"),
                    new UIDisableAttribute("B9.BEREMAGO"),
                    new UIDisableAttribute("B9.BEANX"),
                    new UIDisableAttribute("B9.BEOTHR"),
                    new UIDisableAttribute("B9.BEOTHRX"),
                    new UIDisableAttribute("B9.BEFPRED"),
                    new UIDisableAttribute("B9.BEFPREDX"),
                    new UIDisableAttribute("B9.BEMODE"),
                    new UIDisableAttribute("B9.BEMODEX"),
                    new UIDisableAttribute("B9.BEAGE")
                },
                InstructionalMessage = "Skip to question 13"
            } },

            {"1", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B9.BEAPATHY"),
                    new UIEnableAttribute("B9.BEDEP"),
                    new UIEnableAttribute("B9.BEVHALL"),
                    new UIEnableAttribute("B9.BEVWELL"),
                    new UIEnableAttribute("B9.BEVHAGO"),
                    new UIEnableAttribute("B9.BEAHALL"),
                    new UIEnableAttribute("B9.BEDEL"),
                    new UIEnableAttribute("B9.BEDISIN"),
                    new UIEnableAttribute("B9.BEIRRIT"),
                    new UIEnableAttribute("B9.BEAGIT"),
                    new UIEnableAttribute("B9.BEPERCH"),
                    new UIEnableAttribute("B9.BEREM"),
                    new UIEnableAttribute("B9.BEREMAGO"),
                    new UIEnableAttribute("B9.BEANX"),
                    new UIEnableAttribute("B9.BEOTHR"),
                    new UIEnableAttribute("B9.BEOTHRX"),
                    new UIEnableAttribute("B9.BEFPRED"),
                    new UIEnableAttribute("B9.BEFPREDX"),
                    new UIEnableAttribute("B9.BEMODE"),
                    new UIEnableAttribute("B9.BEMODEX"),
                    new UIEnableAttribute("B9.BEAGE")
                },
                InstructionalMessage = "Continue to question 9A"
            } }
            };
        public List<RadioListItem> CognitiveDomainsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Memory", "1"),
            new RadioListItem("Orientation", "2"),
            new RadioListItem("Executive function — judgment, planning, problem-solving", "3"),
            new RadioListItem("Language", "4"),
            new RadioListItem("Visuospatial function", "5"),
            new RadioListItem("Attention / concentration", "6"),
            new RadioListItem("Fluctuating cognition", "7"),
            new RadioListItem("Other", "8"),
            new RadioListItem("Unknown", "99")
        };
        public Dictionary<string, UIBehavior> COGFPREDUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } },
            {"2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } },
            {"3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } },
            {"4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } },
            {"5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } },
            {"6", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } },
            {"7", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } },
            {"8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.COGFPREX") } },
            {"99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGFPREX") } }
        };

        public List<RadioListItem> OnsetListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gradual", "1"),
            new RadioListItem("Subacute", "2"),
            new RadioListItem("Abrupt", "3"),
            new RadioListItem("Other", "4"),
            new RadioListItem("Unknown", "99")
        };

        public Dictionary<string, UIBehavior> MOMODEUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.MOMODEX") } },
            {"2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.MOMODEX") } },
            {"3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.MOMODEX") } },
            {"4", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.MOMODEX") } },
            {"99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.MOMODEX") } },
        };
        public Dictionary<string, UIBehavior> BEMODEUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEMODEX") } },
            {"2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEMODEX") } },
            {"4", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEMODEX") } },
            {"99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEMODEX") } },
        };

        public Dictionary<string, UIBehavior> COGMODEUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGMODEX") } },
            {"2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGMODEX") } },
            {"3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGMODEX") } },
            {"4", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.COGMODEX") } },
            {"99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.COGMODEX") } },
        };
        public List<RadioListItem> PredominantSymptomListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Apathy/withdrawal", "1"),
            new RadioListItem("Depressed mood", "2"),
            new RadioListItem("Psychosis", "3"),
            new RadioListItem("Disinhibition", "4"),
            new RadioListItem("Irritability", "5"),
            new RadioListItem("Agitation", "6"),
            new RadioListItem("Personality change", "7"),
            new RadioListItem("Personality change", "8"),
            new RadioListItem("Anxiety", "9"),
            new RadioListItem("Other", "10"),
            new RadioListItem("Unknown", "99")
        };

        public Dictionary<string, UIBehavior> BEFPREDUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"4", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEFPREDX") } },
            {"5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"6", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"7", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
            {"10", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B9.BEFPREDX") } },
            {"99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B9.BEFPREDX") } },
        };

        public List<RadioListItem> MotorFunctionListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gait disorder", "1"),
            new RadioListItem("Falls", "2"),
            new RadioListItem("Tremor", "3"),
            new RadioListItem("Slowness", "4"),
            new RadioListItem("Unknown", "99")
        };

        public List<RadioListItem> CourseOfDeclineListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gradually progressive", "1"),
            new RadioListItem("Stepwise", "2"),
            new RadioListItem("Static", "3"),
            new RadioListItem("Fluctuating", "4"),
            new RadioListItem("Improved", "5"),
            new RadioListItem("N/A", "8"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> PredominantDomainListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Cognition", "1"),
            new RadioListItem("Behavior", "2"),
            new RadioListItem("Motor function", "3"),
            new RadioListItem("N/A", "8"),
            new RadioListItem("Unknown", "9")
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
