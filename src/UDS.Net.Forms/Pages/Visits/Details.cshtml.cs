using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Visits
{
    public class DetailsModel : VisitPageModel
    {
        private readonly IPacketService _packetService;

        public DetailsModel(IVisitService visitService, IParticipationService participationService, IPacketService packetService)
: base(visitService, participationService)
        {
            _packetService = packetService;
        }


        [BindProperty]
        public int ErrorId { get; set; }

        public async Task<IActionResult> OnPostResolveErrorAsync(int errorId, int Id)
        {
            var username = User.Identity?.Name ?? "unknown";

            var packet = await _packetService.GetById(username, Visit.Id);

            var submission = packet.Submissions.FirstOrDefault(sub => sub.Errors.Any(e => e.Id == errorId));
            if (submission == null)
                return NotFound("Submission not found.");

            var error = submission.Errors.FirstOrDefault(e => e.Id == errorId);
            if (error == null)
                return NotFound("Error not found.");

            error.Resolve(username, username);

            await _packetService.UpdatePacketSubmissionErrors(username, packet, submission.Id, submission.Errors.ToList());

            await this.OnGet(Id);

            return Partial("_ErrorDisplayPartial", this);
        }

    }
}
