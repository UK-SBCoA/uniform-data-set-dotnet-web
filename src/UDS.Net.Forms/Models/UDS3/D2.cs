using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class D2 : FormModel
    {
        [Display(Name = "")]
        public int? CANCER { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? CANCSITE { get; set; }

        [Display(Name = "")]
        public int? DIABET { get; set; }

        [Display(Name = "")]
        public int? MYOINF { get; set; }

        [Display(Name = "")]
        public int? CONGHRT { get; set; }

        [Display(Name = "")]
        public int? AFIBRILL { get; set; }

        [Display(Name = "")]
        public int? HYPERT { get; set; }

        [Display(Name = "")]
        public int? ANGINA { get; set; }

        [Display(Name = "")]
        public int? HYPCHOL { get; set; }

        [Display(Name = "")]
        public int? VB12DEF { get; set; }

        [Display(Name = "")]
        public int? THYDIS { get; set; }

        [Display(Name = "")]
        public int? ARTH { get; set; }

        [Display(Name = "")]
        public int? ARTYPE { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? ARTYPEX { get; set; }

        [Display(Name = "")]
        public int? ARTUPEX { get; set; }

        [Display(Name = "")]
        public int? ARTLOEX { get; set; }

        [Display(Name = "")]
        public int? ARTSPIN { get; set; }

        [Display(Name = "")]
        public int? ARTUNKN { get; set; }

        [Display(Name = "")]
        public int? URINEINC { get; set; }

        [Display(Name = "")]
        public int? BOWLINC { get; set; }

        [Display(Name = "")]
        public int? SLEEPAP { get; set; }

        [Display(Name = "")]
        public int? REMDIS { get; set; }

        [Display(Name = "")]
        public int? HYPOSOM { get; set; }

        [Display(Name = "")]
        public int? SLEEPOTH { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? SLEEPOTX { get; set; }

        [Display(Name = "")]
        public int? ANGIOCP { get; set; }

        [Display(Name = "")]
        public int? ANGIOPCI { get; set; }

        [Display(Name = "")]
        public int? PACEMAKE { get; set; }

        [Display(Name = "")]
        public int? HVALVE { get; set; }

        [Display(Name = "")]
        public int? ANTIENC { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? ANTIENCX { get; set; }

        [Display(Name = "")]
        public int? OTHCOND { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? OTHCONDX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

