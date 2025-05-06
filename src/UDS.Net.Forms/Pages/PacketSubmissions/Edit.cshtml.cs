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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(PacketSubmissionModel packetSubmission, [FromForm] int packetStatus)
        {
            Packet existingPacket = await GetPacketData(packetSubmission.PacketId);

            if (existingPacket != null)
            {
                // Update packet status using index of packetStatus enum index
                if (existingPacket.TryUpdateStatus((PacketStatus)packetStatus))
                {
                    existingPacket.UpdateStatus((PacketStatus)packetStatus);
                }
                else
                {
                    return NotFound($"Unable to set packet Id ${existingPacket.Id} status to: {packetStatus}");
                }

                if (existingPacket != null)
                {
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

            return NotFound($"Unable to set packet Id ${packetSubmission.PacketId} status to: {(PacketStatus)packetStatus}");
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

