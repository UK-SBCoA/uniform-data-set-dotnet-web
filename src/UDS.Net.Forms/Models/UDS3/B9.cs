﻿using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B9 : FormModel
    {
        [Display(Name = "Does the subject report a decline in memory (relative to previously attained abilities)?")]
        public int? DECSUB { get; set; }

        [Display(Name = "Does the co-participant report a decline in subject’s memory (relative to previously attained abilities)?")]
        public int? DECIN { get; set; }

        [Display(Name = "Based on the clinician’s judgment, is the subject currently experiencing meaningful impairment in cognition?")]
        public int? DECCLCOG { get; set; }

        [Display(Name = "For example, does s/he forget conversations and/or dates, repeat questions and/or statements, misplace things more than usual, forget names of people s/he knows well?")]
        public int? COGMEM { get; set; }

        [Display(Name = "For example, does s/he have trouble knowing the day, month, and year, or not recognize familiar locations, or get lost in familiar locations?")]
        public int? COGORI { get; set; }

        [Display(Name = "Does s/he have trouble handling money (e.g., tips), paying bills, preparing meals, shopping, using appliances, handling medications, driving?")]
        public int? COGJUDG { get; set; }

        [Display(Name = "Does s/he have hesitant speech, have trouble finding words, use inappropriate words without self-correction?")]
        public int? COGLANG { get; set; }

        [Display(Name = "Does s/he have difficulty interpreting visual stimuli and finding his/her way around?")]
        public int? COGVIS { get; set; }

        [Display(Name = "Does the subject have a short attention span or limited ability to concentrate? Is s/he easily distracted?")]
        public int? COGATTN { get; set; }

        [Display(Name = "Does the subject exhibit pronounced variation in attention and alertness, noticeably over hours or days — for example, long lapses or periods of staring into space, or times when his/her ideas have a disorganized flow?")]
        public int? COGFLUC { get; set; }

        [Display(Name = "If yes, at what age did the fluctuating cognition begin?")]
        [RequiredIf(nameof(COGFLUC), "1", ErrorMessage = "Specify age")]
        [Range(15, 110)]
        public int? COGFLAGO { get; set; }

        [Display(Name = "Other")]
        public int? COGOTHR { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(COGOTHR), "1", ErrorMessage = "Specification of other cognitive impairment")]
        [MaxLength(60)]
        public string? COGOTHRX { get; set; }

        [Display(Name = "Indicate the predominant symptom that was first recognized as a decline in the subject’s cognition")]
        public int? COGFPRED { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(COGFPRED), "8", ErrorMessage = "Specification for other predominant symptom first recognized as a decline in the subject’s cognition")]
        [MaxLength(60)]
        public string? COGFPREX { get; set; }

        [Display(Name = "Mode of onset of cognitive symptoms")]
        public int? COGMODE { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(COGMODE), "4", ErrorMessage = "Specification for mode of onset of other cognitive symptoms")]
        [MaxLength(60)]
        public string? COGMODEX { get; set; }

        [Display(Name = "Based on clinician’s assessment, at what age did the cognitive decline begin? (The clinician must use his/her best judgment to estimate an age of onset.)")]
        [Range(15, 110)]
        public int? DECAGE { get; set; }

        [Display(Name = "Based on clinician’s judgment, is the subject currently experiencing any kind of behavioral symptoms?")]
        public int? DECCLBE { get; set; }

        [Display(Name = "Has the subject lost interest in or displayed a reduced ability to initiate usual activities and social interaction, such as conversing with family and/or friends?")]
        public int? BEAPATHY { get; set; }

        [Display(Name = "Has the subject seemed depressed for more than two weeks at a time, e.g., shown loss of interest or pleasure in nearly all activities, sadness, hopelessness, loss of appetite, fatigue?")]
        public int? BEDEP { get; set; }

        [Display(Name = "Visual hallucinations")]
        public int? BEVHALL { get; set; }

        [Display(Name = "If yes, are the hallucinations well-formed and detailed?")]
        [RequiredIf(nameof(BEVHALL), "1", ErrorMessage = "Are the hallucinations well-formed and detailed?")]
        public int? BEVWELL { get; set; }

        [Display(Name = "If well-formed, clear-cut visual hallucinations, at what age did these hallucinations begin?")]
        [RequiredIf(nameof(BEVWELL), "1", ErrorMessage = "At what age did these hallucinations begin?")]
        [RegularExpression("^(1[5-9]|[2-9]\\d|10\\d|110|888)$", ErrorMessage = "(15-110, 888 = N/A, not well-formed)")]
        public int? BEVHAGO { get; set; }

        [Display(Name = "Auditory hallucinations")]
        public int? BEAHALL { get; set; }

        [Display(Name = "Abnormal, false, or delusional beliefs")]
        public int? BEDEL { get; set; }

        [Display(Name = "Does the subject use inappropriate coarse language or exhibit inappropriate speech or behaviors in public or in the home? Does s/he talk personally to strangers or have disregard for personal hygiene?")]
        public int? BEDISIN { get; set; }

        [Display(Name = "Does the subject overreact, e.g., by shouting at family members or others?")]
        public int? BEIRRIT { get; set; }

        [Display(Name = "Does the subject have trouble sitting still? Does s/he shout, hit, and/or kick?")]
        public int? BEAGIT { get; set; }

        [Display(Name = "Does the subject exhibit bizarre behavior 3 or behavior uncharacteristic of the subject, such as unusual collecting, suspiciousness (without delusions), unusual dress, or dietary changes? Does the subject fail to take others’ feelings into account?")]
        public int? BEPERCH { get; set; }

        [Display(Name = "While sleeping, does the subject appear to act out his/her dreams (e.g., punch or flail their arms, shout, or scream)?")]
        public int? BEREM { get; set; }

        [Display(Name = "If Yes, at what age did the REM sleep behavior disorder begin? (The clinician must use his/her best judgment to estimate an age of onset.)")]
        [RequiredIf(nameof(BEREM), "1", ErrorMessage = "At what age did the REM sleep behavior disorder begin")]
        [Range(15, 110)]
        public int? BEREMAGO { get; set; }

        [Display(Name = "For example, does s/he show signs of nervousness (e.g., frequent sighing, anxious facial expressions, or hand-wringing) and/or excessive worrying?")]
        public int? BEANX { get; set; }

        [Display(Name = "Other")]
        public int? BEOTHR { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(BEOTHR), "1", ErrorMessage = "Please provide other value")]
        public string? BEOTHRX { get; set; }

        [Display(Name = "Indicate the predominant symptom that was first recognized as a decline in the subject’s behavior")]
        public int? BEFPRED { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(BEFPRED), "10", ErrorMessage = "Please provide other value")]
        public string? BEFPREDX { get; set; }

        [Display(Name = "Mode of onset of behavioral symptoms")]
        public int? BEMODE { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(BEMODE), "4", ErrorMessage = "Please provide other value")]
        public string? BEMODEX { get; set; }

        [Display(Name = "Based on the clinician's assessment, at what age did the behavioral symptoms begin?")]
        public int? BEAGE { get; set; }

        [Display(Name = "Based on the clinician's judgment, is the subject currently experiencing any motor symptoms?")]
        public int? DECCLMOT { get; set; }

        [Display(Name = "Has the subject's walking changed, not specifically due to arthritis or an injury? Is s/he unsteady, or does s/he shuffle when walking, have little or no arm-swing, or drag a foot?")]
        public int? MOGAIT { get; set; }

        [Display(Name = "Does the subject fall more than usual?")]
        public int? MOFALLS { get; set; }

        [Display(Name = "Has the subject had rhythmic shaking, especially in the hands, arms, legs, head, mouth, or tongue?")]
        public int? MOTREM { get; set; }

        [Display(Name = "Has the subject noticeably slowed down in walking, moving, or writing by hand, other than due to an injury or illness? Has his/her facial expression changed or become more \"wooden, \" or masked and unexpressive?")]
        public int? MOSLOW { get; set; }

        [Display(Name = "Indicate the predominant symptom that was first recognized as a decline in the subject's motor function")]
        public int? MOFRST { get; set; }

        [Display(Name = "Mode of onset of motor symptoms")]
        public int? MOMODE { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? MOMODEX { get; set; }

        [Display(Name = "Were changes in motor function suggestive of parkinsonism?")]
        public int? MOMOPARK { get; set; }

        [Display(Name = "If Yes, at what age did the motor symptoms suggestive of parkinsonism begin?")]
        public int? PARKAGE { get; set; }

        [Display(Name = "Were changes in motor function suggestive of amyotrophic lateral sclerosis?")]
        public int? MOMOALS { get; set; }

        [Display(Name = "If Yes, at what age did the motor symptoms suggestive of ALS begin?")]
        public int? ALSAGE { get; set; }

        [Display(Name = "Based on the clinician's assessment, at what age did the motor changes begin?")]
        public int? MOAGE { get; set; }

        [Display(Name = "Overall course of decline of cognitive / behavorial / motor syndrome")]
        public int? COURSE { get; set; }

        [Display(Name = "Indicate the predominant domain that was first recognized as changed in the subject")]
        public int? FRSTCHG { get; set; }

        [Display(Name = "Is the subject a potential candidate for further evaluation for Lewy body disease?")]
        public int? LBDEVAL { get; set; }

        [Display(Name = "Is the subject a potential candidate for further evaluation for frontotemporal lobar degeneration?")]
        public int? FTLDEVAL { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

