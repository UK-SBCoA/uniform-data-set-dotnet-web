﻿using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B1 : FormModel
    {
        [Display(Name = "Participant height (inches)")]
        [RegularExpression("^(3[6-9](.[0-9])?|[4-7][0-9](.[0-9])?|8[0-7](.[0-9])?|88.8)$", ErrorMessage = "(36.0-87.9, 88.8 = not assessed)")]
        [RequiredOnComplete]
        public double? HEIGHT { get; set; }

        [Display(Name = "Participant weight (lbs)")]
        [RegularExpression("^(5\\d|[6-9]\\d|[1-3]\\d{2}|400|888)$", ErrorMessage = "(50-400, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? WEIGHT { get; set; }

        [Display(Name = "Systolic (sitting)")]
        [RegularExpression("^(7\\d|[89]\\d|1\\d{2}|2[0-2]\\d|230|777|888)$", ErrorMessage = "(70-230, 777 = BP Addendum submitted, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? BPSYS { get; set; }

        [Display(Name = "Diastolic (sitting)")]
        [RegularExpression("^(3\\d|[4-9]\\d|1[0-3]\\d|140|777|888)$", ErrorMessage = "(30-140, 777 = BP Addendum submitted, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? BPDIAS { get; set; }

        [Display(Name = "Participant resting heart rate (pulse)")]
        [RegularExpression("^(3[3-9]|[4-9]\\d|1[0-5]\\d|160|888)$", ErrorMessage = "(33-160, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? HRATE { get; set; }

        [Display(Name = "Without corrective lenses, is the participant’s vision functionally normal?")]
        [RequiredOnComplete]
        public int? VISION { get; set; }

        [Display(Name = "Does the participant usually wear corrective lenses?")]
        [RequiredOnComplete]
        public int? VISCORR { get; set; }

        [Display(Name = "If yes, is the participant’s vision functionally normal with corrective lenses?")]
        [RequiredIf(nameof(VISCORR), "1", ErrorMessage = "Specify if the participant’s vision functionally normal with corrective lenses?")]
        public int? VISWCORR { get; set; }

        [Display(Name = "Without a hearing aid(s), is the participant’s hearing functionally normal?")]
        [RequiredOnComplete]
        public int? HEARING { get; set; }

        [Display(Name = "Does the participant usually wear a hearing aid(s)?")]
        [RequiredOnComplete]
        public int? HEARAID { get; set; }

        [Display(Name = "If yes, is the participant’s hearing functionally normal with a hearing aid(s)?")]
        [RequiredIf(nameof(HEARAID), "1", ErrorMessage = "Specify if the participant’s hearing functionally normal with a hearing aid(s)?")]
        public int? HEARWAID { get; set; }

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
