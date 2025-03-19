using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class EditModel : MilestonePageModel
    {
        public EditModel(IMilestoneService milestoneService) : base(milestoneService)
        {
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var milestoneFound = await _milestoneService.GetById(User.Identity.Name, id);

            if (milestoneFound == null)
            {
                return NotFound($"No milestone found.");
            }

            Milestone = milestoneFound.ToVM();
            Milestone.ModifiedBy = User.Identity.Name;

            return Page();
        }
    }
}
