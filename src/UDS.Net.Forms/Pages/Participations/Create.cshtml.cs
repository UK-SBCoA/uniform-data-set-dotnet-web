using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Pages.Visits;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Participations
{
    /// <summary>
    /// TODO Continue tutorial here https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio-mac
    ///
    /// The PageModel class allows separation of the logic of a page from its presentation. It defines page handlers for requests sent to the page and the data used to render the page.
    /// </summary>
    public class CreateModel : PageModel
    {
        private readonly IParticipationService _participationService;

        [BindProperty]
        public ParticipationModel Participation { get; set; }

        public CreateModel(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGet()
        {
            Participation = new ParticipationModel
            {
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Username"
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var participation = await _participationService.GetByLegacyId(Participation.LegacyId);

            if (participation != null && participation.LegacyId == Participation.LegacyId)
            {
                ModelState.AddModelError("Participation.LegacyId", "A Participation with this Legacy Id already exists.");
                TempData["Participation"] = participation.Id;
            }

            if (!ModelState.IsValid)
                return Page();

            await _participationService.Add("", Participation.ToEntity());

            return RedirectToPage("./Index");
        }
    }
}