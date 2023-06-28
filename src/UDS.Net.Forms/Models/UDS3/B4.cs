using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B4 : FormModel
    {
        [Display(Name = "")]
        public double? MEMORY { get; set; }

        [Display(Name = "")]
        public double? ORIENT { get; set; }

        [Display(Name = "")]
        public double? JUDGMENT { get; set; }

        [Display(Name = "")]
        public double? COMMUN { get; set; }

        [Display(Name = "")]
        public double? HOMEHOBB { get; set; }

        [Display(Name = "")]
        public double? PERSCARE { get; set; }

        [Display(Name = "")]
        public double? CDRSUM { get; set; }

        [Display(Name = "")]
        public double? CDRGLOB { get; set; }

        [Display(Name = "")]
        public double? COMPORT { get; set; }

        [Display(Name = "")]
        public double? CDRLANG { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

