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

        public B7Model(IVisitService visitService) : base(visitService, "B7")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                B7 = (B7)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(int id)
        {
            /*
             * ValidationContext describes any member on which validation is performed. It also enables
             * custom validation to be added through any service that implements the IServiceProvider
             * interface.
             */
            foreach (var result in B7.Validate(new ValidationContext(B7, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"B7.{memberName}", result.ErrorMessage);
            }

            // if model is attempting to be completed, validation against domain form rules and visit rules
            // if not validates, return with errors

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(B7);

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
