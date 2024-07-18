using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A3 : FormModel
    {
        [Display(Name = "Are there affected first-degree relatives (biological parents, full siblings, or biological children)?")]
        [RegularExpression("^(0|1|9)$")]
        public int? AFFFAMM { get; set; } // initial visits

        [Display(Name = "Since the last visit, is new information available concerning genetic mutations addressed by Questions 2a through 4b, below?\n“Affected” = having dementia or one of the non-normal diagnoses listed in Appendix 1")]
        public int? NWINFMUT { get; set; } // follow-up visits

        [Display(Name = "Mother — birth year")]
        [BirthYear(AllowUnknown = true)]
        [RequiredOnFinalized]
        public int? MOMYOB { get; set; }

        [Display(Name = "Mother — age at death")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "Mother age at death must be 0-110, or 888 (N/A), or 999 (unknown)")]
        [RequiredOnFinalized(ErrorMessage = "Please provide an age at death or indicate otherwise")]
        public int? MOMDAGE { get; set; }


        [Display(Name = "Mother — Primary dx")]
        [RegularExpression("^(0[0-9]|1[0-2]|99)$", ErrorMessage = "Codes must be 00-12 or 99")]
        [RequiredOnFinalized(ErrorMessage = "Please provide a value for Primary dx")]
        public string? MOMETPR { get; set; }

        [Display(Name = "Mother — primary diagnosis")]
        [RegularExpression("^(0[0-9]|1[0-2]|88|99)$", ErrorMessage = "Codes must be 00-12 88 or 99")]
        [RequiredIf(nameof(MOMETPR), "01", ErrorMessage = "Secondary Dx required when Primary Dx = 01")]
        [RequiredIf(nameof(MOMETPR), "02", ErrorMessage = "Secondary Dx required when Primary Dx = 02")]
        [RequiredIf(nameof(MOMETPR), "03", ErrorMessage = "Secondary Dx required when Primary Dx = 03")]
        [RequiredIf(nameof(MOMETPR), "04", ErrorMessage = "Secondary Dx required when Primary Dx = 04")]
        [RequiredIf(nameof(MOMETPR), "05", ErrorMessage = "Secondary Dx required when Primary Dx = 05")]
        [RequiredIf(nameof(MOMETPR), "06", ErrorMessage = "Secondary Dx required when Primary Dx = 06")]
        [RequiredIf(nameof(MOMETPR), "07", ErrorMessage = "Secondary Dx required when Primary Dx = 07")]
        [RequiredIf(nameof(MOMETPR), "08", ErrorMessage = "Secondary Dx required when Primary Dx = 08")]
        [RequiredIf(nameof(MOMETPR), "09", ErrorMessage = "Secondary Dx required when Primary Dx = 09")]
        [RequiredIf(nameof(MOMETPR), "10", ErrorMessage = "Secondary Dx required when Primary Dx = 10")]
        [RequiredIf(nameof(MOMETPR), "11", ErrorMessage = "Secondary Dx required when Primary Dx = 11")]
        [RequiredIf(nameof(MOMETPR), "12", ErrorMessage = "Secondary Dx required when Primary Dx = 12")]
        public string? MOMETSEC { get; set; }

        [Display(Name = "Mother — method of evaluation")]
        [Range(1, 4, ErrorMessage = "Must be in the range of 1-4")]
        [RequiredIf(nameof(MOMETPR), "01", ErrorMessage = "Method required when Primary Dx = 01")]
        [RequiredIf(nameof(MOMETPR), "02", ErrorMessage = "Method required when Primary Dx = 02")]
        [RequiredIf(nameof(MOMETPR), "03", ErrorMessage = "Method required when Primary Dx = 03")]
        [RequiredIf(nameof(MOMETPR), "04", ErrorMessage = "Method required when Primary Dx = 04")]
        [RequiredIf(nameof(MOMETPR), "05", ErrorMessage = "Method required when Primary Dx = 05")]
        [RequiredIf(nameof(MOMETPR), "06", ErrorMessage = "Method required when Primary Dx = 06")]
        [RequiredIf(nameof(MOMETPR), "07", ErrorMessage = "Method required when Primary Dx = 07")]
        [RequiredIf(nameof(MOMETPR), "08", ErrorMessage = "Method required when Primary Dx = 08")]
        [RequiredIf(nameof(MOMETPR), "09", ErrorMessage = "Method required when Primary Dx = 09")]
        [RequiredIf(nameof(MOMETPR), "10", ErrorMessage = "Method required when Primary Dx = 10")]
        [RequiredIf(nameof(MOMETPR), "11", ErrorMessage = "Method required when Primary Dx = 11")]
        [RequiredIf(nameof(MOMETPR), "12", ErrorMessage = "Method required when Primary Dx = 12")]
        public int? MOMMEVAL { get; set; }

        [Display(Name = "Mother — age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Mother age of onset must be 0-110, or 999 (unknown)")]
        [RequiredIf(nameof(MOMETPR), "01", ErrorMessage = "Age of onset required when Primary Dx = 01")]
        [RequiredIf(nameof(MOMETPR), "02", ErrorMessage = "Age of onset required when Primary Dx = 02")]
        [RequiredIf(nameof(MOMETPR), "03", ErrorMessage = "Age of onset required when Primary Dx = 03")]
        [RequiredIf(nameof(MOMETPR), "04", ErrorMessage = "Age of onset required when Primary Dx = 04")]
        [RequiredIf(nameof(MOMETPR), "05", ErrorMessage = "Age of onset required when Primary Dx = 05")]
        [RequiredIf(nameof(MOMETPR), "06", ErrorMessage = "Age of onset required when Primary Dx = 06")]
        [RequiredIf(nameof(MOMETPR), "07", ErrorMessage = "Age of onset required when Primary Dx = 07")]
        [RequiredIf(nameof(MOMETPR), "08", ErrorMessage = "Age of onset required when Primary Dx = 08")]
        [RequiredIf(nameof(MOMETPR), "09", ErrorMessage = "Age of onset required when Primary Dx = 09")]
        [RequiredIf(nameof(MOMETPR), "10", ErrorMessage = "Age of onset required when Primary Dx = 10")]
        [RequiredIf(nameof(MOMETPR), "11", ErrorMessage = "Age of onset required when Primary Dx = 11")]
        [RequiredIf(nameof(MOMETPR), "12", ErrorMessage = "Age of onset required when Primary Dx = 12")]
        public int? MOMAGEO { get; set; }

        [Display(Name = "Father — birth year")]
        [BirthYear(AllowUnknown = true)]
        [RequiredOnFinalized]
        public int? DADYOB { get; set; }

        [Display(Name = "Father — age at death")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "Father age at death must be 0-110, or 888 (N/A), or 999 (unknown)")]
        [RequiredOnFinalized(ErrorMessage = "Please provide an age at death or indicate otherwise")]
        public int? DADDAGE { get; set; }

        [Display(Name = "Father — neurological problem")]
        [RegularExpression("^(0[0-9]|1[0-2]|99)$", ErrorMessage = "Codes must be 00-12 or 99")]
        [RequiredOnFinalized(ErrorMessage = "Please provide a value for Primary dx")]
        public string? DADETPR { get; set; }

        [Display(Name = "Father — primary diagnosis")]
        [RegularExpression("^(0[0-9]|1[0-2]|88|99)$", ErrorMessage = "Codes must be 00-12 88 or 99")]
        [RequiredIf(nameof(DADETPR), "01", ErrorMessage = "Secondary Dx required when Primary Dx = 01")]
        [RequiredIf(nameof(DADETPR), "02", ErrorMessage = "Secondary Dx required when Primary Dx = 02")]
        [RequiredIf(nameof(DADETPR), "03", ErrorMessage = "Secondary Dx required when Primary Dx = 03")]
        [RequiredIf(nameof(DADETPR), "04", ErrorMessage = "Secondary Dx required when Primary Dx = 04")]
        [RequiredIf(nameof(DADETPR), "05", ErrorMessage = "Secondary Dx required when Primary Dx = 05")]
        [RequiredIf(nameof(DADETPR), "06", ErrorMessage = "Secondary Dx required when Primary Dx = 06")]
        [RequiredIf(nameof(DADETPR), "07", ErrorMessage = "Secondary Dx required when Primary Dx = 07")]
        [RequiredIf(nameof(DADETPR), "08", ErrorMessage = "Secondary Dx required when Primary Dx = 08")]
        [RequiredIf(nameof(DADETPR), "09", ErrorMessage = "Secondary Dx required when Primary Dx = 09")]
        [RequiredIf(nameof(DADETPR), "10", ErrorMessage = "Secondary Dx required when Primary Dx = 10")]
        [RequiredIf(nameof(DADETPR), "11", ErrorMessage = "Secondary Dx required when Primary Dx = 11")]
        [RequiredIf(nameof(DADETPR), "12", ErrorMessage = "Secondary Dx required when Primary Dx = 12")]
        public string? DADETSEC { get; set; }

        [Display(Name = "Father — method of evaluation")]
        [Range(1, 4, ErrorMessage = "Must be in the range of 1-4")]
        [RequiredIf(nameof(DADETPR), "01", ErrorMessage = "Method required when Primary Dx = 01")]
        [RequiredIf(nameof(DADETPR), "02", ErrorMessage = "Method required when Primary Dx = 02")]
        [RequiredIf(nameof(DADETPR), "03", ErrorMessage = "Method required when Primary Dx = 03")]
        [RequiredIf(nameof(DADETPR), "04", ErrorMessage = "Method required when Primary Dx = 04")]
        [RequiredIf(nameof(DADETPR), "05", ErrorMessage = "Method required when Primary Dx = 05")]
        [RequiredIf(nameof(DADETPR), "06", ErrorMessage = "Method required when Primary Dx = 06")]
        [RequiredIf(nameof(DADETPR), "07", ErrorMessage = "Method required when Primary Dx = 07")]
        [RequiredIf(nameof(DADETPR), "08", ErrorMessage = "Method required when Primary Dx = 08")]
        [RequiredIf(nameof(DADETPR), "09", ErrorMessage = "Method required when Primary Dx = 09")]
        [RequiredIf(nameof(DADETPR), "10", ErrorMessage = "Method required when Primary Dx = 10")]
        [RequiredIf(nameof(DADETPR), "11", ErrorMessage = "Method required when Primary Dx = 11")]
        [RequiredIf(nameof(DADETPR), "12", ErrorMessage = "Method required when Primary Dx = 12")]
        public int? DADMEVAL { get; set; }

        [Display(Name = "Father — age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Father age of onset must be 0-110, or 999 (unknown)")]
        [RequiredIf(nameof(DADETPR), "01", ErrorMessage = "Age of onset required when Primary Dx = 01")]
        [RequiredIf(nameof(DADETPR), "02", ErrorMessage = "Age of onset required when Primary Dx = 02")]
        [RequiredIf(nameof(DADETPR), "03", ErrorMessage = "Age of onset required when Primary Dx = 03")]
        [RequiredIf(nameof(DADETPR), "04", ErrorMessage = "Age of onset required when Primary Dx = 04")]
        [RequiredIf(nameof(DADETPR), "05", ErrorMessage = "Age of onset required when Primary Dx = 05")]
        [RequiredIf(nameof(DADETPR), "06", ErrorMessage = "Age of onset required when Primary Dx = 06")]
        [RequiredIf(nameof(DADETPR), "07", ErrorMessage = "Age of onset required when Primary Dx = 07")]
        [RequiredIf(nameof(DADETPR), "08", ErrorMessage = "Age of onset required when Primary Dx = 08")]
        [RequiredIf(nameof(DADETPR), "09", ErrorMessage = "Age of onset required when Primary Dx = 09")]
        [RequiredIf(nameof(DADETPR), "10", ErrorMessage = "Age of onset required when Primary Dx = 10")]
        [RequiredIf(nameof(DADETPR), "11", ErrorMessage = "Age of onset required when Primary Dx = 11")]
        [RequiredIf(nameof(DADETPR), "12", ErrorMessage = "Age of onset required when Primary Dx = 12")]
        public int? DADAGEO { get; set; }

        [Display(Name = "How many full siblings does the participant have? (77 = adopted, unknown)")]
        [RegularExpression("^(\\d|[1]\\d|20|77)$", ErrorMessage = "Number of siblings must be 0-20, or 77 = adopted, unknown")]
        public int? SIBS { get; set; }

        [Display(Name = "Since the last UDS visit, is new information available concerning the status of the participant’s siblings?")]
        public int? NWINFSIB { get; set; }

        [Display(Name = "How many known biological children does the participant have?")]
        [Range(0, 15, ErrorMessage = "Number of children must be 0-15")]
        public int? KIDS { get; set; }

        [Display(Name = "Since the last UDS visit, is new information available concerning the status of the participant’s siblings?")]
        public int? NWINFKID { get; set; }

        public List<A3FamilyMember> Siblings { get; set; } = new List<A3FamilyMember>();

        public List<A3FamilyMember> Children { get; set; } = new List<A3FamilyMember>();

        // Validation in these scenarios
        // - cross-form validation
        // - differences in validation across visit types for instance, IVP vs FVP
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

