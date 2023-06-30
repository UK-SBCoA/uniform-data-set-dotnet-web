using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B4 : FormModel
    {
        [Display(Name = "Memory")]
        public double? MEMORY { get; set; }

        [Display(Name = "Orientation")]
        public double? ORIENT { get; set; }

        [Display(Name = "Judgment and problem solving")]
        public double? JUDGMENT { get; set; }

        [Display(Name = "Community affairs")]
        public double? COMMUN { get; set; }

        [Display(Name = "Homes and hobbies")]
        public double? HOMEHOBB { get; set; }

        [Display(Name = "Personal care")]
        public double? PERSCARE { get; set; }

        [Display(Name = "CDR sum of boxes")]
        [RegularExpression("^(0(.5)?|[1-9](.5)?|1[0-5](.5)?|1[6-8])$", ErrorMessage = "0,18 (except scores of 16.5 and 17.5 not possible)")]
        public double? CDRSUM { get; set; }

        [Display(Name = "Global CDR")]
        public double? CDRGLOB { get; set; }

        [Display(Name = "Behavior, comportment, and personality")]
        public double? COMPORT { get; set; }

        [Display(Name = "Language")]
        public double? CDRLANG { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

