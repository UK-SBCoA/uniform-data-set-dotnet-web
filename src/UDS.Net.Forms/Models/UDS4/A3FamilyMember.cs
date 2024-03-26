using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A3FamilyMember
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

    }
}

