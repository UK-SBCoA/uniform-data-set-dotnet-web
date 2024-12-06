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
        private readonly IFilterService _filterService;

        public VisitsPaginatedModel Visits { get; set; } = new VisitsPaginatedModel();

        //Initialize Filter model with a string array of items
        public FilterModel Filter = new FilterModel(Enum.GetValues(typeof(PacketStatus)));

        public IndexModel(IVisitService visitService, IFilterService filterService)
        {
            _visitService = visitService;
            _filterService = filterService;
        }

        public async Task<IActionResult> OnGetAsync(string[] filter, int pageSize = 10, int pageIndex = 1, string search = null)
        {
            //Modify filter property with filter service
            Filter = _filterService.SetFilterData(filter, Filter.ToDomain()).ToVM();

            var visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, Filter.SelectedItems.ToArray());

            int total = await _visitService.CountByStatus(User.Identity.Name, Filter.SelectedItems.ToArray());

            Visits = visits.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
