using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    public class B9 : FormModel
    {
        public int? DECSUB { get; set; }

        public int? DECIN { get; set; }

        public int? DECCLCOG { get; set; }

        public int? COGMEM { get; set; }

        public int? COGORI { get; set; }

        public int? COGJUDG { get; set; }

        public int? COGLANG { get; set; }

        public int? COGVIS { get; set; }

        public int? COGATTN { get; set; }

        public int? COGFLUC { get; set; }

        public int? COGFLAGO { get; set; }

        public int? COGOTHR { get; set; }

        public string COGOTHRX { get; set; }

        public int? COGFPRED { get; set; }

        public string COGFPREX { get; set; }

        public int? COGMODE { get; set; }

        public string COGMODEX { get; set; }

        public int? DECAGE { get; set; }

        public int? DECCLBE { get; set; }

        public int? BEAPATHY { get; set; }

        public int? BEDEP { get; set; }

        public int? BEVHALL { get; set; }

        public int? BEVWELL { get; set; }

        public int? BEVHAGO { get; set; }

        public int? BEAHALL { get; set; }

        public int? BEDEL { get; set; }

        public int? BEDISIN { get; set; }

        public int? BEIRRIT { get; set; }

        public int? BEAGIT { get; set; }

        public int? BEPERCH { get; set; }

        public int? BEREM { get; set; }

        public int? BEREMAGO { get; set; }

        public int? BEANX { get; set; }

        public int? BEOTHR { get; set; }

        public string BEOTHRX { get; set; }

        public int? BEFPRED { get; set; }

        public string BEFPREDX { get; set; }

        public int? BEMODE { get; set; }

        public string BEMODEX { get; set; }

        public int? BEAGE { get; set; }

        public int? DECCLMOT { get; set; }

        public int? MOGAIT { get; set; }

        public int? MOFALLS { get; set; }

        public int? MOTREM { get; set; }

        public int? MOSLOW { get; set; }

        public int? MOFRST { get; set; }

        public int? MOMODE { get; set; }

        public string MOMODEX { get; set; }

        public int? MOMOPARK { get; set; }

        public int? PARKAGE { get; set; }

        public int? MOMOALS { get; set; }

        public int? ALSAGE { get; set; }

        public int? MOAGE { get; set; }

        public int? COURSE { get; set; }

        public int? FRSTCHG { get; set; }

        public int? LBDEVAL { get; set; }

        public int? FTLDEVAL { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

