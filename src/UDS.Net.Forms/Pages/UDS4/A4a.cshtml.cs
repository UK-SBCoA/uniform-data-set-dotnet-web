using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
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

            if (Visit.PACKET == PacketKind.F)
            {
                var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(User.Identity?.Name, Visit.ParticipationId, Visit.VISITNUM - 1, "A4a");

                var currentA4a = A4a;

                var previousA4a = previousVisit.Forms
                    .Where(f => f.Kind == "A4a")
                    .Select(f => ((A4a)f.ToVM()))
                    .FirstOrDefault();

                List<A4aTreatment> currentTreatments = A4a.Treatments;
                List<A4aTreatment> previousTreatments = previousA4a?.Treatments ?? new List<A4aTreatment>();

                if (A4a.TRTBIOMARK != 1)
                {
                    if (previousA4a!.TRTBIOMARK == 1)
                    {
                        ModelState.AddModelError("A4a.TRTBIOMARK", "If previous visit indicated a treatment or clincial trial that was expected to modify biomarkers, then must response be marked as \"Yes\".");
                    }
                }

                if (A4a.NEWTREAT != null)
                {
                    bool newTreatmentInformation = A4a.NEWTREAT == 1;
                    bool newAdverseEventInformartion = A4a.NEWADEVENT == 1;

                    bool treatmentValuesMatch = true;
                    foreach (var treatment in currentTreatments)
                    {
                        var previousTreatment = previousTreatments.FirstOrDefault(pt => pt.TreatmentIndex == treatment.TreatmentIndex);

                        if (!treatment.TreatmentMatchesPreviousVisit(previousTreatment, treatment))
                        {
                            treatmentValuesMatch = false;
                            break;
                        }
                    }

                    var adverseEventValuesMatch = AdverseEventsMatchPreviousVisit(previousA4a!, currentA4a!);

                    if (newTreatmentInformation && newAdverseEventInformartion)
                    {
                        if (treatmentValuesMatch && adverseEventValuesMatch)
                        {
                            ModelState.AddModelError("A4a", "If both NEWTREAT and NEWADEVENT are marked as 1 all treatment values cannot match previous visit");
                        }
                    }
                    if (newTreatmentInformation && !newAdverseEventInformartion)
                    {
                        if (treatmentValuesMatch)
                        {
                            ModelState.AddModelError("A4a.NEWTREAT", "Treatment values cannot match previous visit if new information is avaiable");
                        }
                    }

                    if (!newTreatmentInformation)
                    {
                        A4a.Treatments = previousTreatments;
                    }
                    if (!newAdverseEventInformartion)
                    {
                        A4a.ARIAE = previousA4a.ARIAE;
                        A4a.ARIAH = previousA4a.ARIAH;
                        A4a.ADVERSEOTH = previousA4a.ADVERSEOTH;
                        A4a.ADVERSEOTX = previousA4a.ADVERSEOTX;
                    }
                    Visit.Forms.Add(A4a);

                    return await base.OnPostAsync(id, goNext); // checks for validation, etc.
                }
            }
            Visit.Forms.Add(A4a); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
        public bool AdverseEventsMatchPreviousVisit(A4a previousA4aFields, A4a currentA4aFields)
        {
            if (previousA4aFields == null || currentA4aFields == null)
                return false;

            foreach (var prop in previousA4aFields.GetType().GetProperties())
            {
                if (prop.Name == nameof(A4a.ARIAE) || prop.Name == nameof(A4a.ARIAH) || prop.Name == nameof(A4a.ADVERSEOTH) || prop.Name == nameof(A4a.ADVERSEOTX))
                {
                    var prevValue = prop.GetValue(previousA4aFields);
                    var currentValue = prop.GetValue(currentA4aFields);

                    if (!object.Equals(prevValue, currentValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
