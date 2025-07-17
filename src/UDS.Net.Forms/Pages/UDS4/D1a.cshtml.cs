using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class D1aModel : FormPageModel
    {

        [BindProperty]
        public D1a D1a { get; set; } = default!;

        public D1aModel(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "D1a")
        {
        }

        public List<RadioListItem> DiagnosisMethodListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Single clinician", "1"),
            new RadioListItem("Formal consensus panel", "2"),
            new RadioListItem("Other (e.g., two or more clinicians or other informal group", "3")
        };

        public List<RadioListItem> NORMCOGListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 3)", "0"),
            new RadioListItem("Yes (CONTINUE TO QUESTION 2a) ", "1")

        };

        public List<RadioListItem> SCDListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (END FORM HERE)", "0"),
            new RadioListItem("Yes", "1")

        };

        public List<RadioListItem> SCDDXCONFListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (END FORM HERE)", "0"),
            new RadioListItem("Yes (END FORM HERE)", "1")

        };

        public List<RadioListItem> DEMENTEDListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (CONTINUE TO QUESTION 4)", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 6a)", "1")

        };

        public List<RadioListItem> MCIListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (CONTINUE TO QUESTION 5)", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 6a)", "1")

        };

        public List<RadioListItem> IMPNOMCIListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 7)", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 7)", "1")

        };

        public List<RadioListItem> MBIListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 8)", "0"),
            new RadioListItem("Yes (CONTINUE TO QUESTION 7a)", "1")

        };

        public List<RadioListItem> SimpleNoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> PPASyndromeListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Semantic PPA", "1"),
            new RadioListItem("Logopenic PPA", "2"),
            new RadioListItem("Nonfluent/agrammatic PPA", "3"),
            new RadioListItem("Primary progressive apraxia of speech", "5"),
            new RadioListItem("PPA other/not otherwise specified", "4")
        };

        public List<RadioListItem> LBDSYNTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Dementia with Lewy bodies", "1"),
            new RadioListItem("Parkinson’s disease", "2"),
            new RadioListItem("Parkinson’s disease dementia syndrome", "3")
        };

        public List<RadioListItem> PSPSYNTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Richardson’s syndrome criteria", "1"),
            new RadioListItem("Non-Richardson’s", "2")
        };

        public List<RadioListItem> MSASYNTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("MSA-predominant cerebellar ataxia (MSA-C)", "1"),
            new RadioListItem("MSA-predominant Parkinsonism (MSA-P)", "2"),
            new RadioListItem("MSA-predominant dysautonomia", "3")
        };

        public List<RadioListItem> EtiologyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Primary", "1"),
            new RadioListItem("Contributing", "2"),
            new RadioListItem("Non-contributing", "3")
        };

        public List<RadioListItem> NEOPSTATListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Benign", "1"),
            new RadioListItem("Malignant", "2")
        };

        public List<RadioListItem> PREDOMSYNListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 10) ", "0"),
            new RadioListItem("Yes", "1")
        };

        public Dictionary<string, UIBehavior> NORMCOGUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1a.SCD"),
                    new UIDisableAttribute("D1a.SCDDXCONF"),
                    new UIEnableAttribute("D1a.DEMENTED")

                },
                InstructionalMessage = "Continue to question 3"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1a.SCD"),
                    new UIDisableAttribute("D1a.DEMENTED")

                },
                InstructionalMessage = "Skip to question 2a"
            } }
        };


        public Dictionary<string, UIBehavior> SCDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1a.SCDDXCONF")

                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1a.SCDDXCONF")

                }
            } }
        };

        public Dictionary<string, UIBehavior> DEMENTEDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1a.MCICRITCLN"),
                    new UIEnableAttribute("D1a.MCICRITIMP"),
                    new UIEnableAttribute("D1a.MCICRITFUN"),
                    new UIEnableAttribute("D1a.MCI"),
                    new UIDisableAttribute("D1a.CDOMMEM"),
                    new UIDisableAttribute("D1a.CDOMLANG"),
                    new UIDisableAttribute("D1a.CDOMATTN"),
                    new UIDisableAttribute("D1a.CDOMEXEC"),
                    new UIDisableAttribute("D1a.CDOMVISU"),
                    new UIDisableAttribute("D1a.CDOMBEH"),
                    new UIDisableAttribute("D1a.CDOMAPRAX"),

                }
            } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1a.MCICRITCLN"),
                    new UIDisableAttribute("D1a.MCICRITIMP"),
                    new UIDisableAttribute("D1a.MCICRITFUN"),
                    new UIDisableAttribute("D1a.MCI"),
                    new UIDisableAttribute("D1a.IMPNOMCIFU"),
                    new UIDisableAttribute("D1a.IMPNOMCICG"),
                    new UIDisableAttribute("D1a.IMPNOMCLCD"),
                    new UIDisableAttribute("D1a.IMPNOMCIO"),
                    new UIDisableAttribute("D1a.IMPNOMCI"),
                    new UIEnableAttribute("D1a.CDOMMEM"),
                    new UIEnableAttribute("D1a.CDOMLANG"),
                    new UIEnableAttribute("D1a.CDOMATTN"),
                    new UIEnableAttribute("D1a.CDOMEXEC"),
                    new UIEnableAttribute("D1a.CDOMVISU"),
                    new UIEnableAttribute("D1a.CDOMBEH"),
                    new UIEnableAttribute("D1a.CDOMAPRAX"),

                }
             } }
        };

        public Dictionary<string, UIBehavior> MCIUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1a.IMPNOMCIFU"),
                    new UIEnableAttribute("D1a.IMPNOMCICG"),
                    new UIEnableAttribute("D1a.IMPNOMCLCD"),
                    new UIEnableAttribute("D1a.IMPNOMCIO"),
                    new UIEnableAttribute("D1a.IMPNOMCI"),
                    new UIDisableAttribute("D1a.CDOMMEM"),
                    new UIDisableAttribute("D1a.CDOMLANG"),
                    new UIDisableAttribute("D1a.CDOMATTN"),
                    new UIDisableAttribute("D1a.CDOMEXEC"),
                    new UIDisableAttribute("D1a.CDOMVISU"),
                    new UIDisableAttribute("D1a.CDOMBEH"),
                    new UIDisableAttribute("D1a.CDOMAPRAX"),

                },
                InstructionalMessage =""
            } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1a.IMPNOMCIFU"),
                    new UIDisableAttribute("D1a.IMPNOMCICG"),
                    new UIDisableAttribute("D1a.IMPNOMCLCD"),
                    new UIDisableAttribute("D1a.IMPNOMCIO"),
                    new UIDisableAttribute("D1a.IMPNOMCI"),
                    new UIEnableAttribute("D1a.CDOMMEM"),
                    new UIEnableAttribute("D1a.CDOMLANG"),
                    new UIEnableAttribute("D1a.CDOMATTN"),
                    new UIEnableAttribute("D1a.CDOMEXEC"),
                    new UIEnableAttribute("D1a.CDOMVISU"),
                    new UIEnableAttribute("D1a.CDOMBEH"),
                    new UIEnableAttribute("D1a.CDOMAPRAX"),

                }
             } }
        };

        public Dictionary<string, UIBehavior> MBIUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1a.BDOMMOT"),
                    new UIDisableAttribute("D1a.BDOMAFREG"),
                    new UIDisableAttribute("D1a.BDOMIMP"),
                    new UIDisableAttribute("D1a.BDOMSOCIAL"),
                    new UIDisableAttribute("D1a.BDOMTHTS")
                },
                InstructionalMessage =""
            } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1a.BDOMMOT"),
                    new UIEnableAttribute("D1a.BDOMAFREG"),
                    new UIEnableAttribute("D1a.BDOMIMP"),
                    new UIEnableAttribute("D1a.BDOMSOCIAL"),
                    new UIEnableAttribute("D1a.BDOMTHTS")

                },
             } }
        };

        public Dictionary<string, UIBehavior> PREDOMSYNUIBehavior = new Dictionary<string, UIBehavior>
        {
             { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("D1a.AMNDEM"),
                    new UIDisableAttribute("D1a.DYEXECSYN"),
                    new UIDisableAttribute("D1a.PCA"),
                    new UIDisableAttribute("D1a.PPASYN"),
                    new UIDisableAttribute("D1a.FTDSYN"),
                    new UIDisableAttribute("D1a.LBDSYN"),
                    new UIDisableAttribute("D1a.NAMNDEM"),
                    new UIDisableAttribute("D1a.PSPSYN"),
                    new UIDisableAttribute("D1a.CTESYN"),
                    new UIDisableAttribute("D1a.CBSSYN"),
                    new UIDisableAttribute("D1a.MSASYN"),
                    new UIDisableAttribute("D1a.OTHSYN"),
                    new UIDisableAttribute("D1a.SYNINFCLIN"),
                    new UIDisableAttribute("D1a.SYNINFCTST"),
                    new UIDisableAttribute("D1a.SYNINFBIOM")
                },
                InstructionalMessage = ""
            } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("D1a.AMNDEM"),
                    new UIEnableAttribute("D1a.DYEXECSYN"),
                    new UIEnableAttribute("D1a.PCA"),
                    new UIEnableAttribute("D1a.PPASYN"),
                    new UIEnableAttribute("D1a.FTDSYN"),
                    new UIEnableAttribute("D1a.LBDSYN"),
                    new UIEnableAttribute("D1a.NAMNDEM"),
                    new UIEnableAttribute("D1a.PSPSYN"),
                    new UIEnableAttribute("D1a.CTESYN"),
                    new UIEnableAttribute("D1a.CBSSYN"),
                    new UIEnableAttribute("D1a.MSASYN"),
                    new UIEnableAttribute("D1a.OTHSYN"),
                    new UIEnableAttribute("D1a.SYNINFCLIN"),
                    new UIEnableAttribute("D1a.SYNINFCTST"),
                    new UIEnableAttribute("D1a.SYNINFBIOM")
                },

            } }
        };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D1a = (D1a)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = D1a; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(D1a); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}