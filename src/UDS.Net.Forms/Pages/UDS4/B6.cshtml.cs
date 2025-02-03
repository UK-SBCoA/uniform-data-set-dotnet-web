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
    public class B6Model : FormPageModel
    {
        [BindProperty]
        public B6 B6 { get; set; } = default!;

        public List<RadioListItem> DisagreeIncreasesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "0"),
            new RadioListItem("No", "1"),
            new RadioListItem("Did not answer", "9")
        };

        public List<RadioListItem> AgreeIncreasesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "1"),
            new RadioListItem("No", "0"),
            new RadioListItem("Did not answer", "9")
        };

        public B6Model(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "B6")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B6 = (B6)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = B6; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(B6); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
