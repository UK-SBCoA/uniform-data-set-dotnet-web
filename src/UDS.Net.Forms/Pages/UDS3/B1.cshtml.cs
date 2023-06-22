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
    public class B1Model : FormPageModel
    {
        [BindProperty]
        public B1 B1 { get; set; } = default!;

        public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public B1Model(IVisitService visitService) : base(visitService, "B1")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                B1 = (B1)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPost(int id)
        {
            foreach (var result in B1.Validate(new ValidationContext(B1, null, null)))
            {
                // Validation in these scenarios
                // - cross-form validation
                // - differences in validation across visit types for instance, IVP vs FVP
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"B1.{memberName}", result.ErrorMessage);
            }

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(B1);

                await base.OnPost(id); // checks for domain-level business rules validation
            }

            var visit = await _visitService.GetByIdWithForm("", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}
