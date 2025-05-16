using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Services.DomainModels.Submission;
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
            EditModel editModelData = new EditModel
            {
                PacketSubmissionId = packetSubmissionId,
                PacketId = packetId,
                LegacyId = legacyId,
                VisitNum = visitNum,
            };

            return Partial("_Edit", editModelData);
        }
    }
}

