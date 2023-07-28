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
    public class B5Model : FormPageModel
    {
        [BindProperty]
        public B5 B5 { get; set; } = default!;

        public List<RadioListItem> CoparticipantListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Spouse", "1"),
            new RadioListItem("Child", "2"),
            new RadioListItem("Other", "3")
        };

        public List<RadioListItem> SymptomPresentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "1"),
            new RadioListItem("No", "0"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SeverityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Mild", "1"),
            new RadioListItem("Mod", "2"),
            new RadioListItem("Severe", "3"),
            new RadioListItem("Unknown", "9"),
        };

        public Dictionary<string, UIBehavior> NPIQINFUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.NPIQINFX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.NPIQINFX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.NPIQINFX") } }
        };

        public Dictionary<string, UIBehavior> DELUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.DELSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.DELSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.DELSEV") } }
        };
        public Dictionary<string, UIBehavior> HALLUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.HALLSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.HALLSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.HALLSEV") } }
        };

        public Dictionary<string, UIBehavior> AGITUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.AGITSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.AGITSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.AGITSEV") } }
        };

        public Dictionary<string, UIBehavior> DEPDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.DEPDSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.DEPDSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.DEPDSEV") } }
        };

        public Dictionary<string, UIBehavior> ANXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.ANXSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.ANXSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.ANXSEV") } }
        };

        public Dictionary<string, UIBehavior> ELATUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.ELATSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.ELATSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.ELATSEV") } }
        };

        public Dictionary<string, UIBehavior> APAUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.APASEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.APASEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.APASEV") } }
        };

        public Dictionary<string, UIBehavior> DISNUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.DISNSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.DISNSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.DISNSEV") } }
        };

        public Dictionary<string, UIBehavior> IRRUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.IRRSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.IRRSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.IRRSEV") } }
        };

        public Dictionary<string, UIBehavior> MOTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.MOTSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.MOTSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.MOTSEV") } }
        };

        public Dictionary<string, UIBehavior> NITEUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.NITESEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.NITESEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.NITESEV") } }
        };

        public Dictionary<string, UIBehavior> APPUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B5.APPSEV") } },
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.APPSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B5.APPSEV") } }
        };

        public B5Model(IVisitService visitService) : base(visitService, "B5")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B5 = (B5)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = B5; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(B5); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}