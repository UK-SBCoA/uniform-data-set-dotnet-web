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

            Isvalid(Milestone);

            if (ModelState.IsValid)
            {
                //TODO sending participationId from page model for now, I think we want to send the Id from visit/participation data?
                //the api checks to make sure participationId and milestone.ToEntity() participationId are the same
                await _participationService.UpdateMilestone(Milestone.FormId, Milestone.FormId, Milestone.ToEntity());

                return RedirectToPage("/Participations/Details", new { Id = Milestone.ParticipationId });
            }

            return Page();
        }
    }
}
