using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B6 : FormModel
    {
        [Display(Name = "")]
        public int? NOGDS { get; set; }

        [Display(Name = "")]
        public int? SATIS { get; set; }

        [Display(Name = "")]
        public int? DROPACT { get; set; }

        [Display(Name = "")]
        public int? EMPTY { get; set; }

        [Display(Name = "")]
        public int? BORED { get; set; }

        [Display(Name = "")]
        public int? SPIRITS { get; set; }

        [Display(Name = "")]
        public int? AFRAID { get; set; }

        [Display(Name = "")]
        public int? HAPPY { get; set; }

        [Display(Name = "")]
        public int? HELPLESS { get; set; }

        [Display(Name = "")]
        public int? STAYHOME { get; set; }

        [Display(Name = "")]
        public int? MEMPROB { get; set; }

        [Display(Name = "")]
        public int? WONDRFUL { get; set; }

        [Display(Name = "")]
        public int? WRTHLESS { get; set; }

        [Display(Name = "")]
        public int? ENERGY { get; set; }

        [Display(Name = "")]
        public int? HOPELESS { get; set; }

        [Display(Name = "")]
        public int? BETTER { get; set; }

        [Display(Name = "")]
        public int? GDS { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

