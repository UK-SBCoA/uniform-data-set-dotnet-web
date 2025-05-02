using System;
using System.Data;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language.Extensions;
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
            Packet existingPacket = await GetPacketData(packetSubmission.PacketId);

            // Update status to failed error checks when error count is saved
            if (existingPacket.TryUpdateStatus(PacketStatus.FailedErrorChecks))
            {
                existingPacket.UpdateStatus(PacketStatus.FailedErrorChecks);

                Packet updatedPacket = await _packetService.UpdatePacketSubmissionErrorCount(User.Identity.Name, existingPacket, (int)packetSubmission.ErrorCount, packetSubmission.Id);

                // Create a packetModel to return to the index
                PacketModel updatedPacketModel = updatedPacket.ToVM();
                updatedPacketModel.Participation = existingPacket.Participation.ToVM();

                return Partial("_Index", updatedPacketModel);
            }

            // return existing packetModel on failure to update
            PacketModel existingPacketModel = existingPacket.ToVM();
            existingPacketModel.Participation = existingPacket.Participation.ToVM();

            return Partial("_Index", existingPacketModel);

        }

        public async Task<IActionResult> OnPostSuccessAsync(int packetId, int packetSubmissionId)
        {
            Packet existingPacket = await GetPacketData(packetId);

            // Update status to failed error checks when error count is saved
            if (existingPacket.TryUpdateStatus(PacketStatus.PassedErrorChecks))
            {
                existingPacket.UpdateStatus(PacketStatus.PassedErrorChecks);

                Packet updatedPacket = await _packetService.UpdatePacketSubmissionErrorCount(User.Identity.Name, existingPacket, 0, packetSubmissionId);

                // Create a packetModel to return to the index
                PacketModel updatedPacketModel = updatedPacket.ToVM();
                updatedPacketModel.Participation = existingPacket.Participation.ToVM();

                return Partial("_Index", updatedPacketModel);
            }

            // return existing packetModel on failure to update
            PacketModel existingPacketModel = existingPacket.ToVM();
            existingPacketModel.Participation = existingPacket.Participation.ToVM();

            return Partial("_Index", existingPacketModel);
        }

        private async Task<Packet> GetPacketData(int packetId)
        {
            Packet packetFound = await _packetService.GetById(User.Identity.Name, packetId);

            if (packetFound == null)
                return null;

            var packetFoundParticipation = await _participationService.GetById(User.Identity.Name, packetFound.ParticipationId);

            if (packetFoundParticipation == null)
                return null;

            packetFound.Participation = packetFoundParticipation;

            return packetFound;
        }
    }
}

