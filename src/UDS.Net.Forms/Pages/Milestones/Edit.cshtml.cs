using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class EditModel : MilestonePageModel
    {
        public EditModel(IParticipationService participationService) : base(participationService)
        {
        }

        public async Task<IActionResult> OnGet(int id, int formId)
        {
            var milestoneFound = await _participationService.GetMilestoneById(id, formId);

            if (milestoneFound == null)
            {
                return NotFound($"No milestones found within formId of: {formId}");
            }

            Milestone = milestoneFound.ToVM();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Milestone == null)
            {
                return Page();
            }

            Milestone.ModifiedBy = User.Identity.Name;

            IsValid(Milestone);

            if (ModelState.IsValid)
            {
                await _participationService.UpdateMilestone(Milestone.Id, Milestone.FormId, Milestone.ToEntity());

                return RedirectToPage("/Participations/Details", new { Id = Milestone.ParticipationId });
            }

            return Page();
        }
    }
}
