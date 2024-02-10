using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Pages.Lookup
{
    public class DrugCodeModel : PageModel
    {
        private readonly IVisitService _visitService;
        private readonly ILookupService _lookupService;
        private string _formKind = "A4";

        public VisitModel? Visit { get; private set; }

        [BindProperty]
        public DrugCodeLookupModel Lookup { get; set; } = new DrugCodeLookupModel();

        public DrugCodeModel(IVisitService visitService, ILookupService lookupService)
        {
            _visitService = visitService;
            _lookupService = lookupService;
        }

        public async Task<IActionResult> OnGetAsync(int? visitId, string? searchTerm)
        {
            if (visitId == null || visitId == 0)
                return NotFound();

            var visit = await _visitService.GetByIdWithForm("", visitId.Value, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                Lookup.SearchTerm = searchTerm.Trim();

                var lookup = await _lookupService.SearchDrugCodes(10, 1, false, searchTerm);

                if (lookup != null)
                    Lookup.DrugCodes = lookup.DrugCodes.Select(c => c.ToVM()).ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? visitId, string? searchTerm)
        {

            if (visitId == null || visitId == 0)
                return NotFound();

            var entity = await _visitService.GetByIdWithForm("", visitId.Value, _formKind);

            if (entity == null)
                return NotFound();

            var form = entity.Forms.Where(f => f.Kind == _formKind).FirstOrDefault();

            var fields = (A4GFormFields)form.Fields;

            foreach (var newCode in Lookup.DrugCodes.Where(d => d.IsSelected).ToList())
            {
                if (fields.A4Ds.Any(a => a.DRUGID == newCode.DrugId))
                {
                    var existingA4D = fields.A4Ds.Where(d => d.DRUGID == newCode.DrugId).FirstOrDefault();

                    if (existingA4D.IsDeleted)
                    {
                        // update
                        existingA4D.IsDeleted = false;
                        existingA4D.DeletedBy = null;
                        existingA4D.ModifiedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "username";

                    }
                }
                else
                {
                    // add
                    fields.A4Ds.Add(new A4DFormFields
                    {
                        DRUGID = newCode.DrugId,
                        CreatedAt = DateTime.Now,
                        CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "username"
                    });
                }
            }

            await _visitService.UpdateForm(User.Identity.IsAuthenticated ? User.Identity.Name : "username", entity, _formKind);

            return Redirect($"/{entity.Version}/{form.Kind}?Id={entity.Id}&VisitKind={entity.Kind}");
        }
    }
}
