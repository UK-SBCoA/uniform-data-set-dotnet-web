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
    public class B4Model : FormPageModel
    {
        [BindProperty]
        public B4 B4 { get; set; } = default!;

        public List<RadioListItem> ImpairmentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("None", "0"),
            new RadioListItem("Questionable", "0.5"),
            new RadioListItem("Mild", "1"),
            new RadioListItem("Moderate", "2"),
            new RadioListItem("Severe", "3"),
        };

        public List<RadioListItem> ImpairmentSimpleListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("None", "0"),
            new RadioListItem("Mild", "1"),
            new RadioListItem("Moderate", "2"),
            new RadioListItem("Severe", "3"),
        };

        public B4Model(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "B4")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B4 = (B4)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = B4; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(B4); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
