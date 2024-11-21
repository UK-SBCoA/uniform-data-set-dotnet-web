using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;


namespace UDS.Net.Forms.Models
{
    public class MilestoneModel
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int ParticipationId { get; set; }
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
        //Temporary properties only used in the view and NOT sent to the API
        //validation properties used as targets for validation messages in the manual validation
        [NotMapped]
        public int ProtocolReasonValidation { get; set; }
    }
}