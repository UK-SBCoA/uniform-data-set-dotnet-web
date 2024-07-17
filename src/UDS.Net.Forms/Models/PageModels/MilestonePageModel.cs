using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Models.PageModels
{
    public class MilestonePageModel : PageModel
    {
        protected readonly IParticipationService _participationService;

        [BindProperty]
        public MilestoneModel? Milestone { get; set; }

        public MilestonePageModel(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        public List<RadioListItem> MilestoneTypeItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Data-collection status CHANGE followed by CONTINUED CONTACT with participant (Box A)", "1"),
            new RadioListItem("Change followed by NO FURTHER CONTACT with participant (Box B)", "0")
        };

        public List<RadioListItem> ProtocolItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Annual UDS follow-up by telephone (CONTINUE TO QUESTION 2A1)", "1"),
            new RadioListItem("Minimal contact (CONTINUE TO QUESTION 2A1)", "2"),
            new RadioListItem("Annual in-person UDS follow-up", "3")
        };

        public List<RadioListItem> AconsentItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No (CONTINUE TO QUESTION 2B)", "0"),
            new RadioListItem("Yes (CONTINUE TO QUESTION 2B)", "1")
        };

        public List<RadioListItem> AutopsyItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No ADC autopsy expected", "0"),
            new RadioListItem("An ADC autopsy has been done; data submitted or pending", "1")
        };

        public List<RadioListItem> DropReasonItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("ADC decision or protocol", "1"),
            new RadioListItem("Participant or co-participant asked to be dropped (ie. withdrawn)", "2")
        };

        public List<RadioListItem> FTLDREASItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("ADC decision", "1"),
            new RadioListItem("Participant/co-participant refused", "2"),
            new RadioListItem("Co-participant not available", "3"),
            new RadioListItem("Other, specify below", "4")
        };

        public Dictionary<string, UIBehavior> ProtocolBehavior = new Dictionary<string, UIBehavior>
        {
            {
                "3", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIDisableAttribute("Milestone.ACONSENT")
                    }
                }
            },
            {
                "1", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIDisableAttribute("Milestone.ACONSENT")
                    }
                }
            },
            {
                "2", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIEnableAttribute("Milestone.ACONSENT")
                    }
                }
            }
        };

        public Dictionary<string, UIBehavior> FTLDREASBehavior = new Dictionary<string, UIBehavior>
        {
            {
                "4", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIEnableAttribute("Milestone.FTLDREAX")
                    }
                }
            },
            {
                "1", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIDisableAttribute("Milestone.FTLDREAX")
                    }
                }
            },
            {
                "2", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIDisableAttribute("Milestone.FTLDREAX")
                    }
                }
            },
            {
                "3", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIDisableAttribute("Milestone.FTLDREAX")
                    }
                }
            },
        };

        public Dictionary<string, UIBehavior> DECEASEDBehavior = new Dictionary<string, UIBehavior>
        {
            {
                "true", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIEnableAttribute("Milestone.DEATHDY"),
                        new UIEnableAttribute("Milestone.DEATHYR"),
                        new UIEnableAttribute("Milestone.AUTOPSY"),
                        new UIDisableAttribute("Milestone.DISCDAY"),
                        new UIDisableAttribute("Milestone.DISCYR"),
                        new UIDisableAttribute("Milestone.DROPREAS")
                    }
                }
            },
            {
                "false", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIDisableAttribute("Milestone.DEATHDY"),
                        new UIDisableAttribute("Milestone.DEATHYR"),
                        new UIDisableAttribute("Milestone.AUTOPSY"),
                        new UIEnableAttribute("Milestone.DISCDAY"),
                        new UIEnableAttribute("Milestone.DISCYR"),
                        new UIEnableAttribute("Milestone.DROPREAS")
                    }
                }
            }
        };

        public Dictionary<string, UIBehavior> MilestoneTypeUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("Milestone.CHANGEMO"),
                    new UIEnableAttribute("Milestone.CHANGEDY"),
                    new UIEnableAttribute("Milestone.CHANGEYR"),
                    new UIEnableAttribute("Milestone.PROTOCOL"),
                    new UIEnableAttribute("Milestone.ACONSENT"),
                    new UIEnableAttribute("Milestone.RECOGIM"),
                    new UIEnableAttribute("Milestone.REPHYILL"),
                    new UIEnableAttribute("Milestone.REREFUSE"),
                    new UIEnableAttribute("Milestone.RENURSE"),
                    new UIEnableAttribute("Milestone.NURSEMO"),
                    new UIEnableAttribute("Milestone.NURSEDY"),
                    new UIEnableAttribute("Milestone.NURSEYR"),
                    new UIEnableAttribute("Milestone.REJOIN"),
                    new UIEnableAttribute("Milestone.FTLDDISC"),
                    new UIEnableAttribute("Milestone.FTLDREAS"),
                    new UIEnableAttribute("Milestone.FTLDREAX"),
                    new UIDisableAttribute("Milestone.DECEASED"),
                    new UIDisableAttribute("Milestone.DISCONT"),
                    new UIDisableAttribute("Milestone.DEATHMO"),
                    new UIDisableAttribute("Milestone.DEATHDY"),
                    new UIDisableAttribute("Milestone.DEATHYR"),
                    new UIDisableAttribute("Milestone.AUTOPSY"),
                    new UIDisableAttribute("Milestone.DISCMO"),
                    new UIDisableAttribute("Milestone.DISCDAY"),
                    new UIDisableAttribute("Milestone.DISCYR"),

                },
                InstructionalMessage = ""
            } },
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("Milestone.CHANGEMO"),
                    new UIDisableAttribute("Milestone.CHANGEDY"),
                    new UIDisableAttribute("Milestone.CHANGEYR"),
                    new UIDisableAttribute("Milestone.PROTOCOL"),
                    new UIDisableAttribute("Milestone.ACONSENT"),
                    new UIDisableAttribute("Milestone.RECOGIM"),
                    new UIDisableAttribute("Milestone.REPHYILL"),
                    new UIDisableAttribute("Milestone.REREFUSE"),
                    new UIDisableAttribute("Milestone.RENURSE"),
                    new UIDisableAttribute("Milestone.NURSEMO"),
                    new UIDisableAttribute("Milestone.NURSEDY"),
                    new UIDisableAttribute("Milestone.NURSEYR"),
                    new UIDisableAttribute("Milestone.REJOIN"),
                    new UIDisableAttribute("Milestone.FTLDDISC"),
                    new UIDisableAttribute("Milestone.FTLDREAS"),
                    new UIDisableAttribute("Milestone.FTLDREAX"),
                    new UIEnableAttribute("Milestone.DECEASED"),
                    new UIEnableAttribute("Milestone.DISCONT"),
                    new UIEnableAttribute("Milestone.DEATHMO"),
                    new UIEnableAttribute("Milestone.DEATHDY"),
                    new UIEnableAttribute("Milestone.DEATHYR"),
                    new UIEnableAttribute("Milestone.AUTOPSY"),
                    new UIEnableAttribute("Milestone.DISCMO"),
                    new UIEnableAttribute("Milestone.DISCDAY"),
                    new UIEnableAttribute("Milestone.DISCYR"),

                },
                InstructionalMessage = ""
            } },
        };

        protected private void IsValid(MilestoneModel milestone)
        {
            if (milestone.MilestoneType == 1)
            {
                ValidateMonth(milestone.CHANGEMO, "Milestone.CHANGEMO");
                ValidateDay(milestone.CHANGEDY, "Milestone.CHANGEDY");
                ValidateYear(milestone.CHANGEYR, "Milestone.CHANGEYR");

                if (milestone.PROTOCOL == null)
                {
                    ModelState.AddModelError("Milestone.PROTOCOL", "Must have a value when indicating continued contact");
                }

                if (milestone.PROTOCOL == 2 || milestone.PROTOCOL == 1 && milestone.ACONSENT == null)
                {
                    ModelState.AddModelError("Milestone.ACONSENT", "Autopsy status required");
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

            if (milestone.MilestoneType == 0)
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

            if (dayValue < 1 || dayValue > 12 && dayValue != 99)
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
    }
}

