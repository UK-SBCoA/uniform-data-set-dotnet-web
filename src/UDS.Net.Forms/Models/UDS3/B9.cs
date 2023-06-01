using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B9 : FormModel
    {
        [Display(Name = "")]
        public int? DECSUB { get; set; }

        [Display(Name = "")]
        public int? DECIN { get; set; }

        [Display(Name = "")]
        public int? DECCLCOG { get; set; }

        [Display(Name = "")]
        public int? COGMEM { get; set; }

        [Display(Name = "")]
        public int? COGORI { get; set; }

        [Display(Name = "")]
        public int? COGJUDG { get; set; }

        [Display(Name = "")]
        public int? COGLANG { get; set; }

        [Display(Name = "")]
        public int? COGVIS { get; set; }

        [Display(Name = "")]
        public int? COGATTN { get; set; }

        [Display(Name = "")]
        public int? COGFLUC { get; set; }

        [Display(Name = "")]
        public int? COGFLAGO { get; set; }

        [Display(Name = "")]
        public int? COGOTHR { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? COGOTHRX { get; set; }

        [Display(Name = "")]
        public int? COGFPRED { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? COGFPREX { get; set; }

        [Display(Name = "")]
        public int? COGMODE { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? COGMODEX { get; set; }

        [Display(Name = "")]
        public int? DECAGE { get; set; }

        [Display(Name = "")]
        public int? DECCLBE { get; set; }

        [Display(Name = "")]
        public int? BEAPATHY { get; set; }

        [Display(Name = "")]
        public int? BEDEP { get; set; }

        [Display(Name = "")]
        public int? BEVHALL { get; set; }

        [Display(Name = "")]
        public int? BEVWELL { get; set; }

        [Display(Name = "")]
        public int? BEVHAGO { get; set; }

        [Display(Name = "")]
        public int? BEAHALL { get; set; }

        [Display(Name = "")]
        public int? BEDEL { get; set; }

        [Display(Name = "")]
        public int? BEDISIN { get; set; }

        [Display(Name = "")]
        public int? BEIRRIT { get; set; }

        [Display(Name = "")]
        public int? BEAGIT { get; set; }

        [Display(Name = "")]
        public int? BEPERCH { get; set; }

        [Display(Name = "")]
        public int? BEREM { get; set; }

        [Display(Name = "")]
        public int? BEREMAGO { get; set; }

        [Display(Name = "")]
        public int? BEANX { get; set; }

        [Display(Name = "")]
        public int? BEOTHR { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? BEOTHRX { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public int? BEFPRED { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? BEFPREDX { get; set; }

        [Display(Name = "")]
        public int? BEMODE { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? BEMODEX { get; set; }

        [Display(Name = "")]
        public int? BEAGE { get; set; }

        [Display(Name = "")]
        public int? DECCLMOT { get; set; }

        [Display(Name = "")]
        public int? MOGAIT { get; set; }

        [Display(Name = "")]
        public int? MOFALLS { get; set; }

        [Display(Name = "")]
        public int? MOTREM { get; set; }

        [Display(Name = "")]
        public int? MOSLOW { get; set; }

        [Display(Name = "")]
        public int? MOFRST { get; set; }

        [Display(Name = "")]
        public int? MOMODE { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? MOMODEX { get; set; }

        [Display(Name = "")]
        public int? MOMOPARK { get; set; }

        [Display(Name = "")]
        public int? PARKAGE { get; set; }

        [Display(Name = "")]
        public int? MOMOALS { get; set; }

        [Display(Name = "")]
        public int? ALSAGE { get; set; }

        [Display(Name = "")]
        public int? MOAGE { get; set; }

        [Display(Name = "")]
        public int? COURSE { get; set; }

        [Display(Name = "")]
        public int? FRSTCHG { get; set; }

        [Display(Name = "")]
        public int? LBDEVAL { get; set; }

        [Display(Name = "")]
        public int? FTLDEVAL { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

