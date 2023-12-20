using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.Milestones
{
	public class EditModel : BaseModel
    {
        public EditModel(IParticipationService participationService) : base(participationService)
        {
        }

        public async Task<IActionResult> OnGet(int id, int participationId)
        {
            //TODO temporary method for getting the selected milestone for edit. Will need to create "getById" in the API
            var milestonesByParticipationId = await _participationService.GetMilestonesByParticipationId(participationId);

            if(milestonesByParticipationId.Count() < 1)
            {
                return NotFound($"No milestones found within participationId of: {participationId}");
            }

            var milestoneFound = milestonesByParticipationId.Where(m => m.Id == id).FirstOrDefault().ToVM();

            if(milestoneFound == null)
            {
                return NotFound($"Milestone with participation Id of: {participationId} was not found");
            }

            Milestone = milestoneFound;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Milestone == null)
            {
                return Page();
            }

            //TODO sending participationId from page model for now, I think we want to send the Id from visit/participation data?
            //the api checks to make sure participationId and milestone.ToEntity() participationId are the same
            await _participationService.UpdateMilestone(Milestone.FormId, Milestone.FormId, Milestone.ToEntity());

            return RedirectToPage($"/Participations/Details/{Milestone.ParticipationId}");
        }
    }
}
