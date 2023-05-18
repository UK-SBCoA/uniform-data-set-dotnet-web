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
    public class IndexModel : PageModel
    {
        private readonly IParticipationService _participationService;

        public IList<ParticipationModel>? Participations { get; set; }

        public IndexModel(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGet()
        {
            var participations = await _participationService.List("");

            Participations = participations.Select(p => p.ToVM()).ToList();

            return Page();
        }
    }
}
