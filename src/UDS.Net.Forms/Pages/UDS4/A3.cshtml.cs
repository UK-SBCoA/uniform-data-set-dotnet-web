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

        public A3Model(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "A3")
        {
        }

        private void ValidateAgeRange(int? ageOfOnset, int? ageAtDeath, int? birthYear, ModelStateDictionary modelState, string onsetField, string deathField)
        {
            if (ageOfOnset.HasValue && ageAtDeath.HasValue && ageOfOnset > ageAtDeath && ageOfOnset != 999 && ageOfOnset != 888)
            {
                modelState.AddModelError(onsetField, "Age of onset cannot be greater than age of death");
            }

            if (birthYear.HasValue && ageAtDeath.HasValue && ageAtDeath.Value > DateTime.Now.Year - birthYear && ageAtDeath.Value != 999 && ageAtDeath.Value != 888)
            {
                modelState.AddModelError(deathField, "Age of death cannot be greater than the current year minus the birth year");
            }

            if (birthYear.HasValue && ageOfOnset.HasValue && ageOfOnset > DateTime.Now.Year - birthYear && ageOfOnset != 999)
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

                if (A3.Siblings != null)
                {
                    for (int i = 0; i < A3.Siblings.Count; i++)
                    {
                        var sibling = A3.Siblings[i];
                        if (sibling == null) continue;

                        if (sibling.YOB.HasValue && !sibling.AGD.HasValue)
                        {
                            ModelState.AddModelError($"A3.Siblings[{i}].AGD", "Please provide a value for age at death.");
                        }

                        if (sibling.YOB.HasValue || sibling.AGD.HasValue)
                        {
                            if (string.IsNullOrEmpty(sibling.ETPR))
                            {
                                ModelState.AddModelError($"A3.Siblings[{i}].ETPR", "Please provide a value for primary dx.");
                            }
                        }

                        if (!string.IsNullOrEmpty(sibling.ETPR) && sibling.ETPR != "00" && sibling.ETPR != "99")
                        {
                            if (sibling.ETSEC == null)
                            {
                                ModelState.AddModelError($"A3.Siblings[{i}].ETSEC", "Please provide a value for secondary dx.");
                            }
                            if (!sibling.MEVAL.HasValue)
                            {
                                ModelState.AddModelError($"A3.Siblings[{i}].MEVAL", "Please provide a value for method of evaluation.");
                            }
                            if (!sibling.AGO.HasValue)
                            {
                                ModelState.AddModelError($"A3.Siblings[{i}].AGO", "Please provide a value for age of onset.");
                            }
                        }

                        ValidateAgeRange(sibling.AGO, sibling.AGD, sibling.YOB, ModelState, $"A3.Siblings[{i}].AGO", $"A3.Siblings[{i}].AGD");
                    }
                }

                if (A3.Children != null)
                {
                    for (int i = 0; i < A3.Children.Count; i++)
                    {
                        var child = A3.Children[i];
                        if (child == null) continue;

                        if (child.YOB.HasValue && !child.AGD.HasValue)
                        {
                            ModelState.AddModelError($"A3.Children[{i}].AGD", "Please provide a value for age at death.");
                        }

                        if (child.YOB.HasValue || child.AGD.HasValue)
                        {
                            if (string.IsNullOrEmpty(child.ETPR))
                            {
                                ModelState.AddModelError($"A3.Children[{i}].ETPR", "Please provide a value for primary dx.");
                            }
                        }

                        if (!string.IsNullOrEmpty(child.ETPR) && child.ETPR != "00" && child.ETPR != "99")
                        {
                            if (child.ETSEC == null)
                            {
                                ModelState.AddModelError($"A3.Children[{i}].ETSEC", "Please provide a value for secondary dx.");
                            }
                            if (!child.MEVAL.HasValue)
                            {
                                ModelState.AddModelError($"A3.Children[{i}].MEVAL", "Please provide a value for method of evaluation.");
                            }
                            if (!child.AGO.HasValue)
                            {
                                ModelState.AddModelError($"A3.Children[{i}].AGO", "Please provide a value for age of onset.");
                            }
                        }

                        ValidateAgeRange(child.AGO, child.AGD, child.YOB, ModelState, $"A3.Children[{i}].AGO", $"A3.Children[{i}].AGD");
                    }
                }
                return await base.OnPostAsync(id, goNext); // checks for validation, etc.

            }
            return await base.OnPostAsync(id, goNext);
        }
    }
}
