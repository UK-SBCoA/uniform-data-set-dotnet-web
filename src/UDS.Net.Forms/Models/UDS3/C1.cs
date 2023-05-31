using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    public class C1 : FormModel
    {
        public int? MMSECOMP { get; set; }

        public int? MMSEREAS { get; set; }

        public int? MMSELOC { get; set; }

        public int? MMSELAN { get; set; }

        public string MMSELANX { get; set; }

        public int? MMSEVIS { get; set; }

        public int? MMSEHEAR { get; set; }

        public int? MMSEORDA { get; set; }

        public int? MMSEORLO { get; set; }

        public int? PENTAGON { get; set; }

        public int? MMSE { get; set; }

        public int? NPSYCLOC { get; set; }

        public int? NPSYLAN { get; set; }

        public string NPSYLANX { get; set; }

        public int? LOGIMO { get; set; }

        public int? LOGIDAY { get; set; }

        public int? LOGIYR { get; set; }

        public int? LOGIPREV { get; set; }

        public int? LOGIMEM { get; set; }

        public int? UDSBENTC { get; set; }

        public int? DIGIF { get; set; }

        public int? DIGIFLEN { get; set; }

        public int? DIGIB { get; set; }

        public int? DIGIBLEN { get; set; }

        public int? ANIMALS { get; set; }

        public int? VEG { get; set; }

        public int? TRAILA { get; set; }

        public int? TRAILARR { get; set; }

        public int? TRAILALI { get; set; }

        public int? TRAILB { get; set; }

        public int? TRAILBRR { get; set; }

        public int? TRAILBLI { get; set; }

        public int? MEMUNITS { get; set; }

        public int? MEMTIME { get; set; }

        public int? UDSBENTD { get; set; }

        public int? UDSBENRS { get; set; }

        public int? BOSTON { get; set; }

        public int? UDSVERFC { get; set; }

        public int? UDSVERFN { get; set; }

        public int? UDSVERNF { get; set; }

        public int? UDSVERLC { get; set; }

        public int? UDSVERLR { get; set; }

        public int? UDSVERLN { get; set; }

        public int? UDSVERTN { get; set; }

        public int? UDSVERTE { get; set; }

        public int? UDSVERTI { get; set; }

        public int? COGSTAT { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

