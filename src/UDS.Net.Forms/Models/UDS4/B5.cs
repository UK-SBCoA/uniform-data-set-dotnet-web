using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B5 : FormModel
    {
        [Display(Name = "NPI co-participant")]
        [Range(1, 3)]
        [RequiredOnFinalized]
        public int? NPIQINF { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(NPIQINF), "3", ErrorMessage = "Specify other co-participant")]
        [ProhibitedCharacters]
        public string? NPIQINFX { get; set; }

        [Display(Name = "Delusions - Does the patient have false beliefs, such as thinking that others are stealing from him/her or planning to harm him/her in some way?")]
        [RequiredOnFinalized(ErrorMessage = "Delusions is required.")]
        public int? DEL { get; set; }

        [RequiredIf(nameof(DEL), "1", ErrorMessage = "Provide severity of delusions.")]
        public int? DELSEV { get; set; }

        [Display(Name = "Hallucinations - Does the patient have hallucinations such as false visions or voices? Does he or she seem to hear or see things that are not present?")]
        [RequiredOnFinalized(ErrorMessage = "Hallucinations is required.")]
        public int? HALL { get; set; }

        [RequiredIf(nameof(HALL), "1", ErrorMessage = "Provide severity of hallucinations")]
        public int? HALLSEV { get; set; }

        [Display(Name = "Agitation/aggression - Is the patient resistive to help from others at times, or hard to handle?")]
        [RequiredOnFinalized(ErrorMessage = "Agitation/aggression is required.")]
        public int? AGIT { get; set; }

        [RequiredIf(nameof(AGIT), "1", ErrorMessage = "Provide severity of agitation/aggression.")]
        public int? AGITSEV { get; set; }

        [Display(Name = "Depression/dysphoria - Does the patient seem sad or say that he/she is despressed?")]
        [RequiredOnFinalized(ErrorMessage = "Depression/dysphoria is required.")]
        public int? DEPD { get; set; }

        [RequiredIf(nameof(DEPD), "1", ErrorMessage = "Provide severity of depression/dysphoria.")]
        public int? DEPDSEV { get; set; }

        [Display(Name = "Anxiety - Does the patient become upset when separated from you? Does he/she have any other signs of nervousness such as shortness of breath, sighing, being unable to relax or feeling excessively tense?")]
        [RequiredOnFinalized(ErrorMessage = "Anxiety is required.")]
        public int? ANX { get; set; }

        [RequiredIf(nameof(ANX), "1", ErrorMessage = "Provide severity of anxiety.")]
        public int? ANXSEV { get; set; }

        [Display(Name = "Elation/euphoria - Does the patient appear to feel too good or act excessively happy?")]
        [RequiredOnFinalized(ErrorMessage = "Elation/euphoria is required.")]
        public int? ELAT { get; set; }

        [RequiredIf(nameof(ELAT), "1", ErrorMessage = "Provide severity of elation/euphoria.")]
        public int? ELATSEV { get; set; }

        [Display(Name = "Apathy/indifference - Does the patient seem less interested in his/her usual activities or in the activities and plans of others?")]
        [RequiredOnFinalized(ErrorMessage = "Apathy/indifference is required.")]
        public int? APA { get; set; }

        [RequiredIf(nameof(APA), "1", ErrorMessage = "Provide severity of apathy/indifference.")]
        public int? APASEV { get; set; }

        [Display(Name = "Disinhibition - Does the patient seem to act impulsively, for example, talking to strangers as if he/she knows them, or saying things that may hurt people's feelings?")]
        [RequiredOnFinalized(ErrorMessage = "Disinhibition is required.")]
        public int? DISN { get; set; }

        [RequiredIf(nameof(DISN), "1", ErrorMessage = "Provide severity of disinhibition.")]
        public int? DISNSEV { get; set; }

        [Display(Name = "Irritability/lability - Is the patient impatient and cranky? Does he/she have difficulty coping with delays or waiting for planned activities?")]
        [RequiredOnFinalized(ErrorMessage = "Irritability/Lability is required.")]
        public int? IRR { get; set; }

        [RequiredIf(nameof(IRR), "1", ErrorMessage = "Provide severity of irritability/lability.")]
        public int? IRRSEV { get; set; }

        [Display(Name = "Motor disturbance - Does the patient engage in repetitive activities such as pacing around the house, handling buttons, wrapping string, or doing other things repeatedly?")]
        [RequiredOnFinalized(ErrorMessage = "Motor disturbance is required.")]
        public int? MOT { get; set; }

        [RequiredIf(nameof(MOT), "1", ErrorMessage = "Provide severity of motor disturbance.")]
        public int? MOTSEV { get; set; }

        [Display(Name = "Nighttime behaviors - Does the patient awaken you during the night, rise too early in the morning, or take excessive naps during the day?")]
        [RequiredOnFinalized(ErrorMessage = "Nighttime behaviors is required.")]
        public int? NITE { get; set; }

        [RequiredIf(nameof(NITE), "1", ErrorMessage = "Provide severity of nighttime behaviors.")]
        public int? NITESEV { get; set; }

        [Display(Name = "Appetite/eating - Has the patient lost or gained weight, or had a change in the type of food he/she likes?")]
        [RequiredOnFinalized(ErrorMessage = "Appetite/eating is required.")]
        public int? APP { get; set; }

        [RequiredIf(nameof(APP), "1", ErrorMessage = "Provide severity of appetite/eating.")]
        public int? APPSEV { get; set; }

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

