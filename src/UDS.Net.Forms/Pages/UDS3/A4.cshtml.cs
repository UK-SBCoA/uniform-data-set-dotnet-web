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
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class A4Model : FormPageModel
    {
        protected readonly ILookupService _lookupService;

        [BindProperty]
        public A4 A4 { get; set; } = default!;

        public DrugCodeLookupModel DrugCodeLookup { get; private set; } = default!;

        public List<RadioListItem> MedicationsWithinLastTwoWeeksListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1")
        };

        public A4Model(IVisitService visitService, ILookupService lookupService) : base(visitService, "A4")
        {
            _lookupService = lookupService;
        }

        private async Task SetDrugCodeLookup()
        {
            var lookup = await _lookupService.LookupDrugCodes(100, 1);

            DrugCodeLookup = new DrugCodeLookupModel
            {
                DrugCodes = lookup.DrugCodes
                    .Select(d => new DrugCodeModel
                    {
                        DrugId = d.DrugId,
                        DrugName = d.DrugName,
                        BrandName = d.BrandName,
                        IsOverTheCounter = d.IsOverTheCounter,
                        IsPopular = d.IsPopular
                    })
                    .ToList()
            };
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (_formModel != null)
            {
                A4 = (A4)_formModel; // class library should always handle new instances
            }

            await SetDrugCodeLookup();

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id)
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
