using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class A2Model : FormPageModel
    {
        [BindProperty]
        public A2 A2 { get; set; } = default!;

        public List<RadioListItem> SexListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Male", "1"),
            new RadioListItem("Female", "2")
        };

        public List<RadioListItem> HispanicLatinoListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No  (If No, SKIP TO QUESTION below)", "1"),
            new RadioListItem("Yes", "2"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION below)", "9")
        };

        public List<RadioListItem> OriginsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Mexican, Chicano, or Mexican-American", "1"),
            new RadioListItem("Puerto Rican", "2"),
            new RadioListItem("Cuban", "3"),
            new RadioListItem("Dominican", "4"),
            new RadioListItem("Central American", "5"),
            new RadioListItem("South American", "6"),
            new RadioListItem("Other (specify)", "50"),
            new RadioListItem("Unknown","99")
        };

        public List<RadioListItem> RacialGroupsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("White", "1"),
            new RadioListItem("Black or African American", "2"),
            new RadioListItem("American Indian or Alaska Native", "3"),
            new RadioListItem("Native Hawaiian or other Pacific Islander", "4"),
            new RadioListItem("Asian", "5"),
            new RadioListItem("Other (specify)", "50"),
            new RadioListItem("Unknown", "99")
        };

        public List<RadioListItem> RelationshipTypesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Spouse, partner, or companion (include ex-spouse, ex-partner, fiancé, boyfriend, girlfriend)", "1"),
            new RadioListItem("Child (by blood or through marriage or adoption)", "2"),
            new RadioListItem("Sibling (by blood or through marriage or adoption)", "3"),
            new RadioListItem("Other relative (by blood or through marriage or adoption)", "4"),
            new RadioListItem("Friend, neighbor, or someone known through family, friends, work, or community (e.g., church)", "5"),
            new RadioListItem("Paid caregiver, health care provider, or clinician", "6"),
        };

        public List<RadioListItem> LivingSituationListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes (If Yes, SKIP TO QUESTION 10)", "1")
        };

        public List<RadioListItem> ContactFrequencyListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Daily", "1"),
            new RadioListItem("At least 3 times per week", "2"),
            new RadioListItem("Weekly", "3"),
            new RadioListItem("At least three times per month", "4"),
            new RadioListItem("Monthly", "5"),
            new RadioListItem("Less than once a month", "6"),
        };

        public List<RadioListItem> ReliabilityListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public A2Model(IVisitService visitService) : base(visitService, "A2")
        {
        }


        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                A2 = (A2)_formModel; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(int id)
        {
            // server validation for form fields
            foreach (var result in A2.Validate(new ValidationContext(A2, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"A2.{memberName}", result.ErrorMessage);
            }

            // annotations as well in view model
            if (ModelState.IsValid)
            {
                await base.OnPost(id);
            }

            var visit = await _visitService.GetByIdWithForm("", id, _formKind);

            if (visit == null)
                return NotFound();

            Visit = visit.ToVM();

            return Page();
        }
    }
}
