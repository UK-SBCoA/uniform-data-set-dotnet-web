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
    }
}

