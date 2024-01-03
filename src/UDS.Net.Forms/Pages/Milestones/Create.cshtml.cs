using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class CreateModel : BaseModel
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
            if(Milestone == null)
            {
                return Page();
            }

            //TODO sending participationId from page model for now, I think we want to send the Id from visit/participation data?
            //the api checks to make sure participationId and milestone.ToEntity() participationId are the same
            await _participationService.AddMilestone(User.Identity?.Name, Milestone.ParticipationId, Milestone.ToEntity());

            return RedirectToPage("/Participations/Details", new { Id = Milestone.ParticipationId });
        }
    }
}
