using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class A1Model : FormPageModel
    {
        [BindProperty]
        public A1 A1 { get; set; } = default!;

        public List<RadioListItem> HispanicLatinoListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No  (If No, SKIP TO QUESTION 9)", "1"),
            new RadioListItem("Yes", "2"),
            new RadioListItem("Unknown (If Unknown, SKIP TO QUESTION 9)", "9")
        };

        public List<RadioListItem> OriginsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Mexican, Chicano, or Mexican-American", "1"),
            new RadioListItem("Puerto Rican", "2"),
            new RadioListItem("Cuban", "3"),
            new RadioListItem("Dominican", "4"),
            new RadioListItem("Central American", "5"),
            new RadioListItem("South American", "6"),
            new RadioListItem("Other (specify)", "50", new Dictionary<string, string> { { "HISPORX", "disabled" } }),
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

        public List<RadioListItem> ParticipationReasonsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("To participate in a research study", "1"),
            new RadioListItem("To have clinical evaluation", "2"),
            new RadioListItem("Both (to participate in a research study and to have clinical evaluation", "4"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ReferralSourcesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Self-referral", "1", new Dictionary<string, string> { { "LEARNED", "disabled" } }),
            new RadioListItem("Non-professional contact (spouse/partner, relative, friend, coworker, etc.)", "2", new Dictionary<string, string> { { "LEARNED", "disabled" } }),
            new RadioListItem("ADC participant referral", "3"),
            new RadioListItem("ADC clinician, staff, or investigator referral", "4"),
            new RadioListItem("Nurse, doctor, or other health care provider", "5"),
            new RadioListItem("Other research study clinician/staff/investigator (non-ADC; e.g., ADNI, Women's Health Initiative)", "6"),
            new RadioListItem("Other", "8"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> SecondaryReferralSourcesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("ADC advertisement (e.g., website, mailing, newspaper ad, community presentation)", "1"),
            new RadioListItem("News article or TV program mentioning the ADC study", "2"),
            new RadioListItem("Conference or community event (e.g., community memory walk)", "3"),
            new RadioListItem("Another organization's media appeal or website", "4"),
            new RadioListItem("Other", "8"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> DiseaseStatusesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Case, patient, or proband", "1"),
            new RadioListItem("Control or normal", "2"),
            new RadioListItem("No presumed disease status", "3")
        };

        public List<RadioListItem> ParticipationsListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Initial evaluation only", "1"),
            new RadioListItem("Longitudinal follow-up planned", "2")
        };

        public List<RadioListItem> EnrollmentTypesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Primarily ADC-funded (Clinical Core, Satellite Core, or other ADC Core or project)", "1"),
            new RadioListItem("Participant is supported primarily by a non-ADC study (e.g., R01, including non-ADC grants supporting FTLD Module participation)", "2")
        };

        public List<RadioListItem> SexListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Male", "1"),
            new RadioListItem("Female", "2")
        };

        public List<RadioListItem> PrimaryLanguage { get; } = new List<RadioListItem>
        {
            new RadioListItem("English", "1"),
            new RadioListItem("Spanish", "2"),
            new RadioListItem("Mandarin", "3"),
            new RadioListItem("Cantonese", "4"),
            new RadioListItem("Russian", "5"),
            new RadioListItem("Japanese", "6"),
            new RadioListItem("Other (specify)", "8"),
            new RadioListItem("Unknown", "9"),
        };

        public List<RadioListItem> MaritalStatusListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Married", "1"),
            new RadioListItem("Widowed", "2"),
            new RadioListItem("Divorced", "3"),
            new RadioListItem("Separated", "4"),
            new RadioListItem("Never married (or marriage was annulled)", "5"),
            new RadioListItem("Living as married/domestic partner", "6"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> LivingSituationListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Lives alone", "1"),
            new RadioListItem("Lives with one other person: a spouse or partner", "2"),
            new RadioListItem("Lives with one other person: a relative, friend, or roommate", "3"),
            new RadioListItem("Lives with caregiver who is not spouse/partner, relative,\nor friend", "4"),
            new RadioListItem("Lives with a group (related or not related) in a private residence", "5"),
            new RadioListItem("Lives in group home (e.g., assisted living, nursing home,\nconvent)", "6"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> IndependenceLevelListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Able to live independently", "1"),
            new RadioListItem("Requires some assistance with complex activities", "2"),
            new RadioListItem("Requires some assistance with basic activities", "3"),
            new RadioListItem("Completely dependent", "4"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ResidenceTypeListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Single- or multi-family private residence (apartment, condo,\nhouse)", "1"),
            new RadioListItem("Retirement community or independent group living", "2"),
            new RadioListItem("Assisted living, adult family home, or boarding home", "3"),
            new RadioListItem("Skilled nursing facility, nursing home, hospital, or hospice", "4"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> HandednessListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Left-handed", "1"),
            new RadioListItem("Right-handed", "2"),
            new RadioListItem("Ambidextrous", "3"),
            new RadioListItem("Unknown", "9"),
        };

        public A1Model(IVisitService visitService) : base(visitService, "A1")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            if (_formModel != null)
            {
                A1 = (A1)_formModel; // class library should always handle new instances
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
            foreach (var result in A1.Validate(new ValidationContext(A1, null, null)))
            {
                var memberName = result.MemberNames.FirstOrDefault();
                ModelState.AddModelError($"A1.{memberName}", result.ErrorMessage);
            }

            // if model is attempting to be completed, validation against domain form rules and visit rules
            // if not validates, return with errors

            if (ModelState.IsValid)
            {
                Visit.Forms.Add(A1);


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
