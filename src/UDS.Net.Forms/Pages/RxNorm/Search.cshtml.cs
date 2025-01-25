using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.RxNorm
{
    public class SearchModel : PageModel
    {
        protected readonly ILookupService _lookupService;

        [BindProperty]
        public RxNormLookupModel RxNormLookup { get; set; } = default!;

        public SearchModel(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            RxNormLookup = new RxNormLookupModel();
            if (id.HasValue)
                RxNormLookup.Id = id.Value;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (String.IsNullOrWhiteSpace(RxNormLookup.SearchTerm))
            {
                ModelState.AddModelError("RxNormLookup.SearchTerm", "Must include a search term.");
                return Page();
            }

            try
            {
                var results = await _lookupService.LookupRxNormApproximateMatches(RxNormLookup.SearchTerm);

                var count = results.Where(t => t.Name.ToLower().Contains(RxNormLookup.SearchTerm.ToLower())).Count();

                if (count > 0)
                {
                    return RedirectToPage("/RxNorm/Select", new { Id = RxNormLookup.Id, SearchTerm = RxNormLookup.SearchTerm });
                }
                else
                {
                    ModelState.AddModelError("RxNormLookup.SearchTerm", "No results found.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RxNormLookup.SearchTerm", "Trouble accessing RxNorm web api. Please use RxNav: https://lhncbc.nlm.nih.gov/RxNav/ to find RxCUI and submit ticket to DMS to update packet.");
                return Page();
            }
        }
    }
}
