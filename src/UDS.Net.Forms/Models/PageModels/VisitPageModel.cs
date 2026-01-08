using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Models
{
    public class VisitPageModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;

        [BindProperty]
        public VisitModel? Visit { get; set; }

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

        public VisitPageModel(IVisitService visitService, IParticipationService participationService) : base()
        {
            _visitService = visitService;
            _participationService = participationService;
        }

        public virtual async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            // TODO: Visit-level UnresolvedErrors should all map to a FormKind.
            // Currently the mapping is unreliable, visit.UnresolvedErrors are not all present on all forms of the visit.
            var visit = await _visitService.GetById(User.Identity.Name, id.Value);

            if (visit == null)
                return NotFound();

            var visitErrors = (visit.UnresolvedErrors ?? new List<PacketSubmissionError>()).ToList();
            var participation = await _participationService.GetById(User.Identity.Name, visit.ParticipationId);

            if (participation == null)
                return NotFound();

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
                    var form = Visit.Forms.FirstOrDefault(f => string.Equals(f.Kind?.Trim(), kind?.Trim(), StringComparison.OrdinalIgnoreCase));
                    if (form == null)
                        continue;

                    forms.Add(form);

                    var matchingErrors = visitErrors.Where(e => string.Equals(e.FormKind?.Trim(), form.Kind?.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

                    if (matchingErrors.Count > 0)
                    {
                        form.UnresolvedErrorCount = matchingErrors.Count;
                        form.UnresolvedErrors = matchingErrors.Select(e => e.ToVM()).ToList();
                    }
                }
                Visit.Forms = forms;
            }

            return Page();
        }
    }
}

