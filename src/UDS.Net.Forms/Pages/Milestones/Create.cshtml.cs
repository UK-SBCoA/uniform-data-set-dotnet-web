using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.Milestones
{
	public class CreateModel : PageModel
    {
        [BindProperty]
        public MilestoneModel? Milestone { get; set; }

        public int participationId { get; set; } 

        public async Task<IActionResult> OnGet(int participationId)
        {
            MilestoneModel newMilstone = new MilestoneModel()
            {
                ParticipationId = participationId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity!.IsAuthenticated ? User.Identity.Name : "Username",
            };

            Milestone = newMilstone;

            return Page();
        }

        public List<RadioListItem> MilestoneTypeItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("CONTINUED CONTACT", "1"),
            new RadioListItem("NO FURTHER CONTACT", "0"),
        };

        public List<RadioListItem> ProtocolItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Annual UDS follow-up by telephone (CONTINUE TO QUESTION 2A1)", "1"),
            new RadioListItem("Minimal contact (CONTINUE TO QUESTION 2A1)", "2"),
            new RadioListItem("Annual in-person UDS follow-up", "3")
        };

        public List<RadioListItem> AconsentItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };
    }
}
