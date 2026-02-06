using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Dto;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Models.PageModels
{
    public class MilestonePageModel : PageModel
    {
        protected readonly IMilestoneService _milestoneService;
        protected readonly IParticipationService _participationService;

        [BindProperty]
        public MilestoneModel? Milestone { get; set; }

        public string PageTitle { get; set; }

        public List<M1Dto> M1Submissions { get; set; } = new List<M1Dto>();
        public MilestonePageModel(IMilestoneService milestoneService, IParticipationService participationService)
        {
            _milestoneService = milestoneService;
            _participationService = participationService;
        }

        // TODO Move this to NotMapped properties in the view model and use custom annotations for required if
        protected private void Validate(MilestoneModel milestone)
        {
            if (milestone.MILESTONETYPE == 1)
            {
                ValidateMonth(milestone.CHANGEMO, "CHANGEMO");
                ValidateDay(milestone.CHANGEDY, "CHANGEDY");
                ValidateYear(milestone.CHANGEYR, "CHANGEYR");

                if (milestone.PROTOCOL == null)
                {
                    ModelState.AddModelError("PROTOCOL", "Must have a value when indicating continued contact");
                }

                if (milestone.PROTOCOL == 2 || milestone.PROTOCOL == 1)
                {
                    if (milestone.ACONSENT == null)
                    {
                        ModelState.AddModelError("ACONSENT", "Autopsy status required");
                    }
                }

                if (milestone.RECOGIM == false && milestone.REPHYILL == false && milestone.REREFUSE == false && milestone.RENAVAIL == false && milestone.RENURSE == false && milestone.REJOIN == false)
                {
                    ModelState.AddModelError("ProtocolReasonValidation", "Must select AT LEAST ONE reason for change as indicated in 2a");
                }

                if (milestone.RENURSE == true)
                {
                    ValidateMonth(milestone.NURSEMO, "NURSEMO");
                    ValidateDay(milestone.NURSEDY, "NURSEDY");
                    ValidateYear(milestone.NURSEYR, "NURSEYR");
                }

                if (milestone.FTLDREAS == 4 && String.IsNullOrEmpty(milestone.FTLDREAX))
                {
                    ModelState.AddModelError("FTLDREAX", "Must have a value when indicating reason of other");
                }
            }

            if (milestone.MILESTONETYPE == 0)
            {
                if (milestone.DECEASED == false && milestone.DISCONT == false)
                {
                    ModelState.AddModelError("DECEASED", "When indicating no further contact, Deceased OR Discontinued must be select");
                    ModelState.AddModelError("DISCONT", "When indicating no further contact, Deceased OR Discontinued must be select");
                }

                if (milestone.DECEASED == true)
                {
                    ValidateMonth(milestone.DEATHMO, "DEATHMO");
                    ValidateDay(milestone.DEATHDY, "DEATHDY");
                    ValidateYear(milestone.DEATHYR, "DEATHYR");

                    if (milestone.AUTOPSY == null)
                    {
                        ModelState.AddModelError("AUTOPSY", "Must have a value");
                    }
                }

                if (milestone.DISCONT == true)
                {
                    ValidateMonth(milestone.DISCMO, "DISCMO");
                    ValidateDay(milestone.DISCDAY, "DISCDAY");
                    ValidateYear(milestone.DISCYR, "DISCYR");

                    if (milestone.DROPREAS == null)
                    {
                        ModelState.AddModelError("DROPREAS", "Must have a value");
                    }
                }
            }
        }

        private void ValidateMonth(int? monthValue, string property)
        {
            if (monthValue == null)
            {
                ModelState.AddModelError(property, "Must have a value for month");
            }

            if (monthValue < 1 || monthValue > 12 && monthValue != 99)
            {
                ModelState.AddModelError(property, "Provide a valid month between 1 - 12 or 99");
            }
        }

        private void ValidateDay(int? dayValue, string property)
        {
            if (dayValue == null)
            {
                ModelState.AddModelError(property, "Must have a value for day");
            }

            if (dayValue < 1 || dayValue > 31 && dayValue != 99)
            {
                ModelState.AddModelError(property, "Provide a valid day between 1 - 31 or 99");
            }
        }

        private void ValidateYear(int? yearValue, string property)
        {
            if (yearValue == null)
            {
                ModelState.AddModelError(property, "Must have a value for year");
            }

            if (yearValue < 2015 || yearValue > 2999)
            {
                ModelState.AddModelError(property, "Provide a valid year between 2015 - 2999");
            }
        }

        public async Task<IActionResult> OnGetAsync(int id, int? participationId)
        {
            // Check if this is the beginning of an create, details, or edit
            if (id == 0)
            {
                // create new
                if (!participationId.HasValue)
                    return NotFound("Requires participation id");

                Milestone = new MilestoneModel()
                {
                    ParticipationId = participationId.Value,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = User.Identity!.IsAuthenticated ? User.Identity.Name : "Username",
                    IsDeleted = false
                };
                PageTitle = "Create milestone for ";
            }
            else
            {
                // find existing for details or edit
                var milestoneFound = await _milestoneService.GetById(User.Identity.Name, id);

                if (milestoneFound == null)
                {
                    return NotFound("No milestone found.");
                }
                Milestone = milestoneFound.ToVM();
                PageTitle = "Milestone for ";

                // set modifiedby in case it is for editing
                Milestone.ModifiedBy = User.Identity.Name;
            }

            var participation = await _participationService.GetById(User.Identity.Name, Milestone.ParticipationId, false);

            if (participation == null)
                return NotFound("No participation found.");

            Milestone.Participation = participation.ToVM();
            PageTitle += "Participant " + Milestone.Participation.LegacyId;

            M1Submissions = await _milestoneService.FindByLegacyId(
                User.Identity.Name,
                Milestone.Participation.LegacyId,
                new string[] { }
            );

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (Milestone == null)
            {
                return Page();
            }

            Validate(Milestone);

            if (ModelState.IsValid)
            {
                var milestone = Milestone.ToEntity();
                // upsert based on the id
                if (Milestone.Id == 0)
                    await _milestoneService.Add(User.Identity.Name, milestone);
                else
                    await _milestoneService.Update(User.Identity.Name, milestone);

                return RedirectToPage("/Participations/Details", new { Id = Milestone.ParticipationId });
            }

            var participation = await _participationService.GetById(User.Identity.Name, Milestone.ParticipationId, false);

            if (participation == null)
                return NotFound();

            Milestone.Participation = participation.ToVM();

            return Page();
        }
    }
}

