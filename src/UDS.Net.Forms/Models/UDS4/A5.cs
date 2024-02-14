using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A5 : FormModel
    {
        [Display(Name = "Has subject smoked within the last 30 days?")]
        [RequiredOnComplete(ErrorMessage = "Has the subject smoked within the last 30 days?")]
        public int? TOBAC30 { get; set; }

        [Display(Name = "Has participant smoked more than 100 cigarettes in his/her life?")]
        [RequiredOnComplete(ErrorMessage = "Has the participant smoked more than 100 cigarettes in their life?")]
        public int? TOBAC100 { get; set; }

        [Display(Name = "Total years smoked")]
        [RegularExpression("^(\\d|[1-7]\\d|8[0-7]|99)$", ErrorMessage = "(0-87, 99 = Unknown)")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Specify total years smoked")]
        public int? SMOKYRS { get; set; }

        [Display(Name = "Average number of packs smoked per day")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Specify average number of packs smoked per day")]
        public int? PACKSPER { get; set; }

        [Display(Name = "If the subject quit smoking, specify age at which he/she last smoked (i.e., quit)")]
        [RegularExpression("^([89]|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "(8-110, 888 = N/A, 999 = Unknown)")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Specify age participant last smoked")]
        public int? QUITSMOK { get; set; }

        [Display(Name = "In the past three months,has the subject consumed any alcohol?")]
        [RequiredOnComplete]
        public int? ALCOCCAS { get; set; }

        [Display(Name = "During the past three months, how often did the subject have at least one drink of any alcoholic beverage such as wine, beer, malt liquor, or spirits?")]
        [RequiredIf(nameof(ALCOCCAS), "1", ErrorMessage = "Specify how often the participant has at least one drink")]
        public int? ALCFREQ { get; set; }

        [Display(Name = "Heart attack/cardiac arrest")]
        [RequiredOnComplete]
        public int? CVHATT { get; set; }

        [Display(Name = "More than one heart attack?")]
        [RequiredIf(nameof(CVHATT), "1", ErrorMessage = "Specify if more than one heart attack")]
        [RequiredIf(nameof(CVHATT), "2", ErrorMessage = "Specify if more than one heart attack")]
        public int? HATTMULT { get; set; }

        [Display(Name = "Year of most recent heart attack")]
        [RequiredIf(nameof(CVHATT), "1", ErrorMessage = "Specify year of most recent heart attack")]
        [RequiredIf(nameof(CVHATT), "2", ErrorMessage = "Specify year of most recent heart attack")]
        public int? HATTYEAR { get; set; }

        [Display(Name = "Atrial fibrillation")]
        [RequiredOnComplete]
        public int? CVAFIB { get; set; }

        [Display(Name = "Angioplasty/endarterectomy/stent")]
        [RequiredOnComplete]
        public int? CVANGIO { get; set; }

        [Display(Name = "Cardiac bypass procedure")]
        [RequiredOnComplete]
        public int? CVBYPASS { get; set; }

        [Display(Name = "Pacemaker and/or defibrillator")]
        [RequiredOnComplete]
        public int? CVPACDEF { get; set; }

        [Display(Name = "Congestive heart failure")]
        [RequiredOnComplete]
        public int? CVCHF { get; set; }

        [Display(Name = "Angina")]
        [RequiredOnComplete]
        public int? CVANGINA { get; set; }

        [Display(Name = "Heart valve replacement or repair")]
        [RequiredOnComplete]
        public int? CVHVALVE { get; set; }

        [Display(Name = "Other cardiovascular disease")]
        [RequiredOnComplete]
        public int? CVOTHR { get; set; }


        [Display(Name = "Other cardiovascular disease (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(CVOTHR), "1", ErrorMessage = "Specify cardiovascular disease")]
        [RequiredIf(nameof(CVOTHR), "2", ErrorMessage = "Specify cardiovascular disease")]
        [ProhibitedCharacters]
        public string? CVOTHRX { get; set; }

        [Display(Name = "Stroke – by history, not exam (imaging is not required)")]
        [RequiredOnComplete]
        public int? CBSTROKE { get; set; }

        [Display(Name = "More than one stroke?")]
        [RequiredIf(nameof(CBSTROKE), "1", ErrorMessage = "Specify if more than one stroke")]
        [RequiredIf(nameof(CBSTROKE), "2", ErrorMessage = "Specify if more than one stroke")]
        public int? STROKMUL { get; set; }

        [Display(Name = "Year of most recent stroke")]
        [RequiredIf(nameof(CBSTROKE), "1", ErrorMessage = "Specify year of most recent stroke")]
        [RequiredIf(nameof(CBSTROKE), "2", ErrorMessage = "Specify year of most recent stroke")]
        public int? STROKYR { get; set; }

        [Display(Name = "Transient ischemic attack (TIA)")]
        [RequiredOnComplete]
        public int? CBTIA { get; set; }

        [Display(Name = "More than one TIA")]
        [RequiredIf(nameof(CBTIA), "1", ErrorMessage = "Specify if more than one TIA")]
        [RequiredIf(nameof(CBTIA), "2", ErrorMessage = "Specify if more than one TIA")]
        public int? TIAMULT { get; set; }

        [Display(Name = "Year of most recent TIA")]
        [RequiredIf(nameof(CBTIA), "1", ErrorMessage = "Specify year of most recent TIA")]
        [RequiredIf(nameof(CBTIA), "2", ErrorMessage = "Specify year of most recent TIA")]
        public int? TIAYEAR { get; set; }

        [Display(Name = "Parkinson’s disease (PD)")]
        [RequiredOnComplete]
        public int? PD { get; set; }

        [Display(Name = "Year of PD diagnosis")]
        [RequiredIf(nameof(PD), "1", ErrorMessage = "Specify year of diagnosis")]
        public int? PDYR { get; set; }

        [Display(Name = "Other parkinsonian disorder (e.g, PSP, CBD")]
        [RequiredOnComplete]
        public int? PDOTHR { get; set; }

        [Display(Name = "Year of parkinsonian disorder diagnosis")]
        [RequiredIf(nameof(PDOTHRYR), "1", ErrorMessage = "Specify year of diagnosis")]
        public int? PDOTHRYR { get; set; }

        [Display(Name = "Seizures")]
        [RequiredOnComplete]
        public int? SEIZURES { get; set; }

        [Display(Name = "Traumatic brain injury (TBI)")]
        [RequiredOnComplete]
        public int? TBI { get; set; }

        [Display(Name = "TBI with brief loss of consciousness (<5 minutes)")]
        [RequiredIf(nameof(TBI), "1", ErrorMessage = "Specify TBI with brief loss of consciousness")]
        [RequiredIf(nameof(TBI), "2", ErrorMessage = "Specify TBI with brief loss of consciousness")]
        public int? TBIBRIEF { get; set; }

        [Display(Name = "TBI with extended loss of consciousness (≥5 minutes)")]
        [RequiredIf(nameof(TBI), "1", ErrorMessage = "Specify TBI with extended loss of consciousness")]
        [RequiredIf(nameof(TBI), "2", ErrorMessage = "Specify TBI with extended loss of consciousness")]
        public int? TBIEXTEN { get; set; }

        [Display(Name = "TBI without loss of consciousness (as might result from military detonations or sports injuries)?")]
        [RequiredIf(nameof(TBI), "1", ErrorMessage = "Specify TBI without loss of consciousness")]
        [RequiredIf(nameof(TBI), "2", ErrorMessage = "Specify TBI without extended loss of consciousness")]
        public int? TBIWOLOS { get; set; }

        [Display(Name = "Year of most recent TBI")]
        [RequiredIf(nameof(TBI), "1", ErrorMessage = "Specify year of most recent TBI")]
        [RequiredIf(nameof(TBI), "2", ErrorMessage = "Specify year of most recent TBI")]
        public int? TBIYEAR { get; set; }

        [Display(Name = "Diabetes")]
        [RequiredOnComplete]
        public int? DIABETES { get; set; }

        [Display(Name = "If Recent/active or Remote/inactive, which type?")]
        [RequiredIf(nameof(DIABETES), "1", ErrorMessage = "Specify type")]
        [RequiredIf(nameof(DIABETES), "2", ErrorMessage = "Specify type")]
        public int? DIABTYPE { get; set; }

        [Display(Name = "Hypertension")]
        [RequiredOnComplete]
        public int? HYPERTEN { get; set; }

        [Display(Name = "Hypercholesterolemia")]
        [RequiredOnComplete]
        public int? HYPERCHO { get; set; }

        [Display(Name = "B12 deficiency")]
        [RequiredOnComplete]
        public int? B12DEF { get; set; }

        [Display(Name = "Thyroid disease")]
        [RequiredOnComplete]
        public int? THYROID { get; set; }

        [Display(Name = "Arthritis")]
        [RequiredOnComplete]
        public int? ARTHRIT { get; set; }

        [Display(Name = "Type of arthritis")]
        [RequiredIf(nameof(ARTHRIT), "1", ErrorMessage = "Specify type of arthritis")]
        [RequiredIf(nameof(ARTHRIT), "2", ErrorMessage = "Specify type of arthritis")]
        public int? ARTHTYPE { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(ARTHTYPE), "3", ErrorMessage = "Specify sleep disorder")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? ARTHTYPX { get; set; }

        [Display(Name = "Upper extremity")]
        public bool ARTHUPEX { get; set; }

        [Display(Name = "Lower extremity")]
        public bool ARTHLOEX { get; set; }

        [Display(Name = "Spine")]
        public bool ARTHSPIN { get; set; }

        [Display(Name = "Unknown")]
        public bool ARTHUNK { get; set; }

        [Display(Name = "Incontinence - urinary")]
        [RequiredOnComplete]
        public int? INCONTU { get; set; }

        [Display(Name = "Incontinence — bowel")]
        [RequiredOnComplete]
        public int? INCONTF { get; set; }

        [Display(Name = "Sleep apnea")]
        [RequiredOnComplete]
        public int? APNEA { get; set; }

        [Display(Name = "REM sleep behavior disorder (RBD)")]
        [RequiredOnComplete]
        public int? RBD { get; set; }

        [Display(Name = "Hyposomnia/insomnia")]
        [RequiredOnComplete]
        public int? INSOMN { get; set; }

        [Display(Name = "Other sleep disorder")]
        [RequiredOnComplete]
        public int? OTHSLEEP { get; set; }


        [Display(Name = "Other sleep disorder (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHSLEEP), "1", ErrorMessage = "Specify sleep disorder")]
        [RequiredIf(nameof(OTHSLEEP), "2", ErrorMessage = "Specify sleep disorder")]
        [ProhibitedCharacters]
        public string? OTHSLEEX { get; set; }

        [Display(Name = "Alcohol abuse: Clinically significant impairment occuring over a 12-month period manifested in one of the following areas: work, driving, legal, or social")]
        [RequiredOnComplete]
        public int? ALCOHOL { get; set; }

        [Display(Name = "Other abused substances: Clinically significant impairment occuring over a 12-month period manifested in one of the following areas: work, driving, legal, or social")]
        [RequiredOnComplete]
        public int? ABUSOTHR { get; set; }


        [Display(Name = "If recent/active or remote/inactive, specify abused substance")]
        [MaxLength(60)]
        [RequiredIf(nameof(ABUSOTHR), "1", ErrorMessage = "Specify abused substance")]
        [RequiredIf(nameof(ABUSOTHR), "2", ErrorMessage = "Specify abused substance")]
        [ProhibitedCharacters]
        public string? ABUSX { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD)")]
        [RequiredOnComplete]
        public int? PTSD { get; set; }

        [Display(Name = "Bipolar disorder")]
        [RequiredOnComplete]
        public int? BIPOLAR { get; set; }

        [Display(Name = "Schizophrenia")]
        [RequiredOnComplete]
        public int? SCHIZ { get; set; }

        [Display(Name = "Active depression in the last two years")]
        [RequiredOnComplete]
        public int? DEP2YRS { get; set; }

        [Display(Name = "Depression episodes more than two years ago")]
        [RequiredOnComplete]
        public int? DEPOTHR { get; set; }

        [Display(Name = "Anxiety")]
        [RequiredOnComplete]
        public int? ANXIETY { get; set; }

        [Display(Name = "Obsessive-compulsive disorder (OCD)")]
        [RequiredOnComplete]
        public int? OCD { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder [ASD], attention-deficit hyperactivity disorder [ADHD], dyslexia)")]
        [RequiredOnComplete]
        public int? NPSYDEV { get; set; }

        [Display(Name = "Other psychiatric disorders")]
        [RequiredOnComplete]
        public int? PSYCDIS { get; set; }


        [Display(Name = "If recent/active or remote/inactive, specify disorder")]
        [MaxLength(60)]
        [RequiredIf(nameof(PSYCDIS), "1", ErrorMessage = "Specify disorder")]
        [RequiredIf(nameof(PSYCDIS), "2", ErrorMessage = "Specify disorder")]
        [ProhibitedCharacters]
        public string? PSYCDISX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            if (Status == Services.Enums.FormStatus.Complete)
            {
                bool isValid = false;
                string errorMessage = "Value must be between 1900 and the current year of the visit date";


                var visitValue = validationContext.Items.FirstOrDefault(v => v.Key.ToString() == "Visit").Value;
                if (visitValue is VisitModel)
                {
                    VisitModel visit = (VisitModel)visitValue;

                    if (visit != null)
                    {
                        var min = new DateTime(1900, 1, 1);
                        var max = visit.StartDateTime;

                        if (STROKYR.HasValue && STROKYR.Value != 9999)
                        {
                            var strokeYear = new DateTime(STROKYR.Value, 1, 1);
                            if (strokeYear >= min && strokeYear <= max)
                            {
                                isValid = true;
                            }
                            else
                            {
                                yield return new ValidationResult(errorMessage, new[] { nameof(STROKYR) });
                            }
                        }
                        if (HATTYEAR.HasValue && HATTYEAR.Value != 9999)
                        {
                            var hatYear = new DateTime(HATTYEAR.Value, 1, 1);
                            if (hatYear >= min && hatYear <= max)
                            {
                                isValid = true;
                            }
                            else
                            {
                                yield return new ValidationResult(errorMessage, new[] { nameof(HATTYEAR) });
                            }
                        }
                        if (TIAYEAR.HasValue && TIAYEAR.Value != 9999)
                        {
                            var tiaYear = new DateTime(TIAYEAR.Value, 1, 1);
                            if (tiaYear >= min && tiaYear <= max)
                            {
                                isValid = true;
                            }
                            else
                            {
                                yield return new ValidationResult(errorMessage, new[] { nameof(TIAYEAR) });
                            }
                        }
                        if (PDYR.HasValue && PDYR.Value != 9999)
                        {
                            var pdYear = new DateTime(PDYR.Value, 1, 1);
                            if (pdYear >= min && pdYear <= max)
                            {
                                isValid = true;
                            }
                            else
                            {
                                yield return new ValidationResult(errorMessage, new[] { nameof(PDYR) });
                            }
                        }
                        if (PDOTHRYR.HasValue && PDOTHRYR.Value != 9999)
                        {
                            var pdOtherYear = new DateTime(PDOTHRYR.Value, 1, 1);
                            if (pdOtherYear >= min && pdOtherYear <= max)
                            {
                                isValid = true;
                            }
                            else
                            {
                                yield return new ValidationResult(errorMessage, new[] { nameof(PDOTHRYR) });
                            }
                        }
                        if (TBIYEAR.HasValue && TBIYEAR.Value != 9999)
                        {
                            var tbiYear = new DateTime(TBIYEAR.Value, 1, 1);
                            if (tbiYear >= min && tbiYear <= max)
                            {
                                isValid = true;
                            }
                            else
                            {
                                yield return new ValidationResult(errorMessage, new[] { nameof(TBIYEAR) });
                            }
                        }
                    }
                }
                yield break;
            }

        }

    }
}
