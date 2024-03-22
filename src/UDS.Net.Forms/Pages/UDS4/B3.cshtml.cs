using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class B3Model : FormPageModel
    {
        [BindProperty]
        public B3 B3 { get; set; } = default!;

        public List<RadioListItem> SpeechListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal", "0"),
            new RadioListItem("Slight loss of expression, diction and/or volume", "1"),
            new RadioListItem("Monotone, slurred but understandable; moderately impaired", "2"),
            new RadioListItem("Marked impairment, difficult to understand", "3"),
            new RadioListItem("Unintelligible", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> FACEXPListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal", "0"),
            new RadioListItem("Minimal hypomimia, could be normal “poker face”", "1"),
            new RadioListItem("Slight but definitely abnormal diminution of facial expression", "2"),
            new RadioListItem("Moderate hypomimia; lips parted some of the time", "3"),
            new RadioListItem("Masked or fixed facies with severe or complete loss of facial expression; lips parted ¼ inches or more", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> TremorListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Slight and infrequently present", "1"),
            new RadioListItem("Mild in amplitude and persistent; or moderate in amplitude, but only intermittently present", "2"),
            new RadioListItem("Moderate in amplitude and present most of the time", "3"),
            new RadioListItem("Marked in amplitude and present most of the time", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> HandListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Slight; present with action", "1"),
            new RadioListItem("Moderate in amplitude, present with action", "2"),
            new RadioListItem("Moderate in amplitude with posture holding as well as action", "3"),
            new RadioListItem("Marked in amplitude; interferes with feeding", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> RigidityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Slight or detectable only when activated by mirror or other movements", "1"),
            new RadioListItem("Mild to moderate", "2"),
            new RadioListItem("Marked, but full range of motion easily achieved", "3"),
            new RadioListItem("Severe; range of motion achieved with difficulty", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> FingerListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> HandMovementsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> RapidHandsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> LegListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> ArisingListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Slow; or may need more than one attempt", "1"),
            new RadioListItem("Pushes self up from arms of seat.", "2"),
            new RadioListItem(" Tends to fall back and may have to try more than one time, but can get up without help", "3"),
            new RadioListItem("Unable to arise without help.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> PostureListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Not quite erect, slightly stooped posture; could be normal for older person", "1"),
            new RadioListItem("Moderately stooped posture, definitely abnormal; can be slightly leaning to one side", "2"),
            new RadioListItem("Severely stooped posture with kyphosis; can be moderately leaning to one side", "3"),
            new RadioListItem("Marked flexion with extreme abnormality of posture", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> GaitListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Walks slowly; may shuffle with short steps, but no festination (hastening steps) or propulsion", "1"),
            new RadioListItem("Walks with difficulty, but requires little or no assistance; may have some festination, short steps, nor propulsion", "2"),
            new RadioListItem("Severe disturbance of gait requiring assistance", "3"),
            new RadioListItem("Cannot walk at all, even with assistance", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> PostureStabilityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal erect", "0"),
            new RadioListItem("Retropulsion, but recovers unaided", "1"),
            new RadioListItem("Absence of postural response; would fall if not caught by examiner", "2"),
            new RadioListItem("Very unstable, tends to lose balance spontaneously", "3"),
            new RadioListItem("Unable to stand without assistance", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public List<RadioListItem> BodyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("None", "0"),
            new RadioListItem("Minimal slowness, giving movement a deliberate character; could be normal for some persons; possibly reduced amplitude", "1"),
            new RadioListItem("Mild degree of slowness and poverty of movement which is definitely abnormal; alternatively, some reduced amplitude", "2"),
            new RadioListItem("Moderate slowness, poverty or small amplitude of movement", "3"),
            new RadioListItem("Marked slowness, poverty or small amplitude of movement", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public B3Model(IVisitService visitService) : base(visitService, "B3")
        {
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B3 = (B3)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = B3;

            Visit.Forms.Add(B3);

            return await base.OnPostAsync(id); // checks for domain-level business rules validation
        }

    }
}
