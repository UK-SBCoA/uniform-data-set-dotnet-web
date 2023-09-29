using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B9 : FormModel
    {
        [Display(Name = "Does the participant report a decline in memory (relative to previously attained abilities)?")]
        [RequiredOnComplete (ErrorMessage ="Response required for DECSUB")]
        public int? DECSUB { get; set; }

        [Display(Name = "Does the co-participant report a decline in participant’s memory (relative to previously attained abilities)?")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? DECIN { get; set; }

        #region Cognitive symptoms

        [Display(Name = "Based on the clinician’s judgment, is the participant currently experiencing meaningful impairment in cognition?")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? DECCLCOG { get; set; }

        [Display(Name = "MEMORY For example, does s/he forget conversations and/or dates, repeat questions and/or statements, misplace things more than usual, forget names of people s/he knows well?")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGMEM { get; set; }

        [Display(Name = "ORIENTATION For example, does s/he have trouble knowing the day, month, and year, or not recognize familiar locations, or get lost in familiar locations?")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGORI { get; set; }

        [Display(Name = "EXECUTIVE FUNCTION - JUDGMENT, PLANNING, PROBLEM-SOLVING Does s/he have trouble handling money (e.g., tips), paying bills, preparing meals, shopping, using appliances, handling medications, driving?")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGJUDG { get; set; }

        [Display(Name = "LANGUAGE Does s/he have hesitant speech, have trouble finding words, use inappropriate words without self-correction?")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGLANG { get; set; }

        [Display(Name = "VISUOSPATIAL FUNCTION Does s/he have difficulty interpreting visual stimuli and finding his/her way around?")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGVIS { get; set; }

        [Display(Name = "ATTENTION, CONCENTRATION Does the participant have a short attention span or limited ability to concentrate? Is s/he easily distracted?")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGATTN { get; set; }

        [Display(Name = "FLUCTUATING COGNITION Does the participant exhibit pronounced variation in attention and alertness, noticeably over hours or days — for example, long lapses or periods of staring into space, or times when his/her ideas have a disorganized flow?")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGFLUC { get; set; }

        [Display(Name = "If yes, at what age did the fluctuating cognition begin? (The clinician must use his/her best judgment to estimate an age of onset.)")]
        [RequiredIf(nameof(COGFLUC), "1", ErrorMessage = "Specify age")]
        [Range(15, 110)]
        public int? COGFLAGO { get; set; }

        [Display(Name = "Indicate whether the subject currently is meaningfully impaired, relative to previously attained abilities, in other cognitive domains ")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGOTHR { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(COGOTHR), "1", ErrorMessage = "Specification of other cognitive impairment")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? COGOTHRX { get; set; }

        [Display(Name = "Indicate the predominant symptom that was first recognized as a decline in the participant’s cognition")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGFPRED { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(COGFPRED), "8", ErrorMessage = "Specification for other predominant symptom first recognized as a decline in the participant’s cognition")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? COGFPREX { get; set; }

        [Display(Name = "Mode of onset of cognitive symptoms")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? COGMODE { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(COGMODE), "4", ErrorMessage = "Specification for mode of onset of other cognitive symptoms")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? COGMODEX { get; set; }

        [Display(Name = "Based on clinician’s assessment, at what age did the cognitive decline begin? (The clinician must use his/her best judgment to estimate an age of onset.)")]
        [Range(15, 110)]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Please provide a value")]
        public int? DECAGE { get; set; }

        #endregion

        #region Behavioral symptoms

        [Display(Name = "Based on clinician’s judgment, is the participant currently experiencing any kind of behavioral symptoms?")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? DECCLBE { get; set; }

        [Display(Name = "APATHY, WITHDRAWAL Has the participant lost interest in or displayed a reduced ability to initiate usual activities and social interaction, such as conversing with family and/or friends?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEAPATHY { get; set; }

        [Display(Name = "DEPRESSED MOOD Has the participant seemed depressed for more than two weeks at a time, e.g., shown loss of interest or pleasure in nearly all activities, sadness, hopelessness, loss of appetite, fatigue?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEDEP { get; set; }

        [Display(Name = "Visual hallucinations")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEVHALL { get; set; }

        [Display(Name = "If yes, are the hallucinations well-formed and detailed?")]
        [RequiredIf(nameof(BEVHALL), "1", ErrorMessage = "Are the hallucinations well-formed and detailed?")]
        public int? BEVWELL { get; set; }

        [Display(Name = "If well-formed, clear-cut visual hallucinations, at what age did these hallucinations begin?")]
        [RequiredIf(nameof(BEVWELL), "1", ErrorMessage = "At what age did these hallucinations begin?")]
        [RegularExpression("^(1[5-9]|[2-9]\\d|10\\d|110|888)$", ErrorMessage = "(15-110, 888 = N/A, not well-formed)")]
        public int? BEVHAGO { get; set; }

        [Display(Name = "Auditory hallucinations")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEAHALL { get; set; }

        [Display(Name = "Abnormal, false, or delusional beliefs")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEDEL { get; set; }

        [Display(Name = "DISINHIBITION Does the participant use inappropriate coarse language or exhibit inappropriate speech or behaviors in public or in the home? Does s/he talk personally to strangers or have disregard for personal hygiene?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEDISIN { get; set; }

        [Display(Name = "IRRITABILITY Does the participant overreact, e.g., by shouting at family members or others?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEIRRIT { get; set; }

        [Display(Name = "AGITATION Does the participant have trouble sitting still? Does s/he shout, hit, and/or kick?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEAGIT { get; set; }

        [Display(Name = "PERSONALITY CHANGE Does the participant exhibit bizarre behavior 3 or behavior uncharacteristic of the participant, such as unusual collecting, suspiciousness (without delusions), unusual dress, or dietary changes? Does the participant fail to take others’ feelings into account?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEPERCH { get; set; }

        [Display(Name = "REM SLEEP BEHAVIOR DISORDER While sleeping, does the participant appear to act out his/her dreams (e.g., punch or flail their arms, shout, or scream)?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEREM { get; set; }

        [Display(Name = "If Yes, at what age did the REM sleep behavior disorder begin? (The clinician must use his/her best judgment to estimate an age of onset.)")]
        [RequiredIf(nameof(BEREM), "1", ErrorMessage = "At what age did the REM sleep behavior disorder begin")]
        [Range(15, 110)]
        public int? BEREMAGO { get; set; }

        [Display(Name = "ANXIETY For example, does s/he show signs of nervousness (e.g., frequent sighing, anxious facial expressions, or hand-wringing) and/or excessive worrying?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEANX { get; set; }

        [Display(Name = "Other")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEOTHR { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(BEOTHR), "1", ErrorMessage = "Please provide other value")]
        [ProhibitedCharacters]
        public string? BEOTHRX { get; set; }

        [Display(Name = "Indicate the predominant symptom that was first recognized as a decline in the participant’s behavior")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEFPRED { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(BEFPRED), "10", ErrorMessage = "Please provide other value")]
        [ProhibitedCharacters]
        public string? BEFPREDX { get; set; }

        [Display(Name = "Mode of onset of behavioral symptoms")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEMODE { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(BEMODE), "4", ErrorMessage = "Please provide other value")]
        [ProhibitedCharacters]
        public string? BEMODEX { get; set; }

        [Display(Name = "Based on the clinician's assessment, at what age did the behavioral symptoms begin?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Please provide a value")]
        public int? BEAGE { get; set; }

        #endregion

        #region Motor Symptoms

        [Display(Name = "Based on the clinician's judgment, is the participant currently experiencing any motor symptoms?")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? DECCLMOT { get; set; }

        [Display(Name = "GAIT DISORDER Has the participant's walking changed, not specifically due to arthritis or an injury? Is s/he unsteady, or does s/he shuffle when walking, have little or no arm-swing, or drag a foot?")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOGAIT { get; set; }

        [Display(Name = "FALLS Does the participant fall more than usual?")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOFALLS { get; set; }

        [Display(Name = "TREMOR Has the participant had rhythmic shaking, especially in the hands, arms, legs, head, mouth, or tongue?")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOTREM { get; set; }

        [Display(Name = "SLOWNESS Has the participant noticeably slowed down in walking, moving, or writing by hand, other than due to an injury or illness? Has his/her facial expression changed or become more \"wooden,\" or masked and unexpressive?")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOSLOW { get; set; }

        [Display(Name = "Indicate the predominant symptom that was first recognized as a decline in the participant's motor function")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOFRST { get; set; }

        [Display(Name = "Mode of onset of motor symptoms")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOMODE { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(MOMODE), "4", ErrorMessage = "Please provide pther value")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? MOMODEX { get; set; }

        [Display(Name = "Were changes in motor function suggestive of parkinsonism?")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOMOPARK { get; set; }

        [Display(Name = "If Yes, at what age did the motor symptoms suggestive of parkinsonism begin?")]
        [RequiredIf(nameof(MOMOPARK), "1", ErrorMessage = "Please provide an age")]
        [Range(15, 110)]
        public int? PARKAGE { get; set; }

        [Display(Name = "Were changes in motor function suggestive of amyotrophic lateral sclerosis?")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOMOALS { get; set; }

        [Display(Name = "If Yes, at what age did the motor symptoms suggestive of ALS begin?")]
        [RequiredIf(nameof(MOMOALS), "1", ErrorMessage = "Please provide an age")]
        [Range(15, 110)]
        public int? ALSAGE { get; set; }

        [Display(Name = "Based on the clinician's assessment, at what age did the motor changes begin?")]
        [Range(15, 110)]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Please provide a value")]
        public int? MOAGE { get; set; }

        #endregion

        [Display(Name = "Overall course of decline of cognitive / behavorial / motor syndrome")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? COURSE { get; set; }

        [Display(Name = "Indicate the predominant domain that was first recognized as changed in the participant")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? FRSTCHG { get; set; }

        [Display(Name = "Is the participant a potential candidate for further evaluation for Lewy body disease?")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? LBDEVAL { get; set; }

        [Display(Name = "Is the participant a potential candidate for further evaluation for frontotemporal lobar degeneration?")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? FTLDEVAL { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

