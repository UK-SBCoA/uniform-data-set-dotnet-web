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

        public B4Model(IVisitService visitService) : base(visitService, "B4")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (_formModel != null)
            {
                B4 = (B4)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            /*
             * ValidationContext describes any member on which validation is performed. It also enables
             * custom validation to be added through any service that implements the IServiceProvider
             * interface.
             */
            foreach (var result in B4.Validate(new ValidationContext(B4, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"A1.{memberName}", result.ErrorMessage);
            }

            // if model is attempting to be completed, validation against domain form rules and visit rules
            // if not validates, return with errors

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(B4);

                await base.OnPostAsync(id); // checks for domain-level business rules validation
            }

            var visit = await _visitService.GetByIdWithForm("", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}
