using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class B8Model : FormPageModel
    {
        [BindProperty]
        public B8 B8 { get; set; } = default!;

        public List<RadioListItem> FindingsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No abnormal findings (END FORM HERE)", "0"),
            new RadioListItem("Yes - abnormal findings were consistent with syndromes listed in Questions 2–8", "1"),
            new RadioListItem("Yes - abnormal findings were consistent with age-associated changes or irrelevant to dementing disorders (e.g., Bell's palsy) (SKIP TO QUESTION 8)", "2")
        };

        public List<RadioListItem> SyndromePresentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> AssessmentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Yes", "1"),
            new RadioListItem("No", "0"),
            new RadioListItem("Not assessed", "8")
        };

        public B8Model(IVisitService visitService) : base(visitService, "B8")
        {
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            await base.OnGet(id);

            return Page();
        }
    }
}
