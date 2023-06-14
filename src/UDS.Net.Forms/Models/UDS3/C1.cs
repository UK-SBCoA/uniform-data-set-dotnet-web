using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class C1 : FormModel
    {
        [Display(Name = "Was any part of the MMSE completed?")]
        public int? MMSECOMP { get; set; }

        [Display(Name = "N0 (Enter reason code, 95-98 and SKIP TO QUESTION 2a)")]
        [Range(95, 98)]
        public int? MMSEREAS { get; set; }

        [Display(Name = "Administration of the MMSE was")]
        public int? MMSELOC { get; set; }

        [Display(Name = "Language of MMSE administration")]
        public int? MMSELAN { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? MMSELANX { get; set; }

        [Display(Name = "Participant was unable to complete one or more sections due to visual impairment")]
        public int? MMSEVIS { get; set; }

        [Display(Name = "Participant was unable to complete one or more sections due to hearing impairment")]
        public int? MMSEHEAR { get; set; }

        [Display(Name = "Time")]
        [RegularExpression("^(0-5|95-98)$")]
        public int? MMSEORDA { get; set; }

        [Display(Name = "Place")]
        [RegularExpression("^(0-5|95-98)$")]
        public int? MMSEORLO { get; set; }

        [Display(Name = "Intersecting pentagon subscale score")]
        [RegularExpression("^(0-1|95-98)$")]
        public int? PENTAGON { get; set; }

        [Display(Name = "Total MMSE score (using D-L-R-O-W)")]
        [RegularExpression("^(0-30|88)$")]
        public int? MMSE { get; set; }

        [Display(Name = "The remainder of the battery (i.e., the tests summarized below) was administered")]
        public int? NPSYCLOC { get; set; }

        [Display(Name = "Language of test administration")]
        public int? NPSYLAN { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? NPSYLANX { get; set; }

        [Display(Name = "month")]
        [RegularExpression("^(0-12|88)$")]
        public int? LOGIMO { get; set; }

        [Display(Name = "day")]
        [RegularExpression("^(0-31|88)$")]
        public int? LOGIDAY { get; set; }

        //year validation
        [Display(Name = "year")]
        public int? LOGIYR { get; set; }

        [Display(Name = "Total score from the previous test administration")]
        [RegularExpression("^(0-25|88)$")]
        public int? LOGIPREV { get; set; }

        [Display(Name = "Total number of story units recalled from this current test administration")]
        [RegularExpression("^(0-25|95-98)$")]
        public int? LOGIMEM { get; set; }

        [Display(Name = "Total score for copy of Bension figure")]
        [RegularExpression("^(0-17|95-98)$")]
        public int? UDSBENTC { get; set; }

        [Display(Name = "Total number of trials correct before to two consecutive errors at the same digit length")]
        [RegularExpression("^(0-12|95-98)$")]
        public int? DIGIF { get; set; }

        [Display(Name = "Digit span forward length ")]
        [Range(0, 8)]
        public int? DIGIFLEN { get; set; }

        [Display(Name = "Total number of trials correct before to two consecutive errors at the same digit length ")]
        [RegularExpression("^(0-12|95-98)$")]
        public int? DIGIB { get; set; }

        [Display(Name = "Digit span backward length")]
        [Range(0, 7)]
        public int? DIGIBLEN { get; set; }

        [Display(Name = "Animals: Total number of animals named in 60 seconds")]
        [RegularExpression("^(0-77|95-98)$")]
        public int? ANIMALS { get; set; }

        [Display(Name = "Vegetables: Total number of vegetables named in 60 seconds")]
        [RegularExpression("^(0-77|95-98)$")]
        public int? VEG { get; set; }

        [Display(Name = "PART A: Total number of seconds to complete")]
        [RegularExpression("^(0-150|995-998)$")]
        public int? TRAILA { get; set; }

        [Display(Name = "Number of commission errors")]
        [Range(0, 40)]
        public int? TRAILARR { get; set; }

        [Display(Name = "Number of correct lines")]
        [Range(0, 24)]
        public int? TRAILALI { get; set; }

        [Display(Name = "PART B: Total number of seconds to complete")]
        [RegularExpression("^(0-300|995-998)$")]
        public int? TRAILB { get; set; }

        [Display(Name = "Number of commission errors")]
        [Range(0, 40)]
        public int? TRAILBRR { get; set; }

        [Display(Name = "Number of correct lines")]
        [Range(0, 24)]
        public int? TRAILBLI { get; set; }

        [Display(Name = "Total number of story units recalled")]
        [RegularExpression("^(0-25|95-98)$")]
        public int? MEMUNITS { get; set; }

        [Display(Name = "Time elapsed since Logical Memory IA–Immediate")]
        [RegularExpression("^(0-85|99)$")]
        public int? MEMTIME { get; set; }

        [Display(Name = "Total score for 10- to 15-minute delayed drawing of Bension figure")]
        [RegularExpression("^(0-17|95-98)$")]
        public int? UDSBENTD { get; set; }

        [Display(Name = "Recognized original stimulus from among four options?")]
        public int? UDSBENRS { get; set; }

        [Display(Name = "Total score")]
        [RegularExpression("^(0-30|95-98)$")]
        public int? BOSTON { get; set; }

        [Display(Name = "Number of correct F-words generated in 1 minute")]
        [RegularExpression("^(0-40|95-98)$")]
        public int? UDSVERFC { get; set; }

        [Display(Name = "Number of F-words repeated in 1 minute")]
        [Range(0, 15)]
        public int? UDSVERFN { get; set; }

        [Display(Name = "Number of non-F-words and rule violation errors in 1 minute")]
        [Range(0, 15)]
        public int? UDSVERNF { get; set; }

        [Display(Name = "Number of correct L-words generated in 1 minute")]
        [RegularExpression("^(0-40|95-98)$")]
        public int? UDSVERLC { get; set; }

        [Display(Name = "Number of L-words repeated in one minute")]
        [Range(0, 15)]
        public int? UDSVERLR { get; set; }

        [Display(Name = "Number of non-Lwords and rule violation errors in 1 minute")]
        [Range(0, 15)]
        public int? UDSVERLN { get; set; }

        [Display(Name = "TOTAL number of correct F-words and L-words")]
        [Range(0, 80)]
        public int? UDSVERTN { get; set; }

        [Display(Name = "TOTAL number of F-word and L-word repetition errors")]
        [Range(0, 80)]
        public int? UDSVERTE { get; set; }

        [Display(Name = "TOTAL number of non-F/L words and rule violation errors")]
        [Range(0, 80)]
        public int? UDSVERTI { get; set; }

        [Display(Name = "Per Clinician (e.g., neuropsychologist, behavioral neurologist, or other suitably qualified clinician), based on the UDS neuropsychological examination, the participant’s cognitive status is deemed")]
        public int? COGSTAT { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

