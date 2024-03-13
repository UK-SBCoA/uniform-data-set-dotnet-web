
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A4a : FormModel
    {

        [Display(Name = "Has the participant ever been prescribed or been enrolled in a clinical trial of a treatment expected to modify ADRD biomarkers?")]
        public int? TRTBIOMARK { get; set; }

        public int? ADVEVENT { get; set; }

        public bool? ARIAE { get; set; }

        public bool? ARIAH { get; set; }

        public bool? ADVERSEOTH { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? ADVERSEOTX { get; set; }

        public List<A4aTreatment> Treatment1 { get; set; } = new List<A4aTreatment>();

        public List<A4aTreatment> Treatment2 { get; set; } = new List<A4aTreatment>();

        public List<A4aTreatment> Treatment3 { get; set; } = new List<A4aTreatment>();

        public List<A4aTreatment> Treatment4 { get; set; } = new List<A4aTreatment>();

        public List<A4aTreatment> Treatment5 { get; set; } = new List<A4aTreatment>();

        public List<A4aTreatment> Treatment6 { get; set; } = new List<A4aTreatment>();

        public List<A4aTreatment> Treatment7 { get; set; } = new List<A4aTreatment>();

        public List<A4aTreatment> Treatment8 { get; set; } = new List<A4aTreatment>();

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

