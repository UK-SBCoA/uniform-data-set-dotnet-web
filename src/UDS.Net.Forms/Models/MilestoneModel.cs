using System;
using System.ComponentModel.DataAnnotations;
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
        public string Status { get; set; }
        [Display(Name = "Month")]
        [RequiredIf(nameof(MilestoneType), "1")]
        public int? CHANGEMO { get; set; }
        [Display(Name = "Day")]
        public int? CHANGEDY { get; set; }
        [Display(Name = "Year")]
        public int? CHANGEYR { get; set; }
        [Display(Name = "UDS data collection status changed; subject's new status is (CHECK ONE):")]
        public int? PROTOCOL { get; set; }
        [Display(Name = "Autopsy consent on file?")]
        public int? ACONSENT { get; set; }
        [Display(Name = "Subject is too cognitively impaired")]
        public bool? RECOGIM { get; set; }
        [Display(Name = "Subject is too ill or\nphysically impaired")]
        public bool? REPHYILL { get; set; }
        [Display(Name = "Subject refuses neuropsychological testing or clinical exam")]
        public bool? REREFUSE { get; set; }
        [Display(Name = "Subject or coparticipant unreachable, not available, or moved away")]
        public bool? RENAVAIL { get; set; }
        [Display(Name = "Subject has permanently entered nursing home")]
        public bool? RENURSE { get; set; }
        public int? NURSEMO { get; set; }
        public int? NURSEDY { get; set; }
        public int? NURSEYR { get; set; }
        [Display(Name = "Subject is rejoining ADC")]
        public bool? REJOIN { get; set; }
        [Display(Name = "Subject will no longer receive FTLD Module follow-up, but annual in-person UDS visits will continue")]
        public bool? FTLDDISC { get; set; }
        public int? FTLDREAS { get; set; }
        public string FTLDREAX { get; set; }
        [Display(Name = "Subject has DIED (COMPLETE DEATH SECTION, BELOW)")]
        public bool? DECEASED { get; set; }
        [Display(Name = "Subject has been DROPPED from ADC. (COMPLETE DROPPED SECTION, BELOW)")]
        public bool? DISCONT { get; set; }
        public int? DEATHMO { get; set; }
        public int? DEATHDY { get; set; }
        public int? DEATHYR { get; set; }
        [Display(Name = "ADC autopsy")]
        public int? AUTOPSY { get; set; }
        public int? DISCMO { get; set; }
        public int? DISCDAY { get; set; }
        public int? DISCYR { get; set; }
        [Display(Name = "Main reason for being dropped from ADC (CHECK ONE):")]
        public int? DROPREAS { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Which milesone type are you reporting?")]
        [Range(0, 1)]
        public int? MilestoneType { get; set; } = null;
    }
}