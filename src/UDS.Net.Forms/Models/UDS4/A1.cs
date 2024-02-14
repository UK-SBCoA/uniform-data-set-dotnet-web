using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A1 : FormModel
    {
        [Display(Name = "Participant's month of birth")]
        public int? BIRTHMO { get; set; }

        [Display(Name = "Participant's year of birth")]
        public int? BIRTHYR { get; set; }

        [Display(Name = "In which country or region did you spend most of your childhood?")]
        public string? CHLDHDCTRY { get; set; }

        [Display(Name = "Race--White")]
        public int? RACEWHITE { get; set; }

        [Display(Name = "Race--White--German")]
        public int? ETHGERMAN { get; set; }

        [Display(Name = "Race--White--Irish")]
        public int? ETHIRISH { get; set; }

        [Display(Name = "Race--White--English")]
        public int? ETHENGLISH { get; set; }

        [Display(Name = "Race--White--Italian")]
        public int? ETHITALIAN { get; set; }

        [Display(Name = "Race--White--Polish")]
        public int? ETHPOLISH { get; set; }

        [Display(Name = "Race--White--French")]
        public int? ETHFRENCH { get; set; }

        [Display(Name = "Race--White--Other")]
        public int? ETHWHIOTH { get; set; }

        [Display(Name = "Race--White--Other (specify)")]
        public string? ETHWHIOTHX { get; set; }

        [Display(Name = "Race--Hispanic or Latino")]
        public int? ETHISPANIC { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Mexican or Mexican American")]
        public int? ETHMEXICAN { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Puerto Rican")]
        public int? ETHPUERTO { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Cuban")]
        public int? ETHCUBAN { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Salvadoran")]
        public int? ETHSALVA { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Dominican")]
        public int? ETHDOMIN { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Colombian")]
        public int? ETHCOLOM { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Other")]
        public int? ETHHISOTH { get; set; }

        [Display(Name = "Race--Hispanic or Latino--Other (Specify)")]
        public string? ETHHISOTHX { get; set; }

        [Display(Name = "Race--Black or African American")]
        public int? RACEBLACK { get; set; }

        [Display(Name = "Race--Black or African American--African American")]
        public int? ETHAFAMER { get; set; }

        [Display(Name = "Race--Black or African American--Jamaican")]
        public int? ETHJAMAICA { get; set; }

        [Display(Name = "Race--Black or African American--Haitian")]
        public int? ETHHAITIAN { get; set; }

        [Display(Name = "Race--Black or African American--Nigerian")]
        public int? ETHNIGERIA { get; set; }

        [Display(Name = "Race--Back or African American--Ethiopian")]
        public int? ETHETHIOP { get; set; }

        [Display(Name = "Race--Black or African American--Somali")]
        public int? ETHSOMALI { get; set; }

        [Display(Name = "Race--Black or African American--Other")]
        public int? ETHBLKOTH { get; set; }

        [Display(Name = "Race--Black or African American--Other (Specify)")]
        public string? ETHBLKOTHX { get; set; }

        [Display(Name = "Race--Asian")]
        public int? RACEASIAN { get; set; }

        [Display(Name = "Race--Asian--Chinese")]
        public int? ETHCHINESE { get; set; }

        [Display(Name = "Race--Asian--Filipino")]
        public int? ETHFILIP { get; set; }

        [Display(Name = "Race--Asian--Asian Indian")]
        public int? ETHINDIA { get; set; }

        [Display(Name = "Race--Asian--Vietnamese")]
        public int? ETHVIETNAM { get; set; }

        [Display(Name = "Race--Asian--Korean")]
        public int? ETHKOREAN { get; set; }

        [Display(Name = "Race--Asian--Japanese")]
        public int? ETHJAPAN { get; set; }

        [Display(Name = "Race--Asian--Other")]
        public int? ETHASNOTH { get; set; }

        [Display(Name = "Race--Asian--Other (Specify)")]
        public string? ETHASNOTHX { get; set; }

        [Display(Name = "Race--American Indian or Alaska Native")]
        public int? RACEAIAN { get; set; }

        [Display(Name = "Race--American Indian or Alaska Native (Specify)")]
        public string? RACEAIANX { get; set; }

        [Display(Name = "Race--Middle Eastern or North African")]
        public int? RACEMENA { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Lebanese")]
        public int? ETHLEBANON { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Iranian")]
        public int? ETHIRAN { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Egyptian")]
        public int? ETHEGYPT { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Syrian")]
        public int? ETHSYRIA { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Moroccan")]
        public int? ETHMOROCCO { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Israeli")]
        public int? ETHISRAEL { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Other")]
        public int? ETHMENAOTH { get; set; }

        [Display(Name = "Race--Middle Eastern or North African--Other (Specify)")]
        public string? ETHMENAOTX { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander")]
        public int? RACENHPI { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Hawaiian")]
        public int? ETHHAWAII { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Samoan")]
        public int? ETHSAMOAN { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Chamorro")]
        public int? ETHCHAMOR { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Tongan")]
        public int? ETHTONGAN { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Fijian")]
        public int? ETHFIJIAN { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Marshallese")]
        public int? ETHMARSHAL { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Other")]
        public int? ETHNHPIOTH { get; set; }

        [Display(Name = "Race--Native Hawaiian or Other Pacific Islander--Other (Specify)")]
        public string? ETHNHPIOTX { get; set; }

        [Display(Name = "Race Unknown")]
        public int? RACEUNKN { get; set; }

        [Display(Name = "Gender--Man")]
        public int? GENMAN { get; set; }

        [Display(Name = "Gender--Woman")]
        public int? GENWOMAN { get; set; }

        [Display(Name = "Gender--Transgender Man")]
        public int? GENTRMAN { get; set; }

        [Display(Name = "Gender--Transgender Woman")]
        public int? GENTRWOMAN { get; set; }

        [Display(Name = "Gender--Non-binary")]
        public int? GENNONBI { get; set; }

        [Display(Name = "Gender--Two-Spirit")]
        public int? GENTWOSPIR { get; set; }

        [Display(Name = "Gender--Other")]
        public int? GENOTH { get; set; }

        [Display(Name = "Gender--Other (Specify)")]
        public string? GENOTHX { get; set; }

        [Display(Name = "Gender Unknown")]
        public int? GENDKN { get; set; }

        [Display(Name = "No Answer on Gender")]
        public int? GENNOANS { get; set; }

        [Display(Name = "Participant's birth sex")]
        public int? BIRTHSEX { get; set; }

        [Display(Name = "Intersex")]
        public int? INTERSEX { get; set; }

        [Display(Name = "Sexual Orientation--Gay")]
        public int? SEXORNGAY { get; set; }

        [Display(Name = "Sexual Orientation--Heterosexual")]
        public int? SEXORNHET { get; set; }

        [Display(Name = "Sexual Orientation--Bisexual")]
        public int? SEXORNBI { get; set; }

        [Display(Name = "Sexual Orientation--Two-Spirit")]
        public int? SEXORNTWOS { get; set; }

        [Display(Name = "Sexual Orientation--Other")]
        public int? SEXORNOTH { get; set; }

        [Display(Name = "Sexual Orientation--Other (Specify)")]
        public string? SEXORNOTHX { get; set; }

        [Display(Name = "Sexual Orientation Unknown")]
        public int? SEXORNDNK { get; set; }

        [Display(Name = "No Answer on Sexual Orientation")]
        public int? SEXORNNOAN { get; set; }

        [Display(Name = "Participant's primary language")]
        public int? PREDOMLAN { get; set; }

        [Display(Name = "Participant's primary language--Other (specify)")]
        public string? PREDOMLANX { get; set; }

        [Display(Name = "Are you left- or right-handed?")]
        public int? HANDED { get; set; }

        [Display(Name = "How many years of education have you completed?")]
        public int? EDUC { get; set; }

        [Display(Name = "What is the highest level of education you have achieved?")]
        public int? LVLEDUC { get; set; }

        [Display(Name = "What is your current marital status?")]
        public int? MARISTAT { get; set; }

        [Display(Name = "What is your living situation?")]
        public int? LIVSITUA { get; set; }

        [Display(Name = "What is your primary type of residence?")]
        public int? RESIDENC { get; set; }

        [Display(Name = "What are the first three digits of your ZIP code?")]
        public string? ZIP { get; set; }

        [Display(Name = "Have you ever served in the U.S. Armed Forces, military Reserves, or National Guard?")]
        public int? SERVED { get; set; }

        [Display(Name = "Have you ever obtained medical care or prescription drugs from a VA facility?")]
        public int? MEDVA { get; set; }

        [Display(Name = "How much time each week do you spend on physical activity that increases your heart rate?")]
        public int? EXRTIME { get; set; }

        [Display(Name = "Do you feel like your memory is getting worse?")]
        public int? MEMWORS { get; set; }

        [Display(Name = "How often do you have trouble remembering things?")]
        public int? MEMTROUB { get; set; }

        [Display(Name = "Compared to 10 years ago, how would you rate your memory now?")]
        public int? MEMTEN { get; set; }

        [Display(Name = "ADI state-only decile")]
        public int? ADISTATE { get; set; }

        [Display(Name = "ADI national percentile")]
        public int? ADINAT { get; set; }

        [Display(Name = "Participant's primary occupation throughout their working life")]
        public int? PRIOCC { get; set; }

        [Display(Name = "ADRC enrollment type")]
        public int? SOURCENW { get; set; }

        [Display(Name = "Principal referral source")]
        public int? REFERSC { get; set; }

        [Display(Name = "Principal referral source - other (specify)")]
        public string? REFERSCX { get; set; }

        [Display(Name = "If the referral source was a self-referral or a nonprofessional contact, how did the referral source learn of the ADRC?")]
        public int? REFLEARNED { get; set; }

        [Display(Name = "Center social media - specify")]
        public string? REFCTRSOCX { get; set; }

        [Display(Name = "Center registry - specify")]
        public string? REFCTRREGX { get; set; }

        [Display(Name = "Other website - specify")]
        public string? REFOTHWEBX { get; set; }

        [Display(Name = "Other media - specify")]
        public string? REFOTHMEDX { get; set; }

        [Display(Name = "Other registry - specify")]
        public string? REFOTHREGX { get; set; }

        [Display(Name = "Other - specify")]
        public string? REFOTHX { get; set; }


        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Primary reason for coming to ADC")]
        //[Range(1, 9)]
        //public int? REASON { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Principal referral source", Description = "If answer is 1 or 2, CONTINUE TO QUESTION 2b; otherwise, SKIP TO QUESTION 3.")]
        //[Range(1, 9)]
        //public int? REFERSC { get; set; }

        //[Display(Name = "If the referral source was self-referral or a non-professional contact, how did the referral source learn of the ADC?")]
        //[Range(1, 9)]
        //[RequiredIf(nameof(REFERSC), "1", ErrorMessage = "How did the referral source learn of the ADC?")]
        //[RequiredIf(nameof(REFERSC), "2", ErrorMessage = "How did the referral source learn of the ADC?")]
        //public int? LEARNED { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Presumed disease status at enrollment")]
        //[Range(1, 3)]
        //public int? PRESTAT { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Presumed participation")]
        //[Range(1, 2)]
        //public int? PRESPART { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "ADC enrollment type")]
        //[Range(1, 2)]
        //public int? SOURCENW { get; set; }

        //[Display(Name = "Participant’s month of birth")]
        //[BirthMonth]
        //[RequiredOnComplete]
        //public int? BIRTHMO { get; set; }

        //[Display(Name = "Participant’s year of birth")]
        //[BirthYear]
        //[RequiredOnComplete]
        //public int? BIRTHYR { get; set; }

        //[Display(Name = "Participant’s sex")]
        //[Range(1, 2)]
        //[RequiredOnComplete]
        //public int? SEX { get; set; }

        //[Display(Name = "Participant’s current marital status")]
        //[Range(0, 9)]
        //[RequiredOnComplete]
        //public int? MARISTAT { get; set; }

        //[Display(Name = "What is the participant’s living situation?")]
        //[Range(0, 9)]
        //[RequiredOnComplete]
        //public int? LIVSITUA { get; set; }

        //[Display(Name = "What is the participant’s level of independence?")]
        //[Range(0, 9)]
        //[RequiredOnComplete]
        //public int? INDEPEND { get; set; }

        //[Display(Name = "What is the participant’s primary type of residence?")]
        //[Range(0, 9)]
        //[RequiredOnComplete]
        //public int? RESIDENC { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Does the participant report being of Hispanic/Latino ethnicity (i.e., having origins from a mainly Spanish-speaking Latin American country), regardless of race?")]
        //[Range(0, 9)]
        //public int? HISPANIC { get; set; }

        //[Display(Name = "If yes, what are the participant's reported origins?")]
        //[RequiredIf(nameof(HISPANIC), "2", ErrorMessage = "Indicate reported origin.")]
        //[RequiredIf(nameof(HISPANIC), "9", ErrorMessage = "Indicate reported origin.")]
        //[Range(1, 99)]
        //public int? HISPOR { get; set; }

        //[Display(Name = "Other (specify)", Prompt = "Other origin")]
        //[MaxLength(60)]
        //[RequiredIf(nameof(HISPOR), "50", ErrorMessage = "Indicate other origin.")]
        //[ProhibitedCharacters]
        //public string? HISPORX { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "What does the participant report as his or her race?")]
        //[Range(1, 99)]
        //public int? RACE { get; set; }

        //[Display(Name = "Other (specify)", Prompt = "Other race")]
        //[MaxLength(60)]
        //[RequiredIf(nameof(RACE), "50", ErrorMessage = "Indicate other race.")]
        //[ProhibitedCharacters]
        //public string? RACEX { get; set; }

        ///// <summary>
        ///// Never required, but only allowed if primary race is defined
        ///// </summary>
        //[Display(Name = "What additional race does participant report?")]
        //[Range(1, 99)]
        //public int? RACESEC { get; set; }

        //[Display(Name = "Other (specify)", Prompt = "Other additional race")]
        //[MaxLength(60)]
        //[RequiredIf(nameof(RACESEC), "50", ErrorMessage = "Indicate other additional race.")]
        //[ProhibitedCharacters]
        //public string? RACESECX { get; set; }

        ///// <summary>
        ///// Never required, but only allowed if secondary race is defined
        ///// </summary>
        //[Display(Name = "What additional race, beyond those reported in Questions 9 and 10, does participant report?")]
        //[Range(1, 99)]
        //public int? RACETER { get; set; }

        //[Display(Name = "Other (specify)", Prompt = "Other additional race")]
        //[MaxLength(60)]
        //[RequiredIf(nameof(RACETER), "50", ErrorMessage = "Indicate other additional race.")]
        //[ProhibitedCharacters]
        //public string? RACETERX { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Participant’s primary language")]
        //[Range(1, 9)]
        //public int? PRIMLANG { get; set; }

        //[Display(Name = "Other (specify)", Prompt = "Other primary language")]
        //[MaxLength(60)]
        //[RequiredIf(nameof(PRIMLANG), "50", ErrorMessage = "Indicate other language.")]
        //[ProhibitedCharacters]
        //public string? PRIMLANX { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Participant’s years of education - use the codes to report the level achieved; if an attempted level is not completed, enter the number of years completed", Description = "12 = high school or GED, 16 = bachelor’s degree, 18 = master’s degree, 20 = doctorate, 99 = unknown")]
        //[Range(0, 99)]
        //public int? EDUC { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "ZIP Code (first three characters) of participant’s primary residence")]
        //[StringLength(3)]
        //public string? ZIP { get; set; }

        ///// <summary>
        ///// Only required during initial visits
        ///// </summary>
        //[Display(Name = "Is the participant left- or right-handed (for example, which hand would s/ he normally use to write or throw a ball)?")]
        //[Range(1, 9)]
        //public int? HANDED { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (Status == FormStatus.Complete)
            //{
            //    var visitValue = validationContext.Items.FirstOrDefault(v => v.Key.ToString() == "Visit").Value;
            //    if (visitValue is VisitModel)
            //    {
            //        VisitModel visit = (VisitModel)visitValue;

            //        if (visit != null)
            //        {
            //            if (visit.Kind == VisitKind.IVP || visit.Kind == VisitKind.TIP)
            //            {
            //                if (!REASON.HasValue)
            //                    yield return new ValidationResult("Primary reason for coming to ADC is required.", new[] { nameof(REASON) });

            //                if (!REFERSC.HasValue)
            //                    yield return new ValidationResult("Principal referral source is required.", new[] { nameof(REFERSC) });

            //                if (!PRESTAT.HasValue)
            //                    yield return new ValidationResult("Presumed disease status at enrollment is required.", new[] { nameof(PRESTAT) });

            //                if (!PRESPART.HasValue)
            //                    yield return new ValidationResult("Presumed participation is required.", new[] { nameof(PRESPART) });

            //                if (!SOURCENW.HasValue)
            //                    yield return new ValidationResult("ADC enrollment type is required.", new[] { nameof(SOURCENW) });

            //                if (!HISPANIC.HasValue)
            //                    yield return new ValidationResult("Ethnicity is required.", new[] { nameof(HISPANIC) });

            //                if (!RACE.HasValue)
            //                    yield return new ValidationResult("Race is required.", new[] { nameof(RACE) });

            //                // RACESEC is not required, but check to make sure RACE is defined first
            //                if (RACESEC.HasValue)
            //                {
            //                    if (!RACE.HasValue)
            //                        yield return new ValidationResult("Define primary race before defining secondary race.", new[] { nameof(RACESEC) });
            //                }

            //                // RACETER is not required, but check to make sure RACESEC is defined first
            //                if (RACETER.HasValue)
            //                {
            //                    if (!RACESEC.HasValue)
            //                        yield return new ValidationResult("Define secondary race before defining tertiary race.", new[] { nameof(RACETER) });
            //                }

            //                if (!PRIMLANG.HasValue)
            //                    yield return new ValidationResult("Primary language is required.", new[] { nameof(PRIMLANG) });

            //                if (!EDUC.HasValue)
            //                    yield return new ValidationResult("Years of education is required.", new[] { nameof(EDUC) });

            //                if (String.IsNullOrWhiteSpace(ZIP))
            //                    yield return new ValidationResult("First three characters of ZIP Code is required.", new[] { nameof(ZIP) });

            //                if (!HANDED.HasValue)
            //                    yield return new ValidationResult("Handedness is required.", new[] { nameof(HANDED) });
            //            }
            //        }
            //    }
            //}

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

