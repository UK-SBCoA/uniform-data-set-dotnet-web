﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Participations
{
    public class DetailsModel : PageModel
    {
        private readonly IParticipationService _participationService;

        public ParticipationModel? Participation { get; set; }

        public IEnumerable<MilestoneModel> Milestones { get; set; }

        public DetailsModel(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            var participation = await _participationService.GetById(User.Identity.Name, id.Value, true);

            if (participation == null)
                return NotFound();

            Participation = participation.ToVM();

            var milestones = await _participationService.GetMilestonesByParticipationId(id.Value);

            Milestones = milestones.ToVM();

            return Page();
        }
    }
}
