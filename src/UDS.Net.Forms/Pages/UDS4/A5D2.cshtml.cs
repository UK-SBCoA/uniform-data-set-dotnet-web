using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4;

public class A5D2Model : FormPageModel
{
    [BindProperty]
    public A5D2 A5D2 { get; set; } = default!;

    public A5D2Model(IVisitService visitService) : base(visitService, "A5D2")
    {
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        await base.OnGetAsync(id);

        if (BaseForm != null)
        {
            A5D2 = (A5D2)BaseForm;
        }

        return Page();
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostAsync(int id)
    {
        BaseForm = A5D2; // reassign bounded and derived form to base form for base method

        Visit.Forms.Add(A5D2); // visit needs updated form as well

        return await base.OnPostAsync(id); // checks for validation, etc.
    }
}
