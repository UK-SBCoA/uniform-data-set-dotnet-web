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

        public ParticipationsPaginatedModel Participations { get; set; } = new ParticipationsPaginatedModel();

        public IndexModel(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGet(int pageSize = 10, int pageIndex = 1, string search = "")
        {
            var participations = new List<Services.DomainModels.Participation>();
            int total = 0;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var participation = await _participationService.GetByLegacyId(User.Identity.Name, search);

                if (participation != null)
                {
                    participations.Add(participation);
                    total = 1;
                }
            }
            else
            {
                total = await _participationService.Count(User.Identity.Name);
                if (total > 0)
                {
                    var page = await _participationService.List(User.Identity.Name, pageSize, pageIndex);

                    if (page != null)
                        participations.AddRange(page);
                }
            }

            Participations = participations.ToVM(pageSize, pageIndex, total, search);

            return Page();
        }
    }
}
