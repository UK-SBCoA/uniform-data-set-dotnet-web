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

        public A3Model(IVisitService visitService) : base(visitService, "A3")
        {
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
        public new async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = A3; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A3); // visit needs updated form as well

            if (A3 != null && A3.Status == FormStatus.Finalized)
            {
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
                            }

                        }
                    }
                }
                return await base.OnPostAsync(id); // checks for validation, etc.

            }
            return await base.OnPostAsync(id);
        }
    }
}
