using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class T1Model : FormPageModel
    {
        [BindProperty]
        public T1 T1 { get; set; } = default!;

        public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SimpleYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> ModalityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Telephone", "1"),
            new RadioListItem("Video-assisted conference", "2"),
            new RadioListItem("Some combination of the two", "3")
        };

        public T1Model(IVisitService visitService) : base(visitService, "T1")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                T1 = (T1)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = T1; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(T1); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
