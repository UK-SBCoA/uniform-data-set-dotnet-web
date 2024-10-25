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

        public VisitsPaginatedModel Visits { get; set; } = new VisitsPaginatedModel();

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(int pageSize = 10, int pageIndex = 1, string search = "")
        {
            var visits = await _visitService.List(User.Identity.Name, pageSize, pageIndex);

            int total = await _visitService.Count(User.Identity.Name);

            Visits = visits.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }

    }
}
