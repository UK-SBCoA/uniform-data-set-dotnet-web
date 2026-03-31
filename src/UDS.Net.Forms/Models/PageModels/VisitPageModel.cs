using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Services;

namespace UDS.Net.Forms.Models
{
    public class VisitPageModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        [BindProperty]
        public VisitModel? Visit { get; set; }

        [BindProperty]
        public PacketSubmissionModel? PacketSubmission { get; set; }

        public string PageTitle
        {
            get
            {
                if (Visit != null)
                {
                    return $"Participant {Visit.Participation.LegacyId} Visit {Visit.VISITNUM} {Visit.PACKET.GetDescription()}";
                }
                return "";
            }
        }

        public VisitPageModel(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base()
        {
            _visitService = visitService;
            _participationService = participationService;
            _packetService = packetService;
        }

        public virtual async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var visit = await _visitService.GetById(User.Identity.Name, id.Value);

            if (visit == null)
                return NotFound();

            var participation = await _participationService.GetById(User.Identity.Name, visit.ParticipationId);

            if (participation == null)
                return NotFound();

            var packet = await _packetService.GetById(User.Identity.Name, id.Value);

            var packetSubmission = packet.Submissions.Where(p => p.PacketId == visit.Id).FirstOrDefault();

            if (packetSubmission != null)
            {
                PacketSubmission = packetSubmission.ToVM();
            }
            Visit = visit.ToVM();
            Visit.Participation = participation.ToVM();

            // Re-order forms
            if (Visit.Forms != null)
            {
                // Sort forms
                var ordering = await _visitService.GetFormOrder(User.Identity.Name, id.Value);
                List<FormModel> forms = new List<FormModel>();
                foreach (var kind in ordering)
                {
                    var form = Visit.Forms.Where(f => f.Kind == kind).FirstOrDefault();
                    if (form != null)
                        forms.Add(form);
                }
                Visit.Forms = forms;
            }

            return Page();
        }
    }
}

