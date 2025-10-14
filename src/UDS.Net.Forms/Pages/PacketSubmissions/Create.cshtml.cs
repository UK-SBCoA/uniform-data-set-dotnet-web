using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class CreateModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        [BindProperty]
        public PacketModel? Packet { get; set; }

        public string PageTitle
        {
            get
            {
                if (Packet != null)
                {
                    return $"Participant {Packet.Participation.LegacyId} Visit {Packet.VISITNUM} Packet Submissions";
                }
                return "";
            }
        }

        public CreateModel(IParticipationService participationService, IPacketService packetService)
        {
            _participationService = participationService;
            _packetService = packetService;
        }

        public async Task<IActionResult> OnGetPartialAsync(int? packetId)
        {
            if (packetId == null || packetId == 0)
                return NotFound();

            var packet = await _packetService.GetById(User.Identity.Name, packetId.Value);

            if (packet == null)
                return NotFound();

            var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

            if (participation == null)
                return NotFound();

            Packet = packet.ToVM();

            Packet.Participation = participation.ToVM();

            Packet.NewPacketSubmission = new PacketSubmissionModel
            {
                PacketId = packet.Id,
                SubmissionDate = DateTime.Now,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Username"
            };

            return Partial("_Create", Packet);
        }

        public async Task<IActionResult> OnPostAsync(int packetId, PacketSubmissionModel newPacketSubmission)
        {
            var packet = await _packetService.GetById(User.Identity.Name, packetId);

            if (packet == null)
                return NotFound();

            var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

            if (participation == null)
                return NotFound();

            Packet = packet.ToVM();

            Packet.Participation = participation.ToVM();

            ModelState.Clear();

            TryValidateModel(newPacketSubmission);

            if (!ModelState.IsValid)
            {
                Packet.NewPacketSubmission = newPacketSubmission;
                return Partial("_Create", Packet);
            }

            packet.AddSubmission(newPacketSubmission.ToEntity()); // this ensures the packet's state is set according to business rules

            await _packetService.Update(User.Identity.Name, packet);

            var updatedPacket = await _packetService.GetById(User.Identity.Name, packetId); // get updated packet

            Packet = updatedPacket.ToVM();
            Packet.Participation = participation.ToVM();

            return Partial("_Index", Packet);
        }
    }
}

