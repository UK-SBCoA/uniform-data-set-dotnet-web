using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Models
{
    public class VisitPageModel : PageModel
    {
        protected readonly IVisitService _visitService;

        [BindProperty]
        public VisitModel? Visit { get; set; }

        public VisitPageModel(IVisitService visitService) : base ()
        {
            _visitService = visitService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var visit = await _visitService.GetById("", id.Value);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}

