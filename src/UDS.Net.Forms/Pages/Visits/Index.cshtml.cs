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

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(int pageSize = 10, int pageIndex = 1, string search = null, string statuses = null)
        {
            if (statuses != null)
            {
                Visits.StatusFilter.StatusList = statuses.Split(",");
            }

            var visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, Visits.StatusFilter.StatusList);

            int total = await _visitService.CountByStatus(User.Identity.Name, Visits.StatusFilter.StatusList);

            Visits = visits.ToVM(pageSize, pageIndex, total, search, Visits.StatusFilter.StatusList);

            return Page();
        }
    }
}
