using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.Visits
{
    public class IndexModel : PageModel
    {
        private readonly IVisitService _visitService;

        public VisitsPaginatedModel Visits { get; set; } = new VisitsPaginatedModel();

        public FilterModel Filter;

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(string[] filter, DateTime? startDate, DateTime? endDate, int pageSize = 10, int pageIndex = 1, string search = null)
        {
            Filter = new FilterModel(Enum.GetNames(typeof(PacketStatus)).ToList(), filter.ToList(), startDate, endDate);

            IEnumerable<Services.DomainModels.Visit> visits;
            int total;

            bool invalidDateRange = startDate.HasValue && endDate.HasValue && endDate < startDate;
            bool hasValidDateRange = (startDate.HasValue || endDate.HasValue) && !invalidDateRange;

            if (!hasValidDateRange)
            {
                if (invalidDateRange)
                    ModelState.AddModelError(string.Empty, "End date cannot be before start date.");

                visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, Filter.SelectedItems.ToArray());
                total = await _visitService.CountByStatus(User.Identity.Name, Filter.SelectedItems.ToArray());
            }
            else
            {
                if (endDate.HasValue)
                {
                    endDate = endDate.Value.Date.AddDays(1).AddTicks(-1);
                }

                visits = await _visitService.ListByDateRangeAndStatus(User.Identity.Name, Filter.SelectedItems.ToArray(), startDate, endDate, pageSize, pageIndex);
                total = await _visitService.CountByDateRangeAndStatus(User.Identity.Name, Filter.SelectedItems.ToArray(), startDate, endDate);
            }

            Visits = visits.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
