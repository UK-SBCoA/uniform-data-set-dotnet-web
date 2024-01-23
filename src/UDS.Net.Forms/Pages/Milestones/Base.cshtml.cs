using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class BaseModel : PageModel
    {
        protected readonly IParticipationService _participationService;

        [BindProperty]
        public MilestoneModel? Milestone { get; set; }

        public BaseModel(IParticipationService participationService)
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

        public List<RadioListItem> SimpleYesNoRadio { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> AutopsyItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No ADC autopsy expected", "0"),
            new RadioListItem("An ADC autopsy has been done; data submitted or pending", "1")
        };

        public List<RadioListItem> DropReasonItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("ADC decision or protocol", "1"),
            new RadioListItem("Participant or co-paprticipant asked to be dropped", "2")
        };

        public List<RadioListItem> FTLDREASItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("ADC decision", "1"),
            new RadioListItem("Participant/informant refused", "2"),
            new RadioListItem("Informant not available", "3"),
            new RadioListItem("Other, specify below", "4")
        };

        public Dictionary<string, UIBehavior> ProtocolBehavior = new Dictionary<string, UIBehavior>
        {
            {
                "3", new UIBehavior
                {
                    PropertyAttributes = new List<UIPropertyAttributes>
                    {
                        new UIEnableAttribute("Milestone.ACONSENT")
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
                        new UIDisableAttribute("Milestone.ACONSENT")
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

        public void Isvalid(MilestoneModel milestone)
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

                if (milestone.PROTOCOL == 3 && milestone.ACONSENT == null)
                {
                    ModelState.AddModelError("Milestone.ACONSENT", "Must have a value when indicating continued contact");
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
                ModelState.AddModelError(property, "Must have a value of 1 - 12 or 99 for month");
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
                ModelState.AddModelError(property, "Must have a value of 1 - 31 or 99 for day");
            }
        }

        private void ValidateYear(int? yearValue, string property)
        {
            if (yearValue == null)
            {
                ModelState.AddModelError(property, "Must have a value for year");
            }

            if (yearValue < 1000 || yearValue > 9999 && yearValue != 9999)
            {
                ModelState.AddModelError(property, "Must have a valid value or 9999 for year");
            }
        }
    }
}
