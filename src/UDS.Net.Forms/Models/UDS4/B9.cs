using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B9 : FormModel
    {
        [RequiredOnComplete(ErrorMessage = "Response required")]
        [Display(Name = "Does the participant report a decline in any cognitive domain (relative to stable baseline prior to onset of current syndrome)?")]
        public int? DECCOG { get; set; }
        [RequiredOnComplete(ErrorMessage = "Response required")]
        [Display(Name = "Does the participant report a decline in any motor domain (relative to stable baseline prior to onset of current syndrome)?")]
        public int? DECMOT { get; set; }
        [RequiredOnComplete(ErrorMessage = "Response required")]
        [Display(Name = "Does the participant report the development of any significant neuropsychiatric/behavioral symptoms (relative to stable baseline prior to onset of current syndrome)?")]
        public int? PSYCHSYM { get; set; }
        [RequiredOnComplete(ErrorMessage = "Response required")]
        [Display(Name = "Does the co-participant report a decline in any cognitive domain (relative to stable baseline prior to onset of current syndrome)?")]
        public int? DECCOGIN { get; set; }
        [RequiredOnComplete(ErrorMessage = "Response required")]
        [Display(Name = "Does the co-participant report a change in any motor domain (relative to stable baseline prior to onset of current syndrome)?")]
        public int? DECMOTIN { get; set; }
        [RequiredOnComplete(ErrorMessage = "Response required")]
        [Display(Name = "Does the co-participant report the development of any significant neuropsychiatric/behavioral symptoms (relative to stable baseline prior to onset of current syndrome)?")]
        public int? PSYCHSYMIN { get; set; }
        [RequiredOnComplete(ErrorMessage = "Response required")]
        [Display(Name = "Does the participant have any neuropsychiatric/behavioral symptoms or declines in any cognitive or motor domain?")]
        public int? DECCLIN { get; set; }
        [Display(Name = "Based on the clinician’s judgment, is the participant currently experiencing meaningful impairment in cognition?")]
        public int? DECCLCOG { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in memory.")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGMEM { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in orientation.")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGORI { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in executive function (judgment, planning, and problem-solving)")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGJUDG { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in language")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGLANG { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in visuospatial function")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGVIS { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in attention/concentration")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGATTN { get; set; }
        [Display(Name = "Indicate whether the participant currently has fluctuating cognition")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGFLUC { get; set; }
        [Display(Name = "Other cognitive impairment")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGOTHR { get; set; }
        [Display(Name = "Specify other cognitive domains")]
        [MaxLength(60)]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public string? COGOTHRX { get; set; }
        [Display(Name = "If any of the cognitive-related behavioral symptoms in 9a-9h are present, at what age did they begin?")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGAGE { get; set; }
        [Display(Name = "Indicate the mode of onset for the most prominent cognitive problem that is causing the participant's complaints and/or affecting the participant's function.")]
        [RequiredIf(nameof(DECCLCOG), "0", ErrorMessage = "Value required")]
        public int? COGMODE { get; set; }
        [Display(Name = "Specify other mode of onset of cognitive symptoms")]
        [MaxLength(60)]
        public string? COGMODEX { get; set; }
        [Display(Name = "Based on the clinician’s judgment, is the participant currently experiencing any kind of behavioral symptoms?")]
        public int? DECCLBE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Apathy, withdrawal")]
        public int? BEAPATHY { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Depressed mood")]
        public int? BEDEP { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Anxiety")]
        public int? BEANX { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior - Euphoria")]
        public int? BEEUPH { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Irritability")]
        public int? BEIRRIT { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Agitation")]
        public int? BEAGIT { get; set; }
        [Display(Name = "If any of the mood-related behavioral symptoms in 12a-12f are present, at what age did they begin?")]
        public int? BEHAGE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Psychosis — Visual hallucinations")]
        public int? BEVHALL { get; set; }
        [Display(Name = "IF YES, do their hallucinations include patterns that are not definite objects, such as pixelation of flat uniform surfaces?")]
        public int? BEVPATT { get; set; }
        [Display(Name = "IF YES, do their hallucinations include well formed and detailed images of objects or people, either as independent images or as part of other objects?")]
        public int? BEVWELL { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Psychosis — Auditory hallucinations")]
        public int? BEAHALL { get; set; }
        [Display(Name = "IF YES, do the auditory hallucinations include simple sounds like knocks or other simple sounds?")]
        public int? BEAHSIMP { get; set; }
        [Display(Name = "IF YES, do the auditory hallucinations include complex sounds like voices speaking words, or music?")]
        public int? BEAHCOMP { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Psychosis — Abnormal, false, or delusional beliefs")]
        public int? BEDEL { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Aggression")]
        public int? BEAGGRS { get; set; }
        [Display(Name = "If any of the psychosis and impulse control-related behavioral symptoms in 12h-12k are present, at what age did they begin?")]
        public int? PSYCHAGE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Disinhibition")]
        public int? BEDISIN { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Personality change")]
        public int? BEPERCH { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Loss of empathy")]
        public int? BEEMPATH { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Obsessions/compulsions")]
        public int? BEOBCOM { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Explosive anger")]
        public int? BEANGER { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior - Substance use")]
        public int? BESUBAB { get; set; }
        [Display(Name = "Alcohol use")]
        public int? ALCUSE { get; set; }
        [Display(Name = "Sedative/hypnotic use")]
        public int? SEDUSE { get; set; }
        [Display(Name = "Opiate use")]
        public int? OPIATEUSE { get; set; }
        [Display(Name = "Cocaine use")]
        public int? COCAINEUSE { get; set; }
        [Display(Name = "Other substance use")]
        public int? OTHSUBUSE { get; set; }
        [Display(Name = "Specify other substance use")]
        [MaxLength(60)]
        public string? OTHSUBUSEX { get; set; }
        [Display(Name = "If any of the personality-related behavioral symptoms in 12m-12r are present, at what age did they begin?")]
        public int? PERCHAGE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — REM sleep behavior disorder")]
        public int? BEREM { get; set; }
        [Display(Name = "IF YES, at what age did the dream enactment behavior begin?")]
        public int? BEREMAGO { get; set; }
        [Display(Name = "Was REM sleep behavior disorder confirmed by polysomnography?")]
        public int? BEREMCONF { get; set; }
        [Display(Name = "Other behavioral symptom")]
        public int? BEOTHR { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior - Other, specify")]
        public string? BEOTHRX { get; set; }
        [Display(Name = "Overall mode of onset for behavioral symptoms")]
        public int? BEMODE { get; set; }
        [Display(Name = "Other mode of onset - specify")]
        public string? BEMODEX { get; set; }
        [Display(Name = "Based on the clinician’s judgment, is the participant currently experiencing any motor symptoms?")]
        public int? DECCLMOT { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Gait disorder")]
        public int? MOGAIT { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Falls")]
        public int? MOFALLS { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Slowness")]
        public int? MOSLOW { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Tremor")]
        public int? MOTREM { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Limb weakness")]
        public int? MOLIMB { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Change in facial expression")]
        public int? MOFACE { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Change in speech")]
        public int? MOSPEECH { get; set; }
        [Display(Name = "If changes in motor function are present in 15a-15g, at what age did they begin?")]
        public int? MOTORAGE { get; set; }
        [Display(Name = "Indicate the mode of onset for the most prominent motor problem that is causing the participant's complaints and/or affecting the participant's function.")]
        public int? MOMODE { get; set; }
        [Display(Name = "Indicate mode of onset for the most prominent motor problem that is causing the participant's complains and or affecting the participant's function - Other, specify")]
        public string? MOMODEX { get; set; }
        [Display(Name = "Were changes in motor function suggestive of parkinsonism?")]
        public int? MOMOPARK { get; set; }
        [Display(Name = "Were changes in motor function suggestive of amyotrophic lateral sclerosis?")]
        public int? MOMOALS { get; set; }
        [Display(Name = "Overall course of decline of cognitive / behavorial / motor syndrome")]
        public int? COURSE { get; set; }
        [Display(Name = "Indicate the predominant domain that was first recognized as changed in the participant")]
        public int? FRSTCHG { get; set; }
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

