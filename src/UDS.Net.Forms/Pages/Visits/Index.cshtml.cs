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

        public FilterModel Filter = new FilterModel(Enum.GetValues(typeof(PacketStatus)));

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(string[] filterItems, int pageSize = 10, int pageIndex = 1, string search = null)
        {
            if (filterItems == null || filterItems.Length == 0) throw new ArgumentNullException("filterItems array route parameter must be provided for filter");

            //previous and next buttons will return a single comma delimeted string item in array, seperate and split into filter array
            if (filterItems.Count() == 1)
            {
                filterItems = filterItems[0].Split(',');
            }

            for (var i = 0; i < Filter.FilterList.Count(); i++)
            {
                foreach (var item in filterItems)
                {
                    if (Filter.FilterList[i].Text == item)
                    {
                        Filter.FilterList[i].Selected = true;
                        Filter.SelectedItems.Add(Filter.FilterList[i].Text.ToString());
                    }
                }
            }

            var visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, Filter.SelectedItems.ToArray());

            int total = await _visitService.CountByStatus(User.Identity.Name, Filter.SelectedItems.ToArray());

            Visits = visits.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
