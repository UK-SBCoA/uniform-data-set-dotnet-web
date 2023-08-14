using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A1 : FormModel
    {
        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Primary reason for coming to ADC")]
        [Range(1, 9)]
        public int? REASON { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Principal referral source", Description = "If answer is 1 or 2, CONTINUE TO QUESTION 2b; otherwise, SKIP TO QUESTION 3.")]
        [Range(1, 9)]
        public int? REFERSC { get; set; }

        [Display(Name = "If the referral source was self-referral or a non-professional contact, how did the referral source learn of the ADC?")]
        [Range(1, 9)]
        [RequiredIf(nameof(REFERSC), "1", ErrorMessage = "How did the referral source learn of the ADC?")]
        [RequiredIf(nameof(REFERSC), "2", ErrorMessage = "How did the referral source learn of the ADC?")]
        public int? LEARNED { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Presumed disease status at enrollment")]
        [Range(1, 3)]
        public int? PRESTAT { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Presumed participation")]
        [Range(1, 2)]
        public int? PRESPART { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "ADC enrollment type")]
        [Range(1, 2)]
        public int? SOURCENW { get; set; }

        [Display(Name = "Participant’s month of birth")]
        [BirthMonth]
        [RequiredOnComplete]
        public int? BIRTHMO { get; set; }

        [Display(Name = "Participant’s year of birth")]
        [BirthYear]
        [RequiredOnComplete]
        public int? BIRTHYR { get; set; }

        [Display(Name = "Participant’s sex")]
        [Range(1, 2)]
        [RequiredOnComplete]
        public int? SEX { get; set; }

        [Display(Name = "Participant’s current marital status")]
        [Range(0, 9)]
        [RequiredOnComplete]
        public int? MARISTAT { get; set; }

        [Display(Name = "What is the participant’s living situation?")]
        [Range(0, 9)]
        [RequiredOnComplete]
        public int? LIVSITUA { get; set; }

        [Display(Name = "What is the participant’s level of independence?")]
        [Range(0, 9)]
        [RequiredOnComplete]
        public int? INDEPEND { get; set; }

        [Display(Name = "What is the participant’s primary type of residence?")]
        [Range(0, 9)]
        [RequiredOnComplete]
        public int? RESIDENC { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Does the participant report being of Hispanic/Latino ethnicity (i.e., having origins from a mainly Spanish-speaking Latin American country), regardless of race?")]
        [Range(0, 9)]
        public int? HISPANIC { get; set; }

        [Display(Name = "If yes, what are the participant's reported origins?")]
        [RequiredIf(nameof(HISPANIC), "2", ErrorMessage = "Indicate reported origin.")]
        [RequiredIf(nameof(HISPANIC), "9", ErrorMessage = "Indicate reported origin.")]
        [Range(1, 99)]
        public int? HISPOR { get; set; }

        [Display(Name = "Other (specify)", Prompt = "Other origin")]
        [MaxLength(60)]
        [RequiredIf(nameof(HISPOR), "50", ErrorMessage = "Indicate other origin.")]
        [SpecialCharacter]
        public string? HISPORX { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "What does the participant report as his or her race?")]
        [Range(1, 99)]
        public int? RACE { get; set; }

        [Display(Name = "Other (specify)", Prompt = "Other race")]
        [MaxLength(60)]
        [RequiredIf(nameof(RACE), "50", ErrorMessage = "Indicate other race.")]
        [SpecialCharacter]
        public string? RACEX { get; set; }

        /// <summary>
        /// Never required, but only allowed if primary race is defined
        /// </summary>
        [Display(Name = "What additional race does participant report?")]
        [Range(1, 99)]
        public int? RACESEC { get; set; }

        [Display(Name = "Other (specify)", Prompt = "Other additional race")]
        [MaxLength(60)]
        [RequiredIf(nameof(RACESEC), "50", ErrorMessage = "Indicate other additional race.")]
        [SpecialCharacter]
        public string? RACESECX { get; set; }

        /// <summary>
        /// Never required, but only allowed if secondary race is defined
        /// </summary>
        [Display(Name = "What additional race, beyond those reported in Questions 9 and 10, does participant report?")]
        [Range(1, 99)]
        public int? RACETER { get; set; }

        [Display(Name = "Other (specify)", Prompt = "Other additional race")]
        [MaxLength(60)]
        [RequiredIf(nameof(RACETER), "50", ErrorMessage = "Indicate other additional race.")]
        [SpecialCharacter]
        public string? RACETERX { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Participant’s primary language")]
        [Range(1, 9)]
        public int? PRIMLANG { get; set; }

        [Display(Name = "Other (specify)", Prompt = "Other primary language")]
        [MaxLength(60)]
        [RequiredIf(nameof(PRIMLANG), "50", ErrorMessage = "Indicate other language.")]
        [SpecialCharacter]
        public string? PRIMLANX { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Participant’s years of education - use the codes to report the level achieved; if an attempted level is not completed, enter the number of years completed", Description = "12 = high school or GED, 16 = bachelor’s degree, 18 = master’s degree, 20 = doctorate, 99 = unknown")]
        [Range(0, 99)]
        public int? EDUC { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "ZIP Code (first three characters) of participant’s primary residence")]
        [StringLength(3)]
        public string? ZIP { get; set; }

        /// <summary>
        /// Only required during initial visits
        /// </summary>
        [Display(Name = "Is the participant left- or right-handed (for example, which hand would s/ he normally use to write or throw a ball)?")]
        [Range(1, 9)]
        public int? HANDED { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == FormStatus.Complete)
            {
                var visitValue = validationContext.Items.FirstOrDefault(v => v.Key.ToString() == "Visit").Value;
                if (visitValue is VisitModel)
                {
                    VisitModel visit = (VisitModel)visitValue;

                    if (visit != null)
                    {
                        if (visit.Kind == VisitKind.IVP || visit.Kind == VisitKind.TIP)
                        {
                            if (!REASON.HasValue)
                                yield return new ValidationResult("Primary reason for coming to ADC is required.", new[] { nameof(REASON) });

                            if (!REFERSC.HasValue)
                                yield return new ValidationResult("Principal referral source is required.", new[] { nameof(REFERSC) });

                            if (!PRESTAT.HasValue)
                                yield return new ValidationResult("Presumed disease status at enrollment is required.", new[] { nameof(PRESTAT) });

                            if (!PRESPART.HasValue)
                                yield return new ValidationResult("Presumed participation is required.", new[] { nameof(PRESPART) });

                            if (!SOURCENW.HasValue)
                                yield return new ValidationResult("ADC enrollment type is required.", new[] { nameof(SOURCENW) });

                            if (!HISPANIC.HasValue)
                                yield return new ValidationResult("Ethnicity is required.", new[] { nameof(HISPANIC) });

                            if (!RACE.HasValue)
                                yield return new ValidationResult("Race is required.", new[] { nameof(RACE) });

                            // RACESEC is not required, but check to make sure RACE is defined first
                            if (RACESEC.HasValue)
                            {
                                if (!RACE.HasValue)
                                    yield return new ValidationResult("Define primary race before defining secondary race.", new[] { nameof(RACESEC) });
                            }

                            // RACETER is not required, but check to make sure RACESEC is defined first
                            if (RACETER.HasValue)
                            {
                                if (!RACESEC.HasValue)
                                    yield return new ValidationResult("Define secondary race before defining tertiary race.", new[] { nameof(RACETER) });
                            }

                            if (!PRIMLANG.HasValue)
                                yield return new ValidationResult("Primary language is required.", new[] { nameof(PRIMLANG) });

                            if (!EDUC.HasValue)
                                yield return new ValidationResult("Years of education is required.", new[] { nameof(EDUC) });

                            if (String.IsNullOrWhiteSpace(ZIP))
                                yield return new ValidationResult("First three characters of ZIP Code is required.", new[] { nameof(ZIP) });

                            if (!HANDED.HasValue)
                                yield return new ValidationResult("Handedness is required.", new[] { nameof(HANDED) });
                        }
                    }
                }
            }

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

