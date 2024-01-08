using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

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
            new RadioListItem("NO FURTHER CONTACT", "0"),
            new RadioListItem("CONTINUED CONTACT", "1"),
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
            new RadioListItem("Subject or co-paprticipant asked to be dropped", "2")
        };

        public List<RadioListItem> FTLDREASItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("ADC decision", "1"),
            new RadioListItem("Subject/informant refused", "2"),
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
            if(milestone.MilestoneType == 1)
            {
                if(milestone.CHANGEMO == null)
                {
                    ModelState.AddModelError("Milestone.CHANGEMO", "Must have a value when indicating continued contact");
                }

                if (milestone.CHANGEDY == null)
                {
                    ModelState.AddModelError("Milestone.CHANGEDY", "Must have a value when indicating continued contact");
                }

                if (milestone.CHANGEYR == null)
                {
                    ModelState.AddModelError("Milestone.CHANGEYR", "Must have a value when indicating continued contact");
                }

                if (milestone.PROTOCOL == null)
                {
                    ModelState.AddModelError("Milestone.PROTOCOL", "Must have a value when indicating continued contact");
                }

                if(milestone.PROTOCOL == 3 && milestone.ACONSENT == null)
                {
                    ModelState.AddModelError("Milestone.ACONSENT", "Must have a value when indicating continued contact");
                }

                if(milestone.RECOGIM == false && milestone.REPHYILL == false && milestone.REREFUSE == false && milestone.RENAVAIL == false && milestone.RENURSE == false && milestone.REJOIN == false)
                {
                    ModelState.AddModelError("Milestone.ProtocolReasonValidation", "Must select AT LEAST ONE reason for change as indicated in 2a");
                }

                if(milestone.RENURSE == true)
                {
                    if(milestone.NURSEMO == null)
                    {
                        ModelState.AddModelError("Milestone.NURSEMO", "Must have a value if subject has entered a nursing home");
                    }

                    if(milestone.NURSEDY == null)
                    {
                        ModelState.AddModelError("Milestone.NURSEDY", "Must have a value if subject has entered a nursing home");
                    }

                    if(milestone.NURSEYR == null)
                    {
                        ModelState.AddModelError("Milestone.NURSEYR", "Must have a value if subject has entered a nursing home");
                    }
                }

                if(milestone.FTLDREAS == 4 &&  String.IsNullOrEmpty(milestone.FTLDREAX))
                {
                    ModelState.AddModelError("Milestone.FTLDREAX", "Must have a value when indicating reason of other");
                }
            }

            if(milestone.MilestoneType == 0)
            {
                if(milestone.DECEASED == true)
                {
                    if(milestone.DEATHMO == null)
                    {
                        ModelState.AddModelError("Milestone.DEATHMO", "Must have a value");
                    }

                    if (milestone.DEATHDY == null)
                    {
                        ModelState.AddModelError("Milestone.DEATHDY", "Must have a value");
                    }

                    if (milestone.DEATHYR == null)
                    {
                        ModelState.AddModelError("Milestone.DEATHYR", "Must have a value");
                    }

                    if (milestone.AUTOPSY == null)
                    {
                        ModelState.AddModelError("Milestone.AUTOPSY", "Must have a value");
                    }
                }

                if(milestone.DISCONT == true)
                {
                    if (milestone.DISCMO == null)
                    {
                        ModelState.AddModelError("Milestone.DISCMO", "Must have a value");
                    }

                    if (milestone.DISCDAY == null)
                    {
                        ModelState.AddModelError("Milestone.DISCDAY", "Must have a value");
                    }

                    if (milestone.DISCYR == null)
                    {
                        ModelState.AddModelError("Milestone.DISCYR", "Must have a value");
                    }

                    if (milestone.DROPREAS == null)
                    {
                        ModelState.AddModelError("Milestone.DROPREAS", "Must have a value");
                    }
                }
            }
        }
    }
}
