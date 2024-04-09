using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class D1aModel : FormPageModel
    {

        [BindProperty]
        public D1a D1a { get; set; } = default!;

        public D1aModel(IVisitService visitService, string formKind) : base(visitService, formKind)
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D1a = (D1a)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = D1a; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(D1a); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}