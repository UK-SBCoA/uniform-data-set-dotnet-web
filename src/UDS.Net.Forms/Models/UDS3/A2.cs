
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.TagHelpers;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A2 : FormModel
    {
        [Display(Name = "Co-participant's birth month")]
        [BirthMonth(AllowUnknown = true)]
        public int? INBIRMO { get; set; }

        [Display(Name = "Co-participant's birth year")]
        [BirthYear(Minimum = 1850, AllowUnknown = true)]
        public int? INBIRYR { get; set; }

        [Display(Name = "Co-participant's sex")]
        public int? INSEX { get; set; }

        [Display(Name = "Is this a new co-participant - i.e., one who was not a co-participant at any past UDS visit?")]
        public int? NEWINF { get; set; }

        [Display(Name = "Does the co-participant report being of Hispanic/Latino ethnicity  (i.e., having origins from a mainly Spanish-speaking Latin American country), regardless of race?")]
        public int? INHISP { get; set; }

        [Display(Name = "If yes, what are the co-participant's reported origins?")]
        public int? INHISPOR { get; set; }

        [Display(Name = "Other (SPECIFY)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? INHISPOX { get; set; }

        [Display(Name = "What does the co-participant report as his or her race?")]
        public int? INRACE { get; set; }

        [Display(Name = "Other (SPECIFY)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? INRACEX { get; set; }

        [Display(Name = "What additional race does the co-participant report?")]
        public int? INRASEC { get; set; }

        [Display(Name = "Other (SPECIFY)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? INRASECX { get; set; }

        [Display(Name = "What additional race, beyond those reported in Questions 4 and 5, does the co-participant report?")]
        public int? INRATER { get; set; }

        [Display(Name = "Other (SPECIFY)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? INRATERX { get; set; }

        [Display(Name = "Co-participant's years of education — use the codes below to report the level achieved; if an attempted level is not completed, enter the number of years completed" +
         "<br /><br /> 12 = high school or GED<br />  16 = bachelor's degree<br /> 18 = master's degree<br /> 20 = doctorate<br /> 99 = unknown")]
        [RegularExpression(@"^(99|[0-9]|[1-2][0-9]|3[0-6])$", ErrorMessage = "Co-participants years of education must be within 0 and 36 or 99.")]
        public int? INEDUC { get; set; }

        [Display(Name = "What is the co-participant's relationship to the participant?")]
        public int? INRELTO { get; set; }

        [Display(Name = "How long has the co-participant known the participant?")]
        [Range(0, 999, ErrorMessage = "Years known must be within 0 and 999")]
        public int? INKNOWN { get; set; }

        [Display(Name = "Does the co-participant live with the subject?")]
        public int? INLIVWTH { get; set; }

        [Display(Name = "If no, approximate frequency of in-person visits?")]
        public int? INVISITS { get; set; }

        [Display(Name = "If no, approximate frequency of telephone contact?")]
        public int? INCALLS { get; set; }

        [Display(Name = "Is there a question about the co-participant's reliability?")]
        public int? INRELY { get; set; }

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

