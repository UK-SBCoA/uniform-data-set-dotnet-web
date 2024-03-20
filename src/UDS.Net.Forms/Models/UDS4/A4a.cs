
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
        [RequiredOnComplete]
        [Display(Name = "Has the participant ever been prescribed or been enrolled in a clinical trial of a treatment expected to modify ADRD biomarkers?")]
        public int? TRTBIOMARK { get; set; }

        [RequiredIf(nameof(TRTBIOMARK), "1", ErrorMessage = "Please specify adverse events associated with treatments expected to modify ADRD biomarkers.")]
        [RequiredIf(nameof(TRTBIOMARK), "9", ErrorMessage = "Please specify adverse events associated with treatments expected to modify ADRD biomarkers.")]
        [Display(Name = "Has the participant ever experienced amyloid related imaging abnormalities–edema (ARIA-E), amyloid related imaging abnormalities–hemorrhage (ARIA-H), or other major adverse events associated with treatments expected to modify ADRD biomarkers?")]
        public int? ADVEVENT { get; set; }

        [Display(Name = "Amyloid related imaging abnormalities–edema (ARIA-E) 3a2. 1 Amyloid related")]
        public bool? ARIAE { get; set; }

        [Display(Name = "Amyloid related imaging abnormalities–hemorrhage (ARIA-H)")]
        public bool? ARIAH { get; set; }

        [Display(Name = "Other issues")]
        public bool? ADVERSEOTH { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(ADVERSEOTH), "1", ErrorMessage = "Specify other issues.")]
        public string? ADVERSEOTX { get; set; }

        [RequiredIf(nameof(ADVEVENT), "1", ErrorMessage = "Please indicate major adverse event(s) associated with treatments expected to modify ADRD biomarkers.")]
        [RequiredIf(nameof(ADVEVENT), "9", ErrorMessage = "Please indicate major adverse event(s) associated with treatments expected to modify ADRD biomarkers.")]
        [NotMapped]
        public bool? AdverseEventsIndicated
        {
            get
            {
                if (ARIAE.HasValue || ARIAH.HasValue || ADVERSEOTH.HasValue)
                {
                    return true;
                }
                else return null;
            }
        }

        public List<A4aTreatment> Treatment { get; set; } = new List<A4aTreatment>();

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

