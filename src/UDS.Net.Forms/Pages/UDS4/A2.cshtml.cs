using Microsoft.AspNetCore.Mvc;
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

        public List<RadioListItem> INRELTOListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Spouse, partner, or companion (include ex-spouse,ex-partner,fiancé(e),boyfriend,girlfriend)", "1"),
            new RadioListItem("Child (by blood or through marriage or adoption)", "2"),
            new RadioListItem("Sibling (by blood or through marriage or adoption)", "3"),
            new RadioListItem("Other relative (by blood or through marriage or adoption)", "4"),
            new RadioListItem("Friend, neighbor, or someone known through family, friends, work, or community (e.g., church)", "5"),
            new RadioListItem("Paid caregiver, health care provider, or clinician", "6")
        };

        public List<RadioListItem> NEWINFListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
        };

        public List<RadioListItem> INLIVWTHListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes (SKIP TO QUESTION 5)", "1")
        };

        public Dictionary<string, UIBehavior> INLIVWTHOptionsUIBehavior = new Dictionary<string, UIBehavior>
        {

            { "0", new UIBehavior { PropertyAttributes = new List<UIPropertyAttributes>
            {
            new UIEnableAttribute("A2.INCNTMOD"),
            new UIEnableAttribute("A2.INCNTFRQ"),
            new UIEnableAttribute("A2.INCNTTIM")}
            } },

            {"1", new UIBehavior {PropertyAttributes = new List<UIPropertyAttributes>
            {
            new UIDisableAttribute("A2.INCNTMOD"),
            new UIDisableAttribute("A2.INCNTMDX"),
            new UIDisableAttribute("A2.INCNTFRQ"),
            new UIDisableAttribute("A2.INCNTTIM")
            }
            } }

        };

        public List<RadioListItem> INCNTMODListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("In-person", "1"),
            new RadioListItem("Telephone", "2"),
            new RadioListItem("Video conferencing", "3"),
            new RadioListItem("Texting or email", "4"),
            new RadioListItem("Social media platforms", "5"),
            new RadioListItem("Other (SPECIFY)", "6")
        };

        public Dictionary<string, UIBehavior> INCNTMODUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INCNTMDX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INCNTMDX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INCNTMDX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INCNTMDX") } },
            { "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A2.INCNTMDX") } },
            { "6", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A2.INCNTMDX") } },

        };

        public List<RadioListItem> INCNTFRQListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Daily", "1"),
            new RadioListItem("At least three times per week", "2"),
            new RadioListItem("Weekly", "3"),
            new RadioListItem("At least three times per month", "4"),
            new RadioListItem("Monthly", "5"),
            new RadioListItem("Less than once a month", "6")
        };

        public List<RadioListItem> INCNTTIMListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Less than 5 minutes (appropriate for texing or email and may be applicable to other modes of contact as well)", "1"),
            new RadioListItem("5-15 minutes", "2"),
            new RadioListItem("15-30 minutes", "3"),
            new RadioListItem("30-60 minutes", "4"),
            new RadioListItem("Longer than one hour", "5"),
        };

        public List<RadioListItem> INRELYListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
        };

        public List<RadioListItem> INMEMWORSListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes, but this does not worry me", "1"),
            new RadioListItem("Yes, and this worries me", "2"),
            new RadioListItem("Unknown", "9"),
        };

        public List<RadioListItem> INMEMTROUBListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Never", "1"),
            new RadioListItem("Rarely", "2"),
            new RadioListItem("Sometimes", "3"),
            new RadioListItem("Often", "4"),
            new RadioListItem("Very Often", "5"),
            new RadioListItem("Unknown", "9"),
        };

        public List<RadioListItem> INMEMTENListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Much better", "1"),
            new RadioListItem("A little better", "2"),
            new RadioListItem("The same", "3"),
            new RadioListItem("A little worse", "4"),
            new RadioListItem("Much worse", "5"),
            new RadioListItem("Unknown", "9"),
        };



        public A2Model(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base(visitService, participationService, packetService, "A2")
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
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = A2; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A2); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
