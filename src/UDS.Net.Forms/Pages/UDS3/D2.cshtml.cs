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
    public class D2Model : FormPageModel
    {
        [BindProperty]
        public D2 D2 { get; set; } = default!;

        public Dictionary<string, UIBehavior> CancerUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.CANCSITE") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D2.CANCSITE") } },
            {"2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D2.CANCSITE") } },
            {"8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.CANCSITE") } }
        };

        public Dictionary<string, UIBehavior> ARTHUIBehavior = new Dictionary<string, UIBehavior>
        {
             { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("D2.ARTYPE"),
                    new UIDisableAttribute("D2.ARTYPEX"),
                    new UIDisableAttribute("D2.ARTUPEX"),
                    new UIDisableAttribute("D2.ARTLOEX"),
                    new UIDisableAttribute("D2.ARTSPIN"),
                    new UIDisableAttribute("D2.ARTUNKN"),
                },
                InstructionalMessage = ""
            } },

             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("D2.ARTYPE"),
                    new UIEnableAttribute("D2.ARTUPEX"),
                    new UIEnableAttribute("D2.ARTLOEX"),
                    new UIEnableAttribute("D2.ARTSPIN"),
                    new UIEnableAttribute("D2.ARTUNKN"),
                },

            } },

                { "8", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("D2.ARTYPE"),
                    new UIDisableAttribute("D2.ARTUPEX"),
                    new UIDisableAttribute("D2.ARTLOEX"),
                    new UIDisableAttribute("D2.ARTSPIN"),
                    new UIDisableAttribute("D2.ARTUNKN"),
                },

            } }
        };

        public Dictionary<string, UIBehavior> ARTYPEUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.ARTYPEX") } },
            {"2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.ARTYPEX") } },
            {"3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D2.ARTYPEX") } },
            {"9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.ARTYPEX") } }
        };

        public Dictionary<string, UIBehavior> SLEEPOTHUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.SLEEPOTX") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D2.SLEEPOTX") } },
            {"8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.SLEEPOTX") } }
        };

        public Dictionary<string, UIBehavior> ANTIENCUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.ANTIENCX") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D2.ANTIENCX") } },
            {"8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.ANTIENCX") } }
        };

        public Dictionary<string, UIBehavior> OTHCONDUIBehavior = new Dictionary<string, UIBehavior>
        {
            {"0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.OTHCONDX") } },
            {"1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D2.OTHCONDX") } },
            {"8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D2.OTHCONDX") } }
        };

        public List<RadioListItem> CancerListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 2)", "0"),
            new RadioListItem("Yes, primary/non-metastatic", "1"),
            new RadioListItem("Yes, metastatic", "2"),
            new RadioListItem("Not assessed (skip to question 2)", "8")
        };

        public List<RadioListItem> DiabetesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes, Type I", "1"),
            new RadioListItem("Yes, Type II", "2"),
            new RadioListItem("Yes, other type (diabetes insipidus, latent autoimmune diabetes/type 1.5, gestational diabetes)", "3"),
            new RadioListItem("Not assessed or unknown", "8")
        };

        public List<RadioListItem> SimpleListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Not assessed", "8")
        };

        public List<RadioListItem> ArthritisListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Rheumatoid", "1"),
            new RadioListItem("Osteoarthritis", "2"),
            new RadioListItem("Other (specify)", "3"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> NoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> ListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("", "")
        };

        public D2Model(IVisitService visitService) : base(visitService, "D2")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D2 = (D2)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = D2; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(D2); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
