using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class IndexModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IPacketSubmissionService _packetSubmissionService;

        [BindProperty]
        public VisitModel Visit { get; set; }

        [BindProperty]
        public List<PacketSubmissionModel> Submissions { get; set; }

        public string PageTitle
        {
            get
            {
                if (Visit != null)
                {
                    return $"Participant {Visit.Participation.LegacyId} Visit {Visit.VISITNUM} Packet Submissions";
                }
                return "";
            }
        }

        public IndexModel(IVisitService visitService) : base()
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGetAsync(int? visitId = null, int pageSize = 10, int pageIndex = 1)
        {
            if (visitId.HasValue)
            {
                var visit = await _visitService.GetById(User.Identity.Name, visitId.Value);

                Visit = visit.ToVM();
            }
            else
            {
                var packetSubmissions = await _packetSubmissionService.List(User.Identity.Name, pageSize, pageIndex);

                //Submissions = packetSubmissions.Select(p => p.ToVM()).List();
            }

            return Page();
        }
    }
}

