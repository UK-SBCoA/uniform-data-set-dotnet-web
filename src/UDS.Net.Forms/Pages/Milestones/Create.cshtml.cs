using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;


namespace UDS.Net.Forms.Pages.Milestones
{
    public class CreateModel : MilestonePageModel
    {
        public CreateModel(IParticipationService participationService) : base(participationService)
        {
        }

        public async Task<IActionResult> OnGet(int participationId)
        {
            MilestoneModel newMilstone = new MilestoneModel()
            {
                ParticipationId = participationId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity!.IsAuthenticated ? User.Identity.Name : "Username",
                IsDeleted = false
            };

            Milestone = newMilstone;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Milestone == null)
            {
                return Page();
            }

            IsValid(Milestone);

            if (ModelState.IsValid)
            {
                await _participationService.AddMilestone(Milestone.ParticipationId, Milestone.ToEntity());

                return RedirectToPage("/Participations/Details", new { Id = Milestone.ParticipationId });
            }

            return Page();
        }
    }
}
