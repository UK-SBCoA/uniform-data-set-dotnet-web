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

        [BindProperty]
        public VisitModel? Visit { get; set; }

        public Participation? Participation { get; set; }

        public List<SelectListItem> VisitKindOptions { get; set; } = new List<SelectListItem>();

        public CreateModel(IVisitService visitService, IParticipationService participationService)
        {
            _visitService = visitService;
            _participationService = participationService;
        }

        private void PopulateVisitKindOptions(int nextVisitNumber, int udsv4VisitCount)
        {
            // the visit number could be > 1, but the first uds version 4 visit will always be I
            if (udsv4VisitCount == 0)
            {
                // is the participant new or existing?
                if (nextVisitNumber == 1)
                    VisitKindOptions.Add(new SelectListItem { Value = PacketKind.I.ToString(), Text = PacketKind.I.ToString(), Selected = true });
                else
                    VisitKindOptions.Add(new SelectListItem { Value = PacketKind.I4.ToString(), Text = PacketKind.I4.ToString(), Selected = true });

            }
            else
            {
                VisitKindOptions.Add(new SelectListItem { Value = PacketKind.F.ToString(), Text = PacketKind.F.ToString(), Selected = true });
            }
        }

        public async Task<IActionResult> OnGetAsync(int? participationId)
        {
            if (!participationId.HasValue)
                return NotFound();

            Participation = await _participationService.GetById(User.Identity.Name, participationId.Value);

            var shortenedInitials = "UNK";
            if (User.Identity.Name.Length > 3)
                shortenedInitials = User.Identity.Name.Substring(0, 3);
            else
                shortenedInitials = User.Identity.Name;

            Visit = new VisitModel
            {
                ParticipationId = participationId.Value,
                FORMVER = "4",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Unknown",
                VISIT_DATE = DateTime.Now,
                INITIALS = shortenedInitials.ToUpper(),
                VISITNUM = await _visitService.GetNextVisitNumber(User.Identity.Name, participationId.Value)
            };

            int countOfVersion4Visits = await _visitService.GetVisitCountByVersion(User.Identity.Name, participationId.Value, "4");

            PopulateVisitKindOptions(Visit.VISITNUM, countOfVersion4Visits);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int participationId)
        {
            if (!ModelState.IsValid)
            {
                Participation = await _participationService.GetById(User.Identity.Name, participationId);

                PopulateVisitKindOptions(Visit.VISITNUM, Visit.VISITNUM);

                return Page();
            }

            int newId = 0;
            if (Visit != null)
            {
                Visit.Forms = new List<FormModel>(); // initialize form set
                var newVisit = await _visitService.Add(User.Identity?.Name, Visit.ToEntity());
                newId = newVisit.Id;
            }

            return RedirectToPage("./Details", new { Id = newId });
        }
    }
}
