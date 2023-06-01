using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B5 : FormModel
    {
        [Display(Name = "")]
        public int? NPIQINF { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? NPIQINFX { get; set; }

        [Display(Name = "")]
        public int? DEL { get; set; }

        [Display(Name = "")]
        public int? DELSEV { get; set; }

        [Display(Name = "")]
        public int? HALL { get; set; }

        [Display(Name = "")]
        public int? HALLSEV { get; set; }

        [Display(Name = "")]
        public int? AGIT { get; set; }

        [Display(Name = "")]
        public int? AGITSEV { get; set; }

        [Display(Name = "")]
        public int? DEPD { get; set; }

        [Display(Name = "")]
        public int? DEPDSEV { get; set; }

        [Display(Name = "")]
        public int? ANX { get; set; }

        [Display(Name = "")]
        public int? ANXSEV { get; set; }

        [Display(Name = "")]
        public int? ELAT { get; set; }

        [Display(Name = "")]
        public int? ELATSEV { get; set; }

        [Display(Name = "")]
        public int? APA { get; set; }

        [Display(Name = "")]
        public int? APASEV { get; set; }

        [Display(Name = "")]
        public int? DISN { get; set; }

        [Display(Name = "")]
        public int? DISNSEV { get; set; }

        [Display(Name = "")]
        public int? IRR { get; set; }

        [Display(Name = "")]
        public int? IRRSEV { get; set; }

        [Display(Name = "")]
        public int? MOT { get; set; }

        [Display(Name = "")]
        public int? MOTSEV { get; set; }

        [Display(Name = "")]
        public int? NITE { get; set; }

        [Display(Name = "")]
        public int? NITESEV { get; set; }

        [Display(Name = "")]
        public int? APP { get; set; }

        [Display(Name = "")]
        public int? APPSEV { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

