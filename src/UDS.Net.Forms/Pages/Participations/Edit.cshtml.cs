using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Participations
{
    public class EditModel : PageModel
    {
        private readonly IParticipationService _participationService;

        [ViewData]
        public string Title { get; } = "Edit participation";

        [BindProperty]
        public ParticipationModel? Participation { get; set; }

        public EditModel(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            var participation = await _participationService.GetById("", id.Value);

            if (participation == null)
                return NotFound();

            Participation = participation.ToVM();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Participation != null)
            {
                var participation = Participation.ToEntity();

                var updatedParticipation = _participationService.Update("", participation);

                if (updatedParticipation != null)
                    return RedirectToPage("Details", new { Id = participation.Id });
            }

            return Page();
        }
    }
}
