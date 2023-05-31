using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UDS.Net.Forms.Models.UDS3
{
    public class T1 : FormModel
    {
        [Display(Name = "")]
        public int? TELCOG { get; set; }

        [Display(Name = "")]
        public int? TELILL { get; set; }

        [Display(Name = "")]
        public int? TELHOME { get; set; }

        [Display(Name = "")]
        public int? TELREFU { get; set; }

        [Display(Name = "")]
        public int? TELCOV { get; set; }

        [Display(Name = "")]
        public int? TELOTHR { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? TELOTHRX { get; set; }

        [Display(Name = "")]
        public int? TELMOD { get; set; }

        [Display(Name = "")]
        public int? TELINPER { get; set; }

        [Display(Name = "")]
        public int? TELMILE { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

