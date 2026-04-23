using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A4aModel : FormPageModel
    {
        [BindProperty]
        public A4a A4a { get; set; } = default!;

        public A4aTreatment A4ATreatment { get; set; }

        public List<RadioListItem> BiomarkerListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No (end form here)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown (end form here)", "9")
        };

        public Dictionary<string, UIBehavior> TRTBIOMARKUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ADVEVENT"),
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                    new UIDisableAttribute("A4a.NEWTREAT"),
                    new UIDisableAttribute("A4a.NEWADEVENT")
                },
                InstructionalMessage = "END FORM HERE"
            } },
            { "1", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A4a.ADVEVENT"),
                    new UIEnableAttribute("A4a.NEWTREAT"),
                    new UIEnableAttribute("A4a.NEWADEVENT"),
                },
            } },
            { "9", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ADVEVENT"),
                    new UIDisableAttribute("A4a.NEWTREAT"),
                    new UIDisableAttribute("A4a.NEWADEVENT"),
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                },
                InstructionalMessage = "END FORM HERE"
            }
            }
        };
        public Dictionary<string, UIBehavior> NEWTREATUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ADVEVENT"),
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                    new UIDisableAttribute("A4a.NEWADEVENT")
                },
                InstructionalMessage = "END FORM HERE"
            } },
            { "1", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A4a.ADVEVENT"),
                    new UIEnableAttribute("A4a.NEWADEVENT"),
                },
            } },
            { "9", new UIBehavior{
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ADVEVENT"),
                    new UIDisableAttribute("A4a.NEWADEVENT"),
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                },
                InstructionalMessage = "END FORM HERE"
            }
            }
        };

        public Dictionary<string, UIBehavior> ADVEVENTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                    new UIDisableAttribute("A4a.NEWADEVENT")
                },
                InstructionalMessage = "END FORM HERE"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A4a.ARIAE"),
                    new UIEnableAttribute("A4a.ARIAH"),
                    new UIEnableAttribute("A4a.ADVERSEOTH"),
                    new UIEnableAttribute("A4a.NEWADEVENT")
                },
                InstructionalMessage = ""
            } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                    new UIDisableAttribute("A4a.NEWADEVENT")
                },
                InstructionalMessage = ""
            } }
        };

        public Dictionary<string, UIBehavior> NEWADVEVENTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                },
                InstructionalMessage = "END FORM HERE"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A4a.ARIAE"),
                    new UIEnableAttribute("A4a.ARIAH"),
                    new UIEnableAttribute("A4a.ADVERSEOTH"),
                },
                InstructionalMessage = ""
            } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A4a.ARIAE"),
                    new UIDisableAttribute("A4a.ARIAH"),
                    new UIDisableAttribute("A4a.ADVERSEOTH"),
                    new UIDisableAttribute("A4a.ADVERSEOTX"),
                },
                InstructionalMessage = ""
            } }
        };

        public async Task CompareValuesFromPreviousVisit(int participationId)
        {
            int countOfVisits = await _visitService.GetVisitCountByVersion(User.Identity?.Name!, participationId, "4.0.0");

            if (Visit.VISITNUM < countOfVisits || countOfVisits == 1)
                return;

            var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(User.Identity?.Name, participationId, Visit.VISITNUM - 1, "A4a");

            if (previousVisit == null)
                return;

            var currentA4a = BaseForm.ToEntity();

            var previousA4a = previousVisit.Forms.Where(f => f.Kind == "A4a").FirstOrDefault();

            var previousA4aFields = previousA4a?.Fields as A4aFormFields;
            var currentA4aFields = currentA4a.Fields as A4aFormFields;

            if (previousA4aFields == null || currentA4aFields == null)
                return;
            bool allValuesMatch = true;
            foreach (var fields in previousA4aFields.GetType().GetProperties())
            {
                var prevValue = fields.GetValue(previousA4aFields);
                var currentValue = fields.GetValue(currentA4aFields);
                if (!object.Equals(prevValue, currentValue))
                {
                    allValuesMatch = false;
                    break;
                }
            }
            if (allValuesMatch)
            {
                ModelState.AddModelError("A4a.NEWTREAT", "If NEWTREAT has a value of 1, treatment responses must differ from previous visit");
            }
            return;
        }

        public A4aModel(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base(visitService, participationService, packetService, "A4a")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A4a = (A4a)BaseForm;
            }

            if (A4a.PacketKind == PacketKind.F && BaseForm.Id == 0)
            {

                int countOfVisits = await _visitService.GetVisitCountByVersion(
                    User.Identity!.Name!,
                    Visit.ParticipationId,
                    "4.0.0");

                if (Visit.VISITNUM >= countOfVisits && countOfVisits > 1)
                {
                    var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(
                        User.Identity!.Name!,
                        Visit.ParticipationId,
                        Visit.VISITNUM - 1,
                        "A4a");

                    if (previousVisit != null)
                    {
                        var previousA4aForm = previousVisit.Forms
                            .Where(f => f.Kind == "A4a")
                            .FirstOrDefault();

                        if (previousA4aForm != null)
                        {
                            var previousFormModel = previousA4aForm.PreviousVisitToVM();

                            A4a = (A4a)previousFormModel;

                            A4a.SetBaseProperties(BaseForm);
                        }
                    }
                }
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = A4a; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A4a); // visit needs updated form as well

            if (A4a.NEWTREAT != null && A4a.NEWTREAT == 1)
            {
                await CompareValuesFromPreviousVisit(Visit.ParticipationId);
            }
            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
