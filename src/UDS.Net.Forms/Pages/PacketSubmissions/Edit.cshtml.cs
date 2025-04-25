using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class EditModel : PageModel
    {
        protected readonly IPacketService _packetService;
        
        PacketSubmissionModel packet { get; set; }

        public EditModel(IPacketService packetService)
        {
            _packetService = packetService;
        }

        public IActionResult OnGetPartial(int id)
        {
            packet = new PacketSubmissionModel
            {
                PacketId = id
            };

            return Partial("_Edit", packet);
        }

        //public async Task<IActionResult> OnPostAsync(int packetId, PacketSubmissionModel newPacketSubmission)
        //{
        //    var packet = await _packetService.GetById(User.Identity.Name, packetId);

        //    if (packet == null)
        //        return NotFound();

        //    var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

        //    if (participation == null)
        //        return NotFound();

        //    Packet = packet.ToVM();

        //    Packet.Participation = participation.ToVM();

        //    ModelState.Clear();

        //    TryValidateModel(newPacketSubmission);

        //    if (!ModelState.IsValid)
        //    {
        //        Packet.NewPacketSubmission = newPacketSubmission;
        //        return Partial("_Create", Packet);
        //    }

        //    packet.AddSubmission(newPacketSubmission.ToEntity()); // this ensures the packet's state is set according to business rules

        //    await _packetService.Update(User.Identity.Name, packet);

        //    var updatedPacket = await _packetService.GetById(User.Identity.Name, packetId); // get updated packet

        //    Packet = updatedPacket.ToVM();
        //    Packet.Participation = participation.ToVM();

        //    return Partial("_Index", Packet);
        //}
    }
}

