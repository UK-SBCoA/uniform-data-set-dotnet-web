using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.Pages.UDS4;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.PageModels
{
    public class FormPageModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        protected string _formKind { get; set; }

        [BindProperty]
        public VisitModel Visit { get; set; } = default!;

        public FormModel BaseForm { get; set; }

        public string PageTitle
        {
            get
            {
                if (Visit != null)
                {
                    if (Visit.Participation != null)
                        return $"Participant {Visit.Participation.LegacyId} Visit {Visit.VISITNUM} {Visit.PACKET.GetDescription()}";
                    else
                        return $"Participant {Visit.ParticipationId} Visit {Visit.VISITNUM} {Visit.PACKET.GetDescription()}";
                }
                return "";
            }
        }

        public FormPageModel(IVisitService visitService, IParticipationService participationService, IPacketService packetService, string formKind) : base()
        {
            _visitService = visitService;
            _participationService = participationService;
            _formKind = formKind;
            _packetService = packetService;
        }

        protected async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _formKind == null)
                return NotFound();

            var visit = await _visitService.GetByIdWithForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", id.Value, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            var participation = await _participationService.GetById(User.Identity.Name, visit.ParticipationId, false);

            if (participation == null)
                return NotFound();

            Visit.Participation = participation.ToVM();

            var form = visit.Forms.Where(f => f.Kind == _formKind).FirstOrDefault();

            BaseForm = form.ToVM(); // this will have the subclass

            if (String.IsNullOrWhiteSpace(BaseForm.INITIALS))
            {
                var shortenedInitials = Visit.INITIALS;
                if (User.Identity.Name.Length > 3)
                    shortenedInitials = User.Identity.Name.Substring(0, 3);
                else
                    shortenedInitials = User.Identity.Name;

                BaseForm.INITIALS = shortenedInitials;
            }

            // Set next form kind for better UX between forms
            BaseForm.NextFormKind = await _visitService.GetNextFormKind(User.Identity.Name, id.Value, _formKind);

            /*if (form.UnresolvedErrors != null && form.UnresolvedErrors.Any())
            {
                var unresolvedErrors = form.UnresolvedErrors
                    .Where(e => !e.IsDeleted && string.IsNullOrEmpty(e.ResolvedBy));

                AddErrorsToModelState(BaseForm, unresolvedErrors);
            }*/

            return Page();
        }

        [ValidateAntiForgeryToken]
        protected async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm.ModifiedBy = User.Identity?.Name;

            var visit = Visit.ToEntity();

            if (BaseForm.Status == FormStatus.Finalized)
            {
                /*
                 * ValidationContext describes any member on which validation is performed. It also enables
                 * custom validation to be added through any service that implements the IServiceProvider
                 * interface.
                 */
                Dictionary<object, object?> visitContext = new Dictionary<object, object?>
                {
                    { "Visit", this.Visit }
                };

                foreach (var result in BaseForm.Validate(new ValidationContext(BaseForm, null, visitContext)))
                {
                    var memberName = result.MemberNames.FirstOrDefault();
                    ModelState.AddModelError($"{BaseForm.GetType().Name}.{memberName}", result.ErrorMessage);
                }
            }

            if (!visit.TryUpdateStatus(PacketStatus.Pending))
            {
                ModelState.AddModelError($"{BaseForm.GetType().Name}.Status", $"Form cannot be modified because packet is in {visit.Status.ToString()} status.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (visit.Status != PacketStatus.Pending)
                    {
                        visit.UpdateStatus(PacketStatus.Pending);
                        await _visitService.PatchStatus(User.Identity.Name, visit);
                    }

                    await _visitService.UpdateForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", visit, _formKind);

                    await ResolveCorrectedErrorsAsync(visit, BaseForm);

                    if (!String.IsNullOrWhiteSpace(goNext) && !String.IsNullOrWhiteSpace(BaseForm.NextFormKind))
                        return RedirectToPage(BaseForm.NextFormKind, new { Id = Visit.Id, PacketKind = Visit.PACKET });
                    else
                        return RedirectToAction("Details", "Visits", new { Id = Visit.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError($"{BaseForm.GetType().Name}.Status", ex.Message);
                }
            }

            // repopulate the visit for navigation menus
            visit = await _visitService.GetByIdWithForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", id, _formKind);

            if (visit == null)
                return NotFound(); // this should never be possible, but just in case

            Visit = visit.ToVM();

            var participation = await _participationService.GetById(User.Identity.Name, visit.ParticipationId, false);

            if (participation == null)
                return NotFound();

            Visit.Participation = participation.ToVM();

            if (BaseForm.Kind == "C2")
            {
                if (BaseForm != null)
                {
                    var C2 = new C2Model(_visitService, _participationService, _packetService);

                    C2.Visit = Visit;
                    C2.BaseForm = BaseForm;
                    C2.C2 = (C2)BaseForm;

                    var form = visit.Forms.Where(f => f.Kind == _formKind).FirstOrDefault();

                    if (!ModelState.IsValid)
                    {
                        Response.ContentType = "text/vnd.turbo-stream.html";
                        return Partial("_C2Validation", C2);
                    }
                };
            }

            return Page();
        }

        protected void AddErrorsToModelState(object model, IEnumerable<PacketSubmissionError> errors)
        {
            foreach (var error in errors)
            {
                var propertyName = error.Location;
                if (!string.IsNullOrEmpty(propertyName))
                {
                    var key = $"{BaseForm.GetType().Name}.{propertyName}";

                    if (!ModelState.ContainsKey(key))
                    {
                        ModelState.AddModelError(key, error.Message);
                    }
                }
            }
        }

        protected async Task ResolveCorrectedErrorsAsync(Visit visitEntity, FormModel updatedForm)
        {
            var username = User.Identity?.Name ?? "unknown";
            var packet = await _packetService.GetById(username, visitEntity.Id);

            if (packet == null || packet.Submissions == null || !packet.Submissions.Any())
                return;

            var mostRecentSubmission = packet.Submissions
                .Where(s => !s.IsDeleted)
                .OrderByDescending(s => s.SubmissionDate)
                .ThenByDescending(s => s.Id)
                .FirstOrDefault();

            if (mostRecentSubmission == null)
                return;

            var unresolvedErrors = mostRecentSubmission.Errors
                .Where(e => !e.IsDeleted && string.IsNullOrEmpty(e.ResolvedBy) &&
                            string.Equals(e.FormKind, updatedForm.Kind, StringComparison.OrdinalIgnoreCase))
                .ToList();

            bool anyResolved = false;

            foreach (var error in unresolvedErrors)
            {
                var propertyInfo = updatedForm.GetType().GetProperty(error.Location);

                if (propertyInfo != null)
                {
                    var currentValue = propertyInfo.GetValue(updatedForm)?.ToString()?.Trim();
                    var originalValue = error.Value?.Trim();

                    if (!string.Equals(currentValue, originalValue, StringComparison.OrdinalIgnoreCase))
                    {
                        error.Resolve(username, username);
                        anyResolved = true;
                    }
                }
            }

            if (anyResolved)
            {
                await _packetService.UpdatePacketSubmissionErrors(username, packet, mostRecentSubmission.Id, mostRecentSubmission.Errors.ToList());

                bool allResolved = packet.Submissions.All(s => s.Errors.All(e => !string.IsNullOrEmpty(e.ResolvedBy)));

                if (allResolved)
                {
                    packet.UpdateStatus(Services.Enums.PacketStatus.Pending);
                    await _packetService.Update(username, packet);
                }
            }
        }

    }
}

