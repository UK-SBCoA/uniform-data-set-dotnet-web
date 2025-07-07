using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class C2 : FormModel
    {
        [Display(Name = "Was any part of MoCA administered?")]
        [RequiredOnFinalized]
        public int? MOCACOMP { get; set; }

        [Display(Name = "If No, enter reason code, 95–98")]
        [Range(95, 98)]
        [RequiredIf(nameof(MOCACOMP), "0", ErrorMessage = "Provide reason code.")]
        public int? MOCAREAS { get; set; }

        [Display(Name = "MoCA was administered")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Which MoCA was administered?")]
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
        public int? MOCAVIS { get; set; }

        [Display(Name = "Subject was unable to complete one or more sections due to hearing impairment")]
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Was the MoCA affected by hearing impairment?")]
        public int? MOCAHEAR { get; set; }

        [Display(Name = "Total Raw Score - Uncorrected", Description = "(0-30,88)")]
        [RegularExpression("^(\\d|[0-2]\\d|30|88)$", ErrorMessage = "Allowed values are 0-30 or 88 = not administered.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCATOTS { get; set; }

        [Display(Name = "Total Raw Score - Uncorrected", Description = "(0-22,88)")]
        [RegularExpression("^(\\d|1\\d|2[0-2]|88)$", ErrorMessage = "Allowed values are 0-22 or 88 = not administered.")]
        [RequiredIfTelephoneVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCBTOTS { get; set; }

        [Display(Name = "Visuospatial/executive — Trails", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCATRAI { get; set; }

        [Display(Name = " Visuospatial/executive — Cube", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCACUBE { get; set; }

        [Display(Name = "Visuospatial/executive — Clock contour", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCACLOC { get; set; }

        [Display(Name = "Visuospatial/executive — Clock numbers", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCACLON { get; set; }

        [Display(Name = "Visuospatial/executive — Clock hands", Description = "(0-1, 95-98)")]
        [RegularExpression("^([0-1]|9[5-8])$", ErrorMessage = "Allowed values are 0-1 or 95-98.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCACLOH { get; set; }

        [Display(Name = "Language — Naming", Description = "(0-3, 95-98)")]
        [RegularExpression("^([0-3]|9[5-8])$", ErrorMessage = "Allowed values are 0-3 or 95-98.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
        public int? MOCANAMI { get; set; }

        [Display(Name = "Memory — Registration (two trials)", Description = "(0-10, 95-98)")]
        [RegularExpression("^(\\d|10|9[5-8])$", ErrorMessage = "Allowed values are 0-10 or 95-98.")]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
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
        [RequiredIf(nameof(MOCACOMP), "1", ErrorMessage = "Response required")]
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
        public int? NPSYCLOC { get; set; }

        [Display(Name = "Language of test administration")]
        [RequiredOnFinalized]
        public int? NPSYLAN { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(NPSYLAN), "3", ErrorMessage = "Specify other language used")]
        [ProhibitedCharacters]
        public string? NPSYLANX { get; set; }

        #region if not completed, skip to question  4a

        [Display(Name = "Total story units recalled, verbatim scoring", Description = "(0-44, 95-98)")]
        [RegularExpression("^([0-9]|[1-3][0-9]|4[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-44 or 95-98.")]
        [RequiredOnFinalized]
        public int? CRAFTVRS { get; set; }

        [Display(Name = "Total story units recalled, paraphrase scoring", Description = "(0-25)")]
        [Range(0, 25, ErrorMessage = "Allowed values are 0-25.")]
        [RequiredIfRange(nameof(CRAFTVRS), 0, 44, ErrorMessage = "Provide total story units recalled, paraphrase scoring.")]
        public int? CRAFTURS { get; set; }

        #endregion

        [Display(Name = "Total Score for copy of Benson figure", Description = "(0-17, 95-98)")]
        [RegularExpression("^(\\d|1[0-7]|9[5-8])$", ErrorMessage = "Allowed values are 0-17 or 95-98.")]
        public int? UDSBENTC { get; set; }

        #region if not completed, skip to  6a

        [Display(Name = "Number of correct trials", Description = "(0-14, 95-98)")]
        [RegularExpression("^(\\d|1[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-14 or 95-98.")]
        [RequiredOnFinalized]
        public int? DIGFORCT { get; set; }

        [Display(Name = "Longest span forward", Description = "(0, 3-9)")]
        [RegularExpression("^(0|[3-9])$", ErrorMessage = "Allowed values are 0 or 3-9.")]
        [RequiredIfRange(nameof(DIGFORCT), 0, 14, ErrorMessage = "Provide longest span forward.")]
        public int? DIGFORSL { get; set; }

        #endregion

        #region if not completed, skip to question 7a

        [Display(Name = "Number of correct trials", Description = "(0-14, 95-98)")]
        [RegularExpression("^(\\d|1[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-14 or 95-98.")]
        [RequiredOnFinalized]
        public int? DIGBACCT { get; set; }

        [Display(Name = "Longest span backward", Description = "(0, 2-8)")]
        [RegularExpression("^(0|[2-8])$", ErrorMessage = "Allowed values are 0 or 2-8.")]
        [RequiredIfRange(nameof(DIGBACCT), 0, 14, ErrorMessage = "Provide longest span backward.")]
        public int? DIGBACLS { get; set; }

        #endregion

        [Display(Name = "Animals: Total number of animals named in 60 seconds", Description = "(0-77, 95-98)")]
        [RegularExpression("^(\\d|[1-6]\\d|7[0-7]|9[5-8])$", ErrorMessage = "Allowed values are 0-77 or 95-98.")]
        [RequiredOnFinalized]
        public int? ANIMALS { get; set; }

        [Display(Name = "Vegetables: Total number of vegtables named in 60 seconds", Description = "(0-77, 95-98)")]
        [RegularExpression("^(\\d|[1-6]\\d|7[0-7]|9[5-8])$", ErrorMessage = "Allowed values are 0-77 or 95-98.")]
        [RequiredOnFinalized]
        public int? VEG { get; set; }

        #region if not completed, skip to question 8b

        [Display(Name = "Part A: Total number of seconds to complete", Description = "(0-150, 995-998)")]
        [RegularExpression("^(\\d|[1-9]\\d|1[0-4]\\d|150|99[5-8])$", ErrorMessage = "Allowed values are 0-150 or 995-998.")]

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
        [RequiredIfRange(nameof(TRAILB), 0, 300, ErrorMessage = "Provide commission errors")]
        public int? TRAILBRR { get; set; }

        [Display(Name = "Number of correct lines", Description = "(0-24)")]
        [Range(0, 24, ErrorMessage = "Allowed values are 0-24.")]
        [RequiredIfRange(nameof(TRAILB), 0, 300, ErrorMessage = "Provide correct lines")]
        public int? TRAILBLI { get; set; }

        #endregion

        #region if not completed, skip to question 10a

        [Display(Name = "Total story units recalled, verbatim scoring", Description = "(0-44, 95-98)")]
        [RegularExpression("^(\\d|[1-3]\\d|4[0-4]|9[5-8])$", ErrorMessage = "Allowed values are 0-44 or 95-98.")]
        [RequiredOnFinalized]
        public int? CRAFTDVR { get; set; }

        [Display(Name = "Total story units recalled, paraphrase scoring", Description = "(0-25)")]
        [Range(0, 25, ErrorMessage = "Allowed values are 0-25.")]
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
        public int? UDSBENTD { get; set; }

        [Display(Name = "Recognized original stimulus among four options?")]
        [RequiredIfRange(nameof(UDSBENTD), 0, 17, ErrorMessage = "Was the original stimulus recognized among four options?")]
        public int? UDSBENRS { get; set; }

        #endregion

        #region if test not completed, skip to question 12a

        [Display(Name = "Which verbal learning test was administered?")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? VERBALTEST { get; set; }

        [Display(Name = "Total score", Description = "(0-32, 95-98)")]
        [RegularExpression("^(\\d|[12]\\d|3[0-2]|9[5-8])$", ErrorMessage = "Allowed values are 0-32 or 95-98.")]
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

        [NotMapped]
        [RequiredIfRange(nameof(MINTTOTS), 0, 32, ErrorMessage = "If MINTSCNG (mint number semantic cues given) is > 0 then MINTSCNC (mint correct with semantic cue) must be less than or equal to MINTSCNG (mint number semantic cues given")]
        public bool? MINTSCNCValidation
        {
            get
            {
                if (RMMODE != RemoteModality.Telephone)
                {
                    if (MINTSCNG.HasValue && MINTSCNC.HasValue)
                    {
                        if (MINTSCNC.Value != 88 && MINTSCNC.Value > MINTSCNG.Value)
                        {
                            return null;
                        }
                    }
                }

                return true;
            }
        }

        [NotMapped]
        [RequiredOnFinalized(ErrorMessage = "If MINTTOTS is between 0 and 32 and MINTSCNC is between 0 and 32, then MINTTOTS must = MINTTOTW + MINTSCNC")]
        public bool? MINTTOTSValidation
        {
            get
            {
                if (MODE == FormMode.InPerson || (MODE == FormMode.Remote && RMMODE == RemoteModality.Video))
                {
                    if (MINTSCNC.HasValue && MINTTOTS.HasValue && MINTTOTW.HasValue)
                    {
                        //If MINTTOTS is is not 95 - 98 and MINTSCNC is not 88
                        if (MINTTOTS.Value <= 32 && MINTSCNC.Value <= 32)
                        {
                            int total = MINTTOTW.Value + MINTSCNC.Value;

                            if (total != MINTTOTS.Value)
                            {
                                return null;
                            }
                        }
                    }
                }

                return true;
            }
        }


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
        [RequiredOnFinalized]
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
        [RequiredOnFinalized]
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
        [RequiredOnFinalized]
        public int? COGSTAT { get; set; }

        [Display(Name = "Total recall", Description = "(0-15,95-98)")]
        [RegularExpression("^(\\d|1[0-5]|9[5-8])$", ErrorMessage = "Allowed values are 0-15 or 95-98.")]
        [RequiredIf(nameof(VERBALTEST), "1", ErrorMessage = "Required if Rey AVLT was administered")]
        public int? REY1REC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 1 intrusions.")]
        public int? REY1INT { get; set; }

        [Display(Name = "Total recall", Description = "(0-15)")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 2 total recall.")]
        public int? REY2REC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 2 intrusions.")]
        public int? REY2INT { get; set; }

        [Display(Name = "Total recall", Description = "(0-15)")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 3 total recall.")]
        public int? REY3REC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 3 instrusions.")]
        public int? REY3INT { get; set; }

        [Display(Name = "Total recall", Description = "(0-15)")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 4 total recall.")]
        public int? REY4REC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 4 intrusions.")]
        public int? REY4INT { get; set; }

        [Display(Name = "Total recall", Description = "(0-15)")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 5 total recall.")]
        public int? REY5REC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 5 intrusions.")]
        public int? REY5INT { get; set; }

        [Display(Name = "Total recall", Description = "(0-15")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide list B recall.")]
        public int? REYBREC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide list B intrusions.")]
        public int? REYBINT { get; set; }

        [Display(Name = "Total recall", Description = "(0-15)")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 6 total recall.")]
        public int? REY6REC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide trial 6 intrusions.")]
        public int? REY6INT { get; set; }

        [Display(Name = "Total delayed recall", Description = "(0-15, 95-98)")]
        [RegularExpression("^(\\d|1[0-5]|9[5-8])$", ErrorMessage = "Allowed values are 0-15 or 95-98.")]
        [RequiredIfRange(nameof(REY1REC), 0, 15, ErrorMessage = "Provide total delayed recall.")]
        public int? REYDREC { get; set; }

        [Display(Name = "Intrusions", Description = "(No limit)")]
        [Range(0, 99)]
        [RequiredIfRange(nameof(REYDREC), 0, 15, ErrorMessage = "Provide total intrusions.")]
        public int? REYDINT { get; set; }

        [Display(Name = "Delay time (minutes)", Description = "(0-85, 99)")]
        [RequiredIfRange(nameof(REYDREC), 0, 15, ErrorMessage = "Provide delay time.")]
        public int? REYDTI { get; set; }

        // Custom validation - REYMETHODValidation(): value required on complete on the C2 when REDREC >= 0 and <=15
        [Display(Name = "Method of recognition test administration")]
        public int? REYMETHOD { get; set; }

        [Display(Name = "Recognition - Total correct", Description = "(0-15)")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REYDREC), 0, 15, ErrorMessage = "Provide total correct recognitions.")]
        public int? REYTCOR { get; set; }

        [Display(Name = "Recognition - Total false positives", Description = "(0-15)")]
        [Range(0, 15)]
        [RequiredIfRange(nameof(REYDREC), 0, 15, ErrorMessage = "Provide total false positives.")]
        public int? REYFPOS { get; set; }

        [Display(Name = "Total recall", Description = "(0-10,95-98)")]
        [RequiredIf(nameof(VERBALTEST), "2", ErrorMessage = "Response required if question VERBALTEST equals 2")]
        [RegularExpression("^(\\d|10|9[5-8])$", ErrorMessage = "Allowed values are 0-10 or 95-98.")]
        public int? CERAD1REC { get; set; }

        [Display(Name = "Can't read", Description = "(0-10)")]
        [RegularExpression("^(10|[0-9])$", ErrorMessage = "Allowed values are 0-10.")]
        public int? CERAD1READ { get; set; }

        [Display(Name = "Intrusions", Description = "(0-99)")]
        [RegularExpression("^([0-9]|[1-9][0-9]|99)$", ErrorMessage = "Allowed values are 0-99.")]
        [RequiredIfRange(nameof(CERAD1REC), 0, 10, ErrorMessage = "Response required.")]
        public int? CERAD1INT { get; set; }

        [Display(Name = "Total recall", Description = "(0-10)")]
        [RegularExpression("^(10|[0-9])$", ErrorMessage = "Allowed values are 0-10.")]
        [RequiredIfRange(nameof(CERAD1REC), 0, 10, ErrorMessage = "Response required.")]
        public int? CERAD2REC { get; set; }

        [Display(Name = "Can't read", Description = "(0-10)")]
        [RegularExpression("^(10|[0-9])$", ErrorMessage = "Allowed values are 0-10.")]
        public int? CERAD2READ { get; set; }

        [Display(Name = "Intrusions", Description = "(0-99)")]
        [RegularExpression("^([0-9]|[1-9][0-9]|99)$", ErrorMessage = "Allowed values are 0-99.")]
        [RequiredIfRange(nameof(CERAD1REC), 0, 10, ErrorMessage = "Response required.")]
        public int? CERAD2INT { get; set; }

        [Display(Name = "Total recall", Description = "(0-10)")]
        [RegularExpression("^(10|[0-9])$", ErrorMessage = "Allowed values are 0-10.")]
        [RequiredIfRange(nameof(CERAD1REC), 0, 10, ErrorMessage = "Response required.")]
        public int? CERAD3REC { get; set; }

        [Display(Name = "Can't read", Description = "(0-10)")]
        [RegularExpression("^(10|[0-9])$", ErrorMessage = "Allowed values are 0-10.")]
        public int? CERAD3READ { get; set; }

        [Display(Name = "Intrusions", Description = "(0-99)")]
        [RegularExpression("^([0-9]|[1-9][0-9]|99)$", ErrorMessage = "Allowed values are 0-99.")]
        [RequiredIfRange(nameof(CERAD1REC), 0, 10, ErrorMessage = "Response required.")]
        public int? CERAD3INT { get; set; }

        [Display(Name = "Delay time (minutes)", Description = "(0-85,99)")]
        [RegularExpression("^(\\d|[1-7]\\d|8[0-5]|99)$", ErrorMessage = "Allowed values are 0-85 or 99 = unknown.")]
        [RequiredIfRange(nameof(CERAD1REC), 0, 10, ErrorMessage = "Response required")]
        public int? CERADDTI { get; set; }

        [Display(Name = "J6 Word List Recall: Total number of words correctly recalled", Description = "(0-10,95-98)")]
        [RegularExpression("^(\\d|10|9[5-8])$", ErrorMessage = "Allowed values are 0-10 or 95-98.")]
        [RequiredIfRange(nameof(CERAD1REC), 0, 10, ErrorMessage = "Response required")]
        public int? CERADJ6REC { get; set; }

        [Display(Name = "J6 Word List Recall: Total number of intrusions", Description = "(0-99)")]
        [RegularExpression("^([0-9]|[1-9][0-9]|99)$", ErrorMessage = "Allowed values are 0-99.")]
        [RequiredIfRange(nameof(CERADJ6REC), 0, 10, ErrorMessage = "Response required")]
        public int? CERADJ6INT { get; set; }

        [Display(Name = "J7 Word List Recognition: Total YES correct", Description = "(0-10,95-98)")]
        [RegularExpression("^(\\d|10|9[5-8])$", ErrorMessage = "Allowed values are 0-10 or 95-98.")]
        public int? CERADJ7YES { get; set; }

        [Display(Name = "J7 Word List Recognition: Total NO correct", Description = "(0-10,95-98)")]
        [RegularExpression("^(\\d|10|9[5-8])$", ErrorMessage = "Allowed values are 0-10 or 95-98.")]
        public int? CERADJ7NO { get; set; }

        [Display(Name = "Part A: Total number of seconds to complete", Description = "(0-100, 888, 995-998)")]
        [RegularExpression("^(\\d{1,2}|100|888|99[5-8])$", ErrorMessage = "Allowed values are 0-100, 888, or 995-998.")]
        [RequiredIf(nameof(RMMODE), "Telephone")]
        public int? OTRAILA { get; set; }

        [Display(Name = "Part A - Number of commission errors", Description = "(0-99)")]
        [RegularExpression("^\\d{1,2}$", ErrorMessage = "Allowed values are 0-99.")]
        [RequiredIfRange(nameof(OTRAILA), 0, 100, ErrorMessage = "Response Required")]
        public int? OTRLARR { get; set; }

        [Display(Name = "Part A - Number of correct lines", Description = "(0-25)")]
        [RegularExpression("^(\\d|1\\d|2[0-5])$", ErrorMessage = "Allowed values are 0-25.")]
        [RequiredIfRange(nameof(OTRAILA), 0, 100, ErrorMessage = "Response Required")]
        public int? OTRLALI { get; set; }

        [Display(Name = "Part B: Total number of seconds to complete", Description = "(0-300, 888, 995-998)")]
        [RegularExpression("^([0-9]|[1-9][0-9]|[12][0-9][0-9]|300|888|99[5-8])$", ErrorMessage = "Allowed values are 0-300, 888, or 995-998.")]
        [RequiredIf(nameof(RMMODE), "Telephone")]
        public int? OTRAILB { get; set; }

        [Display(Name = "Part B - Number of commission errors", Description = "(0-99)")]
        [RegularExpression("^\\d{1,2}$", ErrorMessage = "Allowed values are 0-99.")]
        [RequiredIfRange(nameof(OTRAILB), 0, 300, ErrorMessage = "Response Required")]
        public int? OTRLBRR { get; set; }

        [Display(Name = "Number of correct lines", Description = "(0-25)")]
        [RegularExpression("^(\\d|1\\d|2[0-5])$", ErrorMessage = "Allowed values are 0-25.")]
        [RequiredIfRange(nameof(OTRAILB), 0, 300, ErrorMessage = "Response Required")]
        public int? OTRLBLI { get; set; }


        [Display(Name = "Total correct without a cue", Description = "(0-50, 88, 95-98)")]
        [RegularExpression("^(\\d|[1-4]\\d|50|88|9[5-8])$", ErrorMessage = "Allowed values are 0-50, 88 or 95-98.")]
        [RequiredIf(nameof(RMMODE), "Telephone")]
        public int? VNTTOTW { get; set; }

        [Display(Name = "Total correct with a phonemic cue", Description = "(0-50, 88, 95-98)")]
        [RegularExpression("^(\\d|[1-4]\\d|50|88|9[5-8])$", ErrorMessage = "Allowed values are 0-50, 88 or 95-98.")]
        [RequiredIf(nameof(RMMODE), "Telephone")]
        public int? VNTPCNC { get; set; }

        [Display(Name = "How valid do you think the participant’s responses are?")]
        [Range(1, 3)]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? RESPVAL { get; set; }

        [Display(Name = "Hearing impairment")]
        public bool RESPHEAR { get; set; }

        [Display(Name = "Distractions")]
        public bool RESPDIST { get; set; }

        [Display(Name = "Interruptions")]
        public bool RESPINTR { get; set; }

        [Display(Name = "Lack of effort or disinterest")]
        public bool RESPDISN { get; set; }

        [Display(Name = "Fatigue")]
        public bool RESPFATG { get; set; }

        [Display(Name = "Emotional issues")]
        public bool RESPEMOT { get; set; }

        [Display(Name = "Unapproved assistance")]
        public bool RESPASST { get; set; }

        [Display(Name = "Other (specify)")]
        public bool RESPOTH { get; set; }

        [Display(Name = "Specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(RESPOTH), "True", ErrorMessage = "Please specify.")]
        [ProhibitedCharacters]
        public string? RESPOTHX { get; set; }

        [RequiredIfRange(nameof(RESPVAL), 2, 3, ErrorMessage = "Select at least one reason why the participant's response is less valid.")]
        [NotMapped]
        public bool? RESPVALReasonIndicated
        {
            get
            {
                if (RESPHEAR || RESPDIST || RESPINTR || RESPDISN || RESPFATG || RESPEMOT || RESPASST || RESPOTH)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredOnFinalized(ErrorMessage = "For Delayed recall questions: 'No cue', 'Category cue', and 'Recognition' the sum of questions with a value of 0 - 5 should be less than or equal to 5")]
        [NotMapped]
        public bool? DelayedRecallValidSum
        {
            get
            {
                int? mocarecnValue = 0;
                int? mocareccValue = 0;
                int? mocarecrValue = 0;

                //if input is an exception value (93 - 95 or 88) then calculate as 0 in total
                if (MOCARECN != null)
                {
                    mocarecnValue = MOCARECN >= 95 ? 0 : MOCARECN;
                }

                if (MOCARECC != null)
                {
                    mocareccValue = MOCARECC == 88 ? 0 : MOCARECC;
                }

                if (MOCARECR != null)
                {
                    mocarecrValue = MOCARECR == 88 ? 0 : MOCARECR;
                }

                if (mocarecnValue + mocareccValue + mocarecrValue > 5) return null;

                return true;
            }
        }

        [RequiredOnFinalized(ErrorMessage = "If Delayed recall - No cue is equal to 5, then Delayed recall - Category cue and Delayed recall - Recognition should both be 88")]
        [NotMapped]
        public bool? MOCARECRAndMOCARECCValidValues
        {
            get
            {
                if (MOCARECN == 5)
                {
                    if (MOCARECC != 88 || MOCARECR != 88) return null;
                }

                return true;
            }
        }

        [RequiredOnFinalized(ErrorMessage = "If the sum of Delayed recall - No cue and Delayed recall - Category are equal to 5, then Delayed recall - Recognition should be 88")]
        [NotMapped]
        public bool? MOCARECRValidValue
        {
            get
            {
                if (MOCARECN + MOCARECC == 5)
                {
                    if (MOCARECR != 88) return null;
                }

                return true;
            }
        }

        // validate CERAD1READ, CERAD2READ, and CERAD3READ in C2 (InPerson and Video modalities) for value when CERAD1REC is 0 - 10
        [NotMapped]
        [RequiredOnFinalized(ErrorMessage = "Values required if trial 1 total recall is 0 - 10 for in-person and remote video modalities")]
        public bool? CERADREADValidation
        {
            get
            {
                if (MODE == FormMode.InPerson || RMMODE == RemoteModality.Video)
                {
                    if (CERAD1REC >= 0 && CERAD1REC <= 10)
                    {
                        return CERAD1READ.HasValue && CERAD2READ.HasValue && CERAD3READ.HasValue ? true : null;
                    }
                }

                return true;
            }
        }

        // validate REYMETHOD in C2 (InPerson and Video modalities) for value when REDREC >= 0 and <=15 
        [NotMapped]
        [RequiredOnFinalized(ErrorMessage = "Value required if total delayed recall is 0 - 15 for in-person and remote video modalities")]
        public bool? REYMETHODValidation
        {
            get
            {
                if (MODE == FormMode.InPerson || RMMODE == RemoteModality.Video)
                {
                    if (REYDREC >= 0 && REYDREC <= 15)
                    {
                        return REYMETHOD.HasValue ? true : null;
                    }
                }

                return true;
            }
        }

        // If REY1REC is 95 - 98 for in person and video modalities, then REYDREC must have a value
        [NotMapped]
        [RequiredOnFinalized(ErrorMessage = "A value of 95 - 98 is required for 13a. Total delayed recall when 12a. is 95 - 98")]
        public bool? REYDRECValidation
        {
            get
            {
                if (MODE == FormMode.InPerson || RMMODE == RemoteModality.Video)
                {
                    if (REY1REC.HasValue && (REY1REC.Value >= 95 && REY1REC.Value <= 98))
                    {
                        return REYDREC.HasValue && (REYDREC.Value >= 95 && REYDREC.Value <= 98) ? true : null;
                    }
                }

                return true;
            }
        }

        //MOCATOTS = sum of 1g-1l, 1n-1t, and 1w-1bb when all these sub questions are < 95
        [NotMapped]
        [RequiredIfInPersonVisit(nameof(MOCACOMP), "1", ErrorMessage = "If questions 1g-1l, 1n-1t, and 1w-1bb are all completed, the Total Raw Score - Uncorrected needs to be the sum of these answers.")]
        public bool? MOCATOTSSumValidation
        {
            get
            {
                if (MOCATOTS.HasValue && MOCATOTS != 88)
                {
                    int questionsSum = 0;
                    int questionsCount = 0;

                    if (MODE == FormMode.InPerson || RMMODE == RemoteModality.Video)
                    {
                        if (MOCATRAI.HasValue && MOCATRAI.Value < 95) { questionsCount++; questionsSum += MOCATRAI.Value; }
                        if (MOCACUBE.HasValue && MOCACUBE.Value < 95) { questionsCount++; questionsSum += MOCACUBE.Value; }
                        if (MOCACLOC.HasValue && MOCACLOC.Value < 95) { questionsCount++; questionsSum += MOCACLOC.Value; }
                        if (MOCACLON.HasValue && MOCACLON.Value < 95) { questionsCount++; questionsSum += MOCACLON.Value; }
                        if (MOCACLOH.HasValue && MOCACLOH.Value < 95) { questionsCount++; questionsSum += MOCACLOH.Value; }
                        if (MOCANAMI.HasValue && MOCANAMI.Value < 95) { questionsCount++; questionsSum += MOCANAMI.Value; }
                        if (MOCADIGI.HasValue && MOCADIGI.Value < 95) { questionsCount++; questionsSum += MOCADIGI.Value; }
                        if (MOCALETT.HasValue && MOCALETT.Value < 95) { questionsCount++; questionsSum += MOCALETT.Value; }
                        if (MOCASER7.HasValue && MOCASER7.Value < 95) { questionsCount++; questionsSum += MOCASER7.Value; }
                        if (MOCAREPE.HasValue && MOCAREPE.Value < 95) { questionsCount++; questionsSum += MOCAREPE.Value; }
                        if (MOCAFLUE.HasValue && MOCAFLUE.Value < 95) { questionsCount++; questionsSum += MOCAFLUE.Value; }
                        if (MOCAABST.HasValue && MOCAABST.Value < 95) { questionsCount++; questionsSum += MOCAABST.Value; }
                        if (MOCARECN.HasValue && MOCARECN.Value < 95) { questionsCount++; questionsSum += MOCARECN.Value; }
                        if (MOCAORDT.HasValue && MOCAORDT.Value < 95) { questionsCount++; questionsSum += MOCAORDT.Value; }
                        if (MOCAORMO.HasValue && MOCAORMO.Value < 95) { questionsCount++; questionsSum += MOCAORMO.Value; }
                        if (MOCAORYR.HasValue && MOCAORYR.Value < 95) { questionsCount++; questionsSum += MOCAORYR.Value; }
                        if (MOCAORDY.HasValue && MOCAORDY.Value < 95) { questionsCount++; questionsSum += MOCAORDY.Value; }
                        if (MOCAORPL.HasValue && MOCAORPL.Value < 95) { questionsCount++; questionsSum += MOCAORPL.Value; }
                        if (MOCAORCT.HasValue && MOCAORCT.Value < 95) { questionsCount++; questionsSum += MOCAORCT.Value; }
                    }

                    //number of sub questions
                    if (questionsCount == 19)
                    {
                        return MOCATOTS.Value == questionsSum ? true : null;
                    }
                }

                return true;
            }
        }

        [NotMapped]
        [RequiredIfRange(nameof(UDSVERTE), 0, 30, ErrorMessage = "If UDSVERFN (f-words repeated) is between 0 and 15 and UDSVERLR (l-words repeated) is between 0 and 15, then UDSVERTE must be the total of UDSVERFN and UDSVERLR")]
        public bool? UDSVERTEValidation
        {
            get
            {
                if (UDSVERFN.HasValue && UDSVERLR.HasValue)
                {
                    if (UDSVERTE.HasValue && UDSVERTE.Value != UDSVERFN.Value + UDSVERLR.Value)
                    {
                        return null;
                    }
                }

                return true;
            }
        }

        [NotMapped]
        [RequiredIfRange(nameof(UDSVERTN), 0, 80, ErrorMessage = "If UDSVERFC not 95-98 and UDSVERLC not 95-98, UDSVERTN must be the total of UDSVERFC and UDSVERLC")]
        public bool? UDSVERTNValidation
        {
            get
            {
                if ((UDSVERFC.HasValue && UDSVERFC.Value <= 40) && (UDSVERLC.HasValue && UDSVERLC.Value <= 40))
                {
                    if (UDSVERTN.HasValue && UDSVERTN.Value != UDSVERFC.Value + UDSVERLC.Value)
                    {
                        return null;
                    }
                }

                return true;
            }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == Services.Enums.FormStatus.Finalized)
            {
                // If **any** of the following MoCA items were not administered: 1g –1l, 1n–1t, 1w–1bb, then MOCATOTS must be 88
                // 1g MOCATRAI
                // 1h MOCACUBE
                // 1i MOCACLOC
                // 1j MOCACLON
                // 1k MOCACLOH
                // 1l MOCANAMI
                //
                // 1n MOCADIGI
                // 1o MOCALETT
                // 1p MOCASER7
                // 1q MOCAREPE
                // 1r MOCAFLUE
                // 1s MOCAABST
                // 1t MOCARECN
                //
                // 1w MOCAORDT
                // 1x MOCAORMO
                // 1y MOCAORYR
                // 1z MOCAORDY
                // 1aa MOCAORPL
                // 1bb MOCAORCT
                if (MODE == FormMode.InPerson || (MODE == FormMode.Remote && RMMODE == RemoteModality.Video))
                {
                    if (MOCATOTS.HasValue &&
                        ((MOCATRAI.HasValue && MOCATRAI.Value >= 95) || (MOCACUBE.HasValue && MOCACUBE.Value >= 95) || (MOCACLOC.HasValue && MOCACLOC.Value >= 95) || (MOCACLON.HasValue && MOCACLON.Value >= 95) || (MOCACLOH.HasValue && MOCACLOH.Value >= 95) || (MOCANAMI.HasValue && MOCANAMI.Value >= 95)
                        || (MOCADIGI.HasValue && MOCADIGI.Value >= 95) || (MOCALETT.HasValue && MOCALETT.Value >= 95) || (MOCASER7.HasValue && MOCASER7.Value >= 95) || (MOCAREPE.HasValue && MOCAREPE.Value >= 95) || (MOCAFLUE.HasValue && MOCAFLUE.Value >= 95) || (MOCAABST.HasValue && MOCAABST.Value >= 95) || (MOCARECN.HasValue && MOCARECN.Value >= 95)
                        || (MOCAORDT.HasValue && MOCAORDT.Value >= 95) || (MOCAORMO.HasValue && MOCAORMO.Value >= 95) || (MOCAORYR.HasValue && MOCAORYR.Value >= 95) || (MOCAORDY.HasValue && MOCAORDY.Value >= 95) || (MOCAORPL.HasValue && MOCAORPL.Value >= 95) || (MOCAORCT.HasValue && MOCAORCT.Value >= 95)))
                    {
                        if (MOCATOTS.Value != 88)
                        {
                            yield return new ValidationResult("If 1g-1l, 1n-1t, or 1w-1bb were not administered then MOCATOTS must be 88.", new[] { nameof(MOCATOTS) });
                        }
                    }
                }
                else if ((MODE == FormMode.Remote && RMMODE == RemoteModality.Telephone))
                {
                    if (MOCBTOTS.HasValue &&
                        ((MOCADIGI.HasValue && MOCADIGI.Value >= 95 && MOCADIGI.Value <= 98) ||
                        (MOCALETT.HasValue && MOCALETT.Value >= 95 && MOCALETT.Value <= 98) ||
                        (MOCASER7.HasValue && MOCASER7.Value >= 95 && MOCASER7.Value <= 98) ||
                        (MOCAREPE.HasValue && MOCAREPE.Value >= 95 && MOCAREPE.Value <= 98) ||
                        (MOCAFLUE.HasValue && MOCAFLUE.Value >= 95 && MOCAFLUE.Value <= 98) ||
                        (MOCAABST.HasValue && MOCAABST.Value >= 95 && MOCAABST.Value <= 98) ||
                        (MOCARECN.HasValue && MOCARECN.Value >= 95 && MOCARECN.Value <= 98) ||
                        (MOCAORDT.HasValue && MOCAORDT.Value >= 95 && MOCAORDT.Value <= 98) ||
                        (MOCAORMO.HasValue && MOCAORMO.Value >= 95 && MOCAORMO.Value <= 98) ||
                        (MOCAORYR.HasValue && MOCAORYR.Value >= 95 && MOCAORYR.Value <= 98) ||
                        (MOCAORDY.HasValue && MOCAORDY.Value >= 95 && MOCAORDY.Value <= 98) ||
                        (MOCAORPL.HasValue && MOCAORPL.Value >= 95 && MOCAORPL.Value <= 98) ||
                        (MOCAORCT.HasValue && MOCAORCT.Value >= 95 && MOCAORCT.Value <= 98)))
                    {
                        if (MOCBTOTS.Value != 88)
                        {
                            yield return new ValidationResult("If 1e–1k or 1n–1s were not administered then MOCBTOTS must be 88.", new[] { nameof(MOCBTOTS) });
                        }
                    }
                }


                if (Status == FormStatus.Finalized)
                {
                    if (MODE == FormMode.InPerson || (MODE == FormMode.Remote && RMMODE == RemoteModality.Video))
                    {
                        if (!TRAILA.HasValue)
                            yield return new ValidationResult("Total number of seconds to complete is required.", new[] { nameof(TRAILA) });

                        if (!TRAILB.HasValue)
                            yield return new ValidationResult("Total number of seconds to complete is required.", new[] { nameof(TRAILB) });

                        if (!MOCALOC.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("Which location was the MoCA administered?", new[] { nameof(MOCALOC) });

                        if (!MOCAVIS.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("Was the MoCA affected by visual impairment?", new[] { nameof(MOCAVIS) });

                        if (!MOCATOTS.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("Sum all subscores. The maximum score is 30 points.", new[] { nameof(MOCATOTS) });

                        if (!MOCACLOC.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("If clock contour acceptable, enter 1; otherwise, enter 0.", new[] { nameof(MOCACLOC) });

                        if (!MOCACLON.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("If all clock hands criteria are met, enter 1; otherwise, enter 0.", new[] { nameof(MOCACLON) });

                        if (!MOCACLOH.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("If all clock hands criteria are met, enter 1; otherwise, enter 0.", new[] { nameof(MOCACLOH) });

                        if (!MOCACUBE.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("Assign a point if all cube criteria are met.", new[] { nameof(MOCACUBE) });

                        if (!MOCANAMI.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("One point each is given for the following responses: (1) lion (2) rhinoceros or rhino (3) camel or dromedary.", new[] { nameof(MOCANAMI) });

                        if (!MOCAREGI.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("Count the number correct for both trials.", new[] { nameof(MOCAREGI) });

                        if (!MOCARECN.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("Allocate 1 point for each word recalled freely without any cues.", new[] { nameof(MOCARECN) });

                        if (!MOCATRAI.HasValue && MOCACOMP == 1)
                            yield return new ValidationResult("Allocate one point if the pattern was drawn successfully; otherwise, enter 0.", new[] { nameof(MOCATRAI) });

                        if (!NPSYCLOC.HasValue)
                            yield return new ValidationResult("The tests following the MoCA were administered field is required.", new[] { nameof(NPSYCLOC) });

                        if (!UDSBENTC.HasValue)
                            yield return new ValidationResult("The Total Score for copy of Benson figure field is required", new[] { nameof(UDSBENTC) });

                        if (!UDSBENTD.HasValue)
                            yield return new ValidationResult("Total score for drawing of Benson figure following 10- to 15-minuted delay field is required.", new[] { nameof(UDSBENTD) });

                        if (!MINTTOTS.HasValue)
                            yield return new ValidationResult("The Total score field is required.", new[] { nameof(MINTTOTS) });
                    }
                    else if (MODE == FormMode.Remote && RMMODE == RemoteModality.Telephone)
                    {
                        // TODO C2T validation rules here
                    }

                    if (!RESPVAL.HasValue)
                        yield return new ValidationResult("How valid do you think the participant’s responses are?", new[] { nameof(RESPVAL) });
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
