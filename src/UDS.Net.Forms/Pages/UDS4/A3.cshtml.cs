using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UDS.Net.Forms.Extensions;
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

                // If packet type is follow-up and no ID is found (loading a new form), then load previous A3 form data
                if (A3.PacketKind == PacketKind.F && BaseForm.Id == 0)
                {
                    int countOfVisits = await _visitService.GetVisitCountByVersion(User.Identity!.Name!, Visit.ParticipationId, "4.0.0");

                    if (Visit.VISITNUM >= countOfVisits && countOfVisits > 1)
                    {
                        var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(User.Identity!.Name!, Visit.ParticipationId, Visit.VISITNUM - 1, "A3");

                        if (previousVisit != null)
                        {
                            var previousA3Form = previousVisit.Forms.Where(f => f.Kind == "A3").FirstOrDefault();

                            if (previousA3Form != null)
                            {
                                var previousFormModel = previousA3Form.ToVM();

                                A3 = (A3)previousFormModel;

                                A3 = A3.SetBaseProperties(A3, BaseForm);

                                //Set previous data provided questions to "no change" by default for new follow-up forms
                                A3.NWINFPAR = 0;
                                A3.NWINFKID = 0;
                                A3.NWINFSIB = 0;
                            }
                        }
                    }
                }
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = A3; // reassign bounded and derived form to base form for base method

            // DEVNOTE: adjusting follow-up properties here so the A3 Javascript can continue to run without knowing packetKind
            // If initial or initial for existing, follow-up properties will be null
            if (Visit.PACKET == PacketKind.I || Visit.PACKET == PacketKind.I4)
            {
                A3.NWINFPAR = null;
                A3.NWINFSIB = null;
                A3.NWINFKID = null;
            }

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
                return await base.OnPostAsync(id, goNext); // checks for validation, etc.

            }
            return await base.OnPostAsync(id, goNext);
        }
    }
}
