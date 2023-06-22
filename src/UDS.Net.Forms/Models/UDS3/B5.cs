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
        public string? NPIQINFX { get; set; }

        [Display(Name = "Delusions - Does the participant have false beliefs, such as thinking that others are stealing from him/her or planning to harm him/her in some way?")]
        public int? DEL { get; set; }

        public int? DELSEV { get; set; }

        [Display(Name = "Hallucinations - Does the participant have hallucinations such as false visions or voices? Does he or she seem to hear or see things that are not present?")]
        public int? HALL { get; set; }

        public int? HALLSEV { get; set; }

        [Display(Name = "Agitation/aggression")]
        public int? AGIT { get; set; }

        public int? AGITSEV { get; set; }

        [Display(Name = "Depression/dysphoria")]
        public int? DEPD { get; set; }

        public int? DEPDSEV { get; set; }

        [Display(Name = "Anxiety")]
        public int? ANX { get; set; }

        public int? ANXSEV { get; set; }

        [Display(Name = "Elation/euphoria")]
        public int? ELAT { get; set; }

        public int? ELATSEV { get; set; }

        [Display(Name = "Apathy/indifference")]
        public int? APA { get; set; }

        public int? APASEV { get; set; }

        [Display(Name = "Disinhibition")]
        public int? DISN { get; set; }

        public int? DISNSEV { get; set; }

        [Display(Name = "Irritability/Iability")]
        public int? IRR { get; set; }

        public int? IRRSEV { get; set; }

        [Display(Name = "Motor disturbance")]
        public int? MOT { get; set; }

        public int? MOTSEV { get; set; }

        [Display(Name = "Nighttime behaviors")]
        public int? NITE { get; set; }

        public int? NITESEV { get; set; }

        [Display(Name = "Appetite/eating")]
        public int? APP { get; set; }

        public int? APPSEV { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

