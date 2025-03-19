using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class EditModel : MilestonePageModel
    {
        public EditModel(IMilestoneService milestoneService, IParticipationService participationService) : base(milestoneService, participationService)
        {
        }

        public async Task<IActionResult> OnGet(int id)
        {
            return await base.OnGetAsync(id, "", User.Identity.Name);
        }
    }
}
