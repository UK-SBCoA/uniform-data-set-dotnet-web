using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Participations
{
    public class DetailsModel : PageModel
    {
        private readonly IParticipationService _participationService;
        protected readonly IMilestoneService _milestoneService;

        public ParticipationModel? Participation { get; set; }

        public IEnumerable<MilestoneModel> Milestones { get; set; }

        public DetailsModel(IParticipationService participationService, IMilestoneService milestoneService)
        {
            _participationService = participationService;
            _milestoneService = milestoneService;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int visitPageSize = 10, int visitPageIndex = 1, int milestonePageSize = 10, int milestonePageIndex = 1)
        {
            if (id == null)
                return NotFound();

            var participation = await _participationService.GetById(User.Identity.Name, id.Value, true);

            if (participation == null)
                return NotFound();

            Participation = participation.ToVM();

            var milestones = await _milestoneService.List(User.Identity.Name, id.Value, milestonePageSize, milestonePageIndex);

            Milestones = milestones.ToVM();

            return Page();
        }
    }
}
