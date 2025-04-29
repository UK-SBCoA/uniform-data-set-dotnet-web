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

        [BindProperty]
        public int PacketSubmissionId { get; set; }
        [BindProperty]
        public int PacketId { get; set; }
        [BindProperty]
        public int? ErrorCount { get; set; }

        public PacketModel? Packet { get; set; }

        public EditModel(IParticipationService participationService, IPacketService packetService)
        {
            _participationService = participationService;
            _packetService = packetService;
        }

        // In the get we need to grab all the packet data because packet.update is how the submissions is created/modified. Packet submissions are referenced as a child of packet in the application

        //packetSubmissionId will be used to target and modify the individual packet submission in the post route
        public IActionResult OnGetPartialAsync(int packetSubmissionId, int packetId)
        {
            PacketSubmissionId = packetSubmissionId;
            PacketId = packetId;

            return Partial("_Edit");
        }

        public async Task<IActionResult> OnPostAsync()
        {

            // NOTE: need to modify and save data that was updated from existing packet. Currently, converting to page model Packet is losing data, but existing packet isn't the approppraite type for Update()

            Packet packetFound = await _packetService.GetById(User.Identity.Name, PacketId);

            // Update status to failed error checks if error count is saved
            if (packetFound.TryUpdateStatus(PacketStatus.FailedErrorChecks))
                packetFound.UpdateStatus(PacketStatus.FailedErrorChecks);

            //// when a submission is added, the overall packet state needs to be changed as well
            //if (TryUpdateStatus(PacketStatus.Submitted))
            //    UpdateStatus(PacketStatus.Submitted);

            if (packetFound == null)
                return NotFound();

            var participation = await _participationService.GetById(User.Identity.Name, packetFound.ParticipationId);

            if (participation == null)
                return NotFound();


            // Modify packet submission from list by packet submission Id
            PacketSubmission packetToEdit = packetFound.Submissions.Where(p => p.Id == PacketSubmissionId).FirstOrDefault();

            if (packetToEdit == null)
                return NotFound();

            // get index of packet submission to edit
            int packetSubmissionEditIndex = packetFound.Submissions.IndexOf(packetToEdit);

            packetFound.Submissions[packetSubmissionEditIndex].ErrorCount = ErrorCount;

            // Don't validate for now

            //ModelState.Clear();

            //TryValidateModel(newPacketSubmission);

            //if (!ModelState.IsValid)
            //{
            //    Packet.NewPacketSubmission = newPacketSubmission;
            //    return Partial("_Create", Packet);
            //}

            //packet.AddSubmission(newPacketSubmission.ToEntity()); // this ensures the packet's state is set according to business rules

            await _packetService.Update(User.Identity.Name, packetFound);

            //var updatedPacket = await _packetService.GetById(User.Identity.Name, PacketId); // get updated packet

            Packet = packetFound.ToVM();
            Packet.Participation = participation.ToVM();

            return Partial("_Index", Packet);
        }
    }
}

