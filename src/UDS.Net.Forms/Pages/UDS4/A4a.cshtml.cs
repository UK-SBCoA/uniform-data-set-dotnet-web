using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A4aModel : FormPageModel
    {
        [BindProperty]
        public A4a A4a { get; set; } = default!;

        public A4aTreatment A4ATreatment { get; set; }

        public List<RadioListItem> TRTBIOMARKListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ADVEVENTListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public Dictionary<string, UIBehavior> TRTBIOMARKUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ADVEVENT"),
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),

                },
                InstructionalMessage = "END FORM HERE"
            } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A4a.ADVEVENT") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A4a.ADVEVENT") } }
        };

        public Dictionary<string, UIBehavior> ADVEVENTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),

                },
                InstructionalMessage = "END FORM HERE"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A4a.ARIAE"),
                    new UIEnableAttribute("A4a.ARIAH"),
                    new UIEnableAttribute("A4a.ADVERSEOTH")

                },
                InstructionalMessage = ""
            } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                },
                InstructionalMessage = ""
            } }
        };

        public A4aModel(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "A4a")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A4a = (A4a)BaseForm;
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = A4a; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A4a); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
