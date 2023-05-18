using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class A3Model : FormPageModel
    {
        [BindProperty]
        public A3 A3 { get; set; } = default!;

        public A3Model(IVisitService visitService) : base(visitService, "A3")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                A3 = (A3)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(int id)
        {
            foreach (var result in A3.Validate(new ValidationContext(A3, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"A3.{memberName}", result.ErrorMessage);
            }

            if (ModelState.IsValid)
            {
                await base.OnPost(id); // checks for domain-level business rules validation
            }

            var visit = await _visitService.GetByIdWithForm("", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }

        public JsonResult ValidateYear(int year)
        {
            return new JsonResult(true);
        }
    }
}
