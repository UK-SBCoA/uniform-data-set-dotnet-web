using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A4a : FormModel
    {
        [RequiredOnFinalized]
        [Display(Name = "Has the participant ever been prescribed a treatment or been enrolled in a clinical trial of a treatment expected to modify ADRD biomarkers?")]
        public int? TRTBIOMARK { get; set; }

        [Display(Name = "Since the last UDS visit, is new information available concerning any of the participant's prescribed treatments or clinical trial(s) of a treatment expected to modify ADRD biomarkers?")]
        public int? NEWTREAT { get; set; }

        // ADEVENT is required for I/I4 visits when TRTBIOMARK = 1
        // ADEVENT is required for F visits when 
        [Display(Name = "Has the participant ever experienced amyloid related imaging abnormalities–edema (ARIA-E), amyloid related imaging abnormalities–hemorrhage (ARIA-H), or other major adverse events associated with treatments expected to modify ADRD biomarkers?")]
        public int? ADVEVENT { get; set; }

        [Display(Name = "Since the last UDS visit, is new information available concerning the participant's experience of amyloid related imaging abnormalities-edema (ARIA-E), amyloid related imaging abnormalities-hemorrhage (ARIA-H), or other major adverse events associated with treatments expected to modify ADRD biomarkers?")]
        public int? NEWADEVENT { get; set; }

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
                if (NEWADEVENT == 0 || NEWADEVENT == 9) //FVP variable NEWADEVENT adds seperate validation logic for follow up visits
                {
                    return true;
                }
                return null;
            }
        }

        public List<A4aTreatment> Treatments { get; set; } = new List<A4aTreatment>();

        [NotMapped]
        public bool HasAtLeastOneTreatment
        {
            get
            {
                int treatmentCount = 0;
                foreach (var treatment in Treatments)
                {
                    if (treatment.HasPrimaryDrugTarget || treatment.HasAnyTreatmentData)
                    {
                        treatmentCount++;
                    }
                }
                if (treatmentCount > 0)
                    return true;
                return false;
            }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TRTBIOMARK == 1)
            {
                if (PacketKind == PacketKind.I || PacketKind == PacketKind.I4)
                {
                    bool isAnyTargetSet = Treatments.Any(t => t.HasPrimaryDrugTarget);

                    if (!isAnyTargetSet)
                    {
                        yield return new ValidationResult("At least one primary drug target must be specified.", new[] { "Treatments" });
                    }

                    if (ADVEVENT == null)
                    {
                        yield return new ValidationResult("Please specify adverse events associated with treatments expected to modify ADRD biomarkers.", new[] { nameof(ADVEVENT) });
                    }
                }

                if (PacketKind == PacketKind.F)
                {
                    if (NEWTREAT == null)
                    {
                        yield return new ValidationResult("Is new information available concerning the participant's treatments or trials?", new[] { nameof(NEWTREAT) });
                    }

                }
            }
            if (ADVEVENT == 1)
            {
                if (PacketKind == PacketKind.F)
                {
                    if (NEWTREAT == 1)
                    {
                        if (NEWADEVENT == null)
                        {
                            yield return new ValidationResult("Is new information available concerning the participant's imaging or adverse events that could modify biomarkers?", new[] { nameof(NEWADEVENT) });
                        }
                    }
                }
            }

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }
        }
    }
}

