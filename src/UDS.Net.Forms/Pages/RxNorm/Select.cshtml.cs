using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                SearchTerm = searchTerm
            };

            if (String.IsNullOrWhiteSpace(searchTerm))
                return RedirectToPage("/RxNorm/Search", new { Id = id });

            var results = await _lookupService.LookupRxNormApproximateMatches(searchTerm);

            // WORKAROUND simplify results (rx norm has duplicate names)
            foreach (var result in results)
            {
                if (!RxNormLookup.SearchResults.Where(s => s.Key == result.Name).Any())
                    RxNormLookup.SearchResults.Add(result.Name, result.RxCUI);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id, string rxCUI)
        {
            if (!String.IsNullOrWhiteSpace(rxCUI))
            {
                var visit = await _visitService.GetByIdWithForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", id, "A4");
                if (visit != null)
                {
                    var form = visit.Forms.FirstOrDefault(f => f.Kind == "A4");
                    if (form != null)
                    {
                        var fields = (A4GFormFields)form.Fields;
                        if (fields != null)
                        {
                            if (!fields.A4Ds.Where(a => a.RxNormId == rxCUI).Any())
                            {
                                fields.ANYMEDS = 1;
                                fields.A4Ds.Add(new A4DFormFields
                                {
                                    RxNormId = rxCUI,
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = User.Identity.Name
                                });
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
