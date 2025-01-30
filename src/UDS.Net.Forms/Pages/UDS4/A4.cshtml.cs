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
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Forms.Pages.UDS4
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

        public A4Model(IVisitService visitService, IParticipationService participationService, ILookupService lookupService) : base(visitService, participationService, "A4")
        {
            _lookupService = lookupService;
        }

        private void PopulateDrugCodeList(List<DrugCodeModel> viewModel, List<DrugCodeModel> interactedDrugIds, List<DrugCode> list)
        {
            foreach (var drug in list)
            {
                if (drug != null)
                {
                    // check if the drug has ever been interacted with (checked/checked then unchecked/etc.)
                    if (interactedDrugIds.Any(s => s.RxNormId == drug.RxNormId))
                    {
                        var interacted = interactedDrugIds.Where(s => s.RxNormId == drug.RxNormId).FirstOrDefault();

                        if (interacted != null)
                        {
                            viewModel.Add(drug.ToVM(interacted));

                            interactedDrugIds.Remove(interacted);
                        }
                    }
                    else
                        viewModel.Add(drug.ToVM()); // checkbox has never been interacted with

                }
            }
        }

        private async Task PopulateDrugCodeLists(List<DrugCodeModel> interactedDrugIds)
        {
            var lookup = await _lookupService.LookupDrugCodes(200, 1); // returns popular drugs (prescription + otc) and custom

            var popular = lookup.DrugCodes.Where(d => d.IsPopular == true && d.IsOverTheCounter == false).ToList();

            var otc = lookup.DrugCodes.Where(d => d.IsOverTheCounter == true).ToList();

            var custom = lookup.DrugCodes.Where(d => d.IsPopular == false && d.IsOverTheCounter == false).ToList();

            // combine popular drug list with previously interacted checkboxes
            PopulateDrugCodeList(PopularDrugCodes, interactedDrugIds, popular);

            // combine otc drug list with previously interacted checkboxes
            PopulateDrugCodeList(OTCDrugCodes, interactedDrugIds, otc);

            // combine custom with previously interacted checkboxes
            PopulateDrugCodeList(CustomDrugCodes, interactedDrugIds, custom);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A4 = (A4)BaseForm; // class library should always handle new instances
            }

            await PopulateDrugCodeLists(A4.DrugIds); // put the model's A4D state into separate lists

            return Page();
        }

        private void AssessDrugId(DrugCodeModel? vm)
        {
            if (vm != null)
            {
                if (vm.Id > 0 || vm.IsSelected) // if it is persisted from a previous interaction or new
                {
                    if (vm.Id == null) // it's new
                    {
                        vm.CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "username";
                        vm.CreatedAt = DateTime.Now;
                    }
                    else if (vm.Id > 0)
                    {
                        if (vm.IsSelected)
                        {
                            vm.IsDeleted = false; // checked = new or re-checked (update)
                            vm.DeletedBy = null;
                            vm.ModifiedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "username";

                        }
                        else
                        {
                            vm.DeletedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "username";
                            vm.IsDeleted = true; // unchecked (soft delete)
                        }
                    }
                    // We now have a scenario where custom drug ids can be manually entered, so there is potential for duplicates
                    // across popular, OTC, and custom lists. We'll check for duplicates before adding drug to list of DrugIds.
                    if (!A4.DrugIds.Where(d => d.RxNormId == vm.RxNormId && d.IsDeleted == false).Any())
                        A4.DrugIds.Add(vm);
                }
            }
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id, string? addCustomMed)
        {
            // Reassemble the model's A4D state based on the bound properties
            foreach (var p in PopularDrugCodes)
            {
                AssessDrugId(p);
            }
            foreach (var o in OTCDrugCodes)
            {
                AssessDrugId(o);
            }
            foreach (var c in CustomDrugCodes)
            {
                AssessDrugId(c);
            }

            BaseForm = A4; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A4); // visit needs updated form as well

            if (string.IsNullOrWhiteSpace(addCustomMed))
            {
                return await base.OnPostAsync(id); // checks for validation, etc.
            }
            else
            {
                if (A4.Id == 0)
                    ModelState.AddModelError("A4.ANYMEDS", "Please save form before searching RxNorm for new custom medications");

                await base.OnPostAsync(id);

                if (ModelState.IsValid)
                    return RedirectToPage("/RxNorm/Search", new { Id = id });
                else
                    return Page();
            }
        }
    }
}
