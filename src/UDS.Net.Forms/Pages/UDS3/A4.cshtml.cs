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

namespace UDS.Net.Forms.Pages.UDS3
{
    public class A4Model : FormPageModel
    {
        protected readonly ILookupService _lookupService;

        [BindProperty]
        public A4 A4 { get; set; } = default!;

        [BindProperty]
        public List<DrugCodeModel> PopularDrugCodes { get; set; } = new List<DrugCodeModel>();

        [BindProperty]
        public List<DrugCodeModel> OTCDrugCodes { get; set; } = new List<DrugCodeModel>();

        [BindProperty]
        public List<DrugCodeModel> CustomDrugCodes { get; set; } = new List<DrugCodeModel>();


        public List<RadioListItem> MedicationsWithinLastTwoWeeksListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1")
        };

        public A4Model(IVisitService visitService, ILookupService lookupService) : base(visitService, "A4")
        {
            _lookupService = lookupService;
        }

        private async Task PopulateDrugCodeLists(List<DrugCodeModel> interactedDrugIds)
        {
            var lookup = await _lookupService.LookupDrugCodes(100, 1); // returns popular drugs (prescription + otc)

            var popular = lookup.DrugCodes.Where(d => d.IsOverTheCounter == false).ToList();

            var otc = lookup.DrugCodes.Where(d => d.IsOverTheCounter == true).ToList();

            //  popular drug list combined with previously interacted checkboxes
            foreach (var drug in popular)
            {
                if (drug != null)
                {
                    // check if the drug has ever been interacted with (checked/checked then unchecked/etc.)
                    if (interactedDrugIds.Any(s => s.DrugId == drug.DrugId))
                    {
                        var interacted = interactedDrugIds.Where(s => s.DrugId == drug.DrugId).FirstOrDefault();

                        if (interacted != null)
                        {
                            PopularDrugCodes.Add(drug.ToVM(interacted));

                            interactedDrugIds.Remove(interacted);
                        }
                    }
                    else
                        PopularDrugCodes.Add(drug.ToVM()); // checkbox has never been interacted with
                }
            }

            // otc drug list combined with previously interacted checkboxes
            foreach (var drug in otc)
            {
                if (drug != null)
                {
                    // check if the drug has ever been interacted with (checked/checked then unchecked/etc.)
                    if (interactedDrugIds.Any(s => s.DrugId == drug.DrugId))
                    {
                        var interacted = interactedDrugIds.Where(s => s.DrugId == drug.DrugId).FirstOrDefault();

                        if (interacted != null)
                        {
                            OTCDrugCodes.Add(drug.ToVM(interacted));

                            interactedDrugIds.Remove(interacted);
                        }
                    }
                    else
                        OTCDrugCodes.Add(drug.ToVM()); // checkbox has never been interacted with
                }
            }

            // now whatever is left are the custom drug codes that were added to the visit
            CustomDrugCodes = interactedDrugIds;

        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (_formModel != null)
            {
                A4 = (A4)_formModel; // class library should always handle new instances
            }

            await PopulateDrugCodeLists(A4.DrugIds);

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

            // TODO Update drug ids


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
