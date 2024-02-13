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
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.Visits
{
    public class CreateModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IVisitService _visitService;

        public SelectList ParticipationsSelectList { get; private set; }
        public int SelectedParticipationNextVisit { get; private set; } = 0;

        [BindProperty]
        public VisitModel? Visit { get; set; }

        public Participation? Participation { get; set; }

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

        public List<SelectListItem> VisitKindOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? participationId)
        {
            await PopulateParticipationsDropDownList(participationId);

            Participation = await _participationService.GetById(User.Identity.Name, participationId.Value);

            if (Participation != null)
                SelectedParticipationNextVisit = Participation.LastVisitNumber + 1;


            Visit = new VisitModel
            {
                Version = "UDS4",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Username",
                StartDateTime = DateTime.Now,
            };

            if (participationId.HasValue)
                Visit.ParticipationId = participationId.Value;

            VisitKindOptions = new List<SelectListItem>();

            if (Participation != null)
            {
                if (Participation.LastVisitNumber < 1)
                {
                    VisitKindOptions.Add(new SelectListItem { Value = VisitKind.IVP.ToString(), Text = "IVP" });
                    VisitKindOptions.Add(new SelectListItem { Value = VisitKind.TIP.ToString(), Text = "TIP" });
                }
                else if (Participation.LastVisitNumber >= 1)
                {
                    VisitKindOptions.Add(new SelectListItem { Value = VisitKind.FVP.ToString(), Text = "FVP" });
                    VisitKindOptions.Add(new SelectListItem { Value = VisitKind.TFP.ToString(), Text = "TFP" });
                }
            }

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
                await _visitService.Add(User.Identity?.Name, Visit.ToEntity());
            }

            return RedirectToPage("./Index");
        }
    }
}
