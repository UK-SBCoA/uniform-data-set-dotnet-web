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
    public class DetailsModel : PageModel
    {
        private readonly IParticipationService _participationService;

        public ParticipationModel? Participation { get; set; }

        public DetailsModel(IParticipationService participationService)
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
    }
}
