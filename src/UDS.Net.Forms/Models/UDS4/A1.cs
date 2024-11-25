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
        [BirthMonth]
        [RequiredOnFinalized]
        public int? BIRTHMO { get; set; }

        [Display(Name = "Participant's year of birth")]
        [BirthYear]
        [RequiredOnFinalized]
        public int? BIRTHYR { get; set; }

        [Display(Name = "In which country or region did you spend most of your childhood?")]
        [MaxLength(3)]
        [ProhibitedCharacters]
        [RequiredOnFinalized]
        public string? CHLDHDCTRY { get; set; }

        [Display(Name = "White")]
        public bool RACEWHITE { get; set; }

        [Display(Name = "German")]
        public bool ETHGERMAN { get; set; }

        [Display(Name = "Irish")]
        public bool ETHIRISH { get; set; }

        [Display(Name = "English")]
        public bool ETHENGLISH { get; set; }

        [Display(Name = "Italian")]
        public bool ETHITALIAN { get; set; }

        [Display(Name = "Polish")]
        public bool ETHPOLISH { get; set; }

        [Display(Name = "Scottish")]
        public bool ETHSCOTT { get; set; }

        [Display(Name = "Other")] // White - Other
        public bool ETHWHIOTH { get; set; }

        [Display(Name = "White - Other")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(ETHWHIOTH), "true", ErrorMessage = "Please indicate ethnicity")]
        public string? ETHWHIOTHX { get; set; }

        [Display(Name = "Hispanic or Latino")]
        public bool ETHISPANIC { get; set; }

        [Display(Name = "Mexican")]
        public bool ETHMEXICAN { get; set; }

        [Display(Name = "Puerto Rican")]
        public bool ETHPUERTO { get; set; }

        [Display(Name = "Cuban")]
        public bool ETHCUBAN { get; set; }

        [Display(Name = "Salvadoran")]
        public bool ETHSALVA { get; set; }

        [Display(Name = "Dominican")]
        public bool ETHDOMIN { get; set; }

        [Display(Name = "Guatemalan")]
        public bool ETHGUATEM { get; set; }

        [Display(Name = "Other")] // Hispanic or Latino - Other
        public bool ETHHISOTH { get; set; }

        [Display(Name = "Hispanic or Latino - Other (Specify)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(ETHHISOTH), "true", ErrorMessage = "Please indicate ethnicity")]
        public string? ETHHISOTHX { get; set; }

        [Display(Name = "Black or African American")]
        public bool RACEBLACK { get; set; }

        [Display(Name = "African American")]
        public bool ETHAFAMER { get; set; }

        [Display(Name = "Jamaican")]
        public bool ETHJAMAICA { get; set; }

        [Display(Name = "Haitian")]
        public bool ETHHAITIAN { get; set; }

        [Display(Name = "Nigerian")]
        public bool ETHNIGERIA { get; set; }

        [Display(Name = "Ethiopian")]
        public bool ETHETHIOP { get; set; }

        [Display(Name = "Somali")]
        public bool ETHSOMALI { get; set; }

        [Display(Name = "Other")] // Black or African American - Other
        public bool ETHBLKOTH { get; set; }

        [Display(Name = "Black or African American - Other")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(ETHBLKOTH), "true", ErrorMessage = "Please indicate ethnicity")]
        public string? ETHBLKOTHX { get; set; }

        [Display(Name = "Asian")]
        public bool RACEASIAN { get; set; }

        [Display(Name = "Chinese")]
        public bool ETHCHINESE { get; set; }

        [Display(Name = "Filipino")]
        public bool ETHFILIP { get; set; }

        [Display(Name = "Asian Indian")]
        public bool ETHINDIA { get; set; }

        [Display(Name = "Vietnamese")]
        public bool ETHVIETNAM { get; set; }

        [Display(Name = "Korean")]
        public bool ETHKOREAN { get; set; }

        [Display(Name = "Japanese")]
        public bool ETHJAPAN { get; set; }

        [Display(Name = "Other")] // Asian - Other
        public bool ETHASNOTH { get; set; }

        [Display(Name = "Asian - Other")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(ETHASNOTH), "true", ErrorMessage = "Please indicate ethnicity")]
        public string? ETHASNOTHX { get; set; }

        [Display(Name = "American Indian or Alaska Native")]
        public bool RACEAIAN { get; set; }

        [Display(Name = "American Indian or Alaska Native")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(RACEAIAN), "true", ErrorMessage = "Please indicate ethnicity")]
        public string? RACEAIANX { get; set; }

        [Display(Name = "Middle Eastern or North African")]
        public bool RACEMENA { get; set; }

        [Display(Name = "Lebanese")]
        public bool ETHLEBANON { get; set; }

        [Display(Name = "Iranian")]
        public bool ETHIRAN { get; set; }

        [Display(Name = "Egyptian")]
        public bool ETHEGYPT { get; set; }

        [Display(Name = "Syrian")]
        public bool ETHSYRIA { get; set; }

        [Display(Name = "Iraqi")]
        public bool ETHIRAQI { get; set; }

        [Display(Name = "Israeli")]
        public bool ETHISRAEL { get; set; }

        [Display(Name = "Other")] // Middle Eastern or North African - Other
        public bool ETHMENAOTH { get; set; }

        [Display(Name = "Middle Eastern or North African - Other")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(ETHMENAOTH), "true", ErrorMessage = "Please indicate ethnicity")]
        public string? ETHMENAOTX { get; set; }

        [Display(Name = "Native Hawaiian or Pacific Islander")]
        public bool RACENHPI { get; set; }

        [Display(Name = "Native Hawaiian")]
        public bool ETHHAWAII { get; set; }

        [Display(Name = "Samoan")]
        public bool ETHSAMOAN { get; set; }

        [Display(Name = "Chamorro")]
        public bool ETHCHAMOR { get; set; }

        [Display(Name = "Tongan")]
        public bool ETHTONGAN { get; set; }

        [Display(Name = "Fijian")]
        public bool ETHFIJIAN { get; set; }

        [Display(Name = "Marshallese")]
        public bool ETHMARSHAL { get; set; }

        [Display(Name = "Other")] // Native Hawaiian or Pacific Islander - Other
        public bool ETHNHPIOTH { get; set; }

        [Display(Name = "Native Hawaiian or Pacific Islander - Other")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(ETHNHPIOTH), "true", ErrorMessage = "Please indicate ethnicity")]
        public string? ETHNHPIOTX { get; set; }

        [Display(Name = "Don't know")]
        public bool RACEUNKN { get; set; }

        [RequiredOnFinalized(ErrorMessage = "Please indicate ethnicity/race or don't know.")]
        [NotMapped]
        public bool? EthnicityRaceIndicated
        {
            get
            {
                if (RACEWHITE || ETHGERMAN || ETHIRISH || ETHENGLISH || ETHITALIAN || ETHPOLISH || ETHSCOTT || ETHWHIOTH
                || ETHISPANIC || ETHMEXICAN || ETHPUERTO || ETHCUBAN || ETHSALVA || ETHDOMIN || ETHGUATEM || ETHHISOTH
                || RACEBLACK || ETHAFAMER || ETHJAMAICA || ETHHAITIAN || ETHNIGERIA || ETHETHIOP || ETHSOMALI || ETHBLKOTH
                || RACEASIAN || ETHCHINESE || ETHFILIP || ETHINDIA || ETHVIETNAM || ETHKOREAN || ETHJAPAN || ETHASNOTH
                || RACEAIAN
                || RACEMENA || ETHLEBANON || ETHIRAN || ETHEGYPT || ETHSYRIA || ETHIRAQI || ETHISRAEL || ETHMENAOTH
                || RACENHPI || ETHHAWAII || ETHSAMOAN || ETHCHAMOR || ETHTONGAN || ETHFIJIAN || ETHMARSHAL || ETHNHPIOTH
                || RACEUNKN)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredOnFinalized(ErrorMessage = "Don't know cannot be selected along with a known ethnicity/race.")]
        [NotMapped]
        public bool? EthnicityRaceUnknownOnly
        {
            get
            {
                if (RACEWHITE || ETHGERMAN || ETHIRISH || ETHENGLISH || ETHITALIAN || ETHPOLISH || ETHSCOTT || ETHWHIOTH
                    || ETHISPANIC || ETHMEXICAN || ETHPUERTO || ETHCUBAN || ETHSALVA || ETHDOMIN || ETHGUATEM || ETHHISOTH
                    || RACEBLACK || ETHAFAMER || ETHJAMAICA || ETHHAITIAN || ETHNIGERIA || ETHETHIOP || ETHSOMALI || ETHBLKOTH
                    || RACEASIAN || ETHCHINESE || ETHFILIP || ETHINDIA || ETHVIETNAM || ETHKOREAN || ETHJAPAN || ETHASNOTH
                    || RACEAIAN
                    || RACEMENA || ETHLEBANON || ETHIRAN || ETHEGYPT || ETHSYRIA || ETHIRAQI || ETHISRAEL || ETHMENAOTH
                    || RACENHPI || ETHHAWAII || ETHSAMOAN || ETHCHAMOR || ETHTONGAN || ETHFIJIAN || ETHMARSHAL || ETHNHPIOTH)
                {
                    if (RACEUNKN)
                        return null;
                    else
                        return true;
                }
                else if (RACEUNKN)
                    return true;
                else
                    return null;
            }
        }

        [Display(Name = "Man")]
        public bool GENMAN { get; set; }

        [Display(Name = "Woman")]
        public bool GENWOMAN { get; set; }

        [Display(Name = "Transgender Man")]
        public bool GENTRMAN { get; set; }

        [Display(Name = "Transgender Woman")]
        public bool GENTRWOMAN { get; set; }

        [Display(Name = "Non-binary/genderqueer")]
        public bool GENNONBI { get; set; }

        [Display(Name = "Two-Spirit (if you are AIAN)")]
        public bool GENTWOSPIR { get; set; }

        [Display(Name = "I use a different term")]
        public bool GENOTH { get; set; }

        [Display(Name = "Gender Identity - Different term (Specify)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(GENOTH), "true", ErrorMessage = "Please indicate current gender identity")]
        public string? GENOTHX { get; set; }

        [Display(Name = "Don't know")]
        public bool GENDKN { get; set; }

        [Display(Name = "Prefer not to answer")]
        public bool GENNOANS { get; set; }

        [RequiredOnFinalized(ErrorMessage = "Please indicate current gender identity, dont know, or prefer not to answer.")]
        [NotMapped]
        public bool? GenderIdentityIndicated
        {
            get
            {
                if (GENMAN || GENWOMAN || GENTRMAN || GENTRWOMAN || GENNONBI || GENTWOSPIR || GENOTH || GENDKN || GENNOANS)
                {
                    return true;
                }
                else return null;
            }
        }

        [Display(Name = "What sex were you assigned at birth, on your original birth certificate?")]
        [RequiredOnFinalized]
        public int? BIRTHSEX { get; set; }

        [Display(Name = "Have you ever been diagnosed by a medical doctor or other health professional with an intersex condition or a \"Difference of Sex Development (DSD)\" or were you born with (or developed naturally in puberty) genitals, reproductive organs, and/or chromosomal patterns that do not fit standard definitions of male or female?")]
        [RequiredOnFinalized]
        public int? INTERSEX { get; set; }

        [Display(Name = "Lesbian or gay")]
        public bool SEXORNGAY { get; set; }

        [Display(Name = "Straight/heterosexual")]
        public bool SEXORNHET { get; set; }

        [Display(Name = "Bisexual")]
        public bool SEXORNBI { get; set; }

        [Display(Name = "Two-Spirit (if you are AIAN)")]
        public bool SEXORNTWOS { get; set; }

        [Display(Name = "I use a different term")]
        public bool SEXORNOTH { get; set; }

        [Display(Name = "Sexual Orientation - Different term (Specify)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(SEXORNOTH), "true", ErrorMessage = "Please indicate current gender identity")]
        public string? SEXORNOTHX { get; set; }

        [Display(Name = "Don't know")]
        public bool SEXORNDNK { get; set; }

        [Display(Name = "Prefer not to answer")]
        public bool SEXORNNOAN { get; set; }

        [RequiredOnFinalized(ErrorMessage = "Please indicate sexual orientation, don't know, or prefer not to answer.")]
        [NotMapped]
        public bool? SexualOrientstionIndicated
        {
            get
            {
                if (SEXORNGAY || SEXORNHET || SEXORNBI || SEXORNTWOS || SEXORNOTH || SEXORNDNK || SEXORNNOAN)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredOnFinalized(ErrorMessage = "Both question 15(A1.SERVED) and 16(A1.MEDVA) cannot have a value of \"Don't Know\"")]
        [NotMapped]
        public bool? ServedAndVaCare
        {
            get
            {
                if (SERVED == 9 && MEDVA != 9 ||
                    SERVED == 1 && (MEDVA == 9 || MEDVA == 1 || MEDVA == 0) ||
                    SERVED == 0 && MEDVA == null)
                {
                    return true;
                }
                else return null;
            }
        }
        [RequiredOnFinalized(ErrorMessage = "If response 4f is checked then responses 4h and 4i must be blank")]
        [NotMapped]
        public bool? TwoSpiritGender
        {
            get
            {
                if (GENTWOSPIR == true && (GENDKN == true || GENNOANS == true))
                {
                    return null;
                }
                else return true;
            }
        }
        [RequiredOnFinalized(ErrorMessage = "If response 7a is checked then responses 7f and 7g must be blank")]
        [NotMapped]
        public bool? TwoSpiritSexOrientation
        {
            get
            {
                if (SEXORNTWOS == true && (SEXORNDNK == true || SEXORNNOAN == true))
                {
                    return null;
                }
                else return true;
            }
        }
        [Display(Name = "What is your primary language?")]
        [RequiredOnFinalized]
        public int? PREDOMLAN { get; set; }

        [Display(Name = "Primary Language - Other (Specify)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(PREDOMLAN), "8", ErrorMessage = "Please specify language")]
        public string? PREDOMLANX { get; set; }

        [Display(Name = "Are you left- or right-handed?")]
        [RequiredOnFinalized]
        public int? HANDED { get; set; }

        [Display(Name = "How many years of education have you completed?")]
        [RequiredOnFinalized]
        [RegularExpression("^(\\d|[12]\\d|3[0-6]|99)$", ErrorMessage = "Valid range is 0-36 or 99")]
        public int? EDUC { get; set; }

        [Display(Name = "What is the highest level of education you have achieved?")]
        [RequiredOnFinalized]
        public int? LVLEDUC { get; set; }

        [Display(Name = "What is your current marital status?")]
        [RequiredOnFinalized]
        public int? MARISTAT { get; set; }

        [Display(Name = "What is your living situation?")]
        [RequiredOnFinalized]
        public int? LIVSITUA { get; set; }

        [Display(Name = "What is your primary type of residence?")]
        [RequiredOnFinalized]
        public int? RESIDENC { get; set; }

        [Display(Name = "What are the first three digits of the ZIP code of your primary residence?")]
        [RegularExpression("^(00[6-9]|0[1-9]\\d|[1-9]\\d{2})$", ErrorMessage = "Valid range is 006-999")]
        public string? ZIP { get; set; }

        [Display(Name = "Have you ever served in the U.S. Armed Forces, military Reserves, or National Guard?")]
        [RequiredOnFinalized]
        public int? SERVED { get; set; }

        [Display(Name = "Have you ever obtained medical care or prescription drugs from a Veterans Affairs (VA) facility?")]
        [RequiredIf(nameof(SERVED), "1", ErrorMessage = "Please indicate if have you ever obtained medical care or prescription drugs from a Veterans Affairs (VA) facility.")]
        [RequiredIf(nameof(SERVED), "9", ErrorMessage = "Please indicate if have you ever obtained medical care or prescription drugs from a Veterans Affairs (VA) facility.")]
        public int? MEDVA { get; set; }

        [Display(Name = "How much time each week do you spend performing activities that cause large increases in breathing or heart rate for at least 10 minutes continuously?")]
        [RequiredOnFinalized]
        public int? EXRTIME { get; set; }

        [Display(Name = "Do you feel like your memory is becoming worse?")]
        [RequiredOnFinalized]
        public int? MEMWORS { get; set; }

        [Display(Name = "About how often do you have trouble remembering things?")]
        [RequiredOnFinalized]
        public int? MEMTROUB { get; set; }

        [Display(Name = "Compared to 10 years ago, would you say that your memory is much worse, a little worse, the same, a little better, or much better?")]
        [RequiredOnFinalized]
        public int? MEMTEN { get; set; }

        [Display(Name = "ADI state-only decile")]
        [Range(1, 10)]
        public int? ADISTATE { get; set; }

        [Display(Name = "ADI national percentile")]
        [Range(1, 100)]
        public int? ADINAT { get; set; }

        [Display(Name = "Participant's primary occupation throughout their working life")]
        [Range(100, 731)]
        public int? PRIOCC { get; set; }

        [Display(Name = "ADRC enrollment type")]
        [RequiredOnFinalized]
        public int? SOURCENW { get; set; }

        [Display(Name = "Principal referral source")]
        [RequiredOnFinalized]
        public int? REFERSC { get; set; }

        [Display(Name = "Principal referral source - Other (Specify) (END FORM HERE)")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(REFLEARNED), "8", ErrorMessage = "Please specify principal referral source")]
        public string? REFERSCX { get; set; }

        [Display(Name = "If the referral source was a self-referral or a nonprofessional contact, how did the referral source learn of the ADRC?")]
        [RequiredIf(nameof(REFERSC), "1", ErrorMessage = "Please indicate how did referral source learn of the ADRC")]
        [RequiredIf(nameof(REFERSC), "2", ErrorMessage = "Please indicate how did referral source learn of the ADRC")]
        public int? REFLEARNED { get; set; }

        [Display(Name = "Center social media - Specify")]
        [RequiredIf(nameof(REFLEARNED), "6", ErrorMessage = "Please specify center social media")]
        public string? REFCTRSOCX { get; set; }

        [Display(Name = "Center registry - Specify")]
        [RequiredIf(nameof(REFLEARNED), "7", ErrorMessage = "Please specify center registry")]
        public string? REFCTRREGX { get; set; }

        [Display(Name = "Website - Specify")]
        [RequiredIf(nameof(REFLEARNED), "8", ErrorMessage = "Please specify website")]
        public string? REFOTHWEBX { get; set; }

        [Display(Name = "Media - Specify")]
        [RequiredIf(nameof(REFLEARNED), "9", ErrorMessage = "Please specify media")]
        public string? REFOTHMEDX { get; set; }

        [Display(Name = "Other registry - Specify")]
        [RequiredIf(nameof(REFLEARNED), "10", ErrorMessage = "Please specify other registry")]
        public string? REFOTHREGX { get; set; }

        [Display(Name = "Other - Specify")]
        [RequiredIf(nameof(REFLEARNED), "88", ErrorMessage = "Please specify")]
        public string? REFOTHX { get; set; }


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

