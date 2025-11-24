using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A3Model : FormPageModel
    {
        [BindProperty]
        public A3 A3 { get; set; } = default!;

        public A3Model(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base(visitService, participationService, packetService, "A3")
        {
        }

        private void ValidateAgeRange(int? ageOfOnset, int? ageAtDeath, int? birthYear, ModelStateDictionary modelState, string onsetField, string deathField)
        {
            bool birthYearKnown = birthYear.HasValue && birthYear != 9999;
            bool ageOfDeathKnown = ageAtDeath.HasValue && ageAtDeath != 999 && ageAtDeath != 888;
            bool ageOfOnsetKnown = ageOfOnset.HasValue && ageOfOnset != 999;

            if (ageOfOnsetKnown && ageOfDeathKnown && ageOfOnset > ageAtDeath)
            {
                modelState.AddModelError(onsetField, "Age of onset cannot be greater than age of death");
            }

            if (birthYearKnown && ageOfDeathKnown && ageAtDeath.Value > DateTime.Now.Year - birthYear)
            {
                modelState.AddModelError(deathField, "Age of death cannot be greater than the current year minus the birth year");
            }

            if (birthYearKnown && ageOfOnsetKnown && ageOfOnset > DateTime.Now.Year - birthYear)
            {
                modelState.AddModelError(onsetField, "Age of onset cannot be greater than the current year minus the birth year");
            }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A3 = (A3)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = A3; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A3); // visit needs updated form as well
            var existingSiblings = new List<A3FamilyMember>();
            if (A3.Siblings != null)
            {
                existingSiblings = A3.Siblings.ToList();
            }

            A3.Siblings = new List<A3FamilyMember>();
            for (int i = 0; i < 20; i++)
            {
                if (i < existingSiblings.Count && existingSiblings[i] != null)
                {
                    A3.Siblings.Add(existingSiblings[i]);
                }
                else
                {
                    A3.Siblings.Add(new A3FamilyMember());
                }
            }


            var existingChildren = new List<A3FamilyMember>();
            if (A3.Children != null)
            {
                existingChildren = A3.Children.ToList();
            }

            A3.Children = new List<A3FamilyMember>();
            for (int i = 0; i < 15; i++)
            {
                if (i < existingChildren.Count && existingChildren[i] != null)
                {
                    A3.Children.Add(existingChildren[i]);
                }
                else
                {
                    A3.Children.Add(new A3FamilyMember());
                }
            }

            if (A3 != null && A3.Status == FormStatus.Finalized)
            {
                if (A3.MOMYOB.HasValue || A3.MOMETPR != null || A3.MOMAGEO.HasValue || A3.MOMDAGE.HasValue)
                {
                    if (!A3.MOMDAGE.HasValue)
                    {
                        ModelState.AddModelError("A3.MOMDAGE", "Please provide a value for age at death.");
                    }
                    ValidateAgeRange(A3.MOMAGEO, A3.MOMDAGE, A3.MOMYOB, ModelState, "A3.MOMAGEO", "A3.MOMDAGE");

                }
                if (A3.DADYOB.HasValue || A3.DADETPR != null || A3.DADAGEO.HasValue || A3.DADDAGE.HasValue)
                {
                    if (!A3.DADDAGE.HasValue)
                    {
                        ModelState.AddModelError("A3.DADDAGE", "Please provide a value for age at death.");
                    }
                    ValidateAgeRange(A3.DADAGEO, A3.DADDAGE, A3.DADYOB, ModelState, "A3.DADAGEO", "A3.DADDAGE");
                }
                return await base.OnPostAsync(id, goNext); // checks for validation, etc.

            }
            return await base.OnPostAsync(id, goNext);
        }
    }
}
