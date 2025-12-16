using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    /// DEVNOTE: A3 will be modified for this PR
    public class A3 : FormModel
    {
        [Display(Name = "Since the last UDS visit, is new information available concerning the status of the participant's biological mother or father?")]
        [RequiredOnFinalized(Services.Enums.PacketKind.F)]
        public int? NWINFPAR { get; set; }

        [Display(Name = "Mother — birth year")]
        [BirthYear(AllowUnknown = true, Parent = true)]
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
        [RequiredIfRegex(nameof(MOMETPR), "^(0[1-9]|1[0-2])$", ErrorMessage = "Secondary Dx required")]
        public string? MOMETSEC { get; set; }

        [Display(Name = "Mother — method of evaluation")]
        [Range(1, 4, ErrorMessage = "Must be in the range of 1-4")]
        [RequiredIfRegex(nameof(MOMETPR), "^(0[1-9]|1[0-2])$", ErrorMessage = "Method required")]
        public int? MOMMEVAL { get; set; }

        [Display(Name = "Mother — age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Mother age of onset must be 0-110, or 999 (unknown)")]
        [RequiredIfRegex(nameof(MOMETPR), "^(0[1-9]|1[0-2])$", ErrorMessage = "Age of onset required")]
        public int? MOMAGEO { get; set; }

        [Display(Name = "Father — birth year")]
        [BirthYear(AllowUnknown = true, Parent = true)]
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
        [RequiredIfRegex(nameof(DADETPR), "^(0[1-9]|1[0-2])$", ErrorMessage = "Secondary Dx required")]
        public string? DADETSEC { get; set; }

        [Display(Name = "Father — method of evaluation")]
        [Range(1, 4, ErrorMessage = "Must be in the range of 1-4")]
        [RequiredIfRegex(nameof(DADETPR), "^(0[1-9]|1[0-2])$", ErrorMessage = "Method required")]
        public int? DADMEVAL { get; set; }

        [Display(Name = "Father — age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Father age of onset must be 0-110, or 999 (unknown)")]
        [RequiredIfRegex(nameof(DADETPR), "^(0[1-9]|1[0-2])$", ErrorMessage = "Age of onset required")]
        public int? DADAGEO { get; set; }

        [Display(Name = "Since the last UDS visit, is new information available concerning the status of the participant's full siblings?")]
        [RequiredOnFinalized(Services.Enums.PacketKind.F)]
        public int? NWINFSIB { get; set; }

        [Display(Name = "How many full siblings does the participant have? (77 = adopted, unknown)")]
        [RegularExpression("^(\\d|[1]\\d|20|77)$", ErrorMessage = "Number of siblings must be 0-20, or 77 = adopted, unknown")]
        [RequiredOnFinalized]
        public int? SIBS { get; set; }

        [Display(Name = "Since the last UDS visit, is new information available concerning the stauts of the participant's biological children?")]
        [RequiredOnFinalized(Services.Enums.PacketKind.F)]
        public int? NWINFKID { get; set; }

        [Display(Name = "How many known biological children does the participant have?")]
        [Range(0, 15, ErrorMessage = "Number of children must be 0-15")]
        [RequiredOnFinalized]
        public int? KIDS { get; set; }

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

