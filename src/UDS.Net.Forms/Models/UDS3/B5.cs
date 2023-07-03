using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B5 : FormModel
    {
        [Display(Name = "NPI co-participant")]
        [Range(1, 3)]
        public int? NPIQINF { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(NPIQINF), "3", ErrorMessage = "Specify other co-participant")]
        [RegularExpression(@"^[^'&%""]*$", ErrorMessage = "Single quotes ('), double quotes (\"), ampersands (&) and percentage signs (%) are not allowed")]
        public string? NPIQINFX { get; set; }

        [Display(Name = "Delusions - Does the patient have false beliefs, such as thinking that others are stealing from him/her or planning to harm him/her in some way?")]
        public int? DEL { get; set; }

        public int? DELSEV { get; set; }

        [Display(Name = "Hallucinations - Does the patient have hallucinations such as false visions or voices? Does he or she seem to hear or see things that are not present?")]
        public int? HALL { get; set; }

        public int? HALLSEV { get; set; }

        [Display(Name = "Agitation/aggression - Is the patient resistive to help from others at times, or hard to handle?")]
        public int? AGIT { get; set; }

        public int? AGITSEV { get; set; }

        [Display(Name = "Depression/dysphoria - Does the patient seem sad or say that he/she is despressed?")]
        public int? DEPD { get; set; }

        public int? DEPDSEV { get; set; }

        [Display(Name = "Anxiety - Does the patient become upset when separated from you? Does he/she have any other signs of nervousness such as shortness of breath, sighing, being unable to relax or feeling excessively tense?")]
        public int? ANX { get; set; }

        public int? ANXSEV { get; set; }

        [Display(Name = "Elation/euphoria - Does the patient appear to feel too good or act excessively happy?")]
        public int? ELAT { get; set; }

        public int? ELATSEV { get; set; }

        [Display(Name = "Apathy/indifference - Does the patient seem less interested in his/her usual activities or in the activities and plans of others?")]
        public int? APA { get; set; }

        public int? APASEV { get; set; }

        [Display(Name = "Disinhibition - Does the patient seem to act impulsively, for example, talking to strangers as if he/she knows them, or saying things that may hurt people's feelings?")]
        public int? DISN { get; set; }

        public int? DISNSEV { get; set; }

        [Display(Name = "Irritability/Lability - Is the patient impatient and cranky? Does he/she have difficulty coping with delays or waiting for planned activities?")]
        public int? IRR { get; set; }

        public int? IRRSEV { get; set; }

        [Display(Name = "Motor disturbance - Does the patient engage in repetitive activities such as pacing around the house, handling buttons, wrapping string, or doing other things repeatedly?")]
        public int? MOT { get; set; }

        public int? MOTSEV { get; set; }

        [Display(Name = "Nighttime behaviors - Does the patient awaken you during the night, rise too early in the morning, or take excessive naps during the day?")]
        public int? NITE { get; set; }

        public int? NITESEV { get; set; }

        [Display(Name = "Appetite/eating - Has the patient lost or gained weight, or had a change in the type of food he/she likes?")]
        public int? APP { get; set; }

        public int? APPSEV { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

