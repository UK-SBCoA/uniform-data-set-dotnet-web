using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Services.DomainModels.Submission;
namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class EditModel : PageModel
    {
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
            //Return a model for use in partial
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

