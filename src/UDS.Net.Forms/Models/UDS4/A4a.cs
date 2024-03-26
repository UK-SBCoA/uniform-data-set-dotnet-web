
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
        [Display(Name = "Has the participant ever been prescribed a treatment or been enrolled in a clinical trial of a treatment expected to modify ADRD biomarkers?")]
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
        [RequiredIf(nameof(ADVERSEOTH), "true", ErrorMessage = "Specify other issues.")]
        [Display(Name = "Specify")]
        public string? ADVERSEOTX { get; set; }

        [RequiredIf(nameof(ADVEVENT), "1", ErrorMessage = "Please indicate major adverse event(s) associated with treatments expected to modify ADRD biomarkers.")]
        [RequiredIf(nameof(ADVEVENT), "9", ErrorMessage = "Please indicate major adverse event(s) associated with treatments expected to modify ADRD biomarkers.")]
        [NotMapped]
        public bool? AdverseEventsIndicated
        {
            get
            {
                int counter = 0;
                if (ARIAE == true)
                {
                    counter++;
                }
                if (ARIAH == true)
                {
                    counter++;
                }
                if (ADVERSEOTH == true)
                {
                    counter++;
                }
                if (counter >= 1)
                {
                    return true;
                }
                return null;
            }


        }

        public List<A4aTreatment> Treatments { get; set; } = new List<A4aTreatment>();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == FormStatus.Complete)
            {
                foreach (var treatment in Treatments)
                {
                    if (treatment.STARTYEAR.HasValue && (treatment.STARTYEAR < 1990 || treatment.STARTYEAR > DateTime.Now.Year))
                    {
                        yield return new ValidationResult($"Start year must be between 1990 and {DateTime.Now.Year}.", new[] { nameof(treatment.STARTYEAR) });
                    }

                    if (treatment.ENDYEAR.HasValue && (treatment.ENDYEAR < 1990 || treatment.ENDYEAR > DateTime.Now.Year))
                    {
                        yield return new ValidationResult($"End year must be between 1990 and {DateTime.Now.Year}.", new[] { nameof(treatment.ENDYEAR) });
                    }
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

