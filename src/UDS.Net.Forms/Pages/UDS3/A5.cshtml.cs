using System;
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
    /// <summary>
    /// Only collected during initial visits
    /// </summary>
    public class A5Model : FormPageModel
    {
        [BindProperty]
        public A5 A5 { get; set; } = default!;

        public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ConditionsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Recent/active", "1"),
            new RadioListItem("Remote/inactive", "2"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ConditionsLimitedListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Recent/active", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SmokingFrequencyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("1 cigarette to less than 1/2 pack", "1"),
            new RadioListItem("1/2 pack to less than 1 pack", "2"),
            new RadioListItem("1 pack to less than 1 1/2 packs", "3"),
            new RadioListItem("1 1/2 packs to less than 2 packs", "4"),
            new RadioListItem("2 packs or more", "5"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> RecentAlcoholUseListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 2a)", "0", new Dictionary<string, string> { { "ALCFREQ", "disabled=true" } }),
            new RadioListItem("Yes", "1", new Dictionary<string, string> { { "ALCFREQ", "disabled=false" } }),
            new RadioListItem("Unknown", "9 (skip to question 2a)", new Dictionary<string, string> { { "ALCFREQ", "disabled=true" } })
        };

        public List<RadioListItem> AlcoholUseFrequencyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Less than once a month", "0"),
            new RadioListItem("About once a month", "1"),
            new RadioListItem("About once a week", "2"),
            new RadioListItem("A few times a week", "3"),
            new RadioListItem("Daily or almost daily", "4"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> TBIFrequencyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Single", "1"),
            new RadioListItem("Repeated/multiple", "2"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> DiabetesTypeListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Type 1", "1"),
            new RadioListItem("Type 2", "2"),
            new RadioListItem("Other type (diabetes insipidus, latent automimmune diabetes/type 1.5, gestational diabetes)", "3"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ArthritisListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Rheumatoid","1"),
            new RadioListItem("Osteoarthritis","2"),
            new RadioListItem("Other (specify)","3"),
            new RadioListItem("Unknown","9"),
        };

        public A5Model(IVisitService visitService) : base(visitService, "A5")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (_formModel != null)
            {
                A5 = (A5)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id)
        {
            Dictionary<object, object?> contextDicitonary = new Dictionary<object, object?>
            {
                { "VisitDate", this.Visit.StartDateTime }
            };

            foreach (var result in A5.Validate(new ValidationContext(A5, null, null)))
            {
                // Validation in these scenarios
                // - cross-form validation
                // - differences in validation across visit types for instance, IVP vs FVP
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"A5.{memberName}", result.ErrorMessage);
            }

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(A5);

                await base.OnPostAsync(id); // checks for domain-level business rules validation
            }

            var visit = await _visitService.GetByIdWithForm("", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}
