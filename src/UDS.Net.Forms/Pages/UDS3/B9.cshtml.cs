﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class B9Model : FormPageModel
    {
        [BindProperty]
        public B9 B9 { get; set; } = default!;

        public List<RadioListItem> MemoryDeclineListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Could not be assessed/subject is too impaired", "8")
        };

        public List<RadioListItem> InformantMemoryDeclineListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("There is no co-participant", "8")
        };

        public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SimpleYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> CognitiveDomainsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Memory", "1"),
            new RadioListItem("Orientation", "2"),
            new RadioListItem("Executive function — judgment, planning, problem-solving", "3"),
            new RadioListItem("Language", "4"),
            new RadioListItem("Visuospatial function", "5"),
            new RadioListItem("Attention / concentration", "6"),
            new RadioListItem("Fluctuating cognition", "7"),
            new RadioListItem("Other", "8"),
            new RadioListItem("Unknown", "99")
        };

        public List<RadioListItem> OnsetListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gradual", "1"),
            new RadioListItem("Subacute", "2"),
            new RadioListItem("Abrupt", "3"),
            new RadioListItem("Other", "4"),
            new RadioListItem("Unknown", "99")
        };

        public List<RadioListItem> PredominantSymptomListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Apathy/withdrawal", "1"),
            new RadioListItem("Depressed mood", "2"),
            new RadioListItem("Psychosis", "3"),
            new RadioListItem("Disinhibition", "4"),
            new RadioListItem("Irritability", "5"),
            new RadioListItem("Agitation", "6"),
            new RadioListItem("Personality change", "7"),
            new RadioListItem("Personality change", "8"),
            new RadioListItem("Anxiety", "9"),
            new RadioListItem("Other", "10"),
            new RadioListItem("Unknown", "99")
        };

        public List<RadioListItem> MotorFunctionListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gait disorder", "1"),
            new RadioListItem("Falls", "2"),
            new RadioListItem("Tremor", "3"),
            new RadioListItem("Slowness", "4"),
            new RadioListItem("Unknown", "99")
        };

        public List<RadioListItem> CourseOfDeclineListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Gradually progressive", "1"),
            new RadioListItem("Stepwise", "2"),
            new RadioListItem("Static", "3"),
            new RadioListItem("Fluctuating", "4"),
            new RadioListItem("Improved", "5"),
            new RadioListItem("N/A", "8"),
            new RadioListItem("Unknown", "9")
        };

        public B9Model(IVisitService visitService) : base(visitService, "B9")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                B9 = (B9)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(int id)
        {
            /*
             * ValidationContext describes any member on which validation is performed. It also enables
             * custom validation to be added through any service that implements the IServiceProvider
             * interface.
             */
            foreach (var result in B9.Validate(new ValidationContext(B9, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"B9.{memberName}", result.ErrorMessage);
            }

            // if model is attempting to be completed, validation against domain form rules and visit rules
            // if not validates, return with errors

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(B9);

                await base.OnPost(id); // checks for domain-level business rules validation
            }

            var visit = await _visitService.GetByIdWithForm("", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}
