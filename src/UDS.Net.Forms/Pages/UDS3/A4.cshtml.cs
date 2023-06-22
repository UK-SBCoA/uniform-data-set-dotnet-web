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
    public class A4Model : FormPageModel
    {
        [BindProperty]
        public A4 A4 { get; set; } = default!;

        public List<RadioListItem> MedicationsWithinLastTwoWeeksListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1")
        };

        public A4Model(IVisitService visitService) : base(visitService, "A4")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                A4 = (A4)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPost(int id)
        {
            foreach (var result in A4.Validate(new ValidationContext(A4, null, null)))
            {
                // Validation in these scenarios
                // - cross-form validation
                // - differences in validation across visit types for instance, IVP vs FVP
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"A4.{memberName}", result.ErrorMessage);
            }

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(A4);

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
