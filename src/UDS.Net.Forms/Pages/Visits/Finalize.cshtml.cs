using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Pages.Visits
{
    public class FinalizeModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;
        protected readonly IVisitService _visitService;

        [BindProperty]
        public PacketModel? Packet { get; set; }

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

        public FinalizeModel(IVisitService visitService, IPacketService packetService, IParticipationService participationService)
        {
            // we need the full packet
            // and some previous visits
            // and the ability to edit the visit status

            _visitService = visitService;
            _packetService = packetService;
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, id.Value);

            if (packet == null)
                return NotFound();


            var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

            if (participation == null)
                return NotFound();

            Packet = packet.ToVM();

            var a1 = Packet.Forms.Where(f => f.Kind == "A1").FirstOrDefault();

            Packet.Participation = participation.ToVM();

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, id);
            var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

            Packet = packet.ToVM();
            Packet.Participation = participation.ToVM();

            var p = Packet.ToEntity();
            p.TryValidate();

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

        // Called when page loads
        [ValidateAntiForgeryToken]
        public IEnumerable<VisitValidationResult> _Validate(int id)
        {
            var packet = Packet.ToEntity();

            packet.TryValidate();

            // TODO add a service method to get the previous packet

            if (!packet.IsValid)
            {
                var list = packet.GetModelErrors();
                foreach (var item in list)
                {
                    yield return item;
                }
            }

            yield break;
        }
    }
}
