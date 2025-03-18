using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class IndexModel : PageModel
    {
        protected readonly IMilestoneService _milestoneService;

        public IndexModel(IMilestoneService milestoneService)
        {
            _milestoneService = milestoneService;
        }

        public async Task<IActionResult> OnGet()
        {
            var milestonesPaginated = await _milestoneService.List(User.Identity.Name);
            return Page();
        }
    }
}
