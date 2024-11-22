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

        [BindProperty]
        public StatusFilterModel StatusFilter { get; set; } = new StatusFilterModel();

        public IndexModel(IVisitService visitService)
        {
            _visitService = visitService;

            // sets list of selectitems
            foreach (var status in Enum.GetValues(typeof(PacketStatus)))
            {
                StatusFilter.StatusList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = status.ToString(),
                    Value = status.ToString()
                });
            }

        }

        public async Task<IActionResult> OnGetAsync(int pageSize = 10, int pageIndex = 1, string search = null)
        {
            if (StatusFilter.SelectedStatusCount == 0)
            {
                foreach (var status in StatusFilter.StatusList)
                {
                    if (status.Value == PacketStatus.Pending.ToString())
                        status.Selected = true;
                    if (status.Value == PacketStatus.FailedErrorChecks.ToString())
                        status.Selected = true;
                }
            }

            var selected = StatusFilter.ToArray();

            var visits = await _visitService.ListByStatus(User.Identity.Name, pageSize, pageIndex, StatusFilter.ToArray());

            int total = await _visitService.CountByStatus(User.Identity.Name, StatusFilter.ToArray());

            Visits = visits.ToVM(pageSize, pageIndex, total, search, StatusFilter.ToArray());

            return Page();
        }
    }
}
