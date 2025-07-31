using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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
        public List<string> SelectedDrugs { get; set; } = new List<string>();

        [BindProperty]
        public RxNormLookupModel RxNormLookup { get; set; } = default!;

        public List<RadioListItem> MedicationsWithinLastTwoWeeksListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1")
        };

        public A4Model(IVisitService visitService, IParticipationService participationService, ILookupService lookupService) : base(visitService, participationService, "A4")
        {
            _lookupService = lookupService;
        }

        private async Task PopulateDrugCodeLists()
        {
            var lookup = await _lookupService.LookupDrugCodes(100, 1, true); // returns popular drugs (prescription + otc)

            if (lookup != null && lookup.DrugCodes != null)
            {
                PopularDrugCodes = lookup.DrugCodes.Where(d => d.IsPopular == true && d.IsOverTheCounter == false).Select(d => d.ToVM()).ToList();

                OTCDrugCodes = lookup.DrugCodes.Where(d => d.IsOverTheCounter == true).Select(d => d.ToVM()).ToList();
            }

            if (SelectedDrugs != null)
            {
                // get only the drugs that are custom since we already have popular and otc
                var drugsToRemove = lookup.DrugCodes.Select(d => d.RxNormId).ToHashSet();
                var customDrugsToLookup = SelectedDrugs.ToList(); // copy
                customDrugsToLookup.RemoveAll(d => drugsToRemove.Contains(d));

                var customList = await _lookupService.FindDrugCodes(customDrugsToLookup.ToArray());
                CustomDrugCodes = customList.DrugCodes.Select(d => d.ToVM()).OrderBy(d => d.DrugName).ToList();
            }
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

            SelectedDrugs = A4.DrugIds.Select(d => d.RxNormId).ToList();

            await PopulateDrugCodeLists(); // gather the drug reference lists

            return Page();
        }

        public async Task<IActionResult> OnGetRxNormStream(string searchTerm)
        {
            var autoCompleteList = await _lookupService.LookupRxNormDisplayTerms(searchTerm, 100, 1);

            RxNormLookup = new RxNormLookupModel
            {
                AutocompleteResults = autoCompleteList,
                ResultsCount = autoCompleteList.Count()
            };

            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial("~/Pages/RxNorm/_RxNormAutocompleteStream.cshtml", this.RxNormLookup);
        }

        // Used by Back button on _RxNormSelect partial
        public async Task<IActionResult> OnGetRxNormSearchAsync(int id, string searchTerm)
        {
            this.RxNormLookup = new RxNormLookupModel
            {
                SearchTerm = searchTerm,
                VisitId = id
            };
            ModelState.ClearValidationState(nameof(RxNormLookup));
            return Partial("~/Pages/RxNorm/_RxNormSearch.cshtml", this.RxNormLookup);
        }

        // Used by Reset returns stream
        public async Task<IActionResult> OnGetRxNormSearchResetAsync(int id, string searchTerm)
        {
            this.RxNormLookup = new RxNormLookupModel
            {
                VisitId = id
            };
            ModelState.ClearValidationState(nameof(RxNormLookup.SearchTerm));
            //return Partial("~/Pages/RxNorm/_RxNormSearchForm.cshtml", this.RxNormLookup);
            // refresh the list by returning a turbo stream
            Response.ContentType = "text/vnd.turbo-stream.html"; // this stream replaces _A4 and _RxNorm
            return Partial("~/Pages/RxNorm/_RxNormSearchStream.cshtml", this.RxNormLookup);
        }

        // When Search button is clicked in _RxNormSearch partial
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRxNormSearchAsync(int pageSize = 10, int pageIndex = 1)
        {
            ModelState.ClearValidationState(nameof(RxNormLookup));
            if (!String.IsNullOrWhiteSpace(RxNormLookup.SearchTerm))
            {
                var search = await _lookupService.SearchDrugCodes(pageSize, pageIndex, RxNormLookup.SearchTerm);

                if (search.TotalResultsCount > 0 && search.DrugCodes != null && search.DrugCodes.Count > 0)
                {
                    foreach (var drugCode in search.DrugCodes)
                    {
                        if (!String.IsNullOrWhiteSpace(drugCode.BrandName))
                            drugCode.BrandName = " (" + drugCode.BrandName + ")";

                        RxNormLookup.SearchResults.Add($"{drugCode.DrugName}{drugCode.BrandName}", drugCode.RxNormId);
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
                return Partial("~/Pages/RxNorm/_RxNormSelect.cshtml", this.RxNormLookup);
            }

            return Partial("~/Pages/RxNorm/_RxNormSearch.cshtml", this.RxNormLookup);
        }

        // When Select button is clicked for a new drug in _RxNormSelect partial
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRxNormSelectAsync(int id, string rxCUI, string drugName)
        {
            // TODO check that everything is persisted and we don't need to rebind anything.
            var popular = this.PopularDrugCodes;
            var otc = this.OTCDrugCodes;
            var custom = this.CustomDrugCodes;

            // find out if we have the drug in our local reference
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

            if (!this.CustomDrugCodes.Where(d => d.RxNormId.Trim() == rxCUI.Trim()).Any())
            {
                // add if it is not a duplicate
                this.CustomDrugCodes.Add(new DrugCodeModel
                {
                    RxNormId = rxCUI,
                    DrugName = drugName,
                    IsOverTheCounter = false,
                    IsPopular = false
                });
            }

            this.CustomDrugCodes = this.CustomDrugCodes.OrderBy(d => d.DrugName).ToList();

            SelectedDrugs.Add(rxCUI);

            // Reset RxNormLookup
            RxNormLookup.VisitId = id;
            RxNormLookup.SearchTerm = "";
            ModelState.ClearValidationState(nameof(RxNormLookup));

            // refresh the list by returning a turbo stream
            Response.ContentType = "text/vnd.turbo-stream.html"; // this stream replaces _A4 and _RxNorm
            return Partial("_A4Stream", this);
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            // Reassemble the model's A4D state based on the selected drugs
            // Remove
            A4.DrugIds.RemoveAll(d => !SelectedDrugs.Contains(d.RxNormId));
            // Add
            foreach (var selected in SelectedDrugs)
            {
                if (!A4.DrugIds.Where(d => d.RxNormId == selected).Any())
                {
                    A4.DrugIds.Add(new DrugCodeModel
                    {
                        RxNormId = selected
                    });
                }
            }

            if (A4.DrugIds.Count() > 40)
            {
                ModelState.AddModelError("A4.ANYMEDS", "Only a maximum of 40 drugs can be assigned.");
            }

            BaseForm = A4; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A4); // visit needs updated form as well

            RxNormLookup = new RxNormLookupModel
            {
                VisitId = id
            };

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
