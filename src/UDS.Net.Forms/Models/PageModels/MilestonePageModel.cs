using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                ValidateMonth(milestone.CHANGEMO, "Milestone.CHANGEMO");
                ValidateDay(milestone.CHANGEDY, "Milestone.CHANGEDY");
                ValidateYear(milestone.CHANGEYR, "Milestone.CHANGEYR");

                if (milestone.PROTOCOL == null)
                {
                    ModelState.AddModelError("Milestone.PROTOCOL", "Must have a value when indicating continued contact");
                }

                if (milestone.PROTOCOL == 2 || milestone.PROTOCOL == 1)
                {
                    if (milestone.ACONSENT == null)
                    {
                        ModelState.AddModelError("Milestone.ACONSENT", "Autopsy status required");
                    }
                }

                if (milestone.RECOGIM == false && milestone.REPHYILL == false && milestone.REREFUSE == false && milestone.RENAVAIL == false && milestone.RENURSE == false && milestone.REJOIN == false)
                {
                    ModelState.AddModelError("Milestone.ProtocolReasonValidation", "Must select AT LEAST ONE reason for change as indicated in 2a");
                }

                if (milestone.RENURSE == true)
                {
                    ValidateMonth(milestone.NURSEMO, "Milestone.NURSEMO");
                    ValidateDay(milestone.NURSEDY, "Milestone.NURSEDY");
                    ValidateYear(milestone.NURSEYR, "Milestone.NURSEYR");
                }

                if (milestone.FTLDREAS == 4 && String.IsNullOrEmpty(milestone.FTLDREAX))
                {
                    ModelState.AddModelError("Milestone.FTLDREAX", "Must have a value when indicating reason of other");
                }
            }

            if (milestone.MILESTONETYPE == 0)
            {
                if (milestone.DECEASED == false && milestone.DISCONT == false)
                {
                    ModelState.AddModelError("Milestone.DECEASED", "When indicating no further contact, Deceased OR Discontinued must be select");
                    ModelState.AddModelError("Milestone.DISCONT", "When indicating no further contact, Deceased OR Discontinued must be select");
                }

                if (milestone.DECEASED == true)
                {
                    ValidateMonth(milestone.DEATHMO, "Milestone.DEATHMO");
                    ValidateDay(milestone.DEATHDY, "Milestone.DEATHDY");
                    ValidateYear(milestone.DEATHYR, "Milestone.DEATHYR");

                    if (milestone.AUTOPSY == null)
                    {
                        ModelState.AddModelError("Milestone.AUTOPSY", "Must have a value");
                    }
                }

                if (milestone.DISCONT == true)
                {
                    ValidateMonth(milestone.DISCMO, "Milestone.DISCMO");
                    ValidateDay(milestone.DISCDAY, "Milestone.DISCDAY");
                    ValidateYear(milestone.DISCYR, "Milestone.DISCYR");

                    if (milestone.DROPREAS == null)
                    {
                        ModelState.AddModelError("Milestone.DROPREAS", "Must have a value");
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

        public async Task<IActionResult> OnGetAsync(int id, string createdBy, string modifiedBy)
        {
            // Check if this is the beginning of an create, details, or edit
            if (!String.IsNullOrWhiteSpace(createdBy))
            {
                // create new
                Milestone = new MilestoneModel()
                {
                    ParticipationId = id,
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

                // if edit set modifiedby and override title
                if (!String.IsNullOrWhiteSpace(modifiedBy))
                {
                    Milestone.ModifiedBy = User.Identity.Name;
                    PageTitle = "Edit milestone for ";
                }
            }

            var participation = await _participationService.GetById(User.Identity.Name, id, false);

            if (participation == null)
                return NotFound("No participation found.");

            Milestone.Participation = participation.ToVM();
            PageTitle += Milestone.Participation.LegacyId;

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
                // upsert based on the id
                if (Milestone.Id == 0)
                    await _milestoneService.Add(User.Identity.Name, Milestone.ToEntity());
                else
                    await _milestoneService.Update(User.Identity.Name, Milestone.ToEntity());

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

