using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Visits
{
    public class IndexModel : PageModel
    {
        private readonly IVisitService _visitService;

        public VisitsPaginatedModel Visits { get; set; } = new VisitsPaginatedModel();
        public StatusFilterModel StatusFilter { get; set; } = new StatusFilterModel();

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(int pageSize = 10, int pageIndex = 1, string search = null, string[] statuses = null)
        {
            if (statuses != null)
            {
                StatusFilter.StatusList = statuses;
            }

            StatusFilter.StatusCount = StatusFilter.StatusList.Count();
            StatusFilter.StatusListString = string.Join(",", StatusFilter.StatusList);

            var visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, StatusFilter.StatusList);

            int total = await _visitService.CountByStatus(User.Identity.Name, StatusFilter.StatusList);

            Visits = visits.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
