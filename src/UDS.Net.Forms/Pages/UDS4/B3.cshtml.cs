using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class B3Model : FormPageModel
    {
        [BindProperty]
        public B3 B3 { get; set; } = default!;

        public B3Model(IVisitService visitService) : base(visitService, "B3")
        {
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B3 = (B3)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = B3;

            Visit.Forms.Add(B3);

            return await base.OnPostAsync(id); // checks for domain-level business rules validation
        }

    }
}
