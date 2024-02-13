using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A2Model : FormPageModel
    {
        [BindProperty]
        public A2 A2 { get; set; } = default!;

        #region UDS4

        public List<RadioListItem> INRELTO { get; } = new List<RadioListItem>
        {
            new RadioListItem("Spouse, partner, or companion (include ex-spouse,ex-partner,fiancé(e),boyfriend,girlfriend)", "1"),
            new RadioListItem("Child (by blood or through marriage or adoption)", "2"),
            new RadioListItem("Sibling (by blood or thorugh marriage or adoption)", "3"),
            new RadioListItem("Other relative (by blood or through marriage or adoption)", "4"),
            new RadioListItem("Friend, neighbor, or someone known through family, friends, work, or community (e.g., church)", "5"),
            new RadioListItem("Paid caregiver, health care provider, or clinician", "6")
        };

        public List<RadioListItem> INLIVWTH { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 5)", "1")
        };

        public List<RadioListItem> INCNTMOD { get; } = new List<RadioListItem>
        {
            new RadioListItem("In-person", "1"),
            new RadioListItem("Telephone", "2"),
            new RadioListItem("Video conferencing", "3"),
            new RadioListItem("Texting or email", "4"),
            new RadioListItem("Social media platforms", "5"),
            new RadioListItem("Other (SPECIFY)", "6")
        };

        public List<RadioListItem> INCNTFRQ { get; } = new List<RadioListItem>
        {
            new RadioListItem("Daily", "1"),
            new RadioListItem("At least three times per week", "2"),
            new RadioListItem("Weekly", "3"),
            new RadioListItem("At least three times per month", "4"),
            new RadioListItem("Monthly", "5"),
            new RadioListItem("Less than once a month", "6")
        };

        public List<RadioListItem> INCNTTIM { get; } = new List<RadioListItem>
        {
            new RadioListItem("Less than 5 minutes (appropriate for texing or email and may be applicable to other modes of contact as well)", "1"),
            new RadioListItem("5-15 minutes", "2"),
            new RadioListItem("15-30 minutes", "3"),
            new RadioListItem("30-60 minutes", "4"),
            new RadioListItem("Longer than one hour", "5"),
        };

        public List<RadioListItem> INRELY { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
        };

        public List<RadioListItem> INMEMWORS { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes, but this does not worry me", "1"),
            new RadioListItem("Yes, and this worries me", "2"),
            new RadioListItem("Unknown", "9"),
        };

        public List<RadioListItem> INMEMTROUB { get; } = new List<RadioListItem>
        {
            new RadioListItem("Never", "1"),
            new RadioListItem("Rarely", "2"),
            new RadioListItem("Sometimes", "3"),
            new RadioListItem("Often", "4"),
            new RadioListItem("Very Often", "5"),
            new RadioListItem("Unknown", "9"),
        };

        public List<RadioListItem> INMEMTEN { get; } = new List<RadioListItem>
        {
            new RadioListItem("Much better", "1"),
            new RadioListItem("A little better", "2"),
            new RadioListItem("The same", "3"),
            new RadioListItem("A little worse", "4"),
            new RadioListItem("Much worse", "5"),
            new RadioListItem("Unknown", "9"),
        };


        #endregion

        public List<RadioListItem> SexListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Male", "1"),
            new RadioListItem("Female", "2")
        };

        public List<RadioListItem> NewCoParticipantListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No (If No, SKIP TO QUESTION 9)", "0"),
            new RadioListItem("Yes", "1")
        };

        public Dictionary<string, UIBehavior> NewCoParticipantUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior{
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A2.INHISP"),
                new UIDisableAttribute("A2.INHISPOR"),
                new UIDisableAttribute("A2.INRACE"),
                new UIDisableAttribute("A2.INRASEC"),
                new UIDisableAttribute("A2.INRATER"),
                new UIDisableAttribute("A2.INEDUC")
            },
            InstructionalMessage = "skip to question 9"

            } },
            { "1", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A2.INHISP"),
                new UIEnableAttribute("A2.INHISPOR"),
                new UIEnableAttribute("A2.INRACE"),
                new UIEnableAttribute("A2.INRASEC"),
                new UIEnableAttribute("A2.INRATER"),
                new UIEnableAttribute("A2.INEDUC")
            },
            } }
        };

        public List<RadioListItem> HispanicLatinoListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No  (If No, SKIP TO QUESTION 4)", "1"),
            new RadioListItem("Yes", "2"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION 4)", "9")
        };

        public List<RadioListItem> HispanicLatinoFVPListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No  (If No, SKIP TO QUESTION 5)", "1"),
            new RadioListItem("Yes", "2"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION 5)", "9")
        };
        public Dictionary<string, UIBehavior> HispanicLatinoUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOR") } },
            { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A2.INHISPOR") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOR") } }
        };

        public List<RadioListItem> OriginsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Mexican, Chicano, or Mexican-American", "1"),
            new RadioListItem("Puerto Rican", "2"),
            new RadioListItem("Cuban", "3"),
            new RadioListItem("Dominican", "4"),
            new RadioListItem("Central American", "5"),
            new RadioListItem("South American", "6"),
            new RadioListItem("Other (specify)", "50"),
            new RadioListItem("Unknown","99")
        };

        public Dictionary<string, UIBehavior> OriginsUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOX") } },
            { "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOX") } },
            { "6", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOX") } },
            { "50", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A2.INHISPOX") } },
            { "99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INHISPOX") } }

        };
        public List<RadioListItem> RacialGroupsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("White", "1"),
            new RadioListItem("Black or African American", "2"),
            new RadioListItem("American Indian or Alaska Native", "3"),
            new RadioListItem("Native Hawaiian or other Pacific Islander", "4"),
            new RadioListItem("Asian", "5"),
            new RadioListItem("Other (specify)", "50"),
            new RadioListItem("Unknown", "99")
        };


        public Dictionary<string, UIBehavior> RacialGroupsUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRACEX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRACEX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRACEX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRACEX" ) } },
            { "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRACEX") } },
            { "50", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A2.INRACEX")  } },
            { "99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRACEX") } },

        };

        public List<RadioListItem> AdditionalRacialGroupsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("White", "1"),
            new RadioListItem("Black or African American", "2"),
            new RadioListItem("American Indian or Alaska Native", "3"),
            new RadioListItem("Native Hawaiian or other Pacific Islander", "4"),
            new RadioListItem("Asian", "5"),
            new RadioListItem("Other (specify)", "50"),
            new RadioListItem("Unknown", "99")
        };

        public Dictionary<string, UIBehavior> AdditionalRacialGroupsUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRASECX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRASECX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRACEX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRASECX" ) } },
            { "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRASECX") } },
            { "50", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A2.INRASECX")  } },
            { "99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRASECX") } },

        };

        public List<RadioListItem> BeyondAdditionalRacialGroupsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("White", "1"),
            new RadioListItem("Black or African American", "2"),
            new RadioListItem("American Indian or Alaska Native", "3"),
            new RadioListItem("Native Hawaiian or other Pacific Islander", "4"),
            new RadioListItem("Asian", "5"),
            new RadioListItem("Other (specify)", "50"),
            new RadioListItem("Unknown", "99")
        };

        public Dictionary<string, UIBehavior> BeyondAdditionalRacialGroupsUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRATERX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRATERX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRATERX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRATERX" ) } },
            { "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRATERX") } },
            { "50", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A2.INRATERX")  } },
            { "99", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INRATERX") } },

        };


        public List<RadioListItem> RelationshipTypesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Spouse, partner, or companion (include ex-spouse, ex-partner, fiancé, boyfriend, girlfriend)", "1"),
            new RadioListItem("Child (by blood or through marriage or adoption)", "2"),
            new RadioListItem("Sibling (by blood or through marriage or adoption)", "3"),
            new RadioListItem("Other relative (by blood or through marriage or adoption)", "4"),
            new RadioListItem("Friend, neighbor, or someone known through family, friends, work, or community (e.g., church)", "5"),
            new RadioListItem("Paid caregiver, health care provider, or clinician", "6"),
        };

        public List<RadioListItem> LivingSituationListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes (If Yes, SKIP TO QUESTION 10)", "1")
        };

        public List<RadioListItem> LivingSituationFVPListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes (If Yes, SKIP TO QUESTION 11)", "1")
        };

        public Dictionary<string, UIBehavior> LivingSituationUIBehavior = new Dictionary<string, UIBehavior>
        {

            { "0", new UIBehavior { PropertyAttributes = new List<UIPropertyAttributes>
            {
            new UIEnableAttribute("A2.INVISITS"),
            new UIEnableAttribute("A2.INCALLS")}
            } },

            {"1", new UIBehavior {PropertyAttributes = new List<UIPropertyAttributes>
            {
            new UIDisableAttribute("A2.INVISITS"),
            new UIDisableAttribute("A2.INCALLS")
            }
            } }

        };

        public List<RadioListItem> VisitContactFrequencyListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Daily", "1"),
            new RadioListItem("At least 3 times per week", "2"),
            new RadioListItem("Weekly", "3"),
            new RadioListItem("At least three times per month", "4"),
            new RadioListItem("Monthly", "5"),
            new RadioListItem("Less than once a month", "6"),
        };

        public List<RadioListItem> TelephoneContactFrequencyListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Daily", "1"),
            new RadioListItem("At least 3 times per week", "2"),
            new RadioListItem("Weekly", "3"),
            new RadioListItem("At least three times per month", "4"),
            new RadioListItem("Monthly", "5"),
            new RadioListItem("Less than once a month", "6"),
        };

        public List<RadioListItem> ReliabilityListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public A2Model(IVisitService visitService) : base(visitService, "A2")
        {
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A2 = (A2)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = A2; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A2); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
