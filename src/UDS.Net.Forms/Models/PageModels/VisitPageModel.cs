﻿using System;
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
        protected readonly IParticipationService _participationService;

        [BindProperty]
        public VisitModel? Visit { get; set; }

        public string PageTitle
        {
            get
            {
                if (Visit != null)
                {
                    return $"Participant {Visit.Participation.LegacyId} Visit {Visit.VISITNUM}";
                }
                return "";
            }
        }

        public VisitPageModel(IVisitService visitService, IParticipationService participationService) : base()
        {
            _visitService = visitService;
            _participationService = participationService;
        }

        public virtual async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var visit = await _visitService.GetById(User.Identity.Name, id.Value);

            if (visit == null)
                return NotFound();

            var participation = await _participationService.GetById(User.Identity.Name, visit.ParticipationId);

            if (participation == null)
                return NotFound();

            Visit = visit.ToVM();
            Visit.Participation = participation.ToVM();

            return Page();
        }
    }
}

