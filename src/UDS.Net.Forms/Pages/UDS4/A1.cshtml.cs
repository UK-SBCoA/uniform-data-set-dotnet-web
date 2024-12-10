using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A1Model : FormPageModel
    {
        protected readonly ILookupService _lookupService;

        [BindProperty]
        public A1 A1 { get; set; } = default!;

        public List<RadioListItem> BIRTHSEXListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Male", "1"),
            new RadioListItem("Female", "2"),
            new RadioListItem("Don't know", "9"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> INTERSEXListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Don't know", "9"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> PREDOMLANListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("English", "1"),
            new RadioListItem("Spanish", "2"),
            new RadioListItem("Chinese dialect", "3"),
            new RadioListItem("Other (specify)", "8"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> HANDEDListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Left-handed", "1"),
            new RadioListItem("Right-handed", "2"),
            new RadioListItem("Ambidextrous", "3"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> LVLEDUCListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Less than high school", "1"),
            new RadioListItem("High school or GED", "2"),
            new RadioListItem("Some college", "3"),
            new RadioListItem("Bachelor's degree", "4"),
            new RadioListItem("Master's degree", "5"),
            new RadioListItem("Doctorate", "6"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> MARISTATListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Married", "1"),
            new RadioListItem("Widowed", "2"),
            new RadioListItem("Divorced", "3"),
            new RadioListItem("Seperated", "4"),
            new RadioListItem("Never married (or marriage was annulled)", "5"),
            new RadioListItem("Living as marrieed/domestic partner", "6"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> LIVSITUAListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Live alone", "1"),
            new RadioListItem("Live with one other person: a spouse or partner", "2"),
            new RadioListItem("Live with one other person: a relative, friend, or roommate", "3"),
            new RadioListItem("Live with cargiver who is not spouse /partner, relative, or friend", "4"),
            new RadioListItem("Live with a group (related or not related) in a private residence", "5"),
            new RadioListItem("Live in a group home (e.g., assisted living, nursing home, convent)", "6"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> RESIDENCListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Single- or multi-family private residence (apartment, condo, house)", "1"),
            new RadioListItem("Retirement community or independent group living", "2"),
            new RadioListItem("Assisted living, adult family home, or boarding home", "3"),
            new RadioListItem("Skilled nursing facility, nursing home, hospital, or hospice", "4"),
            new RadioListItem("Do not have housing (e.g., staying with others, in a hotel, in a shelter, living\noutside on the street, on a beach, in a car, or in a park)", "6"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> SERVEDListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No (IF NO, SKIP TO QUESTION 17)", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Don't know", "9"),
        };

        public List<RadioListItem> MEDVAListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Don't know", "9"),
        };

        public List<RadioListItem> EXRTIMEListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("None", "1"),
            new RadioListItem("1 hour or less", "2"),
            new RadioListItem("2.5 hours or less", "3"),
            new RadioListItem("More than 2.5 hours", "4"),
            new RadioListItem("Prefer not to answer", "8"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> MEMWORSListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes, but this does not worry me", "1"),
            new RadioListItem("Yes, and this worries me", "2"),
            new RadioListItem("Don't know / Prefer not to answer", "9")
        };

        public List<RadioListItem> MEMTROUBListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Never", "1"),
            new RadioListItem("Rarely", "2"),
            new RadioListItem("Sometimes", "3"),
            new RadioListItem("Often", "4"),
            new RadioListItem("Much worse", "5"),
            new RadioListItem("Don't know / Prefer not to answer", "9")
        };

        public List<RadioListItem> MEMTENListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Much better", "1"),
            new RadioListItem("A little better", "2"),
            new RadioListItem("The same", "3"),
            new RadioListItem("A little worse", "4"),
            new RadioListItem("Very often ", "5"),
            new RadioListItem("Don't know / Prefer not to answer", "9")
        };

        public List<RadioListItem> EnrollmentTypesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Participant is supported primarily by ADRC funding (Clinical Core, Satellite Core, or other ADRC Core or project) ", "1"),
            new RadioListItem("Participant is supported primarily by a non-ADRC study (e.g., R01, including non-ADRC grants supporting FTLD Module participation))", "2")
        };


        public List<RadioListItem> ReferralSourcesListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Self", "1"),
            new RadioListItem("Non-professional personal contact who is not a current or previous ADRC participant (e.g.,spouse/partner, relative, friend, coworker)", "2"),
            new RadioListItem("Current or previous ADRC participant (END FORM HERE)", "3"),
            new RadioListItem("ADRC clinician, staff, or investigator (END FORM HERE)", "4"),
            new RadioListItem("Non-ADRC healthcare professional (e.g., clinician, nurse, social worker) (END FORM HERE)", "5"),
            new RadioListItem("Other research study clinician/staff/investigator (non-ADRC; e.g., ADNI, Women's Health Initiative,\nLEADS, ALL-FTD) (END FORM HERE)", "6"),
            new RadioListItem("Other", "8"),
            new RadioListItem("Unknown (END FORM HERE)", "9")
        };

        public List<RadioListItem> REFLEARNEDListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("ADRC sponsored event", "1"),
            new RadioListItem("Event sponsored by an external organization (e.g., Alzheimer's Association event, institution sponsored venue, community health fair, professional conference)", "2"),
            new RadioListItem("Newsletter (mailed or digital)", "3"),
            new RadioListItem("Study flyer/brochure (mailed or digital)", "4"),
            new RadioListItem("Center website", "5"),
            new RadioListItem("Center social media", "6"),
            new RadioListItem("Center registry", "7"),
            new RadioListItem("Website", "8"),
            new RadioListItem("Media", "9"),
            new RadioListItem("Registry", "10"),
            new RadioListItem("Other (specify)", "88"),
            new RadioListItem("Unknown", "99")
        };

        public Dictionary<string, UIBehavior> LanguageUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1.PREDOMLANX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1.PREDOMLANX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1.PREDOMLANX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A1.PREDOMLANX")  } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1.PREDOMLANX") } }
        };

        public Dictionary<string, UIBehavior> SERVEDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1.MEDVA") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A1.MEDVA") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A1.MEDVA") } }
        };

        public Dictionary<string, UIBehavior> GENOTHBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1.GENOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A1.GENOTHX") } }
        };

        public Dictionary<string, UIBehavior> REFERSCUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFERSCX"),
                    new UIEnableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFERSCX"),
                    new UIEnableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFERSCX"),
                    new UIDisableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } },
            { "4", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFERSCX"),
                    new UIDisableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } },
            { "5", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFERSCX"),
                    new UIDisableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } },
            { "6", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFERSCX"),
                    new UIDisableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } },
            { "8", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A1.REFERSCX"),
                    new UIDisableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFERSCX"),
                    new UIDisableAttribute("A1.REFLEARNED")
                },
                InstructionalMessage = ""
            } }
        };


        public Dictionary<string, UIBehavior> REFLEARNEDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")

                },
                InstructionalMessage = ""
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")

                },
                InstructionalMessage = ""
            } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")

                },
                InstructionalMessage = ""
            } },
            { "4", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")

                },
                InstructionalMessage = ""
            } },
            { "5", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")

                },
                InstructionalMessage = ""
            } },
            { "6", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")

                },
                InstructionalMessage = "Please specify center social media"
            } },
            { "7", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIEnableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")
                },
                InstructionalMessage = "Please specify center registry"
            } },
            { "8", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIEnableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")
                },
                InstructionalMessage = "Please specify website"
            } },
            { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIEnableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")
                },
                InstructionalMessage = "Please specify media"
            } },
            { "10", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIEnableAttribute("A1.REFOTHREGX"),
                    new UIDisableAttribute("A1.REFOTHX")
                },
                InstructionalMessage = "Please specify other registry"
            } },
            { "88", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A1.REFCTRSOCX"),
                    new UIDisableAttribute("A1.REFCTRREGX"),
                    new UIDisableAttribute("A1.REFOTHWEBX"),
                    new UIDisableAttribute("A1.REFOTHMEDX"),
                    new UIDisableAttribute("A1.REFOTHREGX"),
                    new UIEnableAttribute("A1.REFOTHX")
                },
                InstructionalMessage = "Please specify other referral source"
            } }
        };

        public A1Model(IVisitService visitService, ILookupService lookupService) : base(visitService, "A1")
        {
            _lookupService = lookupService;
        }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A1 = (A1)BaseForm;
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = A1; // reassign bounded and derived form to base form for base method

            if (BaseForm.Status == FormStatus.Finalized)
            {
                if (A1.CHLDHDCTRY != null)
                {
                    var countryCode = await _lookupService.LookupCountryCode(A1.CHLDHDCTRY);

                    if (countryCode.Code == null)
                    {
                        ModelState.AddModelError("A1.CHLDHDCTRY", $"The country code \"{A1.CHLDHDCTRY}\" entered for question 2 ('CHLDHDCTRY') is invalid.");
                    }
                }
            }

            Visit.Forms.Add(A1); // visit needs updated form as well

            return await base.OnPostAsync(id); // checks for validation, etc.
        }
    }
}
