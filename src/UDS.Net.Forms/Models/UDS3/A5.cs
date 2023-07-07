using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A5 : FormModel
    {
        [Display(Name = "")]
        public int? TOBAC30 { get; set; }

        [Display(Name = "")]
        public int? TOBAC100 { get; set; }

        [Display(Name = "")]
        public int? SMOKYRS { get; set; }

        [Display(Name = "")]
        public int? PACKSPER { get; set; }

        [Display(Name = "")]
        public int? QUITSMOK { get; set; }

        [Display(Name = "")]
        public int? ALCOCCAS { get; set; }

        [Display(Name = "")]
        public int? ALCFREQ { get; set; }

        [Display(Name = "")]
        public int? CVHATT { get; set; }

        [Display(Name = "")]
        public int? HATTMULT { get; set; }

        [Display(Name = "")]
        public int? HATTYEAR { get; set; }

        [Display(Name = "")]
        public int? CVAFIB { get; set; }

        [Display(Name = "")]
        public int? CVANGIO { get; set; }

        [Display(Name = "")]
        public int? CVBYPASS { get; set; }

        [Display(Name = "")]
        public int? CVPACDEF { get; set; }

        [Display(Name = "")]
        public int? CVCHF { get; set; }

        [Display(Name = "")]
        public int? CVANGINA { get; set; }

        [Display(Name = "")]
        public int? CVHVALVE { get; set; }

        [Display(Name = "")]
        public int? CVOTHR { get; set; }

        [Display(Name = "")]
        [SpecialCharacter]
        public string? CVOTHRX { get; set; }

        [Display(Name = "")]
        public int? CBSTROKE { get; set; }

        [Display(Name = "")]
        public int? STROKMUL { get; set; }

        [Display(Name = "")]
        public int? STROKYR { get; set; }

        [Display(Name = "")]
        public int? CBTIA { get; set; }

        [Display(Name = "")]
        public int? TIAMULT { get; set; }

        [Display(Name = "")]
        public int? TIAYEAR { get; set; }

        [Display(Name = "")]
        public int? PD { get; set; }

        [Display(Name = "")]
        public int? PDYR { get; set; }

        [Display(Name = "")]
        public int? PDOTHR { get; set; }

        [Display(Name = "")]
        public int? PDOTHRYR { get; set; }

        [Display(Name = "")]
        public int? SEIZURES { get; set; }

        [Display(Name = "")]
        public int? TBI { get; set; }

        [Display(Name = "")]
        public int? TBIBRIEF { get; set; }

        [Display(Name = "")]
        public int? TBIEXTEN { get; set; }

        [Display(Name = "")]
        public int? TBIWOLOS { get; set; }

        [Display(Name = "")]
        public int? TBIYEAR { get; set; }

        [Display(Name = "")]
        public int? DIABETES { get; set; }

        [Display(Name = "")]
        public int? DIABTYPE { get; set; }

        [Display(Name = "")]
        public int? HYPERTEN { get; set; }

        [Display(Name = "")]
        public int? HYPERCHO { get; set; }

        [Display(Name = "")]
        public int? B12DEF { get; set; }

        [Display(Name = "")]
        public int? THYROID { get; set; }

        [Display(Name = "")]
        public int? ARTHRIT { get; set; }

        [Display(Name = "")]
        public int? ARTHTYPE { get; set; }

        [Display(Name = "")]
        [SpecialCharacter]
        public string? ARTHTYPX { get; set; }

        [Display(Name = "")]
        public int? ARTHUPEX { get; set; }

        [Display(Name = "")]
        public int? ARTHLOEX { get; set; }

        [Display(Name = "")]
        public int? ARTHSPIN { get; set; }

        [Display(Name = "")]
        public int? ARTHUNK { get; set; }

        [Display(Name = "")]
        public int? INCONTU { get; set; }

        [Display(Name = "")]
        public int? INCONTF { get; set; }

        [Display(Name = "")]
        public int? APNEA { get; set; }

        [Display(Name = "")]
        public int? RBD { get; set; }

        [Display(Name = "")]
        public int? INSOMN { get; set; }

        [Display(Name = "")]
        public int? OTHSLEEP { get; set; }

        [Display(Name = "")]
        [SpecialCharacter]
        public string? OTHSLEEX { get; set; }

        [Display(Name = "")]
        public int? ALCOHOL { get; set; }

        [Display(Name = "")]
        public int? ABUSOTHR { get; set; }

        [Display(Name = "")]
        [SpecialCharacter]
        public string? ABUSX { get; set; }

        [Display(Name = "")]
        public int? PTSD { get; set; }

        [Display(Name = "")]
        public int? BIPOLAR { get; set; }

        [Display(Name = "")]
        public int? SCHIZ { get; set; }

        [Display(Name = "")]
        public int? DEP2YRS { get; set; }

        [Display(Name = "")]
        public int? DEPOTHR { get; set; }

        [Display(Name = "")]
        public int? ANXIETY { get; set; }

        [Display(Name = "")]
        public int? OCD { get; set; }

        [Display(Name = "")]
        public int? NPSYDEV { get; set; }

        [Display(Name = "")]
        public int? PSYCDIS { get; set; }

        [Display(Name = "")]
        [SpecialCharacter]
        public string? PSYCDISX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

