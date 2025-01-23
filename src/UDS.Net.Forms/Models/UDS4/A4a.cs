using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A4a : FormModel
    {
        [RequiredOnFinalized]
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
            if (Status == FormStatus.Finalized)
            {
                int index = 0;
                foreach (var treatment in Treatments)
                {
                    var treatmentIdentifier = $"Treatments[{index}]";

                    if (index == 0 && (TRTBIOMARK == 1 || TRTBIOMARK == 9))
                    {
                        bool isAnyTargetSet = (treatment.TARGETAB == true || treatment.TARGETTAU == true ||
                                               treatment.TARGETINF == true || treatment.TARGETSYN == true ||
                                               treatment.TARGETOTH == true);

                        if (!isAnyTargetSet)
                        {
                            yield return new ValidationResult("At least one primary drug target must be specified.", new[] { treatmentIdentifier });
                        }
                    }

                    if (treatment.TARGETOTH.HasValue && treatment.TARGETOTH.Value)
                    {
                        if (treatment.TARGETOTX == null)
                        {
                            yield return new ValidationResult("Please specify other target.", new[] { $"{treatmentIdentifier}.{nameof(treatment.TARGETOTX)}" });
                        }
                    }

                    if ((treatment.TARGETAB.HasValue && treatment.TARGETAB == true) ||
                       (treatment.TARGETTAU.HasValue && treatment.TARGETTAU == true) ||
                       (treatment.TARGETINF.HasValue && treatment.TARGETINF == true) ||
                       (treatment.TARGETSYN.HasValue && treatment.TARGETSYN == true) ||
                       (treatment.TARGETOTH.HasValue && treatment.TARGETOTH == true))
                    {
                        if (treatment.TRTTRIAL == null)
                        {
                            yield return new ValidationResult("Please specify.", new[] { $"{treatmentIdentifier}.{nameof(treatment.TRTTRIAL)}" });
                        }
                    }

                    if (treatment.TRTTRIAL != null)
                    {
                        if (!treatment.STARTMO.HasValue)
                        {
                            yield return new ValidationResult("Start month is required.", new[] { $"{treatmentIdentifier}.{nameof(treatment.STARTMO)}" });
                        }

                        if (!treatment.STARTYEAR.HasValue)
                        {
                            yield return new ValidationResult("Start year is required.", new[] { $"{treatmentIdentifier}.{nameof(treatment.STARTYEAR)}" });
                        }
                    }


                    if (treatment.STARTMO.HasValue || treatment.STARTYEAR.HasValue)
                    {
                        if (!treatment.ENDMO.HasValue)
                        {
                            yield return new ValidationResult("End month is required.", new[] { $"{treatmentIdentifier}.{nameof(treatment.ENDMO)}" });
                        }

                        if (!treatment.ENDYEAR.HasValue)
                        {
                            yield return new ValidationResult("End year is required.", new[] { $"{treatmentIdentifier}.{nameof(treatment.ENDYEAR)}" });
                        }
                    }

                    if (treatment.ENDMO.HasValue || treatment.ENDYEAR.HasValue)
                    {
                        if (!treatment.CARETRIAL.HasValue)
                        {
                            yield return new ValidationResult("How was the treatment provided.", new[] { $"{treatmentIdentifier}.{nameof(treatment.CARETRIAL)}" });
                        }
                    }

                    if ((treatment.CARETRIAL.HasValue && treatment.CARETRIAL == 2) || (treatment.CARETRIAL.HasValue && treatment.CARETRIAL == 3))
                    {
                        if (!treatment.TRIALGRP.HasValue)
                        {
                            yield return new ValidationResult("In which group was the participant.", new[] { $"{treatmentIdentifier}.{nameof(treatment.TRIALGRP)}" });
                        }
                    }

                    if (treatment.STARTYEAR.HasValue && (treatment.STARTYEAR < 1990 || treatment.STARTYEAR > DateTime.Now.Year))
                    {
                        yield return new ValidationResult($"Start year must be between 1990 and {DateTime.Now.Year}.", new[] { $"{treatmentIdentifier}.{nameof(treatment.STARTYEAR)}" });
                    }

                    if (treatment.ENDYEAR.HasValue && (treatment.ENDYEAR < 1990 || treatment.ENDYEAR > DateTime.Now.Year) && (treatment.ENDYEAR.Value != 9999) && (treatment.ENDYEAR.Value != 8888))
                    {
                        yield return new ValidationResult($"End year must be between 1990 and {DateTime.Now.Year} or 8888 or 9999", new[] { $"{treatmentIdentifier}.{nameof(treatment.ENDYEAR)}" });
                    }

                    index++;
                }
            }

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }
        }

    }
}

