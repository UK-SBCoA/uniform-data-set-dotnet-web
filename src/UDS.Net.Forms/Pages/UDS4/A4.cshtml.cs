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
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Forms.Pages.UDS4
{
    [RequestFormLimits(ValueCountLimit = 5000)]
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

        [BindProperty]
        public RxNormLookupModel RxNormLookup { get; set; } = default!;

        [BindProperty]
        public string? NewRxCUI { get; set; }

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
            // popular checkboxes are always capped at 100
            var lookup = await _lookupService.LookupDrugCodes(100, 1, true); // returns popular drugs (prescription + otc)

            var popular = lookup.DrugCodes.Where(d => d.IsPopular == true && d.IsOverTheCounter == false).ToList();

            var otc = lookup.DrugCodes.Where(d => d.IsOverTheCounter == true).ToList();

            if (interactedDrugIds != null)
            {
                var lookupIds = lookup.DrugCodes.Select(d => d.RxNormId).ToList();
                var customDrugIds = interactedDrugIds.Where(d => !lookupIds.Contains(d.RxNormId)).Select(d => d.RxNormId).ToList();

                if (customDrugIds != null && customDrugIds.Count() > 0)
                {
                    var custom = await _lookupService.FindDrugCodes(customDrugIds.ToArray());

                    // combine custom with previously interacted checkboxes
                    PopulateDrugCodeList(CustomDrugCodes, interactedDrugIds, custom.DrugCodes);
                }
            }

            // combine popular drug list with previously interacted checkboxes
            PopulateDrugCodeList(PopularDrugCodes, interactedDrugIds, popular);

            // combine otc drug list with previously interacted checkboxes
            PopulateDrugCodeList(OTCDrugCodes, interactedDrugIds, otc);

        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A4 = (A4)BaseForm; // class library should always handle new instances
            }

            RxNormLookup = new RxNormLookupModel
            {
                VisitId = id.HasValue ? id.Value : 0
            };

            await PopulateDrugCodeLists(A4.DrugIds); // put the model's A4D state into separate lists

            return Page();
        }

        public async Task<IActionResult> OnGetRxNormSearchAsync(string searchTerm)
        {
            var autoCompleteList = await _lookupService.LookupRxNormDisplayTerms(searchTerm, 10, 1);

            RxNormLookup = new RxNormLookupModel
            {
                AutocompleteResults = autoCompleteList
            };

            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial("~/Pages/RxNorm/_RxNormAutocomplete.cshtml", this.RxNormLookup);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRxNormSearchAsync(int rxNormLookup__VisitId, string rxNormLookupSearchTerm, int pageSize = 10, int pageIndex = 1)
        {
            var test = A4.DrugIds;
            var count = PopularDrugCodes.Count();
            if (!String.IsNullOrWhiteSpace(RxNormLookup.SearchTerm))
            {
                var search = await _lookupService.SearchDrugCodes(pageSize, pageIndex, RxNormLookup.SearchTerm);

                if (search.TotalResultsCount > 0 && search.DrugCodes != null && search.DrugCodes.Count > 0)
                {
                    foreach (var drugCode in search.DrugCodes)
                    {
                        RxNormLookup.SearchResults.Add(drugCode.DrugName, drugCode.RxNormId);
                    }
                }
                else
                {
                    var results = await _lookupService.LookupRxNormApproximateMatches(RxNormLookup.SearchTerm);

                    foreach (var result in results)
                    {
                        // WORKAROUND simplify results (rx norm has duplicate names)
                        // Duplicate names with different casing like:
                        // Azithromycin
                        // azithromycin
                        // AZITHROMYCIN
                        if (!RxNormLookup.SearchResults.Where(s => s.Key.ToLower() == result.Name.ToLower()).Any() && !RxNormLookup.SearchResults.Where(s => s.Value == result.RxCUI).Any())
                            RxNormLookup.SearchResults.Add(result.Name, result.RxCUI);
                    }
                }
                return Partial("~/Pages/RxNorm/_RxNormSelect.cshtml", this);
            }

            return Partial("~/Pages/RxNorm/_RxNormSearch.cshtml", this);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRxNormSelectAsync(int id, string rxCUI, string drugName)
        {
            var test = A4.DrugIds;
            var count = PopularDrugCodes.Count();
            // find out if we have it.
            var lookup = await _lookupService.FindDrugCode(rxCUI);
            if (lookup.TotalResultsCount > 0 && lookup.DrugCodes != null && lookup.DrugCodes.Count() > 0)
            {
                // Drug code already exists in local lookup
            }
            else
            {
                // Drug code isn't in local db, so we need to add it before assigning to A4
                var added = await _lookupService.AddDrugCodeToLookup(new Services.LookupModels.DrugCode
                {
                    RxNormId = rxCUI,
                    DrugName = drugName,
                    BrandName = "",
                    IsOverTheCounter = false,
                    IsPopular = false
                });
            }

            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A4 = (A4)BaseForm; // class library should always handle new instances
            }

            AssessDrugId(new DrugCodeModel
            {
                RxNormId = rxCUI,
                IsSelected = true,
                IsDeleted = false // we are selecting and adding NOT removing a drug here
            });

            await PopulateDrugCodeLists(A4.DrugIds); // put the model's A4D state into separate lists

            // refresh the list
            return Partial("_A4", this);
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
        public new async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
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

            if (A4.DrugIds.Count() > 40)
            {
                ModelState.AddModelError("A4.ANYMEDS", "Only a maximum of 40 drugs can be assigned.");
            }

            BaseForm = A4; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A4); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
