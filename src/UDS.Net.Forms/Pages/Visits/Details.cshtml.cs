using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.Enums;

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
        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnPostResolveErrorAsync(int errorId, int Id)
        {
            var username = User.Identity?.Name ?? "unknown";
            var packet = await _packetService.GetById(username, Id);

            var submission = packet.Submissions.FirstOrDefault(sub => sub.Errors.Any(e => e.Id == errorId));
            if (submission == null)
                return NotFound("Submission not found.");

            var error = submission.Errors.FirstOrDefault(e => e.Id == errorId);
            if (error == null)
                return NotFound("Error not found.");

            error.Resolve(username);
            await _packetService.UpdatePacketSubmissionErrors(username, packet, submission.Id, submission.Errors.ToList());

            bool allResolved = packet.Submissions.All(s =>
                s.Errors.All(e => e.Status == PacketSubmissionErrorStatus.Resolved || e.Status == PacketSubmissionErrorStatus.Ignored));


            if (allResolved)
            {
                packet.UpdateStatus(Services.Enums.PacketStatus.Pending);
                await _packetService.Update(username, packet);
                return RedirectToPage();
            }

            await this.OnGet(Id);

            Response.ContentType = "text/vnd.turbo-stream.html";
            return new PartialViewResult
            {
                ViewName = "_ResolveErrorResponse",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<VisitModel>(
                    new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                    ModelState)
                {
                    Model = this.Visit
                },
                TempData = TempData,
                ContentType = "text/vnd.turbo-stream.html"
            };
        }

        public async Task<IActionResult> OnPostIgnoreErrorAsync(int errorId, int Id)
        {
            var username = User.Identity?.Name ?? "unknown";
            var packet = await _packetService.GetById(username, Id);

            var submission = packet.Submissions.FirstOrDefault(sub => sub.Errors.Any(e => e.Id == errorId));
            if (submission == null)
                return NotFound("Submission not found.");

            var error = submission.Errors.FirstOrDefault(e => e.Id == errorId);
            if (error == null)
                return NotFound("Error not found.");

            error.Ignore(username);

            await _packetService.UpdatePacketSubmissionErrors(username, packet, submission.Id, submission.Errors.ToList());

            bool allResolved = packet.Submissions.All(s =>
                s.Errors.All(e => e.Status == PacketSubmissionErrorStatus.Resolved || e.Status == PacketSubmissionErrorStatus.Ignored));


            if (allResolved)
            {
                packet.UpdateStatus(Services.Enums.PacketStatus.Pending);
                await _packetService.Update(username, packet);
                return RedirectToPage();
            }

            await this.OnGet(Id);

            Response.ContentType = "text/vnd.turbo-stream.html";
            return new PartialViewResult
            {
                ViewName = "_ResolveErrorResponse",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<VisitModel>(
                    new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                    ModelState)
                {
                    Model = this.Visit
                },
                TempData = TempData,
                ContentType = "text/vnd.turbo-stream.html"
            };
        }

        public async Task<IActionResult> OnPostResolveAllErrorsAsync()
        {
            var username = User.Identity?.Name ?? "unknown";
            var packet = await _packetService.GetById(username, Id);

            if (packet == null || packet.Submissions == null)
                return NotFound("Packet or submissions not found.");

            foreach (var submission in packet.Submissions)
            {
                var errorsToResolve = submission.Errors
                    .Where(e => e.Status == PacketSubmissionErrorStatus.Pending)
                    .ToList();

                foreach (var error in errorsToResolve)
                {
                    error.Resolve(username);
                }

                if (errorsToResolve.Any())
                {
                    await _packetService.UpdatePacketSubmissionErrors(username, packet, submission.Id, submission.Errors.ToList());
                }
            }

            packet.UpdateStatus(Services.Enums.PacketStatus.Pending);
            await _packetService.Update(username, packet);

            return RedirectToPage();
        }

    }
}
