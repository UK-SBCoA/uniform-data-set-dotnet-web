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
        public int? MEMORY { get; set; }

        [Display(Name = "")]
        public int? ORIENT { get; set; }

        [Display(Name = "")]
        public int? JUDGMENT { get; set; }

        [Display(Name = "")]
        public int? COMMUN { get; set; }

        [Display(Name = "")]
        public int? HOMEHOBB { get; set; }

        [Display(Name = "")]
        public int? PERSCARE { get; set; }

        [Display(Name = "")]
        public int? CDRSUM { get; set; }

        [Display(Name = "")]
        public int? CDRGLOB { get; set; }

        [Display(Name = "")]
        public int? COMPORT { get; set; }

        [Display(Name = "")]
        public int? CDRLANG { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

