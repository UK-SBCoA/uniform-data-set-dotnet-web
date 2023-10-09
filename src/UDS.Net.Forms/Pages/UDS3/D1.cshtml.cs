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

        public Dictionary<string, UIBehavior> NORMCOGUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1.DEMENTED"),
                    new UIEnableAttribute("D1.AMNDEM"),
                    new UIEnableAttribute("D1.PCA"),
                    new UIEnableAttribute("D1.PPASYN"),
                    new UIEnableAttribute("D1.PPASYNT"),
                    new UIEnableAttribute("D1.FTDSYN"),
                    new UIEnableAttribute("D1.LBDSYN"),
                    new UIEnableAttribute("D1.NAMNDEM"),
                    new UIEnableAttribute("D1.MCIAMEM"),
                    new UIEnableAttribute("D1.MCIAPLUS"),
                    new UIEnableAttribute("D1.MCIAPLAN"),
                    new UIEnableAttribute("D1.MCIAPATT"),
                    new UIEnableAttribute("D1.MCIAPEX"),
                    new UIEnableAttribute("D1.MCIAPVIS"),
                    new UIEnableAttribute("D1.MCINON1"),
                    new UIEnableAttribute("D1.MCIN1LAN"),
                    new UIEnableAttribute("D1.MCIN1ATT"),
                    new UIEnableAttribute("D1.MCIN1EX"),
                    new UIEnableAttribute("D1.MCIN1VIS"),
                    new UIEnableAttribute("D1.MCINON2"),
                    new UIEnableAttribute("D1.MCIN2LAN"),
                    new UIEnableAttribute("D1.MCIN2ATT"),
                    new UIEnableAttribute("D1.MCIN2EX"),
                    new UIEnableAttribute("D1.MCIN2VIS"),
                    new UIEnableAttribute("D1.IMPNOMCI")

                },
                InstructionalMessage = "Continue to question 3"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1.DEMENTED"),
                    new UIDisableAttribute("D1.AMNDEM"),
                    new UIDisableAttribute("D1.PCA"),
                    new UIDisableAttribute("D1.PPASYN"),
                    new UIDisableAttribute("D1.FTDSYN"),
                    new UIDisableAttribute("D1.LBDSYN"),
                    new UIDisableAttribute("D1.NAMNDEM"),
                    new UIDisableAttribute("D1.LBDSYN"),
                    new UIDisableAttribute("D1.NAMNDEM"),
                    new UIDisableAttribute("D1.MCIAMEM"),
                    new UIDisableAttribute("D1.MCIAPLUS"),
                    new UIDisableAttribute("D1.MCIAPLAN"),
                    new UIDisableAttribute("D1.MCIAPATT"),
                    new UIDisableAttribute("D1.MCIAPEX"),
                    new UIDisableAttribute("D1.MCIAPVIS"),
                    new UIDisableAttribute("D1.MCINON1"),
                    new UIDisableAttribute("D1.MCIN1LAN"),
                    new UIDisableAttribute("D1.MCIN1ATT"),
                    new UIDisableAttribute("D1.MCIN1EX"),
                    new UIDisableAttribute("D1.MCIN1VIS"),
                    new UIDisableAttribute("D1.MCINON2"),
                    new UIDisableAttribute("D1.MCIN2LAN"),
                    new UIDisableAttribute("D1.MCIN2ATT"),
                    new UIDisableAttribute("D1.MCIN2EX"),
                    new UIDisableAttribute("D1.MCIN2VIS"),
                    new UIDisableAttribute("D1.IMPNOMCI"),
                    new UIDisableAttribute("D1.ALZDISIF"),
                    new UIDisableAttribute("D1.LBDIF"),
                    new UIDisableAttribute("D1.MSAIF"),
                    new UIDisableAttribute("D1.PSPIF"),
                    new UIDisableAttribute("D1.CORTIF"),
                    new UIDisableAttribute("D1.FTLDMOIF"),
                    new UIDisableAttribute("D1.FTLDNOIF"),
                    new UIDisableAttribute("D1.CVDIF"),
                    new UIDisableAttribute("D1.ESSTREIF"),
                    new UIDisableAttribute("D1.DOWNSIF"),
                    new UIDisableAttribute("D1.HUNTIF"),
                    new UIDisableAttribute("D1.PRIONIF"),
                    new UIDisableAttribute("D1.BRNINJIF"),
                    new UIDisableAttribute("D1.HYCEPHIF"),
                    new UIDisableAttribute("D1.EPILEPIF"),
                    new UIDisableAttribute("D1.NEOPIF"),
                    new UIDisableAttribute("D1.HIVIF"),
                    new UIDisableAttribute("D1.OTHCOGIF"),
                    new UIDisableAttribute("D1.DEPIF"),
                    new UIDisableAttribute("D1.BIPOLDIF"),
                    new UIDisableAttribute("D1.SCHIZOIF"),
                    new UIDisableAttribute("D1.ANXIETIF"),
                    new UIDisableAttribute("D1.DELIRIF"),
                    new UIDisableAttribute("D1.PTSDDXIF"),
                    new UIDisableAttribute("D1.OTHPSYIF"),
                    new UIDisableAttribute("D1.ALCDEMIF"),
                    new UIDisableAttribute("D1.IMPSUBIF"),
                    new UIDisableAttribute("D1.DYSILLIF"),
                    new UIDisableAttribute("D1.MEDSIF"),
                    new UIDisableAttribute("D1.COGOTHIF"),
                    new UIDisableAttribute("D1.COGOTH2F"),
                    new UIDisableAttribute("D1.COGOTH3F")
                },
                InstructionalMessage = "Skip to question 6"
            } },
        };

        public Dictionary<string, UIBehavior> DEMENTEDBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1.AMNDEM"),
                    new UIDisableAttribute("D1.PCA"),
                    new UIDisableAttribute("D1.PPASYN"),
                    new UIDisableAttribute("D1.PPASYNT"),
                    new UIDisableAttribute("D1.FTDSYN"),
                    new UIDisableAttribute("D1.LBDSYN"),
                    new UIDisableAttribute("D1.NAMNDEM")
                },
                InstructionalMessage = "Skip to question 5"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1.AMNDEM"),
                    new UIEnableAttribute("D1.PCA"),
                    new UIEnableAttribute("D1.PPASYN"),
                    new UIEnableAttribute("D1.PPASYNT"),
                    new UIEnableAttribute("D1.FTDSYN"),
                    new UIEnableAttribute("D1.LBDSYN"),
                    new UIEnableAttribute("D1.NAMNDEM")
                },
                InstructionalMessage = "Continue to question 4"
            } },
        };

        // Checkbox attributes are in view, is there a way to move them here?
        //public Dictionary<string, UIBehavior> PPASYNBehavior = new Dictionary<string, UIBehavior>
        //{
        //    { "true", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1.PPASYNT") } },
        //    { "false", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1.PPASYNT") } }
        //};


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
        public Dictionary<string, UIBehavior> PREVSTKUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1.STROKDEC"),
                    new UIDisableAttribute("D1.STKIMAG"),
                },
                InstructionalMessage ="If Question 15b PREVSTK = 0 (N0), then skip to question 15c"
            } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1.STROKDEC"),
                    new UIEnableAttribute("D1.STKIMAG"),
                }
             } }
        };

        public Dictionary<string, UIBehavior> OTHBIOMUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1.OTHBIOMX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1.OTHBIOMX") } },

        };
        public Dictionary<string, UIBehavior> OTHMUTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1.OTHMUTX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1.OTHMUTX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1.OTHMUTX") } },

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

        public Dictionary<string, UIBehavior> FTLDSUBTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1.FTLDSUBX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1.FTLDSUBX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1.FTLDSUBX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1.FTLDSUBX") } },

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
