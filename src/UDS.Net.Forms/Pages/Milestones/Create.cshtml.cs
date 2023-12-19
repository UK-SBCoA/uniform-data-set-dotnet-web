using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class CreateModel : PageModel
    {
        protected readonly IParticipationService _participationService;

        [BindProperty]
        public MilestoneModel? Milestone { get; set; }

        public int participationId { get; set; }

        public CreateModel(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGet(int participationId)
        {
            MilestoneModel newMilstone = new MilestoneModel()
            {
                ParticipationId = participationId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User.Identity!.IsAuthenticated ? User.Identity.Name : "Username",
                IsDeleted = false,
                // TODO setting status to complete for temp work
                Status = "Complete",
            };

            Milestone = newMilstone;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(Milestone == null)
            {
                return Page();
            }

            await _participationService.AddMilestone(User.Identity?.Name, participationId, Milestone.ToEntity());

            return RedirectToPage($"../Participations/Details/{Milestone.ParticipationId}");
        }

        public List<RadioListItem> MilestoneTypeItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("CONTINUED CONTACT", "1"),
            new RadioListItem("NO FURTHER CONTACT", "0"),
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

        public Dictionary<string, UIBehavior> MilestoneTypeBehavior = new Dictionary<string, UIBehavior>
        {
            {
                "0", new UIBehavior{
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
                        new UIDisableAttribute("Milestone.RENAVAIL"),
                        new UIDisableAttribute("Milestone.RENURSE"),
                        new UIDisableAttribute("Milestone.REJOIN"),
                        new UIDisableAttribute("Milestone.NURSEMO"),
                        new UIDisableAttribute("Milestone.NURSEDY"),
                        new UIDisableAttribute("Milestone.NURSEYR"),
                        new UIDisableAttribute("Milestone.FTLDDISC"),
                        new UIDisableAttribute("Milestone.FTLDREAS"),
                        new UIDisableAttribute("Milestone.FTLDREAX"),
                        new UIEnableAttribute("Milestone.DECEASED"),
                        new UIEnableAttribute("Milestone.DISCONT"),
                    },
                    InstructionalMessage = "skip to question 1F"
                }
            },
            {
            "1", new UIBehavior{
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
                        new UIEnableAttribute("Milestone.RENAVAIL"),
                        new UIEnableAttribute("Milestone.RENURSE"),
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
                        new UIDisableAttribute("Milestone.DROPREAS"),
                    },
                    InstructionalMessage = "skip to question 1F"
                }
            }
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
    }
}
