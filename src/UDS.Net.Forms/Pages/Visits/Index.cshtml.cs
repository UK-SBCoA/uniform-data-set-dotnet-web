using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty]
        public List<SelectListItem> StatusList { get; set; } = new List<SelectListItem>();

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;

            // sets list of selectitems
            foreach (var status in Enum.GetValues(typeof(PacketStatus)))
            {
                StatusList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = status.ToString(),
                    Value = status.ToString()
                });
            }

        }

        public async Task<IActionResult> OnGetAsync(int pageSize = 10, int pageIndex = 1, string search = null, string[]? statuses = null)
        {
            //if filter was not previously used, redirect to set query parameters for previous/next buttons partial
            if (statuses == null)
            {
                return RedirectToPage("Index", new { statuses = new string[] { "Pending", "Frozen" } });
            }

            //previous and next buttons will return a single comma delimeted string item in array, seperate and split into statuses
            if (statuses.Count() == 1)
            {
                statuses = statuses[0].Split(',');
            }

            for (var i = 0; i < StatusList.Count(); i++)
            {
                foreach (var status in statuses)
                {
                    if (StatusList[i].Text == status)
                    {
                        StatusList[i].Selected = true;
                    }
                }

            }

            var selected = StatusList.Where(s => s.Selected == true).Select(s => s.Value).ToArray();

            var visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, selected);

            int total = await _visitService.CountByStatus(User.Identity.Name, selected);

            Visits = visits.ToVM(pageSize, pageIndex, total, search, selected);

            return Page();
        }
    }
}
