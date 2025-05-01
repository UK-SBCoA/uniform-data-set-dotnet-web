using System;
using System.Data;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class EditModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        public EditModel(IParticipationService participationService, IPacketService packetService)
        {
            _participationService = participationService;
            _packetService = packetService;
        }

        public IActionResult OnGetPartial(int packetSubmissionId, int packetId)
        {
            PacketSubmissionModel PacketSubmission = new PacketSubmissionModel
            {
                Id = packetSubmissionId,
                PacketId = packetId
            };

            return Partial("_Edit", PacketSubmission);
        }

        public async Task<IActionResult> OnPostAsync(PacketSubmissionModel packetSubmission)
        {
            Packet packetFound = await _packetService.GetById(User.Identity.Name, packetSubmission.PacketId);

            if (packetFound == null)
                return NotFound("No packet found when submitting a packet submission error count");

            // Update status to failed error checks when error count is saved
            if (packetFound.TryUpdateStatus(PacketStatus.FailedErrorChecks))
                packetFound.UpdateStatus(PacketStatus.FailedErrorChecks);

            var packetFoundParticipation = await _participationService.GetById(User.Identity.Name, packetFound.ParticipationId);

            if (packetFoundParticipation == null)
                return NotFound("No participation found within the packet receiving the submission error count update");

            Packet updatedPacket = await _packetService.UpdatePacketSubmissionErrorCount(User.Identity.Name, packetFound, (int)packetSubmission.ErrorCount, packetSubmission.Id);

            // Create a packetModel to return to the index
            PacketModel packet = updatedPacket.ToVM();
            packet.Participation = packetFoundParticipation.ToVM();

            return Partial("_Index", packet);
        }
    }
}

