﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    /// 

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
        [RequiredIf(nameof(DECCLIN), "1", ErrorMessage = "Value required")]
        public int? DECCLCOG { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in memory.")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGMEM { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in orientation.")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGORI { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in executive function (judgment, planning, and problem-solving)")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGJUDG { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in language")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGLANG { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in visuospatial function")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGVIS { get; set; }
        [Display(Name = "Indicate whether the participant currently is meaningfully impaired in attention/concentration")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGATTN { get; set; }
        [Display(Name = "Indicate whether the participant currently has fluctuating cognition")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGFLUC { get; set; }
        [Display(Name = "Other cognitive impairment")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGOTHR { get; set; }
        [Display(Name = "Specify other cognitive domains")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTHR), "1", ErrorMessage = "Value required")]
        public string? COGOTHRX { get; set; }
        [Display(Name = "If any of the cognitive-related behavioral symptoms in 9a-9h are present, at what age did they begin?")]
        [RegularExpression("^(9|[1-9]\\d|10\\d|110)$", ErrorMessage = "Valid range is 9 - 110")]
        public int? COGAGE { get; set; }
        [Display(Name = "Indicate the mode of onset for the most prominent cognitive problem that is causing the participant's complaints and/or affecting the participant's function.")]
        [RequiredIf(nameof(DECCLCOG), "1", ErrorMessage = "Value required")]
        public int? COGMODE { get; set; }
        [Display(Name = "Specify other mode of onset of cognitive symptoms")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGMODE), "4", ErrorMessage = "Value required")]
        public string? COGMODEX { get; set; }
        [Display(Name = "Based on the clinician’s judgment, is the participant currently experiencing any kind of behavioral symptoms?")]
        public int? DECCLBE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Apathy, withdrawal")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEAPATHY { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Depressed mood")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEDEP { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Anxiety")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEANX { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior - Euphoria")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEEUPH { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Irritability")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEIRRIT { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Agitation")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEAGIT { get; set; }
        [Display(Name = "If any of the mood-related behavioral symptoms in 12a-12f are present, at what age did they begin?")]
        [RegularExpression("^(9|[1-9]\\d|10\\d|110)$", ErrorMessage = "Valid range is 9 - 110")]
        public int? BEHAGE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Psychosis — Visual hallucinations")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEVHALL { get; set; }
        [Display(Name = "IF YES, do their hallucinations include patterns that are not definite objects, such as pixelation of flat uniform surfaces?")]
        public int? BEVPATT { get; set; }
        [Display(Name = "IF YES, do their hallucinations include well formed and detailed images of objects or people, either as independent images or as part of other objects?")]
        public int? BEVWELL { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Psychosis — Auditory hallucinations")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEAHALL { get; set; }
        [Display(Name = "IF YES, do the auditory hallucinations include simple sounds like knocks or other simple sounds?")]
        public int? BEAHSIMP { get; set; }
        [Display(Name = "IF YES, do the auditory hallucinations include complex sounds like voices speaking words, or music?")]
        public int? BEAHCOMP { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Psychosis — Abnormal, false, or delusional beliefs")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEDEL { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Aggression")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEAGGRS { get; set; }
        [Display(Name = "If any of the psychosis and impulse control-related behavioral symptoms in 12h-12k are present, at what age did they begin?")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? PSYCHAGE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Disinhibition")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEDISIN { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Personality change")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEPERCH { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Loss of empathy")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEEMPATH { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Obsessions/compulsions")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEOBCOM { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — Explosive anger")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEANGER { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior - Substance use")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BESUBAB { get; set; }
        [Display(Name = "Alcohol use")]
        public bool ALCUSE { get; set; }
        [Display(Name = "Sedative/hypnotic use")]
        public bool SEDUSE { get; set; }
        [Display(Name = "Opiate use")]
        public bool OPIATEUSE { get; set; }
        [Display(Name = "Cocaine use")]
        public bool COCAINEUSE { get; set; }
        [Display(Name = "Other substance use")]
        public bool OTHSUBUSE { get; set; }
        [Display(Name = "Specify other substance use")]
        [MaxLength(60)]
		[RequiredIf(nameof(OTHSUBUSE), "true", ErrorMessage = "Value required")]
		public string? OTHSUBUSEX { get; set; }
        [Display(Name = "If any of the personality-related behavioral symptoms in 12m-12r are present, at what age did they begin?")]
        [RegularExpression("^(9|[1-9]\\d|10\\d|110)$", ErrorMessage = "Valid range is 9 - 110")]
        public int? PERCHAGE { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior — REM sleep behavior disorder")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEREM { get; set; }
        [Display(Name = "IF YES, at what age did the dream enactment behavior begin?")]
        [RequiredIf(nameof(BEREM), "1", ErrorMessage = "Value Required")]
        [RegularExpression("^(9|[1-9]\\d|10\\d|110)$", ErrorMessage = "Valid range is 9 - 110")]
        public int? BEREMAGO { get; set; }
        [Display(Name = "Was REM sleep behavior disorder confirmed by polysomnography?")]
        [RequiredIf(nameof(BEREM), "1", ErrorMessage = "Value Required")]
        public int? BEREMCONF { get; set; }
        [Display(Name = "Other behavioral symptom")]
		[RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
		public int? BEOTHR { get; set; }
        [Display(Name = "Participant currently manifests meaningful change in behavior - Other, specify")]
        [RequiredIf(nameof(BEOTHR), "1", ErrorMessage = "Value required")]
        [MaxLength(60)]
        public string? BEOTHRX { get; set; }
        [Display(Name = "Overall mode of onset for behavioral symptoms")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? BEMODE { get; set; }
        [Display(Name = "Other mode of onset - specify")]
        [RequiredIf(nameof(BEMODE), "4", ErrorMessage = "Value required")]
        [MaxLength(60)]
        public string? BEMODEX { get; set; }
        [Display(Name = "Based on the clinician’s judgment, is the participant currently experiencing any motor symptoms?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? DECCLMOT { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Gait disorder")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Value required")]
        public int? MOGAIT { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Falls")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Value required")]
        public int? MOFALLS { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Slowness")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Value required")]
        public int? MOSLOW { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Tremor")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Value required")]
        public int? MOTREM { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Limb weakness")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Value required")]
        public int? MOLIMB { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Change in facial expression")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Value required")]
        public int? MOFACE { get; set; }
        [Display(Name = "Indicate whether the participant currently has meaningful changes in motor function — Change in speech")]
        [RequiredIf(nameof(DECCLMOT), "1", ErrorMessage = "Value required")]
        public int? MOSPEECH { get; set; }
        [Display(Name = "If changes in motor function are present in 15a-15g, at what age did they begin?")]
        [RegularExpression("^(9|[1-9]\\d|10\\d|110)$", ErrorMessage = "Valid range is 9 - 110")]
        public int? MOTORAGE { get; set; }
        [Display(Name = "Indicate the mode of onset for the most prominent motor problem that is causing the participant's complaints and/or affecting the participant's function.")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? MOMODE { get; set; }
        [Display(Name = "Indicate mode of onset for the most prominent motor problem that is causing the participant's complains and or affecting the participant's function - Other, specify")]
        [RequiredIf(nameof(MOMODE), "4", ErrorMessage = "Value required")]
        [MaxLength(60)]
        public string? MOMODEX { get; set; }
        [Display(Name = "Were changes in motor function suggestive of parkinsonism?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? MOMOPARK { get; set; }
        [Display(Name = "Were changes in motor function suggestive of amyotrophic lateral sclerosis?")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? MOMOALS { get; set; }
        [Display(Name = "Overall course of decline of cognitive / behavorial / motor syndrome")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? COURSE { get; set; }
        [Display(Name = "Indicate the predominant domain that was first recognized as changed in the participant")]
        [RequiredIf(nameof(DECCLBE), "1", ErrorMessage = "Value required")]
        public int? FRSTCHG { get; set; }
        [NotMapped]
        [RequiredIf(nameof(BESUBAB), "1", ErrorMessage = "Please select at least one substance")]
        public bool? BESUBABCheckboxValidation
        {
            get
            {
                if(ALCUSE == false && SEDUSE == false && OPIATEUSE == false && COCAINEUSE == false && OTHSUBUSE == false)
                {
                    return null;
                }

                return true;
            }
        }
        [NotMapped]
        [RequiredOnComplete(ErrorMessage = "Invalid Response")]
        public bool? COGAGESymptomsPresent
        {
            get
            {
                if(COGMEM == 1 || COGORI == 1 || COGJUDG == 1 || COGLANG == 1 || COGVIS == 1 || COGATTN == 1 || COGFLUC == 1 || !String.IsNullOrEmpty(COGOTHRX))
                {
                    if(COGAGE < 0)
                    {
                        return true;
                    }

                    return null;
                }
                else
                {
                    if(COGAGE > 0)
                    {
                        return null;
                    }

                    return true;
                }
            }
        }

        [NotMapped]
        [RequiredOnComplete(ErrorMessage = "Invalid Response")]
        public bool? BEHAGESymptomsPresent
        {
            get
            {
                if (BEAPATHY == 1 || BEDEP == 1 || BEANX == 1 || BEEUPH == 1 || BEIRRIT == 1 || BEAGIT == 1)
                {
                    if (BEHAGE > 0)
                    {
                        return true;
                    }

                    return null;
                }
                else
                {
                    if (BEHAGE > 0)
                    {
                        return null;
                    }

                    return true;
                }
            }
        }

        [NotMapped]
        [RequiredOnComplete(ErrorMessage = "Invalid Response")]
        public bool? PERCHAGESymptomsPresent
        {
            get
            {
                if (BEVHALL == 1 || BEAHALL == 1 || BEDEL == 1 || BEAGGRS == 1 || PSYCHAGE == 1 || BEDISIN == 1 || BEPERCH == 1 || BEEMPATH == 1 || BEOBCOM == 1 || BEANGER == 1 || BESUBAB == 1)
                {
                    if (PERCHAGE > 0)
                    {
                        return true;
                    }

                    return null;
                }
                else
                {
                    if (PERCHAGE > 0)
                    {
                        return null;
                    }

                    return true;
                }
            }
        }


        [NotMapped]
        [RequiredOnComplete(ErrorMessage = "Invalid Response")]
        public bool? MOTORAGEMotorChangesPresent
        {
            get
            {
                if (MOGAIT == 1 || MOFALLS == 1 || MOSLOW == 1 || MOTREM == 1 || MOLIMB == 1 || MOFACE == 1 || MOSPEECH == 1 )
                {
                    if (MOTORAGE > 0)
                    {
                        return true;
                    }

                    return null;
                }
                else
                {
                    if (MOTORAGE > 0)
                    {
                        return null;
                    }

                    return true;
                }
            }
        }

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

