using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A3Model : FormPageModel
    {
        [BindProperty]
        public A3 A3 { get; set; } = default!;

        public A3Model(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base(visitService, participationService, packetService, "A3")
        {
        }

        //TODO: Double check question label count for complete
        public List<RadioListItem> NWINFPARItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (Skip to question 2)", "0"),
            new RadioListItem("Yes (Complete questions 1A - 1B", "1")
        };

        //TODO: Double check question label count for complete
        public List<RadioListItem> NWINFSIBItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (Skip to question 3)", "0"),
            new RadioListItem("Yes (Complete questions 2a - 2t", "1")
        };

        //TODO: Double check question label count for complete
        public List<RadioListItem> NWINFKIDItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (End Form Here)", "0"),
            new RadioListItem("Yes (Complete questions 3b - 3p)", "1")
        };

        //TODO: Add instructional message for 1
        public Dictionary<string, UIBehavior> NWINFPARBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A3.MOMYOB"),
                    new UIDisableAttribute("A3.MOMDAGE"),
                    new UIDisableAttribute("A3.MOMETPR"),
                    new UIDisableAttribute("A3.MOMETSEC"),
                    new UIDisableAttribute("A3.MOMMEVAL"),
                    new UIDisableAttribute("A3.MOMAGEO"),
                    new UIDisableAttribute("A3.DADYOB"),
                    new UIDisableAttribute("A3.DADDAGE"),
                    new UIDisableAttribute("A3.DADETPR"),
                    new UIDisableAttribute("A3.DADETSEC"),
                    new UIDisableAttribute("A3.DADMEVAL"),
                    new UIDisableAttribute("A3.DADAGEO")
                },
                InstructionalMessage = "SKIP TO QUESTION 2"
            }},
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A3.MOMYOB"),
                    new UIEnableAttribute("A3.MOMDAGE"),
                    new UIEnableAttribute("A3.MOMETPR"),
                    new UIEnableAttribute("A3.DADYOB"),
                    new UIEnableAttribute("A3.DADDAGE"),
                    new UIEnableAttribute("A3.DADETPR"),
                }
            } }
        };

        //TODO: Add instructional message for option 1
        public Dictionary<string, UIBehavior> NWINFSIBBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A3.SIBS"),
                },
                InstructionalMessage = "SKIP TO QUESTION 2"
            }},
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A3.SIBS")
                }
            } }
        };

        //TODO: Doule check the question label count (3b - 3p)
        public Dictionary<string, UIBehavior> NWINFKIDBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A3.KIDS"),
                },
                InstructionalMessage = "End Form Here"
            }},
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A3.KIDS")
                },
                InstructionalMessage = "Complete questions 3b - 3p"
            }}
        };

        //TODO: Add validation for NWINFSIB
        //TODO: Add validation for NWINFKID

        private void ValidateAgeRange(int? ageOfOnset, int? ageAtDeath, int? birthYear, ModelStateDictionary modelState, string onsetField, string deathField)
        {
            bool birthYearKnown = birthYear.HasValue && birthYear != 9999;
            bool ageOfDeathKnown = ageAtDeath.HasValue && ageAtDeath != 999 && ageAtDeath != 888;
            bool ageOfOnsetKnown = ageOfOnset.HasValue && ageOfOnset != 999;

            if (ageOfOnsetKnown && ageOfDeathKnown && ageOfOnset > ageAtDeath)
            {
                modelState.AddModelError(onsetField, "Age of onset cannot be greater than age of death");
            }

            if (birthYearKnown && ageOfDeathKnown && ageAtDeath.Value > DateTime.Now.Year - birthYear)
            {
                modelState.AddModelError(deathField, "Age of death cannot be greater than the current year minus the birth year");
            }

            if (birthYearKnown && ageOfOnsetKnown && ageOfOnset > DateTime.Now.Year - birthYear)
            {
                modelState.AddModelError(onsetField, "Age of onset cannot be greater than the current year minus the birth year");
            }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A3 = (A3)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = A3; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A3); // visit needs updated form as well

            if (A3 != null && A3.Status == FormStatus.Finalized)
            {
                if (A3.MOMYOB.HasValue || A3.MOMETPR != null || A3.MOMAGEO.HasValue || A3.MOMDAGE.HasValue)
                {
                    if (!A3.MOMDAGE.HasValue)
                    {
                        ModelState.AddModelError("A3.MOMDAGE", "Please provide a value for age at death.");
                    }
                    ValidateAgeRange(A3.MOMAGEO, A3.MOMDAGE, A3.MOMYOB, ModelState, "A3.MOMAGEO", "A3.MOMDAGE");

                }
                if (A3.DADYOB.HasValue || A3.DADETPR != null || A3.DADAGEO.HasValue || A3.DADDAGE.HasValue)
                {
                    if (!A3.DADDAGE.HasValue)
                    {
                        ModelState.AddModelError("A3.DADDAGE", "Please provide a value for age at death.");
                    }
                    ValidateAgeRange(A3.DADAGEO, A3.DADDAGE, A3.DADYOB, ModelState, "A3.DADAGEO", "A3.DADDAGE");
                }
                return await base.OnPostAsync(id, goNext); // checks for validation, etc.

            }
            return await base.OnPostAsync(id, goNext);
        }
    }
}
