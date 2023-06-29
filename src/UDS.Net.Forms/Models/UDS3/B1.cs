using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B1 : FormModel
    {
        [Display(Name = "")]
        public double? HEIGHT { get; set; }

        [Display(Name = "")]
        public int? WEIGHT { get; set; }

        [Display(Name = "")]
        public int? BPSYS { get; set; }

        [Display(Name = "")]
        public int? BPDIAS { get; set; }

        [Display(Name = "")]
        public int? HRATE { get; set; }

        [Display(Name = "")]
        public int? VISION { get; set; }

        [Display(Name = "")]
        public int? VISCORR { get; set; }

        [Display(Name = "")]
        public int? VISWCORR { get; set; }

        [Display(Name = "")]
        public int? HEARING { get; set; }

        [Display(Name = "")]
        public int? HEARAID { get; set; }

        [Display(Name = "")]
        public int? HEARWAID { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

