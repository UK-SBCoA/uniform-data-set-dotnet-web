using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class EditModel : PageModel
    {
        //TODO: find out why model binding is not working with this property in the view
        //[BindProperty]
        //public PacketSubmissionModel PacketSubmission { get; set; } = new PacketSubmissionModel();

        [BindProperty]
        public int PacketSubmissionId { get; set; }

        [BindProperty]
        public int PacketId { get; set; }

        [BindProperty]
        public int LegacyId { get; set; }

        [BindProperty]
        public int PacketStatus { get; set; }

        [BindProperty]
        public int VisitNum { get; set; }

        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }

        public IActionResult OnGetPartial(int packetSubmissionId, int packetId, int legacyId, int visitNum)
        {
            //TODO: Find out why model binding to view does not work with PacketSubmissions
            //PacketSubmission = new PacketSubmissionModel
            //{
            //    Id = packetSubmissionId,
            //    PacketId = packetId
            //};

            PacketSubmissionId = packetSubmissionId;
            PacketId = packetId;
            LegacyId = legacyId;
            VisitNum = visitNum;

            return Partial("_Edit");
        }

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> OnPostAsync(PacketSubmissionModel packetSubmission, [FromForm] int packetStatus)
        //{
        //    Packet existingPacket = await GetPacketData(packetSubmission.PacketId);

        //    if (existingPacket != null)
        //    {
        //        // Update packet status using index of packetStatus enum index
        //        if (existingPacket.TryUpdateStatus((PacketStatus)packetStatus))
        //        {
        //            existingPacket.UpdateStatus((PacketStatus)packetStatus);
        //        }
        //        else
        //        {
        //            return NotFound($"Unable to set packet Id ${existingPacket.Id} status to: {packetStatus}");
        //        }

        //        if (existingPacket != null)
        //        {
        //            Packet updatedPacket = await _packetService.UpdatePacketSubmissionErrorCount(User.Identity.Name, existingPacket, (int)packetSubmission.ErrorCount, packetSubmission.Id);

        //            // Create a packetModel to return to the index
        //            PacketModel updatedPacketModel = updatedPacket.ToVM();
        //            updatedPacketModel.Participation = existingPacket.Participation.ToVM();

        //            return Partial("_Index", updatedPacketModel);
        //        }

        //        // return existing packetModel on failure to update
        //        PacketModel existingPacketModel = existingPacket.ToVM();
        //        existingPacketModel.Participation = existingPacket.Participation.ToVM();

        //        return Partial("_Index", existingPacketModel);
        //    }

        //    return NotFound($"Unable to set packet Id ${packetSubmission.PacketId} status to: {(PacketStatus)packetStatus}");
        //}
    }
}

