using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Services;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace UDS.Net.Forms.Pages.Visits
{
    public class IndexModel : PageModel
    {
        private readonly IVisitService _visitService;

        public IList<VisitModel>? Visits { get; set; }

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var visits = await _visitService.List("");

            Visits = visits.Select(d => d.ToVM()).ToList();

            return Page();
        }

    }
}
