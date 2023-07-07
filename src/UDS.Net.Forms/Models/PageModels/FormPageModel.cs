using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.Pages.UDS3;
using UDS.Net.Services;

namespace UDS.Net.Forms.Models.PageModels
{
    public class FormPageModel : PageModel
    {
        [BindProperty]
        public VisitModel Visit { get; set; } = default!;

        public string PageTitle
        {
            get
            {
                if (_formModel != null)
                {
                    return $"Participant {Visit.ParticipationId} Visit {Visit.Number} {Visit.Kind}";
                }
                return "";
            }
        }

        protected readonly IVisitService _visitService;
        protected string _formKind { get; set; }
        public FormModel _formModel;

        public FormPageModel(IVisitService visitService, string formKind) : base()
        {
            _visitService = visitService;
            _formKind = formKind;
        }

        protected async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _formKind == null)
                return NotFound();

            var visit = await _visitService.GetByIdWithForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", id.Value, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            var form = visit.Forms.Where(f => f.Kind.Contains(_formKind)).FirstOrDefault();

            _formModel = form.ToVM(); // this will have the subclass

            return Page();
        }

        [ValidateAntiForgeryToken]
        protected async Task<IActionResult> OnPostAsync(int id)
        {
            var visit = Visit.ToEntity(); // TODO check for domain-level business rules validation

            foreach (var result in _formModel.Validate(new ValidationContext(_formModel, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"{memberName}", result.ErrorMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _visitService.UpdateForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", visit, _formKind);

                    return RedirectToAction("Details", "Visits", new { Id = Visit.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Status", ex.Message);
                }
            }

            // repopulate the visit for navigation menus
            visit = await _visitService.GetByIdWithForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }

    }
}

