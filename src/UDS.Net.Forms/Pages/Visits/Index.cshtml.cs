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

        //Create pageModel filter property to apply values to
        public FilterModel Filter;

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(string[] filter, int pageSize = 10, int pageIndex = 1, string search = null)
        {
            //set Filter property to new filter with supplied array items and filter query
            Filter = new FilterModel(Enum.GetNames(typeof(PacketStatus)).ToList(), filter.ToList());

            var visits = await _visitService.ListByStatus(User?.Identity?.Name ?? "System", pageSize, pageIndex, Filter.SelectedItems.ToArray());

            int total = await _visitService.CountByStatus(User?.Identity?.Name ?? "System", Filter.SelectedItems.ToArray());

            Visits = visits.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
