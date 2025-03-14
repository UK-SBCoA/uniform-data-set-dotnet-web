﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Pages.RxNorm
{
    public class SelectModel : PageModel
    {
        protected readonly ILookupService _lookupService;
        protected readonly IVisitService _visitService;

        public RxNormLookupModel RxNormLookup { get; set; } = default!;

        public SelectModel(ILookupService lookupService, IVisitService visitService)
        {
            _lookupService = lookupService;
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGet(int id, string searchTerm)
        {
            RxNormLookup = new RxNormLookupModel()
            {
                Id = id,
                SearchTerm = searchTerm,
                SearchResults = new Dictionary<string, string>()
            };

            if (String.IsNullOrWhiteSpace(searchTerm))
                return RedirectToPage("/RxNorm/Search", new { Id = id });

            // search local storage before querying rxNorm
            // we want to prevent as many duplicates as possible
            var search = await _lookupService.SearchDrugCodes(10, 1, RxNormLookup.SearchTerm);

            if (search.TotalResultsCount > 0 && search.DrugCodes != null && search.DrugCodes.Count > 0)
            {
                foreach (var drugCode in search.DrugCodes)
                {
                    RxNormLookup.SearchResults.Add(drugCode.DrugName, drugCode.RxNormId);
                }
            }
            else
            {
                var results = await _lookupService.LookupRxNormApproximateMatches(searchTerm);

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

            return Page();
        }

        public async Task<IActionResult> OnPost(int id, string rxCUI, string drugName)
        {
            if (!String.IsNullOrWhiteSpace(rxCUI))
            {
                A4DFormFields newDrug = new A4DFormFields()
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = User.Identity.Name
                };

                var lookup = await _lookupService.FindDrugCode(rxCUI);
                if (lookup.TotalResultsCount > 0 && lookup.DrugCodes != null && lookup.DrugCodes.Count() > 0)
                {
                    // Drug code already exists in local lookup
                    var existing = lookup.DrugCodes.FirstOrDefault();
                    newDrug.RxNormId = existing.RxNormId;
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
                    newDrug.RxNormId = added.RxNormId;
                }

                var visit = await _visitService.GetByIdWithForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", id, "A4");
                if (visit != null)
                {
                    var form = visit.Forms.FirstOrDefault(f => f.Kind == "A4");
                    if (form != null)
                    {
                        form.Status = Services.Enums.FormStatus.InProgress;
                        var fields = (A4GFormFields)form.Fields;
                        if (fields != null)
                        {
                            if (!fields.A4Ds.Where(a => a.RxNormId == rxCUI).Any())
                            {
                                fields.ANYMEDS = 1;
                                fields.A4Ds.Add(newDrug);
                                await _visitService.UpdateForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", visit, "A4");
                            }
                        }
                    }

                }
            }

            return RedirectToPage("/UDS4/A4", new { Id = id });
        }
    }
}
