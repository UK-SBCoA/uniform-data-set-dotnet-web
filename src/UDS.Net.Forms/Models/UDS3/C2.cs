using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class C2 : FormModel
    {
        [Display(Name = "Was any part of MoCA administered?")]
        [RequiredOnComplete]
        public int? MOCACOMP { get; set; }

        [Display(Name = "If No, enter reason code, 95–98")]
        [Range(95, 98)]
        [RequiredIf(nameof(MOCACOMP), "0", ErrorMessage = "Provide reason code")]
        public int? MOCAREAS { get; set; }

        [Display(Name = "MoCA was administered")]
        public int? MOCALOC { get; set; }

        [Display(Name = "Language of MoCA administration")]
        public int? MOCALAN { get; set; }

        [Display(Name = "0ther (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(MOCALAN), "3", ErrorMessage = "Specify other language used")]
        [SpecialCharacter]
        public string? MOCALANX { get; set; }

        [Display(Name = "Subject was unable to complete one or more sections due to visual impairment")]
        public int? MOCAVIS { get; set; }

        [Display(Name = "Subject was unable to complete one or more sections due to hearing impairment")]
        public int? MOCAHEAR { get; set; }

        [Display(Name = "TOTAL RAW SCORE - UNCORRECTED (Not corrected for education or visual/hearing impairment)", Description = "enter 88 if any of the following MoCA items were not administered: 1g-1l, 1n-1t, 1w-1bb")]
        [RegularExpression("^(\\d|[0-2]\\d|30|88)$", ErrorMessage = "(0-30 or 88 = not administered)")]
        public int? MOCATOTS { get; set; }

        [Display(Name = "Visuospatial/executive — Trails", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCATRAI { get; set; }

        [Display(Name = " Visuospatial/executive — Cube", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCACUBE { get; set; }

        [Display(Name = "Visuospatial/executive — Clock contour", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCACLOC { get; set; }

        [Display(Name = "Visuospatial/executive — Clock numbers", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCACLON { get; set; }

        [Display(Name = "Visuospatial/executive — Clock hands", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCACLOH { get; set; }

        [Display(Name = "Language — Naming", Description = "(0-3, 95-98)")]
        [RegularExpression("^([0-3]|9[5-8])$", ErrorMessage = "(0-3, 95-98)")]
        public int? MOCANAMI { get; set; }

        [Display(Name = "Memory — Registration (two trials)", Description = "(0-10, 95-98)")]
        [RegularExpression("^(\\d|10|9[5-8])$", ErrorMessage = "(0-10, 95-98)")]
        public int? MOCAREGI { get; set; }

        [Display(Name = "Attention — Digits", Description = "(0-2, 95-98)")]
        [RegularExpression("^([0-2]|9[5-8])$", ErrorMessage = "(0-2, 95-98)")]
        public int? MOCADIGI { get; set; }

        [Display(Name = "Attention — Letter A", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCALETT { get; set; }

        [Display(Name = "Attention — Serial 7s", Description = "(0-3, 95-98)")]
        [RegularExpression("^([0-3]|9[5-8])$", ErrorMessage = "(0-3, 95-98)")]
        public int? MOCASER7 { get; set; }

        [Display(Name = "Language — Repetition", Description = "(0-2, 95-98)")]
        [RegularExpression("^([0-2]|9[5-8])$", ErrorMessage = "(0-2, 95-98)")]
        public int? MOCAREPE { get; set; }

        [Display(Name = "Language — Fluency", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCAFLUE { get; set; }

        [Display(Name = "Abstraction", Description = "(0-2, 95-98)")]
        [RegularExpression("^([0-2]|9[5-8])$", ErrorMessage = "(0-2, 95-98)")]
        public int? MOCAABST { get; set; }

        [Display(Name = "Delayed recall — No cue", Description = "(0-5, 95-98)")]
        [RegularExpression("^([0-5]|9[5-8])$", ErrorMessage = "(0-5, 95-98)")]
        public int? MOCARECN { get; set; }

        [Display(Name = "Delayed recall — Category cue", Description = "(0-5, 88 = not applicable)")]
        [RegularExpression("^([0-5]|88)$", ErrorMessage = "(0-5, 88 = not applicable)")]
        public int? MOCARECC { get; set; }

        [Display(Name = "Delayed recall — Recognition", Description = "(0-5, 88 = not applicable)")]
        [RegularExpression("^([0-5]|88)$", ErrorMessage = "(0-5, 88 = not applicable)")]
        public int? MOCARECR { get; set; }

        [Display(Name = "Orientation — Date", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCAORDT { get; set; }

        [Display(Name = "Orientation — Month", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCAORMO { get; set; }

        [Display(Name = "Orientation — Year", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCAORYR { get; set; }

        [Display(Name = "Orientation — Day", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCAORDY { get; set; }

        [Display(Name = "Orientation — Place", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCAORPL { get; set; }

        [Display(Name = "Orientation — City", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "(0-1, 95-98)")]
        public int? MOCAORCT { get; set; }

        [Display(Name = "The tests following the MoCA were administered")]
        [RequiredOnComplete]
        public int? NPSYCLOC { get; set; }

        [Display(Name = "Language of test administration")]
        [RequiredOnComplete]
        public int? NPSYLAN { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(NPSYLAN), "3", ErrorMessage = "Specify other language used")]
        [SpecialCharacter]
        public string? NPSYLANX { get; set; }

        [Display(Name = "Total story units recalled, verbatim scoring", Description = "(0-44, 95-98)")]
        [RegularExpression("^([0-9]|[1-3][0-9]|4[0-4]|9[5-8])$", ErrorMessage = "(0-44, 95-98)")]
        [RequiredOnComplete]
        public int? CRAFTVRS { get; set; }

        [Display(Name = "Total story units recalled, paraphrase scoring", Description = "(0-25)")]
        [Range(0, 25, ErrorMessage = "(0-25)")]
        public int? CRAFTURS { get; set; }

        [Display(Name = "Total Score for copy of Benson figure", Description = "(0-17, 95-98)")]
        [RegularExpression("^(\\d|1[0-7]|9[5-8])$", ErrorMessage = "(0-17, 95-98)")]
        [RequiredOnComplete]
        public int? UDSBENTC { get; set; }

        [Display(Name = "Number of correct trials", Description = "(0-14, 95-98)")]
        [RegularExpression("^(\\d|1[0-4]|9[5-8])$", ErrorMessage = "(0-14, 95-98)")]
        [RequiredOnComplete]
        public int? DIGFORCT { get; set; }

        [Display(Name = "Longest span forward", Description = "(0, 3-9)")]
        [RegularExpression("^(0|[3-9])$", ErrorMessage = "(0, 3-9)")]
        public int? DIGFORSL { get; set; }

        [Display(Name = "Number of correct trials", Description = "(0-14, 95-98)")]
        [RegularExpression("^(\\d|1[0-4]|9[5-8])$", ErrorMessage = "(0-14, 95-98)")]
        [RequiredOnComplete]
        public int? DIGBACCT { get; set; }

        [Display(Name = "Longest span backward", Description = "(0, 2-8)")]
        [RegularExpression("^(0|[2-8])$", ErrorMessage = "(0, 2-8)")]
        public int? DIGBACLS { get; set; }

        [Display(Name = "Animals: Total number of animals named in 60 seconds", Description = "(0-77, 95-98)")]
        [RegularExpression("^(\\d|[1-6]\\d|7[0-7]|9[5-8])$", ErrorMessage = "(0-77, 95-98)")]
        [RequiredOnComplete]
        public int? ANIMALS { get; set; }

        [Display(Name = "Vegetables: Total number of vegtables named in 60 seconds", Description = "(0-77, 95-98)")]
        [RegularExpression("^(\\d|[1-6]\\d|7[0-7]|9[5-8])$", ErrorMessage = "(0-77, 95-98)")]
        [RequiredOnComplete]
        public int? VEG { get; set; }

        [Display(Name = "Part A: Total number of seconds to complete", Description = "(0-150, 995-998)")]
        [RegularExpression("^(\\d|[1-9]\\d|1[0-4]\\d|150|99[5-8])$", ErrorMessage = "(0-150, 995-998)")]
        [RequiredOnComplete]
        public int? TRAILA { get; set; }

        [Display(Name = "Number of commission errors", Description = "(0-40)")]
        [Range(0, 40, ErrorMessage = "(0-40)")]
        public int? TRAILARR { get; set; }

        [Display(Name = "Number of correct lines", Description = "(0-24)")]
        [Range(0, 24, ErrorMessage = "(0-24)")]
        public int? TRAILALI { get; set; }

        [Display(Name = "Part B: Total number of seconds to complete", Description = "(0-300, 995-998)")]
        [RegularExpression("^(\\d|[1-9]\\d|[12]\\d{2}|300|99[5-8])$", ErrorMessage = "(0-300, 995-998)")]
        public int? TRAILB { get; set; }

        [Display(Name = "Number of commission errors", Description = "(0-40)")]
        [Range(0, 40, ErrorMessage = "(0-40)")]
        public int? TRAILBRR { get; set; }

        [Display(Name = "Number of correct lines", Description = "(0-24)")]
        [Range(0, 24, ErrorMessage = "(0-24)")]
        public int? TRAILBLI { get; set; }

        [Display(Name = "Total story units recalled, verbatim scoring", Description = "(0-44, 95-98)")]
        [RegularExpression("^(\\d|[1-3]\\d|4[0-4]|9[5-8])$", ErrorMessage = "(0-44, 95-98)")]
        [RequiredOnComplete]
        public int? CRAFTDVR { get; set; }

        [Display(Name = "Total story units recalled, paraphrase scoring", Description = "(0-24)")]
        [Range(0, 25, ErrorMessage = "(0-24)")]
        public int? CRAFTDRE { get; set; }

        [Display(Name = "Delay time (minutes)", Description = "(0-85 minutes, 99 = unknown)")]
        [RegularExpression("^(\\d|[1-7]\\d|8[0-5]|99)$", ErrorMessage = "(0-85 minutes, 99 = unknown)")]
        public int? CRAFTDTI { get; set; }

        [Display(Name = "Cue (\"boy\") needed")]
        public int? CRAFTCUE { get; set; }

        [Display(Name = "Total score for drawing of Benson figure following 10- to 15-minuted delay", Description = "(0-17, 95-98)")]
        [RegularExpression("^(\\d|1[0-7]|9[5-8])$", ErrorMessage = "(0-17, 95-98)")]
        [RequiredOnComplete]
        public int? UDSBENTD { get; set; }

        [Display(Name = "Recognized original stimulus among four options?")]
        public int? UDSBENRS { get; set; }

        [Display(Name = "Total score", Description = "(0-32, 95-98)")]
        [RegularExpression("^(\\d|[12]\\d|3[0-2]|9[5-8])$", ErrorMessage = "(0-32, 95-98)")]
        [RequiredOnComplete]
        public int? MINTTOTS { get; set; }

        [Display(Name = "Total correct without semantic cue", Description = "(0-32)")]
        [Range(0, 32, ErrorMessage = "(0-32)")]
        public int? MINTTOTW { get; set; }

        [Display(Name = "Semantic cues: Number given", Description = "(0-32)")]
        [Range(0, 32, ErrorMessage = "(0-32)")]
        public int? MINTSCNG { get; set; }

        [Display(Name = "Semantic cues: Number correct with cue", Description = "(0-32, 88 = not applicable)")]
        [RegularExpression("^(\\d|[12]\\d|3[0-2]|88)$", ErrorMessage = "(0-32, 88)")]
        public int? MINTSCNC { get; set; }

        [Display(Name = "Phonemic cues: Number given", Description = "(0-32)")]
        [Range(0, 32, ErrorMessage = "(0-32)")]
        public int? MINTPCNG { get; set; }

        [Display(Name = "Phonemic cues: Number correct with cue", Description = "(0-32, 88 = not applicable)")]
        [RegularExpression("^(\\d|[12]\\d|3[0-2]|88)$", ErrorMessage = "(0-32, 88)")]
        public int? MINTPCNC { get; set; }

        [Display(Name = "Number of correct F-words generated in 1 minute", Description = "(0-40, 95-98)")]
        [RegularExpression("^(\\d|[1-3]\\d|40|9[5-8])$", ErrorMessage = "(0-40, 95-98)")]
        [RequiredOnComplete]
        public int? UDSVERFC { get; set; }

        [Display(Name = "Number of correct F-words repeated in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "(0-15)")]
        public int? UDSVERFN { get; set; }

        [Display(Name = "Number of non-F-words and rule violation errors in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "(0-15)")]
        public int? UDSVERNF { get; set; }

        #region If not completed, skip to question 13a

        [Display(Name = "Number of correct L-words generated in 1 minute", Description = "(0-40, 95-98)")]
        [RegularExpression("^(\\d|[1-3]\\d|40|9[5-8])$", ErrorMessage = "(0-40, 95-98)")]
        [RequiredOnComplete]
        public int? UDSVERLC { get; set; }

        [Display(Name = "Number of L-words repeated in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "(0-15)")]
        [RequiredIfRange(nameof(UDSVERLC), 0, 40, ErrorMessage = "Provide count of L-words repeated.")]
        public int? UDSVERLR { get; set; }

        [Display(Name = "Number of non-L-words and rule violation errors in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "(0-15)")]
        [RequiredIfRange(nameof(UDSVERLC), 0, 40, ErrorMessage = "Provide count of non-L-words and rule violation errors.")]
        public int? UDSVERLN { get; set; }

        [Display(Name = "TOTAL number of correct F-words and L-words", Description = "(0-80)")]
        [Range(0, 80, ErrorMessage = "(0-80)")]
        [RequiredOnComplete]
        public int? UDSVERTN { get; set; }

        [Display(Name = "TOTAL number of F-word and L-words repetition errors", Description = "(0-30)")]
        [Range(0, 30, ErrorMessage = "(0-30)")]
        [RequiredOnComplete]
        public int? UDSVERTE { get; set; }

        [Display(Name = "TOTAL number of non-F/L words and rule violation errors", Description = "(0-30)")]
        [Range(0, 30, ErrorMessage = "(0-30)")]
        [RequiredOnComplete]
        public int? UDSVERTI { get; set; }

        #endregion

        [Display(Name = "Per the clinician (e.g., neuropsychologist, behavioral neurologist, or other suitably qualified clinician), based on the UDS neuropsychological examination, the participants cognitive status is deemed")]
        [RequiredOnComplete]
        public int? COGSTAT { get; set; }

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

