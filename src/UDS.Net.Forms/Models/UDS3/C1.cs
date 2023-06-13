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

        //validation needed 
        [Display(Name = "Reason code for not completing MMSE")]
        public int? MMSEREAS { get; set; }

        [Display(Name = "Administration of the MMSE was")]
        public int? MMSELOC { get; set; }

        [Display(Name = "Language of MMSE administration")]
        public int? MMSELAN { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? MMSELANX { get; set; }

        [Display(Name = "Subject was unable to complete one or more sections due to visual impairment")]
        public int? MMSEVIS { get; set; }

        [Display(Name = "Subject was unable to complete one or more sections due to hearing impairment")]
        public int? MMSEHEAR { get; set; }

        //validation needed
        [Display(Name = "Time")]
        public int? MMSEORDA { get; set; }

        //validation
        [Display(Name = "Place")]
        public int? MMSEORLO { get; set; }

        //validation
        [Display(Name = "Intersecting pentagon subscale score")]
        public int? PENTAGON { get; set; }

        [Display(Name = "Total MMSE score (using D-L-R-O-W)")]
        public int? MMSE { get; set; }

        [Display(Name = "The remainder of the battery was administered")]
        public int? NPSYCLOC { get; set; }

        [Display(Name = "Language of test administration")]
        public int? NPSYLAN { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? NPSYLANX { get; set; }

        [Display(Name = "month")]
        public int? LOGIMO { get; set; }

        [Display(Name = "day")]
        public int? LOGIDAY { get; set; }

        [Display(Name = "year")]
        public int? LOGIYR { get; set; }

        [Display(Name = "Total score from the previous test administration")]
        public int? LOGIPREV { get; set; }

        [Display(Name = "Total number of story units recalled from this current test administration")]
        public int? LOGIMEM { get; set; }

        [Display(Name = "Total score for copy of Bension figure")]
        public int? UDSBENTC { get; set; }

        [Display(Name = "Total number of trials correct before to two consecutive errors at the same digit length")]
        public int? DIGIF { get; set; }

        [Display(Name = "Digit span forward length ")]
        public int? DIGIFLEN { get; set; }

        [Display(Name = "Total number of trials correct before to two consecutive errors at the same digit length ")]
        public int? DIGIB { get; set; }

        [Display(Name = "Digit span backward length")]
        public int? DIGIBLEN { get; set; }

        [Display(Name = "Animals — Total number of animals named in 60 seconds")]
        public int? ANIMALS { get; set; }

        [Display(Name = "Vegetables — Total number of vegetables named in 60 seconds")]
        public int? VEG { get; set; }

        [Display(Name = "Total number of seconds to complete")]
        public int? TRAILA { get; set; }

        [Display(Name = "Number of commission errors")]
        public int? TRAILARR { get; set; }

        [Display(Name = "Number of correct lines")]
        public int? TRAILALI { get; set; }

        [Display(Name = "Total number of seconds to complete")]
        public int? TRAILB { get; set; }

        [Display(Name = "Number of commission errors")]
        public int? TRAILBRR { get; set; }

        [Display(Name = "Number of correct lines")]
        public int? TRAILBLI { get; set; }

        [Display(Name = "Total number of story units recalled")]
        public int? MEMUNITS { get; set; }

        [Display(Name = "Time elapsed since Logical Memory IA–Immediate")]
        public int? MEMTIME { get; set; }

        [Display(Name = "Total score for 10- to 15-minute delayed drawing of Bension figure")]
        public int? UDSBENTD { get; set; }

        [Display(Name = "Recognized original stimulus from among four options")]
        public int? UDSBENRS { get; set; }

        [Display(Name = "Boston Naming Test (30) –Total score")]
        public int? BOSTON { get; set; }

        [Display(Name = "Number of correct F-words generated in 1 minute")]
        public int? UDSVERFC { get; set; }

        [Display(Name = "Number of F-words repeated in 1 minute")]
        public int? UDSVERFN { get; set; }

        [Display(Name = "Number of non-Fwords and rule violation errors in 1 minute")]
        public int? UDSVERNF { get; set; }

        [Display(Name = "Number of correct L-words generated in 1 minute")]
        public int? UDSVERLC { get; set; }

        [Display(Name = "Number of L-words repeated in 1 minute")]
        public int? UDSVERLR { get; set; }

        [Display(Name = "Number of non-Lwords and rule violation errors in 1 minute")]
        public int? UDSVERLN { get; set; }

        [Display(Name = "Total number of correct F-words and L-words")]
        public int? UDSVERTN { get; set; }

        [Display(Name = "Total number of F-word and L-word repetition errors")]
        public int? UDSVERTE { get; set; }

        [Display(Name = "Total number of non-F/L-words and rule violation errors")]
        public int? UDSVERTI { get; set; }

        [Display(Name = "Per Clinician, based on the neuropsychological examination, the subject’s cognitive status is deemed")]
        public int? COGSTAT { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

