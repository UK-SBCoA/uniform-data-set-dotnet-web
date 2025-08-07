using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.Extensions;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class IndexModel : PageModel
    {
        protected readonly IMilestoneService _milestoneService;

        public MilestonesPaginatedModel Milestones { get; set; }

        public IndexModel(IMilestoneService milestoneService)
        {
            _milestoneService = milestoneService;
        }

        public async Task<IActionResult> OnGet(string legacyId, int pageSize = 20, int pageIndex = 1)
        {
            if (!string.IsNullOrWhiteSpace(legacyId))
            {
                string[] statuses = { "Complete" };

                var milestonesById = await _milestoneService.FindByLegacyId(legacyId, statuses);

                if (milestonesById != null)
                {
                    Milestones = new MilestonesPaginatedModel
                    {
                        PageSize = pageSize,
                        PageIndex = pageIndex,
                        List = milestonesById.Select(m => m.ToDomain().ToVM()).ToList(),
                        Total = await _milestoneService.Count(User.Identity.Name)
                    };
                    return Page();
                }
            }

            var milestones = await _milestoneService.List(User.Identity.Name, pageSize, pageIndex);

            Milestones = new MilestonesPaginatedModel
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                List = milestones.Select(m => m.ToVM()).ToList(),
                Total = await _milestoneService.Count(User.Identity.Name)
            };

            return Page();
        }
    }
}
