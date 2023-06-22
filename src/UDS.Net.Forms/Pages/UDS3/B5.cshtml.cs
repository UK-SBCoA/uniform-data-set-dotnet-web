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
    public class B5Model : FormPageModel
    {
        [BindProperty]
        public B5 B5 { get; set; } = default!;

        public List<RadioListItem> CoparticipantListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Spouse", "1"),
            new RadioListItem("Child", "2"),
            new RadioListItem("Other", "3")
        };

        public List<RadioListItem> SymptomPresentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "1"),
            new RadioListItem("No", "0"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SeverityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Mild", "1"),
            new RadioListItem("Mod", "2"),
            new RadioListItem("Severe", "3"),
            new RadioListItem("Unknown", "9"),
        };

        public B5Model(IVisitService visitService) : base(visitService, "B5")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                B5 = (B5)_formModel; // class library should always handle new instances
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
            foreach (var result in B5.Validate(new ValidationContext(B5, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"B5.{memberName}", result.ErrorMessage);
            }

            // if model is attempting to be completed, validation against domain form rules and visit rules
            // if not validates, return with errors

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(B5);

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
