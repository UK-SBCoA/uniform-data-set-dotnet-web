using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UDS.Net.Dto;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.Enums;


namespace UDS.Net.Forms.Models
{
    public class MilestoneModel
    {
        public int Id { get; set; }

        public List<M1SubmissionDto> M1Submissions { get; set; } = new();

        [Required]
        public int ParticipationId { get; set; }

        public virtual ParticipationModel? Participation { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Complete";

        [Display(Name = "Month")]
        public int? CHANGEMO { get; set; }

        [Display(Name = "Day")]
        public int? CHANGEDY { get; set; }

        [Display(Name = "Year")]
        public int? CHANGEYR { get; set; }

        [Display(Name = "UDS data collection status changed; participant's new status is")]
        public int? PROTOCOL { get; set; }

        [Display(Name = "Autopsy consent on file?")]
        public int? ACONSENT { get; set; }

        [Display(Name = "Participant is too cognitively impaired.")]
        public bool? RECOGIM { get; set; }

        [Display(Name = "Participant is too ill or physically impaired.")]
        public bool? REPHYILL { get; set; }

        [Display(Name = "Participant refuses neuropsychological testing or clinical exam.")]
        public bool? REREFUSE { get; set; }

        [Display(Name = "Participant or co-participant unreachable, not available, or moved away.")]
        public bool? RENAVAIL { get; set; }

        [Display(Name = "Participant has permanently entered nursing home.")]
        public bool? RENURSE { get; set; }

        public int? NURSEMO { get; set; }

        public int? NURSEDY { get; set; }

        public int? NURSEYR { get; set; }

        [Display(Name = "Participant is REJOINING ADC.")]
        public bool? REJOIN { get; set; }

        [Display(Name = "Participant will no longer receive FTLD Module follow-up, but annual in-person UDS visits will continue")]
        public bool? FTLDDISC { get; set; }

        public int? FTLDREAS { get; set; }

        public string? FTLDREAX { get; set; }

        [Display(Name = "Participant has died")]
        public bool? DECEASED { get; set; }

        [Display(Name = "Participant has been dropped from ADC")]
        public bool? DISCONT { get; set; }

        public int? DEATHMO { get; set; }

        public int? DEATHDY { get; set; }

        public int? DEATHYR { get; set; }

        [Display(Name = "ADC autopsy")]
        public int? AUTOPSY { get; set; }

        public int? DISCMO { get; set; }

        public int? DISCDAY { get; set; }

        public int? DISCYR { get; set; }

        [Display(Name = "Main reason for being dropped from ADC")]
        public int? DROPREAS { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [Display(Name = "Which milestone type are you reporting?")]
        [Range(0, 1)]
        public int? MILESTONETYPE { get; set; }

        [NotMapped]
        public string DisplayChangeDate
        {
            get
            {
                if (MILESTONETYPE.HasValue && MILESTONETYPE.Value == 1)
                {
                    return $"{CHANGEMO}/{CHANGEDY}/{CHANGEYR}";
                }
                else
                {
                    if (DECEASED.HasValue && DECEASED.Value == true)
                        return $"{DEATHMO}/{DEATHDY}/{DEATHYR}";
                    else if (DISCONT.HasValue && DISCONT.Value == true)
                        return $"{DISCMO}/{DISCDAY}/{DISCYR}";
                }
                return "--/--/----";
            }
        }

        //Temporary properties only used in the view and NOT sent to the API
        //validation properties used as targets for validation messages in the manual validation
        [NotMapped]
        public int ProtocolReasonValidation { get; set; }

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
                        new UIEnableAttribute("Milestone.ACONSENT")
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
    }
}