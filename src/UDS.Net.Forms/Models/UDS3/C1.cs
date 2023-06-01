using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class C1 : FormModel
    {
        [Display(Name = "")]
        public int? MMSECOMP { get; set; }

        [Display(Name = "")]
        public int? MMSEREAS { get; set; }

        [Display(Name = "")]
        public int? MMSELOC { get; set; }

        [Display(Name = "")]
        public int? MMSELAN { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? MMSELANX { get; set; }

        [Display(Name = "")]
        public int? MMSEVIS { get; set; }

        [Display(Name = "")]
        public int? MMSEHEAR { get; set; }

        [Display(Name = "")]
        public int? MMSEORDA { get; set; }

        [Display(Name = "")]
        public int? MMSEORLO { get; set; }

        [Display(Name = "")]
        public int? PENTAGON { get; set; }

        [Display(Name = "")]
        public int? MMSE { get; set; }

        [Display(Name = "")]
        public int? NPSYCLOC { get; set; }

        [Display(Name = "")]
        public int? NPSYLAN { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? NPSYLANX { get; set; }

        [Display(Name = "")]
        public int? LOGIMO { get; set; }

        [Display(Name = "")]
        public int? LOGIDAY { get; set; }

        [Display(Name = "")]
        public int? LOGIYR { get; set; }

        [Display(Name = "")]
        public int? LOGIPREV { get; set; }

        [Display(Name = "")]
        public int? LOGIMEM { get; set; }

        [Display(Name = "")]
        public int? UDSBENTC { get; set; }

        [Display(Name = "")]
        public int? DIGIF { get; set; }

        [Display(Name = "")]
        public int? DIGIFLEN { get; set; }

        [Display(Name = "")]
        public int? DIGIB { get; set; }

        [Display(Name = "")]
        public int? DIGIBLEN { get; set; }

        [Display(Name = "")]
        public int? ANIMALS { get; set; }

        [Display(Name = "")]
        public int? VEG { get; set; }

        [Display(Name = "")]
        public int? TRAILA { get; set; }

        [Display(Name = "")]
        public int? TRAILARR { get; set; }

        [Display(Name = "")]
        public int? TRAILALI { get; set; }

        [Display(Name = "")]
        public int? TRAILB { get; set; }

        [Display(Name = "")]
        public int? TRAILBRR { get; set; }

        [Display(Name = "")]
        public int? TRAILBLI { get; set; }

        [Display(Name = "")]
        public int? MEMUNITS { get; set; }

        [Display(Name = "")]
        public int? MEMTIME { get; set; }

        [Display(Name = "")]
        public int? UDSBENTD { get; set; }

        [Display(Name = "")]
        public int? UDSBENRS { get; set; }

        [Display(Name = "")]
        public int? BOSTON { get; set; }

        [Display(Name = "")]
        public int? UDSVERFC { get; set; }

        [Display(Name = "")]
        public int? UDSVERFN { get; set; }

        [Display(Name = "")]
        public int? UDSVERNF { get; set; }

        [Display(Name = "")]
        public int? UDSVERLC { get; set; }

        [Display(Name = "")]
        public int? UDSVERLR { get; set; }

        [Display(Name = "")]
        public int? UDSVERLN { get; set; }

        [Display(Name = "")]
        public int? UDSVERTN { get; set; }

        [Display(Name = "")]
        public int? UDSVERTE { get; set; }

        [Display(Name = "")]
        public int? UDSVERTI { get; set; }

        [Display(Name = "")]
        public int? COGSTAT { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

