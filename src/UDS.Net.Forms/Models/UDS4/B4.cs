using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B4 : FormModel
    {
        [Display(Name = "Memory")]
        [RequiredOnComplete]
        public double? MEMORY { get; set; }

        [Display(Name = "Orientation")]
        [RequiredOnComplete]
        public double? ORIENT { get; set; }

        [Display(Name = "Judgment and problem solving")]
        [RequiredOnComplete]
        public double? JUDGMENT { get; set; }

        [Display(Name = "Community affairs")]
        [RequiredOnComplete]
        public double? COMMUN { get; set; }

        [Display(Name = "Homes and hobbies")]
        [RequiredOnComplete]
        public double? HOMEHOBB { get; set; }

        [Display(Name = "Personal care")]
        [RequiredOnComplete]
        public double? PERSCARE { get; set; }

        [Display(Name = "CDR sum of boxes")]
        [RegularExpression("^(0(.5)?|[1-9](.5)?|1[0-5](.5)?|1[6-8])$", ErrorMessage = "0,18 (except scores of 16.5 and 17.5 not possible)")]
        [RequiredOnComplete]
        public double? CDRSUM { get; set; }

        [Display(Name = "Global CDR")]
        [RequiredOnComplete]
        public double? CDRGLOB { get; set; }

        [Display(Name = "Behavior, comportment, and personality")]
        [RequiredOnComplete]
        public double? COMPORT { get; set; }

        [Display(Name = "Language")]
        [RequiredOnComplete]
        public double? CDRLANG { get; set; }

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

