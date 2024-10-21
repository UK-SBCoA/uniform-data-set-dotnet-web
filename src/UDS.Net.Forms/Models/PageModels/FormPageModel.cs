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
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.Pages.UDS4;
using UDS.Net.Services.Enums;
using UDS.Net.Services;

namespace UDS.Net.Forms.Models.PageModels
{
    public class FormPageModel : PageModel
    {
        [BindProperty]
        public VisitModel Visit { get; set; } = default!;

        public FormModel BaseForm { get; set; }

        public string PageTitle
        {
            get
            {
                if (BaseForm != null)
                {
                    return $"Participant {Visit.ParticipationId} Visit {Visit.VISITNUM} {Visit.PACKET}";
                }
                return "";
            }
        }


        protected readonly IVisitService _visitService;
        protected string _formKind { get; set; }

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

            var form = visit.Forms.Where(f => f.Kind == _formKind).FirstOrDefault();

            BaseForm = form.ToVM(); // this will have the subclass

            return Page();
        }

        [ValidateAntiForgeryToken]
        protected async Task<IActionResult> OnPostAsync(int id)
        {
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

            if (ModelState.IsValid)
            {
                try
                {
                    await _visitService.UpdateForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", visit, _formKind);

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

            if (BaseForm.Kind == "C2")
            {
                if (BaseForm != null)
                {
                    var C2 = new C2Model(_visitService);

                    C2.Visit = Visit;
                    C2.BaseForm = BaseForm;
                    C2.C2 = (C2)BaseForm;

                    var form = visit.Forms.Where(f => f.Kind == _formKind).FirstOrDefault();

                    if (!ModelState.IsValid)

                    Response.ContentType = "text/vnd.turbo-stream.html";
                    return Partial("_C2Validation", C2);
                };
            }

            return Page();
        }

    }
}

