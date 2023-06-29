using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A5 : FormModel
    {
        [Display(Name = "Has subject smoked within the last 30 days?")]
        public int? TOBAC30 { get; set; }

        [Display(Name = "Has participant smoked more than 100 cigarettes in his/her life?")]
        public int? TOBAC100 { get; set; }

        [Display(Name = "Total years smoked")]
        [RegularExpression("^(\\d|[1-7]\\d|8[0-7]|99)$", ErrorMessage = "(0-87, 99 = Unknown)")]
        public int? SMOKYRS { get; set; }

        [Display(Name = "Average number of packs smoked per day")]
        public int? PACKSPER { get; set; }

        [Display(Name = "If the subject quit smoking, specify age at which he/she last smoked (i.e., quit)")]
        [RegularExpression("^([89]|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "(8-110, 888 = N/A, 999 = Unknown)")]
        public int? QUITSMOK { get; set; }

        [Display(Name = "In the past three months,has the subject consumed any alcohol?")]
        public int? ALCOCCAS { get; set; }

        [Display(Name = "During the past three months, how often did the subject have at least one drink of any alcoholic beverage such as wine, beer, malt liquor, or spirits?")]
        public int? ALCFREQ { get; set; }

        [Display(Name = "Heart attack/cardiac arrest")]
        public int? CVHATT { get; set; }

        [Display(Name = "More than one heart attack?")]
        public int? HATTMULT { get; set; }

        [Display(Name = "Year of most recent heart attack")]
        public int? HATTYEAR { get; set; }

        [Display(Name = "Atrial fibrillation")]
        public int? CVAFIB { get; set; }

        [Display(Name = "Angioplasty/endarterectomy/stent")]
        public int? CVANGIO { get; set; }

        [Display(Name = "Cardiac bypass procedure")]
        public int? CVBYPASS { get; set; }

        [Display(Name = "Pacemaker and/or defibrillator")]
        public int? CVPACDEF { get; set; }

        [Display(Name = "Congestive heart failure")]
        public int? CVCHF { get; set; }

        [Display(Name = "Angina")]
        public int? CVANGINA { get; set; }

        [Display(Name = "Heart valve replacement or repair")]
        public int? CVHVALVE { get; set; }

        [Display(Name = "Other cardiovascular disease")]
        public int? CVOTHR { get; set; }

        [Display(Name = "Other cardiovascular disease (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(CVOTHR), "1", ErrorMessage = "Specify cardiovascular disease")]
        [RequiredIf(nameof(CVOTHR), "2", ErrorMessage = "Specify cardiovascular disease")]
        public string? CVOTHRX { get; set; }

        [Display(Name = "Stroke – by history, not exam (imaging is not required)")]
        public int? CBSTROKE { get; set; }

        [Display(Name = "More than one stroke?")]
        public int? STROKMUL { get; set; }

        [Display(Name = "Year of most recent stroke")]
        public int? STROKYR { get; set; }

        [Display(Name = "Transient ischemic attack (TIA)")]
        public int? CBTIA { get; set; }

        [Display(Name = "More than one TIA")]
        public int? TIAMULT { get; set; }

        [Display(Name = "Year of most recent TIA")]
        public int? TIAYEAR { get; set; }

        [Display(Name = "Parkinson’s disease (PD)")]
        public int? PD { get; set; }

        [Display(Name = "Year of PD diagnosis")]
        public int? PDYR { get; set; }

        [Display(Name = "Other parkinsonian disorder (e.g, PSP, CBD")]
        public int? PDOTHR { get; set; }

        [Display(Name = "Year of parkinsonian disorder diagnosis")]
        public int? PDOTHRYR { get; set; }

        [Display(Name = "Seizures")]
        public int? SEIZURES { get; set; }

        [Display(Name = "Traumatic brain injury (TBI)")]
        public int? TBI { get; set; }

        [Display(Name = "TBI with brief loss of consciousness (<5 minutes)")]
        public int? TBIBRIEF { get; set; }

        [Display(Name = "TBI with extended loss of consciousness (≥5 minutes)")]
        public int? TBIEXTEN { get; set; }

        [Display(Name = "TBI without loss of consciousness (as might result from military detonations or sports injuries)?")]
        public int? TBIWOLOS { get; set; }

        [Display(Name = "Year of most recent TBI")]
        public int? TBIYEAR { get; set; }

        [Display(Name = "Diabetes")]
        public int? DIABETES { get; set; }

        [Display(Name = "If Recent/active or Remote/inactive, which type?")]
        public int? DIABTYPE { get; set; }

        [Display(Name = "Hypertension")]
        public int? HYPERTEN { get; set; }

        [Display(Name = "Hypercholesterolemia")]
        public int? HYPERCHO { get; set; }

        [Display(Name = "B12 deficiency")]
        public int? B12DEF { get; set; }

        [Display(Name = "Thyroid disease")]
        public int? THYROID { get; set; }

        [Display(Name = "Arthritis")]
        public int? ARTHRIT { get; set; }

        [Display(Name = "Type of arthritis")]
        public int? ARTHTYPE { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(ARTHTYPE), "1", ErrorMessage = "Specify sleep disorder")]
        [MaxLength(60)]
        public string? ARTHTYPX { get; set; }

        [Display(Name = "Upper extremity")]
        public int? ARTHUPEX { get; set; }

        [Display(Name = "Lower extremity")]
        public int? ARTHLOEX { get; set; }

        [Display(Name = "Spine")]
        public int? ARTHSPIN { get; set; }

        [Display(Name = "Unknown")]
        public int? ARTHUNK { get; set; }

        [Display(Name = "Incontinence - urinary")]
        public int? INCONTU { get; set; }

        [Display(Name = "Incontinence — bowel")]
        public int? INCONTF { get; set; }

        [Display(Name = "Sleep apnea")]
        public int? APNEA { get; set; }

        [Display(Name = "REM sleep behavior disorder (RBD)")]
        public int? RBD { get; set; }

        [Display(Name = "Hyposomnia/insomnia")]
        public int? INSOMN { get; set; }

        [Display(Name = "Other sleep disorder")]
        public int? OTHSLEEP { get; set; }

        [Display(Name = "Other sleep disorder (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHSLEEP), "1", ErrorMessage = "Specify sleep disorder")]
        [RequiredIf(nameof(OTHSLEEP), "2", ErrorMessage = "Specify sleep disorder")]
        public string? OTHSLEEX { get; set; }

        [Display(Name = "Alcohol abuse: Clinically significant impairment occuring over a 12-month period manifested in one of the following areas: work, driving, legal, or social")]
        public int? ALCOHOL { get; set; }

        [Display(Name = "Other abused substances: Clinically significant impairment occuring over a 12-month period manifested in one of the following areas: work, driving, legal, or social")]
        public int? ABUSOTHR { get; set; }

        [Display(Name = "If recent/active or remote/inactive, specify abused substance")]
        [MaxLength(60)]
        [RequiredIf(nameof(ABUSOTHR), "1", ErrorMessage = "Specify abused substance")]
        [RequiredIf(nameof(ABUSOTHR), "2", ErrorMessage = "Specify abused substance")]
        public string? ABUSX { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD)")]
        public int? PTSD { get; set; }

        [Display(Name = "Bipolar disorder")]
        public int? BIPOLAR { get; set; }

        [Display(Name = "Schizophrenia")]
        public int? SCHIZ { get; set; }

        [Display(Name = "Active depression in the last two years")]
        public int? DEP2YRS { get; set; }

        [Display(Name = "Depression episodes more than two years ago")]
        public int? DEPOTHR { get; set; }

        [Display(Name = "Anxiety")]
        public int? ANXIETY { get; set; }

        [Display(Name = "Obsessive-compulsive disorder (OCD)")]
        public int? OCD { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder [ASD], attention-deficit hyperactivity disorder [ADHD], dyslexia)")]
        public int? NPSYDEV { get; set; }

        [Display(Name = "Other psychiatric disorders")]
        public int? PSYCDIS { get; set; }

        [Display(Name = "If recent/active or remote/inactive, specify disorder")]
        [MaxLength(60)]
        [RequiredIf(nameof(PSYCDIS), "1", ErrorMessage = "Specify disorder")]
        [RequiredIf(nameof(PSYCDIS), "2", ErrorMessage = "Specify disorder")]
        public string? PSYCDISX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == "2")
            {
                bool isValid = false;
                string errorMessage = "Value must be between 1900 and the current year of the visit date";
                var visitDateEntry = validationContext.Items.Where(i => i.Key.ToString() == "VisitDate").FirstOrDefault();

                if (STROKYR.HasValue && STROKYR.Value != 9999 ||
                    HATTYEAR.HasValue && HATTYEAR.Value != 9999 ||
                    TIAYEAR.HasValue && TIAYEAR.Value != 9999 ||
                    PDYR.HasValue && PDYR.Value != 9999 ||
                    PDOTHRYR.HasValue && PDOTHRYR.Value != 9999 ||
                     TBIYEAR.HasValue && TBIYEAR.Value != 9999)
                {
                    var visitDate = visitDateEntry.Value;

                    if (visitDate != null)
                    {
                        var min = new DateTime(1900, 1, 1);
                        var max = (DateTime)visitDate;

                        if (STROKYR.HasValue && STROKYR.Value != 9999)
                        {
                            var strokeYear = new DateTime(STROKYR.Value, 1, 1);
                            if (strokeYear >= min && strokeYear <= max)
                            {
                                isValid = true;
                            }


                            if (HATTYEAR.HasValue && HATTYEAR.Value != 9999)
                            {
                                var hatYear = new DateTime(HATTYEAR.Value, 1, 1);
                                if (hatYear >= min && hatYear <= max)
                                {
                                    isValid = true;
                                }
                            }

                            if (TIAYEAR.HasValue && TIAYEAR.Value != 9999)
                            {
                                var tiaYear = new DateTime(TIAYEAR.Value, 1, 1);
                                if (tiaYear >= min && tiaYear <= max)
                                {
                                    isValid = true;
                                }
                            }

                            if (PDYR.HasValue && PDYR.Value != 9999)
                            {
                                var pdYear = new DateTime(PDYR.Value, 1, 1);
                                if (pdYear >= min && pdYear <= max)
                                {
                                    isValid = true;
                                }
                            }

                            if (PDOTHRYR.HasValue && PDOTHRYR.Value != 9999)
                            {
                                var pdOtherYear = new DateTime(PDOTHRYR.Value, 1, 1);
                                if (pdOtherYear >= min && pdOtherYear <= max)
                                {
                                    isValid = true;
                                }
                            }

                            if (TBIYEAR.HasValue && TBIYEAR.Value != 9999)
                            {
                                var tbiYear = new DateTime(TBIYEAR.Value, 1, 1);
                                if (tbiYear >= min && tbiYear <= max)
                                {
                                    isValid = true;
                                }
                            }
                        }
                    }

                    if (!isValid)
                    {
                        yield return new ValidationResult(
                            errorMessage,
                            new[] { nameof(STROKYR), nameof(HATTYEAR), nameof(TIAYEAR), nameof(PDYR), nameof(PDOTHRYR), nameof(TBIYEAR) });
                    }
                }

                yield break;
            }
        }
    }
}
