using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B7 : FormModel
    {
        [Display(Name = "")]
        public int? BILLS { get; set; }

        [Display(Name = "")]
        public int? TAXES { get; set; }

        [Display(Name = "")]
        public int? SHOPPING { get; set; }

        [Display(Name = "")]
        public int? GAMES { get; set; }

        [Display(Name = "")]
        public int? STOVE { get; set; }

        [Display(Name = "")]
        public int? MEALPREP { get; set; }

        [Display(Name = "")]
        public int? EVENTS { get; set; }

        [Display(Name = "")]
        public int? PAYATTN { get; set; }

        [Display(Name = "")]
        public int? REMDATES { get; set; }

        [Display(Name = "")]
        public int? TRAVEL { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

