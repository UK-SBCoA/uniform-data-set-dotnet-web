using System;
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

        [Display(Name = "Waist circumference measurements (inches): Measurement 1")]
        [RegularExpression("^(20|2[1-9]|[3-5]\\d|60|888)$", ErrorMessage = "(20-60, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? WAIST1 { get; set; }

        [Display(Name = "Waist circumference measurements (inches): Measurement 2")]
        [RegularExpression("^(20|2[1-9]|[3-5]\\d|60|888)$", ErrorMessage = "(20-60, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? WAIST2 { get; set; }

        [Display(Name = "Hip circumference measurements (inches): Measurement 1")]
        [RegularExpression("^(20|2[1-9]|[3-5]\\d|60|888)$", ErrorMessage = "(20-60, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? HIP1 { get; set; }

        [Display(Name = "Hip circumference measurements (inches): Measurement 2")]
        [RegularExpression("^(20|2[1-9]|[3-5]\\d|60|888)$", ErrorMessage = "(20-60, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? HIP2 { get; set; }

        [Display(Name = "Reading 1")]
        [RegularExpression("^(7\\d|[89]\\d|1\\d{2}|2[0-2]\\d|230|888)$", ErrorMessage = "(70-230, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Left arm: Systolic Reading 1 Required")]
        public int? BPSYSL1 { get; set; }

        [Display(Name = "Reading 1")]
        [RegularExpression("^(3\\d|[4-9]\\d|1[0-3]\\d|140|888)$", ErrorMessage = "(30-140, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Left arm: Diastolic Reading 1 Required")]
        public int? BPDIASL1 { get; set; }

        [Display(Name = "Reading 2")]
        [RegularExpression("^(7\\d|[89]\\d|1\\d{2}|2[0-2]\\d|230|888)$", ErrorMessage = "(70-230, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Left arm: Systolic Reading 2 Required")]
        public int? BPSYSL2 { get; set; }

        [Display(Name = "Reading 2")]
        [RegularExpression("^(3\\d|[4-9]\\d|1[0-3]\\d|140|888)$", ErrorMessage = "(30-140, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Left arm: Diastolic Reading 2 Required")]
        public int? BPDIASL2 { get; set; }

        [Display(Name = "Reading 1")]
        [RegularExpression("^(7\\d|[89]\\d|1\\d{2}|2[0-2]\\d|230|888)$", ErrorMessage = "(70-230, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Right arm: Systolic Reading 1 Required")]
        public int? BPSYSR1 { get; set; }

        [Display(Name = "Participant blood pressure - Right arm: Diastolic Reading 1")]
        [RegularExpression("^(3\\d|[4-9]\\d|1[0-3]\\d|140|888)$", ErrorMessage = "(30-140, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Right arm: Diastolic Reading 1 Required")]
        public int? BPDIASR1 { get; set; }

        [Display(Name = "Reading 2")]
        [RegularExpression("^(7\\d|[89]\\d|1\\d{2}|2[0-2]\\d|230|888)$", ErrorMessage = "(70-230, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Right arm: Systolic Reading 2 Required")]
        public int? BPSYSR2 { get; set; }

        [Display(Name = "Reading 2")]
        [RegularExpression("^(3\\d|[4-9]\\d|1[0-3]\\d|140|888)$", ErrorMessage = "(30-140, 888 = Not assessed)")]
        [RequiredOnComplete(ErrorMessage = "Right arm: Diastolic Reading 2 Required")]
        public int? BPDIASR2 { get; set; }

        [Display(Name = "Participant resting heart rate (pulse)")]
        [RegularExpression("^(3[3-9]|[4-9]\\d|1[0-5]\\d|160|888)$", ErrorMessage = "(33-160, 888 = Not assessed)")]
        [RequiredOnComplete]
        public int? HRATE { get; set; }

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

