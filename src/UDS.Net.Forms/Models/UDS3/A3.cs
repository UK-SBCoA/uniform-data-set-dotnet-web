using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
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

        [Display(Name = "In this family, is there evidence for an AD mutation? If Yes, select predominant mutation.")]
        [RegularExpression("^([0-3]|8|9)$")]
        public int? FADMUT { get; set; }

        [Display(Name = "If Yes, Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(FADMUT), "8", ErrorMessage = "Other predominant AD mutation must be specified.")]
        [ProhibitedCharacters]
        public string? FADMUTX { get; set; }

        [Display(Name = "Source of evidence for AD mutation")]
        [RegularExpression("^([1-3]|8|9)$")]
        [RequiredIf(nameof(FADMUT), "1", ErrorMessage = "Define source of evidence for APP mutation.")]
        [RequiredIf(nameof(FADMUT), "2", ErrorMessage = "Define source of evidence for PS-1 mutation.")]
        [RequiredIf(nameof(FADMUT), "3", ErrorMessage = "Define source of evidence for PS-2 mutation.")]
        [RequiredIf(nameof(FADMUT), "8", ErrorMessage = "Define source of evidence for other mutation.")]
        public int? FADMUSO { get; set; }

        [Display(Name = "If other, (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(FADMUSO), "8", ErrorMessage = "Other source of evidence for AD mutation must be specified.")]
        [ProhibitedCharacters]
        public string? FADMUSOX { get; set; }

        [Display(Name = "In this family, is there evidence for an FTLD mutation? If Yes, select predominant mutation")]
        [RegularExpression("^([0-4]|8|9)$")]
        public int? FFTDMUT { get; set; }

        [Display(Name = "If Yes, Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(FFTDMUT), "8", ErrorMessage = "Other predominant FTLD mutation must be specified.")]
        [ProhibitedCharacters]
        public string? FFTDMUTX { get; set; }

        [Display(Name = "Source of evidence for FTLD mutation")]
        [RegularExpression("^([1-3]|8|9)$")]
        [RequiredIf(nameof(FFTDMUT), "8", ErrorMessage = "Other predominant FTLD mutation must be specified.")]
        public int? FFTDMUSO { get; set; }

        [Display(Name = "If other, (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(FFTDMUSO), "8", ErrorMessage = "Other source of evidence for FTLD mutation must be specified.")]
        [ProhibitedCharacters]
        public string? FFTDMUSX { get; set; }

        [Display(Name = "In this family, is there evidence for a mutation other than an AD or FTLD mutation?")]
        [RegularExpression("^(0|1|9)$")]
        public int? FOTHMUT { get; set; }

        [Display(Name = "If Yes, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(FFTDMUSO), "1", ErrorMessage = "Specify other evidence for a mutation other than an AD or FTLD mutation.")]
        [ProhibitedCharacters]
        public string? FOTHMUTX { get; set; }

        [Display(Name = "Source of evidence for other mutation")]
        [RegularExpression("^([1-3]|8|9)$")]
        public int? FOTHMUSO { get; set; }

        [Display(Name = "If other, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(FOTHMUSO), "8", ErrorMessage = "Other source of evidence required.")]
        [ProhibitedCharacters]
        public string? FOTHMUSX { get; set; }

        /// <summary>
        /// Only required on follow-up visits
        /// </summary>
        [Display(Name = "Since the last UDS visit, is new information available concerning the status of the participant's biological mother or father?")]
        public int? NWINFPAR { get; set; }

        [Display(Name = "Mother — birth month")]
        [BirthMonth(AllowUnknown = true)]
        public int? MOMMOB { get; set; }

        [Display(Name = "Mother — birth year")]
        [BirthYear(AllowUnknown = true)]
        public int? MOMYOB { get; set; }

        [Display(Name = "Mother — age at death")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "Mother age at death must be 0-110, or 888 (N/A), or 999 (unknown)")]
        [Required(ErrorMessage = "Please provide an age at death or indicate otherwise")]
        public int? MOMDAGE { get; set; }

        [Display(Name = "Mother — neurological problem")]
        [RegularExpression("^([1-5]|8|9)$", ErrorMessage = "Mother neurological problem/psychiatric condition invalid. Please see reference.")]
        [Required(ErrorMessage = "Please provide a value for Primary neurological problem/psychiatric condition")]
        public int? MOMNEUR { get; set; }

        [Display(Name = "Mother — primary diagnosis")]
        [Diagnosis(AllowUnknown = true)]
        [RequiredIf(nameof(MOMNEUR), "1", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(MOMNEUR), "2", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(MOMNEUR), "3", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(MOMNEUR), "4", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(MOMNEUR), "5", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        public int? MOMPRDX { get; set; }

        [Display(Name = "Mother — method of evaluation")]
        [Range(1, 7)]
        [RequiredIf(nameof(MOMNEUR), "1", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(MOMNEUR), "2", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(MOMNEUR), "3", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(MOMNEUR), "4", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(MOMNEUR), "5", ErrorMessage = "Please provide a method of evaluation")]
        public int? MOMMOE { get; set; }

        [Display(Name = "Mother — age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Mother age of onset must be 0-110, or 999 (unknown)")]
        [RequiredIf(nameof(MOMNEUR), "1", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(MOMNEUR), "2", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(MOMNEUR), "3", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(MOMNEUR), "4", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(MOMNEUR), "5", ErrorMessage = "Please provide the age of onset")]
        public int? MOMAGEO { get; set; }

        [Display(Name = "Father — birth month")]
        [BirthMonth(AllowUnknown = true)]
        public int? DADMOB { get; set; }

        [Display(Name = "Father — birth year")]
        [BirthYear(AllowUnknown = true)]
        public int? DADYOB { get; set; }

        [Display(Name = "Father — age at death")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "Father age at death must be 0-110, or 888 (N/A), or 999 (unknown)")]
        [Required(ErrorMessage = "Please provide an age at death or indicate otherwise")]
        public int? DADDAGE { get; set; }

        [Display(Name = "Father — neurological problem")]
        [RegularExpression("^([1-5]|8|9)$", ErrorMessage = "Father neurological problem/psychiatric condition invalid. Please see reference.")]
        [Required(ErrorMessage = "Please provide a value for Primary neurological problem/psychiatric condition")]
        public int? DADNEUR { get; set; }

        [Display(Name = "Father — primary diagnosis")]
        [Diagnosis(AllowUnknown = true)]
        [RequiredIf(nameof(DADNEUR), "1", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(DADNEUR), "2", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(DADNEUR), "3", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(DADNEUR), "4", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        [RequiredIf(nameof(DADNEUR), "5", ErrorMessage = "Please provide a Primary Dx, refer to the codes in APPENDIX 1")]
        public int? DADPRDX { get; set; }

        [Display(Name = "Father — method of evaluation")]
        [Range(1, 7)]
        [RequiredIf(nameof(DADNEUR), "1", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(DADNEUR), "2", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(DADNEUR), "3", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(DADNEUR), "4", ErrorMessage = "Please provide a method of evaluation")]
        [RequiredIf(nameof(DADNEUR), "5", ErrorMessage = "Please provide a method of evaluation")]
        public int? DADMOE { get; set; }

        [Display(Name = "Father — age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Father age of onset must be 0-110, or 999 (unknown)")]
        [RequiredIf(nameof(DADNEUR), "1", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(DADNEUR), "2", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(DADNEUR), "3", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(DADNEUR), "4", ErrorMessage = "Please provide the age of onset")]
        [RequiredIf(nameof(DADNEUR), "5", ErrorMessage = "Please provide the age of onset")]
        public int? DADAGEO { get; set; }

        [Display(Name = "How many full siblings does the participant have? (77 = adopted, unknown)")]
        [RegularExpression("^(\\d|[1]\\d|20|77)$", ErrorMessage = "Number of siblings must be 0-20, or 77 = adopted, unknown")]
        public int? SIBS { get; set; }

        [Display(Name = "Since the last UDS visit, is new information available concerning the status of the participant’s siblings?")]
        public int? NWINFSIB { get; set; }

        [Display(Name = "How many known biological children does the participant have?")]
        [Range(0, 15)]
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

