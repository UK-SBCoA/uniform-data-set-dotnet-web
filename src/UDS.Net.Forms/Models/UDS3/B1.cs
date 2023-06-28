using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B1 : FormModel
    {
    
        [Display(Name = "Participant height (inches)")]
        [RegularExpression("^(3[6-9]\\.\\d| [4-7]\\d\\.\\d|8[0-7]\\.\\d|87\\.[0-9]|88\\.8)$", ErrorMessage = "(36.0-87.9, 88.8 = not assessed)")]
        public double? HEIGHT { get; set; }

        [Display(Name = "Participant weight (lbs)")]
        [RegularExpression("^(5\\d|[6-9]\\d|[1-3]\\d{2}|400|888)$", ErrorMessage = "(50-400, 888 = Not assessed)")]
        public int? WEIGHT { get; set; }

        [Display(Name = "Participantblood pressure at initial reading (sitting)")]
        [RegularExpression("^(7\\d|[89]\\d|1\\d{2}|2[0-2]\\d|230)|777|888)$", ErrorMessage = "(70-230, 777 = BP Addendum submitted, 888 = Not assessed)")]
        public int? BPSYS { get; set; }

        [Display(Name = "Participant blood pressure (sitting), diastolic")]
        [RegularExpression("^(3\\d|[4-9]\\d|1[0-3]\\d|140)|888)$", ErrorMessage = "(30-140, 888 = Not assessed)")]
        public int? BPDIAS { get; set; }

        [Display(Name = "Participantresting heart rate (pulse)")]
        [RegularExpression("^(3[3-9]|[4-9]\\d|1[0-5]\\d|160)|888)$", ErrorMessage = "(33-160, 888 = Not assessed)")]
        public int? HRATE { get; set; }

        [Display(Name = "Without corrective lenses, is the participant’s vision functionally normal?")]
        public int? VISION { get; set; }

        [Display(Name = "Does the participant usually wear corrective lenses?")]
        public int? VISCORR { get; set; }

        [Display(Name = "If yes, is the participant’s vision functionally normal with corrective lenses?")]
        [RequiredIf(nameof(VISCORR), "1", ErrorMessage = "Specify if the participant’s vision functionally normal with corrective lenses?")]
        public int? VISWCORR { get; set; }

        [Display(Name = "Without a hearing aid(s), is the participant’s hearing functionally normal?")]
        public int? HEARING { get; set; }

        [Display(Name = "Does the participant usually wear a hearing aid(s)?")]
        public int? HEARAID { get; set; }

        [Display(Name = "If yes, is the participant’s hearing functionally normal with a hearing aid(s)?")]
        [RequiredIf(nameof(HEARAID), "1", ErrorMessage = "Specify if the participant’s hearing functionally normal with a hearing aid(s)?")]
        public int? HEARWAID { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

