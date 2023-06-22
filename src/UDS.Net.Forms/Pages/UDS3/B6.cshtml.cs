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

        public B6Model(IVisitService visitService) : base(visitService, "B6")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                B6 = (B6)_formModel; // class library should always handle new instances
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
            foreach (var result in B6.Validate(new ValidationContext(B6, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"B6.{memberName}", result.ErrorMessage);
            }

            // if model is attempting to be completed, validation against domain form rules and visit rules
            // if not validates, return with errors

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(B6);

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
