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
	public class A4aModel : FormPageModel
    {
        [BindProperty]
        public A4a A4a { get; set; } = default!;

        public A4aTreatment A4ATreatment { get; set; }

        public List<RadioListItem> TRTBIOMARKListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> CARETRIALListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Clinical care", "1"),
            new RadioListItem("Clinical trial", "2"),
            new RadioListItem("Clinical care and clinical trial", "3")
        };

        public List<RadioListItem> TRIALGRPistItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Active treatment", "1"),
            new RadioListItem("Placebo", "2"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ADVEVENTListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };


        public A4aModel(IVisitService visitService) : base(visitService, "A4a")
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
       public async Task<IActionResult> OnPostAsync(int id)
       {
            BaseForm = A4a; // reassign bounded and derived form to base form for base method

          Visit.Forms.Add(A4a); // visit needs updated form as well

           return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
