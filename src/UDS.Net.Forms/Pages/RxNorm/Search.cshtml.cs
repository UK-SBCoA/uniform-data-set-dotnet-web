using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rxNorm.Net.Api.Wrapper;
using UDS.Net.Forms.Models;

namespace UDS.Net.Forms.Pages.RxNorm
{
    public class SearchModel : PageModel
    {
        protected readonly IRxNormClient _rxNormClient;

        [BindProperty]
        public RxNormLookupModel RxNormLookup { get; set; } = default!;

        public SearchModel(IRxNormClient rxNormClient)
        {
            _rxNormClient = rxNormClient;
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

            var results = await _rxNormClient.SearchDisplayTermsAsync(RxNormLookup.SearchTerm);

            if (results != null)
            {
                RxNormLookup.ResultsCount = results.Count();
                if (RxNormLookup.ResultsCount > 0)
                    RxNormLookup.SearchResults = results.ToList();
                else
                {
                    ModelState.AddModelError("RxNormLookup.SearchTerm", "No results found.");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("RxNormLookup.SearchTerm", "Trouble accessing RxNorm web api. Please use RxNav: https://lhncbc.nlm.nih.gov/RxNav/ to find RxCUI and submit ticket to DMS to update packet.");
                return Page();
            }
            return RedirectToPage("/RxNorm/Select", new { Id = RxNormLookup.Id, SearchTerm = RxNormLookup.SearchTerm });
        }
    }
}
