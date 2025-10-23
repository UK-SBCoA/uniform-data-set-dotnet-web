using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A3FamilyMember : IValidatableObject
    {
        public int FamilyMemberIndex { get; set; }

        [Display(Name = "Birth year")]
        [BirthYear(AllowUnknown = true)]
        public int? YOB { get; set; }

        [Display(Name = "Age at death")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "Age at death must be 0-110, or 888 (N/A), or 999 (unknown)")]
        public int? AGD { get; set; }

        [Display(Name = "Primary Dx")]
        [RegularExpression("^(0[0-9]|1[0-2]|99)$", ErrorMessage = "Codes must be 00-12 or 99")]
        public string? ETPR { get; set; }

        [Display(Name = "Secondary Dx")]
        [RegularExpression("^(0[0-9]|1[0-2]|88|99)$", ErrorMessage = "Codes must be 00-12 88 or 99")]
        public string? ETSEC { get; set; }

        [Display(Name = "Method of evaluation")]
        [Range(1, 4)]
        public int? MEVAL { get; set; }

        [Display(Name = "Age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Age of onset must be 0-110, or 999 (unknown)")]
        public int? AGO { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (YOB.HasValue && !AGD.HasValue)
            {
                yield return new ValidationResult(
                    "Please provide a value for age at death.",
                    new[] { nameof(AGD) });
            }

            if (YOB.HasValue || AGD.HasValue)
            {
                if (string.IsNullOrEmpty(ETPR))
                {
                    yield return new ValidationResult(
                        "Please provide a value for primary dx.",
                        new[] { nameof(ETPR) });
                }
            }

            if (!string.IsNullOrEmpty(ETPR) && ETPR != "00" && ETPR != "99")
            {
                if (ETSEC == null)
                {
                    yield return new ValidationResult(
                        "Please provide a value for secondary dx.",
                        new[] { nameof(ETSEC) });
                }
                if (!MEVAL.HasValue)
                {
                    yield return new ValidationResult(
                        "Please provide a value for method of evaluation.",
                        new[] { nameof(MEVAL) });
                }
                if (!AGO.HasValue)
                {
                    yield return new ValidationResult(
                        "Please provide a value for age of onset.",
                        new[] { nameof(AGO) });
                }
            }

            if (AGO.HasValue && AGD.HasValue && AGO > AGD && AGO != 999 && AGO != 888)
            {
                yield return new ValidationResult(
                    "Age of onset cannot be greater than age of death",
                    new[] { nameof(AGO) });
            }

            bool YOBKnown = YOB.HasValue && YOB != 9999;

            if (YOBKnown && AGD.HasValue && AGD.Value > DateTime.Now.Year - YOB.Value && AGD.Value != 999 && AGD.Value != 888)
            {
                yield return new ValidationResult(
                    "Age of death cannot be greater than the current year minus the birth year",
                    new[] { nameof(AGD) });
            }

            if (YOBKnown && AGO.HasValue && AGO > DateTime.Now.Year - YOB.Value && AGO != 999)
            {
                yield return new ValidationResult(
                    "Age of onset cannot be greater than the current year minus the birth year",
                    new[] { nameof(AGO) });
            }
        }
    }
}

