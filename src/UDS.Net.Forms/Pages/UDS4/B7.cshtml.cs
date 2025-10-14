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
    public class B7Model : FormPageModel
    {
        [BindProperty]
        public B7 B7 { get; set; } = default!;

        public List<RadioListItem> ListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Not applicable (e.g., never did)", "8"),
            new RadioListItem("Normal", "0"),
            new RadioListItem("Has difficulty, but does by self", "1"),
            new RadioListItem("Requires assistance", "2"),
            new RadioListItem("Dependent", "3"),
            new RadioListItem("Unknown", "9")
        };

        public B7Model(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "B7")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B7 = (B7)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = B7; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(B7); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
