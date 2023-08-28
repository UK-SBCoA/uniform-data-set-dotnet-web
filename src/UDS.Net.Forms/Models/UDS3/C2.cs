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
        [RequiredIf(nameof(MOCACOMP), "0", ErrorMessage = "Provide reason code.")]
        public int? MOCAREAS { get; set; }

        [Display(Name = "MoCA was administered")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Which location was the MoCA administered?")]
        public int? MOCALOC { get; set; }

        [Display(Name = "Language of MoCA administration")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Which language was the MoCA administered?")]
        public int? MOCALAN { get; set; }

        [Display(Name = "0ther (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(MOCALAN), "3", ErrorMessage = "Specify other language used.")]
        [ProhibitedCharacters]
        public string? MOCALANX { get; set; }

        [Display(Name = "Subject was unable to complete one or more sections due to visual impairment")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Was the MoCA affected by visual impairment?")]
        public int? MOCAVIS { get; set; }

        [Display(Name = "Subject was unable to complete one or more sections due to hearing impairment")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Was the MoCA affected by hearing impairment?")]
        public int? MOCAHEAR { get; set; }

        [Display(Name = "TOTAL RAW SCORE - UNCORRECTED (Not corrected for education or visual/hearing impairment)", Description = "enter 88 if any of the following MoCA items were not administered: 1g-1l, 1n-1t, 1w-1bb")]
        [RegularExpression("^(\\d|[0-2]\\d|30|88)$", ErrorMessage = "Allowed values are 0-30 or 88 = not administered.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Sum all subscores. The maximum score is 30 points.")]
        public int? MOCATOTS { get; set; }

        [Display(Name = "Visuospatial/executive — Trails", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Allocate one point if the pattern was drawn successfully; otherwise, enter 0.")]
        public int? MOCATRAI { get; set; }

        [Display(Name = " Visuospatial/executive — Cube", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Assign a point if all cube criteria are met.")]
        public int? MOCACUBE { get; set; }

        [Display(Name = "Visuospatial/executive — Clock contour", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "If clock contour acceptable, enter 1; otherwise, enter 0.")]
        public int? MOCACLOC { get; set; }

        [Display(Name = "Visuospatial/executive — Clock numbers", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "If all clock number criteria are met, enter 1; otherwise, enter 0.")]
        public int? MOCACLON { get; set; }

        [Display(Name = "Visuospatial/executive — Clock hands", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "If all clock hands criteria are met, enter 1; otherwise, enter 0.")]
        public int? MOCACLOH { get; set; }

        [Display(Name = "Language — Naming", Description = "(0-3, 95-98)")]
        [RegularExpression("^([0-3]|9[5-8])$", ErrorMessage = "Allowed values are 0-3 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "One point each is given for the following responses: (1) lion (2) rhinoceros or rhino (3) camel or dromedary.")]
        public int? MOCANAMI { get; set; }

        [Display(Name = "Memory — Registration (two trials)", Description = "(0-10, 95-98)")]
        [RegularExpression("^(\\d|10|9[5-8])$", ErrorMessage = "Allowed values are 0-10 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Count the number correct for both trials.")]
        public int? MOCAREGI { get; set; }

        [Display(Name = "Attention — Digits", Description = "(0-2, 95-98)")]
        [RegularExpression("^([0-2]|9[5-8])$", ErrorMessage = "Allowed values are 0-2 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Allocate one point for each sequence correctly repeated.")]
        public int? MOCADIGI { get; set; }

        [Display(Name = "Attention — Letter A", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Give one point if there is zero to one errors.")]
        public int? MOCALETT { get; set; }

        [Display(Name = "Attention — Serial 7s", Description = "(0-3, 95-98)")]
        [RegularExpression("^([0-3]|9[5-8])$", ErrorMessage = "Allowed values are 0-3 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Give no (0) points for no correct subtractions, 1 point for one correction subtraction, 2 points for two to three correct subtractions, and 3 points if the participant successfully makes four or five correct subtractions.")]
        public int? MOCASER7 { get; set; }

        [Display(Name = "Language — Repetition", Description = "(0-2, 95-98)")]
        [RegularExpression("^([0-2]|9[5-8])$", ErrorMessage = "Allowed values are 0-2 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Allocate 1 point for each sentence correctly repeated.")]
        public int? MOCAREPE { get; set; }

        [Display(Name = "Language — Fluency", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Allocate one point if the participant generates 11 words or more in 60 seconds.")]
        public int? MOCAFLUE { get; set; }

        [Display(Name = "Abstraction", Description = "(0-2, 95-98)")]
        [RegularExpression("^([0-2]|9[5-8])$", ErrorMessage = "Allowed values are 0-2 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Give 1 point to each item pair correctly answered.")]
        public int? MOCAABST { get; set; }

        #region Delayed recall

        [Display(Name = "Delayed recall — No cue", Description = "(0-5, 95-98)")]
        [RegularExpression("^([0-5]|9[5-8])$", ErrorMessage = "Allowed values are 0-5 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Allocate 1 point for each word recalled freely without any cues.")]
        public int? MOCARECN { get; set; }

        [Display(Name = "Delayed recall — Category cue", Description = "(0-5, 88 = not applicable)")]
        [RegularExpression("^([0-5]|88)$", ErrorMessage = "Allowed values are 0-5 or 88 = not applicable.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter the number of words recalled; otherwise, enter 88 = not applicable.")]
        public int? MOCARECC { get; set; }

        [Display(Name = "Delayed recall — Recognition", Description = "(0-5, 88 = not applicable)")]
        [RegularExpression("^([0-5]|88)$", ErrorMessage = "Allowed values are 0-5 or 88 = not applicable.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter the number of words recognized; otherwise, enter 88 =  not applicable.")]
        public int? MOCARECR { get; set; }

        #endregion

        [Display(Name = "Orientation — Date", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter 1 if correct or 0 if incorrect for orientation - date.")]
        public int? MOCAORDT { get; set; }

        [Display(Name = "Orientation — Month", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter 1 if correct or 0 if incorrect for orientation - month.")]
        public int? MOCAORMO { get; set; }

        [Display(Name = "Orientation — Year", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter 1 if correct or 0 if incorrect for orientation - year.")]
        public int? MOCAORYR { get; set; }

        [Display(Name = "Orientation — Day", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter 1 if correct or 0 if incorrect for orientation - day.")]
        public int? MOCAORDY { get; set; }

        [Display(Name = "Orientation — Place", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter 1 if correct or 0 if incorrect for orientation - place.")]
        public int? MOCAORPL { get; set; }

        [Display(Name = "Orientation — City", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Enter 1 if correct or 0 if incorrect for orientation - city.")]
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
        [ProhibitedCharacters]
        public string? NPSYLANX { get; set; }

        #region if not completed, skip to question  4a

        [Display(Name = "Total story units recalled, verbatim scoring", Description = "(0-44, 95-98)")]
        [RegularExpression("^([0-9]|[1-3][0-9]|4[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-44 or 95-98.")]
        [RequiredOnComplete]
        public int? CRAFTVRS { get; set; }

        [Display(Name = "Total story units recalled, paraphrase scoring", Description = "(0-25)")]
        [Range(0, 25, ErrorMessage = "Allowed values are 0-25.")]
        [RequiredIfRange(nameof(CRAFTVRS), 0, 44, ErrorMessage = "Provide total story units recalled, paraphrase scoring.")]
        public int? CRAFTURS { get; set; }

        #endregion

        [Display(Name = "Total Score for copy of Benson figure", Description = "(0-17, 95-98)")]
        [RegularExpression("^(\\d|1[0-7]|9[5-8])$", ErrorMessage = "Allowed values are 0-17 or 95-98.")]
        [RequiredOnComplete]
        public int? UDSBENTC { get; set; }

        #region if not completed, skip to  6a

        [Display(Name = "Number of correct trials", Description = "(0-14, 95-98)")]
        [RegularExpression("^(\\d|1[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-14 or 95-98.")]
        [RequiredOnComplete]
        public int? DIGFORCT { get; set; }

        [Display(Name = "Longest span forward", Description = "(0, 3-9)")]
        [RegularExpression("^(0|[3-9])$", ErrorMessage = "Allowed values are 0 or 3-9.")]
        [RequiredIfRange(nameof(DIGFORCT), 0, 14, ErrorMessage = "Provide longest span forward.")]
        public int? DIGFORSL { get; set; }

        #endregion

        #region if not completed, skip to question 7a

        [Display(Name = "Number of correct trials", Description = "(0-14, 95-98)")]
        [RegularExpression("^(\\d|1[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-14 or 95-98.")]
        [RequiredOnComplete]
        public int? DIGBACCT { get; set; }

        [Display(Name = "Longest span backward", Description = "(0, 2-8)")]
        [RegularExpression("^(0|[2-8])$", ErrorMessage = "Allowed values are 0 or 2-8.")]
        [RequiredIfRange(nameof(DIGBACCT), 0, 14, ErrorMessage = "Provide longest span backward.")]
        public int? DIGBACLS { get; set; }

        #endregion

        [Display(Name = "Animals: Total number of animals named in 60 seconds", Description = "(0-77, 95-98)")]
        [RegularExpression("^(\\d|[1-6]\\d|7[0-7]|9[5-8])$", ErrorMessage = "Allowed values are 0-77 or 95-98.")]
        [RequiredOnComplete]
        public int? ANIMALS { get; set; }

        [Display(Name = "Vegetables: Total number of vegtables named in 60 seconds", Description = "(0-77, 95-98)")]
        [RegularExpression("^(\\d|[1-6]\\d|7[0-7]|9[5-8])$", ErrorMessage = "Allowed values are 0-77 or 95-98.")]
        [RequiredOnComplete]
        public int? VEG { get; set; }

        #region if not completed, skip to question 8b

        [Display(Name = "Part A: Total number of seconds to complete", Description = "(0-150, 995-998)")]
        [RegularExpression("^(\\d|[1-9]\\d|1[0-4]\\d|150|99[5-8])$", ErrorMessage = "Allowed values are 0-150 or 995-998.")]
        [RequiredOnComplete]
        public int? TRAILA { get; set; }

        [Display(Name = "Number of commission errors", Description = "(0-40)")]
        [Range(0, 40, ErrorMessage = "Allowed values are 0-40.")]
        [RequiredIfRange(nameof(TRAILA), 0, 150, ErrorMessage = "Provide number of comission errors.")]
        public int? TRAILARR { get; set; }

        [Display(Name = "Number of correct lines", Description = "(0-24)")]
        [Range(0, 24, ErrorMessage = "Allowed values are 0-24.")]
        [RequiredIfRange(nameof(TRAILA), 0, 150, ErrorMessage = "Provide number of correct lines.")]
        public int? TRAILALI { get; set; }

        #endregion

        #region if not completed, skip to question 9a

        [Display(Name = "Part B: Total number of seconds to complete", Description = "(0-300, 995-998)")]
        [RegularExpression("^(\\d|[1-9]\\d|[12]\\d{2}|300|99[5-8])$", ErrorMessage = "(0-300, 995-998)")]
        public int? TRAILB { get; set; }

        [Display(Name = "Number of commission errors", Description = "(0-40)")]
        [Range(0, 40, ErrorMessage = "Allowed values are 0-40.")]
        [RequiredIfRange(nameof(TRAILB), 0, 300, ErrorMessage = "")]
        public int? TRAILBRR { get; set; }

        [Display(Name = "Number of correct lines", Description = "(0-24)")]
        [Range(0, 24, ErrorMessage = "Allowed values are 0-24.")]
        [RequiredIfRange(nameof(TRAILB), 0, 300, ErrorMessage = "")]
        public int? TRAILBLI { get; set; }

        #endregion

        #region if not completed, skip to question 10a

        [Display(Name = "Total story units recalled, verbatim scoring", Description = "(0-44, 95-98)")]
        [RegularExpression("^(\\d|[1-3]\\d|4[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-44 or 95-98.")]
        [RequiredOnComplete]
        public int? CRAFTDVR { get; set; }

        [Display(Name = "Total story units recalled, paraphrase scoring", Description = "(0-24)")]
        [Range(0, 25, ErrorMessage = "Allowed values are 0-24.")]
        [RequiredIfRange(nameof(CRAFTDVR), 0, 44, ErrorMessage = "Provide total recalled, paraphrase scoring.")]
        public int? CRAFTDRE { get; set; }

        [Display(Name = "Delay time (minutes)", Description = "(0-85 minutes, 99 = unknown)")]
        [RegularExpression("^(\\d|[1-7]\\d|8[0-5]|99)$", ErrorMessage = "Allowed values are 0-85 or 99 = unknown.")]
        [RequiredIfRange(nameof(CRAFTDVR), 0, 44, ErrorMessage = "Provide delay time (minutes).")]
        public int? CRAFTDTI { get; set; }

        [Display(Name = "Cue (\"boy\") needed")]
        [RequiredIfRange(nameof(CRAFTDVR), 0, 44, ErrorMessage = "Was cue (\"boy\") needed?")]
        public int? CRAFTCUE { get; set; }

        #endregion

        #region if not completed, skip to question 11a

        [Display(Name = "Total score for drawing of Benson figure following 10- to 15-minuted delay", Description = "(0-17, 95-98)")]
        [RegularExpression("^(\\d|1[0-7]|9[5-8])$", ErrorMessage = "Allowed values are 0-17 or 95-98.")]
        [RequiredOnComplete]
        public int? UDSBENTD { get; set; }

        [Display(Name = "Recognized original stimulus among four options?")]
        [RequiredIfRange(nameof(UDSBENTD), 0, 17, ErrorMessage = "Was the original stimulus recognized among four options?")]
        public int? UDSBENRS { get; set; }

        #endregion

        #region if test not completed, skip to question 12a

        [Display(Name = "Total score", Description = "(0-32, 95-98)")]
        [RegularExpression("^(\\d|[12]\\d|3[0-2]|9[5-8])$", ErrorMessage = "Allowed values are 0-32 or 95-98.")]
        [RequiredOnComplete]
        public int? MINTTOTS { get; set; }

        [Display(Name = "Total correct without semantic cue", Description = "(0-32)")]
        [Range(0, 32, ErrorMessage = "Allowed values are 0-32.")]
        [RequiredIfRange(nameof(MINTTOTS), 0, 32, ErrorMessage = "Provide total count without semantic cue.")]
        public int? MINTTOTW { get; set; }

        [Display(Name = "Semantic cues: Number given", Description = "(0-32)")]
        [Range(0, 32, ErrorMessage = "Allowed values are 0-32.")]
        [RequiredIfRange(nameof(MINTTOTS), 0, 32, ErrorMessage = "Provide semantic number given.")]
        public int? MINTSCNG { get; set; }

        [Display(Name = "Semantic cues: Number correct with cue", Description = "(0-32, 88 = not applicable)")]
        [RegularExpression("^(\\d|[12]\\d|3[0-2]|88)$", ErrorMessage = "Allowed values are 0-32 or 88 = not applicable.")]
        [RequiredIfRange(nameof(MINTTOTS), 0, 32, ErrorMessage = "Provide semantic number correct with cue.")]
        public int? MINTSCNC { get; set; }

        [Display(Name = "Phonemic cues: Number given", Description = "(0-32)")]
        [Range(0, 32, ErrorMessage = "Allowed values are 0-32.")]
        [RequiredIfRange(nameof(MINTTOTS), 0, 32, ErrorMessage = "Provide phonemic number given.")]
        public int? MINTPCNG { get; set; }

        [Display(Name = "Phonemic cues: Number correct with cue", Description = "(0-32, 88 = not applicable)")]
        [RegularExpression("^(\\d|[12]\\d|3[0-2]|88)$", ErrorMessage = "Allowed values are 0-32 or 88 = not applicable.")]
        [RequiredIfRange(nameof(MINTTOTS), 0, 32, ErrorMessage = "Provide phonemic number correct with cue.")]
        public int? MINTPCNC { get; set; }

        #endregion

        #region if not completed, skip to question 12d

        [Display(Name = "Number of correct F-words generated in 1 minute", Description = "(0-40, 95-98)")]
        [RegularExpression("^(\\d|[1-3]\\d|40|9[5-8])$", ErrorMessage = "Allowed values are 0-40 or 95-98.")]
        [RequiredOnComplete]
        public int? UDSVERFC { get; set; }

        [Display(Name = "Number of correct F-words repeated in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "Allowed values are 0-15.")]
        [RequiredIfRange(nameof(UDSVERFC), 0, 40, ErrorMessage = "Provide count of F-words repeated.")]
        public int? UDSVERFN { get; set; }

        [Display(Name = "Number of non-F-words and rule violation errors in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "Allowed values are 0-15.")]
        [RequiredIfRange(nameof(UDSVERFC), 0, 40, ErrorMessage = "Provide count of non-F-words and rule violation errors.")]
        public int? UDSVERNF { get; set; }

        #endregion

        #region If not completed, skip to question 13a

        [Display(Name = "Number of correct L-words generated in 1 minute", Description = "(0-40, 95-98)")]
        [RegularExpression("^(\\d|[1-3]\\d|40|9[5-8])$", ErrorMessage = "Allowed values are 0-40 or 95-98.")]
        [RequiredOnComplete]
        public int? UDSVERLC { get; set; }

        [Display(Name = "Number of L-words repeated in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "Allowed values are 0-15.")]
        [RequiredIfRange(nameof(UDSVERLC), 0, 40, ErrorMessage = "Provide count of L-words repeated.")]
        public int? UDSVERLR { get; set; }

        [Display(Name = "Number of non-L-words and rule violation errors in 1 minute", Description = "(0-15)")]
        [Range(0, 15, ErrorMessage = "Allowed values are 0-15.")]
        [RequiredIfRange(nameof(UDSVERLC), 0, 40, ErrorMessage = "Provide count of non-L-words and rule violation errors.")]
        public int? UDSVERLN { get; set; }

        [Display(Name = "TOTAL number of correct F-words and L-words", Description = "(0-80)")]
        [Range(0, 80, ErrorMessage = "Allowed values are 0-80.")]
        [RequiredIfRange(nameof(UDSVERLC), 0, 40, ErrorMessage = "Provide count of correct F-words and L-words.")]
        public int? UDSVERTN { get; set; }

        [Display(Name = "TOTAL number of F-word and L-word repetition errors", Description = "(0-30)")]
        [Range(0, 30, ErrorMessage = "Allowed values are 0-30.")]
        [RequiredIfRange(nameof(UDSVERLC), 0, 40, ErrorMessage = "Provide count of F-word and L-word repetition errors.")]
        public int? UDSVERTE { get; set; }

        [Display(Name = "TOTAL number of non-F/L words and rule violation errors", Description = "(0-30)")]
        [Range(0, 30, ErrorMessage = "Allowed values are 0-30.")]
        [RequiredIfRange(nameof(UDSVERLC), 0, 40, ErrorMessage = "Provide count of non-F/L words and rule violation errors.")]
        public int? UDSVERTI { get; set; }

        #endregion

        [Display(Name = "Per the clinician (e.g., neuropsychologist, behavioral neurologist, or other suitably qualified clinician), based on the UDS neuropsychological examination, the participants cognitive status is deemed")]
        [RequiredOnComplete]
        public int? COGSTAT { get; set; }

        [Display(Name = "What modality of communication was used to administer this neuropsychological battery?")]
        [RequiredOnComplete]
        [Range(1, 3)]
        public int? MODCOMM { get; set; }

        [Display(Name = "Trial 1 total recall")]
        [RequiredOnComplete]
        [RegularExpression("^(\\d|1[0-5]|9[5-8])$", ErrorMessage = "Allowed values are 0-15 or 95-98.")]
        public int? REY1REC { get; set; }

        [Display(Name = "Trial 1 intrusions")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? REY1INT { get; set; }

        [Display(Name = "Trial 2 total recall")]
        [RequiredOnComplete]
        [Range(0, 15)]
        public int? REY2REC { get; set; }

        [Display(Name = "Trial 2 intrusions")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? REY2INT { get; set; }

        [Display(Name = "Trial 3 total recall")]
        [RequiredOnComplete]
        [Range(0, 15)]
        public int? REY3REC { get; set; }

        [Display(Name = "Trial 3 intrusions")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? REY3INT { get; set; }

        [Display(Name = "Trial 4 total recall")]
        [RequiredOnComplete]
        [Range(0, 15)]
        public int? REY4REC { get; set; }

        [Display(Name = "Trial 4 intrusions")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? REY4INT { get; set; }

        [Display(Name = "Trial 5 total recall")]
        [RequiredOnComplete]
        [Range(0, 15)]
        public int? REY5REC { get; set; }

        [Display(Name = "Trial 5 intrusions")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? REY5INT { get; set; }

        [Display(Name = "Trial 6 total recall")]
        [RequiredOnComplete]
        [Range(0, 15)]
        public int? REY6REC { get; set; }

        [Display(Name = "Trial 6 intrusions")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? REY6INT { get; set; }

        [Display(Name = "Total number of seconds to complete")]
        [RequiredOnComplete]
        [RegularExpression("^(\\d|[1-9]\\d|100|888|99[5-8])$", ErrorMessage = "0-100, or 888 , or 995-998")]
        public int? OTRAILA { get; set; }

        [Display(Name = " Number of commission errors")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? OTRLARR { get; set; }

        [Display(Name = "Part A: Number of correct lines")]
        [RequiredOnComplete]
        [Range(0, 25)]
        public int? OTRLALI { get; set; }

        [Display(Name = "Part B: Total number of seconds to complete")]
        [RequiredOnComplete]
        [RegularExpression("^(\\d|[1-9]\\d|[12]\\d{2}|300|888|99[5-8])$", ErrorMessage = "0-300, or 888 , or 995-998")]
        public int? OTRAILB { get; set; }

        [Display(Name = "Part B: Number of commission errors")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? OTRLBRR { get; set; }

        [Display(Name = "Part B: Number of correct lines")]
        [RequiredOnComplete]
        [Range(0, 25)]
        public int? OTRLBLI { get; set; }

        [Display(Name = "total delayed recall")]
        [RequiredOnComplete]
        [RegularExpression("^(\\d|1[0-5]|9[5-8])$", ErrorMessage = "Allowed values are 0-15 or 95-98.")]
        public int? REYDREC { get; set; }

        [Display(Name = "delayed intrusions")]
        [RequiredOnComplete]
        [Range(0, 99)]
        public int? REYDINT { get; set; }

        [Display(Name = "recognition total correct")]
        [RequiredOnComplete]
        [Range(0, 15)]
        public int? REYTCOR { get; set; }

        [Display(Name = "recognition total false positives")]
        [RequiredOnComplete]
        [Range(0, 15)]
        public int? REYFPOS { get; set; }

        [Display(Name = "total correct without a cue")]
        [RequiredOnComplete]
        [RegularExpression("^(\\d|[1-4]\\d|50|88|9[5-8])$", ErrorMessage = "Allowed values are 0-50 0r 88 or 95-98.")]
        public int? VNTTOTW { get; set; }

        [Display(Name = "total correct with a phonemic cue")]
        [RequiredOnComplete]
        [RegularExpression("^(\\d|[1-4]\\d|50|88|9[5-8])$", ErrorMessage = "Allowed values are 0-50 0r 88 or 95-98.")]
        public int? VNTPCNC { get; set; }

        [Display(Name = "How valid do you think the participant’s responses are?")]
        [RequiredOnComplete]
        [Range(1, 3)]
        public int? RESPVAL { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Hearing impairment")]
        [RequiredOnComplete]
        public bool? RESPHEAR { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Distractions")]
        [RequiredOnComplete]
        public bool? RESPDIST { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Interruptions")]
        [RequiredOnComplete]
        public bool? RESPINTR { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Lack of effort or disinterest")]
        [RequiredOnComplete]
        public bool? RESPDISN { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Fatigue")]
        [RequiredOnComplete]
        public bool? RESPFATG { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Emotional issues")]
        [RequiredOnComplete]
        public bool? RESPEMOT { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Unapproved assistance")]
        [RequiredOnComplete]
        public bool? RESPASST { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Other (specify)")]
        [RequiredOnComplete]
        public bool? RESPOTH { get; set; }

        [Display(Name = "What makes this participant’s responses less valid? Other reason")]
        [RequiredOnComplete]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public int? RESPOTHX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == Services.Enums.FormStatus.Complete)
            {
                // 1g-1l, 1n-1t, or 1w-1bb
                if (MOCATOTS.HasValue && MOCATRAI.HasValue && MOCACUBE.HasValue &&
                    MOCACLOC.HasValue && MOCACLON.HasValue && MOCACLOH.HasValue &&
                    MOCANAMI.HasValue && MOCADIGI.HasValue && MOCALETT.HasValue &&
                    MOCASER7.HasValue && MOCAREPE.HasValue && MOCAFLUE.HasValue &&
                    MOCAABST.HasValue && MOCARECN.HasValue && MOCAORDT.HasValue &&
                    MOCAORMO.HasValue && MOCAORYR.HasValue && MOCAORDY.HasValue &&
                    MOCAORPL.HasValue && MOCAORCT.HasValue)
                {
                    if (MOCATRAI.Value >= 95 && MOCACUBE.Value >= 95 &&
                    MOCACLOC.Value >= 95 && MOCACLON.Value >= 95 && MOCACLOH.Value >= 95 &&
                    MOCANAMI.Value >= 95 && MOCADIGI.Value >= 95 && MOCAFLUE.Value >= 95 &&
                    MOCAABST.Value >= 95 && MOCARECN.Value >= 95 && MOCAORDT.Value >= 95 &&
                    MOCAORMO.Value >= 95 && MOCAORYR.Value >= 95 && MOCAORDY.Value >= 95 &&
                    MOCAORPL.Value >= 95 && MOCAORCT.Value >= 95)
                    {
                        if (MOCATOTS.Value != 88)
                        {
                            yield return new ValidationResult("If 1g-1l, 1n-1t, or 1w-1bb were not administered then MOCATOTS must be 88.", new[] { nameof(MOCATOTS) });
                        }
                    }
                }

                // 1t, 1u, 1v
                // Page 8: https://files.alz.washington.edu/documentation/uds3-np-c2-instructions.pdf
                if (MOCARECN.HasValue && MOCARECC.HasValue && MOCARECR.HasValue &&
                    MOCARECN.Value < 95)
                {
                    int count = MOCARECN.Value;
                    if (MOCARECC.Value != 88)
                        count += MOCARECC.Value;
                    if (MOCARECR.Value != 88)
                        count += MOCARECR.Value;

                    if (count > 5)
                    {
                        yield return new ValidationResult("The total possible words recalled and entered in Questions 1t, 1u, and 1v should be 5 or less.", new[] { nameof(MOCARECN) });
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
}
