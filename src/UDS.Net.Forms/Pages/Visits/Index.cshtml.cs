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

        //Initialize Filter model with a string array of items
        public FilterModel Filter = new FilterModel(Enum.GetValues(typeof(PacketStatus)));

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(string[] filter, int pageSize = 10, int pageIndex = 1, string search = null)
        {
            //Modify filter property with filter service
            Filter = new FilterModel(Filter.FilterList, filter.ToList());

            var visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, Filter.SelectedItems.ToArray());

            int total = await _visitService.CountByStatus(User.Identity.Name, Filter.SelectedItems.ToArray());

            Visits = visits.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
