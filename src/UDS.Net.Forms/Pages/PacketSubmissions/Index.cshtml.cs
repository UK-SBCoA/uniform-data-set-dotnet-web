using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class IndexModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        protected readonly IPacketSubmissionService _packetSubmissionService;

        public VisitModel Visit { get; set; }

        public PacketSubmissionsModel Submissions { get; set; }

        public string PageTitle
        {
            get
            {
                if (Visit != null)
                {
                    return $"Participant {Visit.Participation.LegacyId} Visit {Visit.VISITNUM} Packet Submissions";
                }
                return "";
            }
        }

        public IndexModel(IVisitService visitService, IParticipationService participationService, IPacketSubmissionService packetSubmissionService) : base()
        {
            _visitService = visitService;
            _participationService = participationService;
            _packetSubmissionService = packetSubmissionService;
        }

        public async Task<IActionResult> OnGetAsync(int? visitId = null, int pageSize = 10, int pageIndex = 1)
        {
            if (visitId.HasValue)
            {
                var visit = await _visitService.GetByIdWithSubmissions(User.Identity.Name, visitId.Value);

                if (visit == null)
                    return NotFound();

                var participation = await _participationService.GetById("", visit.ParticipationId);

                if (participation == null)
                    return NotFound();

                Visit = visit.ToVM();

                Visit.Participation = participation.ToVM();

                Submissions = visit.Submissions.ToVM();
            }
            else
            {
                // if there is no visit id, get all packet submissions paginated
                var packetSubmissions = await _packetSubmissionService.List(User.Identity.Name, pageSize, pageIndex);

                Submissions = packetSubmissions.ToVM();
            }

            return Page();
        }
    }
}

