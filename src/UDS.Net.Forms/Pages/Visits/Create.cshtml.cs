using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.Visits
{
    public class CreateModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IVisitService _visitService;

        public SelectList ParticipationsSelectList { get; private set; }
        public int SelectedParticipationNextVisit { get; private set; }

        [BindProperty]
        public VisitModel? Visit { get; set; }

        public CreateModel(IVisitService visitService, IParticipationService participationService)
        {
            _visitService = visitService;
            _participationService = participationService;
        }

        public async Task PopulateParticipationsDropDownList(int? selectedParticipationId)
        {
            Participation selectedParticipation = null;
            var participations = await _participationService.List("");

            if (selectedParticipationId.HasValue)
                selectedParticipation = participations.FirstOrDefault(p => p.Id == selectedParticipationId);

            ParticipationsSelectList = new SelectList(participations,
                nameof(Participation.Id),
                nameof(Participation.LegacyId),
                selectedParticipation.Id);

        }

        public async Task<IActionResult> OnGetAsync(int? participationId)
        {
            await PopulateParticipationsDropDownList(participationId);

            Visit = new VisitModel
            {
                Version = "UDS3",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Username",
                StartDateTime = DateTime.Now
            };

            if (participationId.HasValue)
                Visit.ParticipationId = participationId.Value;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? participationId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Visit != null)
            {
                Visit.Forms = new List<FormModel>(); // initialize form set
                await _visitService.Add("", Visit.ToEntity());
            }

            return RedirectToPage("./Index");
        }
    }
}
