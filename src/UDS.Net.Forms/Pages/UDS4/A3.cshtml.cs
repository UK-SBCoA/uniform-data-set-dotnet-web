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
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
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
            //onset vs death
            if (ageOfOnset.HasValue && ageAtDeath.HasValue && ageOfOnset > ageAtDeath && ageOfOnset != 999 && ageOfOnset != 888)
            {
                modelState.AddModelError(onsetField, "Age of onset cannot be greater than age of death");
            }

            //death vs birth year
            if(birthYear.HasValue && ageAtDeath.HasValue && ageAtDeath.Value > DateTime.Now.Year - birthYear && ageAtDeath.Value != 999 && ageAtDeath.Value != 888)
            {
                modelState.AddModelError(deathField, "Age of death cannot be greater than the current year minus the birth year");
            }

            //onset vs birth year
            if(birthYear.HasValue && ageOfOnset.HasValue && ageOfOnset > DateTime.Now.Year - ageOfOnset.Value && ageOfOnset != 999)
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
                    foreach (var sibling in A3.Siblings)
                    {
                        if (sibling != null)
                        {

                            if (sibling.YOB.HasValue)
                            {
                                if (!sibling.AGD.HasValue)
                                {
                                    ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].AGD", "Please provide a value for age at death.");
                                }
                                if (sibling.AGD.HasValue && sibling.AGD.Value > DateTime.Now.Year - sibling.YOB.Value)
                                {
                                    if (sibling.AGD.Value != 999 && sibling.AGD.Value != 888)
                                    {
                                        ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].AGD", "Age of death cannot be greater than the current year minus the birth year");
                                    }
                                }
                            }

                            if (sibling.YOB.HasValue || sibling.AGD.HasValue)

                            {
                                if (sibling.ETPR == null)
                                {

                                    ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].ETPR", "Please provide a value for primary dx.");

                                }
                            }

                            if (sibling.ETPR != null)
                            {
                                if (sibling.ETPR != "00" && sibling.ETPR != "99")
                                {
                                    if (sibling.ETSEC == null)
                                    {
                                        ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].ETSEC", "Please provide a value for secondary dx.");
                                    }
                                    if (!sibling.MEVAL.HasValue)
                                    {
                                        ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].MEVAL", "Please provide a value for method of evaluation.");
                                    }
                                    if (!sibling.AGO.HasValue)
                                    {
                                        ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].AGO", "Please provide a value for age of onset.");

                                    }
                                    if (sibling.AGO.HasValue && sibling.AGD.HasValue && sibling.AGO.Value > sibling.AGD.Value)
                                    {
                                        if (sibling.AGO.Value != 999 && sibling.AGO.Value != 888)
                                        {
                                            ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].AGO", "Age of onset cannot be greater than age of death");
                                        }
                                    }
                                    if (sibling.YOB.HasValue && sibling.AGO.HasValue && sibling.AGO.Value > DateTime.Now.Year - sibling.YOB.Value)
                                    {
                                        if (sibling.YOB.Value != 999)
                                        {
                                            ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].AGO", "Age of onset cannot be greater than the current year minus the birth year");
                                        }
                                    }
                                }
                            }

                        }
                    }
                }

                if (A3.Children != null)
                {
                    foreach (var child in A3.Children)
                    {
                        if (child != null)
                        {
                            if (child.YOB.HasValue)
                            {
                                if (!child.AGD.HasValue)
                                {
                                    ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].AGD", "Please provide a value for age at death.");
                                }
                                if (child.AGD.HasValue && child.AGD.Value > DateTime.Now.Year - child.YOB.Value)
                                {
                                    if (child.AGD.Value != 999 && child.AGD.Value != 888)
                                    {
                                        ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].AGD", "Age of death cannot be greater than the current year minus the birth year");
                                    }
                                }
                            }

                            if (child.YOB.HasValue || child.AGD.HasValue)

                            {
                                if (child.ETPR == null)
                                {
                                    ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].ETPR", "Please provide a value for primary dx.");
                                }
                            }
                            if (child.ETPR != null)
                            {
                                if (child.ETPR != "00" && child.ETPR != "99")
                                {
                                    if (child.ETSEC == null)
                                    {
                                        ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].ETSEC", "Please provide a value for secondary dx.");
                                    }
                                    if (!child.MEVAL.HasValue)
                                    {
                                        ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].MEVAL", "Please provide a value for method of evaluation.");
                                    }
                                    if (!child.AGO.HasValue)
                                    {
                                        ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].AGO", "Please provide a value for age of onset.");
                                    }
                                }
                                if (child.AGO.HasValue && child.AGD.HasValue && child.AGO.Value > child.AGD.Value)
                                {
                                    if (child.AGO.Value != 999 && child.AGO.Value != 888)
                                    {
                                        ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].AGO", "Age of onset cannot be greater than age of death");
                                    }
                                }
                                if (child.YOB.HasValue && child.AGO.HasValue && child.AGO.Value > DateTime.Now.Year - child.YOB.Value)
                                {
                                    if (child.YOB.Value != 999)
                                    {
                                        ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].AGO", "Age of onset cannot be greater than the current year minus the birth year");
                                    }
                                }
                            }

                        }
                    }
                }
                return await base.OnPostAsync(id, goNext); // checks for validation, etc.

            }
            return await base.OnPostAsync(id, goNext);
        }
    }
}
