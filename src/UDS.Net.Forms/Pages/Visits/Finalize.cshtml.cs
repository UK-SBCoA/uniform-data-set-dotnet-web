using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Pages.Visits
{
    public class FinalizeModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;
        protected readonly IVisitService _visitService;
        private readonly ILookupService _lookupService;

        [BindProperty]
        public PacketModel? Packet { get; set; }

        public bool CanFinalize { get; set; }

        public string PageTitle
        {
            get
            {
                if (Packet != null)
                {
                    return $"Participant {Packet.Participation.LegacyId} Visit {Packet.VISITNUM} Packet Submission";
                }
                return "";
            }
        }
        public FinalizeModel(IVisitService visitService, IPacketService packetService, IParticipationService participationService, ILookupService lookupService)
        {
            // we need the full packet
            // and some previous visits
            // and the ability to edit the visit status

            _visitService = visitService;
            _packetService = packetService;
            _participationService = participationService;
            _lookupService = lookupService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var packet = await _packetService.GetPacketWithForms(User.Identity!.Name!, id.Value);

            if (packet == null)
                return NotFound();

            var participation = await _participationService.GetById(
                User.Identity!.Name!,
                packet.ParticipationId);

            if (participation == null)
                return NotFound();

            D1aFormFields? previousD1a = null;

            var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(
                User.Identity!.Name!,
                packet.ParticipationId,
                packet.VISITNUM - 1,
                "D1a");

            if (previousVisit != null)
            {
                previousD1a = previousVisit.Forms
                    .FirstOrDefault(f => f.Kind == "D1a")
                    ?.Fields as D1aFormFields;
            }

            Packet = packet.ToVM();
            Packet.Participation = participation.ToVM();

            CanFinalize = packet.IsFinalizable &&
                          packet.TryValidate(previousD1a);

            return Page();
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, id);
            var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

            Packet = packet.ToVM();
            Packet.Participation = participation.ToVM();

            D1aFormFields? previousD1a = null;

            var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(
                User.Identity!.Name!,
                packet.ParticipationId,
                packet.VISITNUM - 1,
                "D1a"
            );

            if (previousVisit != null)
            {
                var previousD1aForm = previousVisit.Forms
                    .FirstOrDefault(f => f.Kind == "D1a");

                if (previousD1aForm != null)
                {
                    previousD1a = previousD1aForm.Fields as D1aFormFields;
                }
            }

            var p = Packet.ToEntity();
            p.TryValidate(previousD1a);

            if (!p.IsFinalizable)
            {
                // We shouldn't reach this point, the turbo stream should already display the results
                // And reaching this point shouldn't be possible
                return Page();
            }

            if (p.TryUpdateStatus(Services.Enums.PacketStatus.Finalized))
                p.UpdateStatus(Services.Enums.PacketStatus.Finalized);

            await _visitService.PatchStatus(User.Identity.Name, p);

            return RedirectToAction("Index", "Visits", new { Filter = Services.Enums.PacketStatus.Finalized.ToString() });
        }

        public async Task<IActionResult> OnGetValidate(int id)
        {
            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, id);

            D1aFormFields? previousD1a = null;

            var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(
                User.Identity!.Name!,
                packet.ParticipationId,
                packet.VISITNUM - 1,
                "D1a"
            );

            if (previousVisit != null)
            {
                var previousD1aForm = previousVisit.Forms
                    .FirstOrDefault(f => f.Kind == "D1a");

                if (previousD1aForm != null)
                {
                    previousD1a = previousD1aForm.Fields as D1aFormFields;
                }
            }

            var errors = packet.GetModelErrors(previousD1a).ToList();

            if (errors.Any())
            {
                return Partial("_Validate", errors);
            }

            return Partial("_Validate", null);
        }

        public async Task<IActionResult> OnGetAlerts(int id)
        {
            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, id);

            var list = await packet.GetModelAlerts(_lookupService);

            return Partial("_Alerts", list);
        }
    }
}
