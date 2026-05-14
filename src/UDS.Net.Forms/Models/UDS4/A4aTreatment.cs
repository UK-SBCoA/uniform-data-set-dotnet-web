using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A4aTreatment : IValidatableObject
    {
        public int TreatmentIndex { get; set; }

        [Display(Name = "Amyloid beta")]
        public bool? TARGETAB { get; set; }

        [Display(Name = "Tau")]
        public bool? TARGETTAU { get; set; }

        [Display(Name = "Inflammation")]
        public bool? TARGETINF { get; set; }

        [Display(Name = "Synaptic plasticity/neuroprotection")]
        public bool? TARGETSYN { get; set; }

        [Display(Name = "Other target(s)")]
        public bool? TARGETOTH { get; set; }

        [NotMapped]
        public bool HasPrimaryDrugTarget
        {
            get
            {
                if (TARGETAB.HasValue || TARGETTAU.HasValue || TARGETINF.HasValue || TARGETSYN.HasValue || TARGETOTH.HasValue)
                {
                    if (TARGETAB!.Value == true || TARGETTAU!.Value == true || TARGETINF!.Value == true || TARGETSYN!.Value == true || TARGETOTH!.Value == true)
                        return true;
                }
                
                return false;
            }
        }

        [NotMapped]
        public bool HasAnyTreatmentData
        {
            get
            {
                if (TRTTRIAL != null || NCTNUM != null || STARTMO.HasValue || STARTYEAR.HasValue || ENDMO.HasValue || ENDYEAR.HasValue || CARETRIAL.HasValue)
                {
                    return true;
                }
                return false;
            }
        }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? TARGETOTX { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? TRTTRIAL { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? NCTNUM { get; set; }

        [RegularExpression("^([1-9]|1[0-2]|99)$", ErrorMessage = "Valid range is 1 - 12 or 99")]
        public int? STARTMO { get; set; }

        public int? STARTYEAR { get; set; }

        [NotMapped]
        public bool StartYearValid
        {
            get
            {
                if (STARTYEAR.HasValue)
                {
                    if (STARTYEAR == 9999)
                        return true;
                    if (STARTYEAR >= 1990 && STARTYEAR <= DateTime.Now.Year)
                        return true;
                } 
                return false;
            }
        }

        [RegularExpression("^([1-9]|1[0-2]|88|99)$", ErrorMessage = "Valid range is 1 - 12 or 88 or 99")]
        public int? ENDMO { get; set; }

        public int? ENDYEAR { get; set; }

        [NotMapped]
        public bool EndYearValid
        {
            get
            {
                if (ENDYEAR.HasValue)
                {
                    if (ENDYEAR == 9999)
                        return true;
                    if (ENDYEAR == 8888)
                        return true;
                    if (ENDYEAR >= 1990 && ENDYEAR <= DateTime.Now.Year)
                        return true;
                }
                return false;
            }
        }

        [NotMapped]
        public bool PreciseDateRangeValid
        {
            get
            {
                if (STARTYEAR.HasValue && STARTMO.HasValue &&
                    ENDYEAR.HasValue && ENDMO.HasValue &&
                    STARTMO != 99 && ENDMO != 88 && ENDMO != 99 &&
                    STARTYEAR != 9999 && ENDYEAR != 8888 && ENDYEAR != 9999)
                {
                    if (STARTMO.Value >= 1 && STARTMO.Value <= 12 && ENDMO.Value >= 1 && ENDMO.Value <= 12)
                    {
                        var startDate = new DateTime(STARTYEAR.Value, STARTMO.Value, 1);
                        var endDate = new DateTime(ENDYEAR.Value, ENDMO.Value, 1);
                        if (endDate > startDate)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public int? CARETRIAL { get; set; }

        public int? TRIALGRP { get; set; }

        public List<RadioListItem> CARETRIALListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Clinical care", "1"),
            new RadioListItem("Clinical trial", "2"),
            new RadioListItem("Clinical care and clinical trial", "3")
        };

        public List<RadioListItem> TRIALGRPistItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Active treatment", "1"),
            new RadioListItem("Placebo", "2"),
            new RadioListItem("Unknown", "9")
        };

        public Dictionary<string, UIBehavior> GetCARETRIALUIBehavior(int index) => new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute($"A4a.Treatments[{index}].TRIALGRP"),
                },
            }},
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute($"A4a.Treatments[{index}].TRIALGRP"),
                },
            }},
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute($"A4a.Treatments[{index}].TRIALGRP"),
                },
            }},
        };

        public bool TreatmentMatchesPreviousVisit(A4aTreatment previousTreatment, A4aTreatment currentTreatment)
        {
            var previousFields = previousTreatment.ToEntity();
            var currentFields = currentTreatment.ToEntity();

            foreach (var property in typeof(A4aTreatmentFormFields).GetProperties())
            {
                if (!Equals(property.GetValue(previousFields), property.GetValue(currentFields)))
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // If there is a primary drug target defined then validation will be handled with the usual validation
            // However, if other data is defined, but no primary drug target then we need to require a primary drug target
            if (HasAnyTreatmentData)
            {
                if (!HasPrimaryDrugTarget)
                {
                    yield return new ValidationResult("Please specify the primary drug target for the treatment.", new[] { nameof(TARGETAB) });
                }
            }
            if (HasPrimaryDrugTarget)
            {
                if (TARGETOTH.HasValue && TARGETOTH.Value == true && String.IsNullOrWhiteSpace(TARGETOTX))
                {
                    yield return new ValidationResult("Provide other target(s)", new[] { nameof(TARGETOTX) } );
                }
                if (String.IsNullOrWhiteSpace(TRTTRIAL))
                {
                    yield return new ValidationResult("Provide specific treatment.", new[] { nameof(TRTTRIAL) });
                }
                if (STARTMO.HasValue && STARTYEAR.HasValue && ENDMO.HasValue && ENDYEAR.HasValue)
                {
                    if (!StartYearValid)
                    {
                        yield return new ValidationResult("Start year must be valid year or 9999.", new[] { nameof(STARTYEAR) }); 
                    }
                    if (!EndYearValid)
                    {
                        yield return new ValidationResult("End year must be valid year, 8888, or 9999.", new[] { nameof(ENDYEAR) }); 
                    }
                    if (STARTMO != 99 && STARTYEAR != 9999 && ENDMO != 99 && ENDYEAR != 9999 && ENDMO != 88 && ENDYEAR != 8888 && !PreciseDateRangeValid)
                    {
                        yield return new ValidationResult("End date must be after start date.", new[] { nameof(ENDYEAR) });
                    }
                }
                else
                {
                    yield return new ValidationResult("Start and end dates must be provided.", new[] { nameof(STARTMO) }); 
                }
                if (CARETRIAL.HasValue)
                {
                    if ((CARETRIAL == 2 || CARETRIAL == 3) && !TRIALGRP.HasValue)
                    {
                        yield return new ValidationResult("If a clinical trial then group must be provided.", new[] { nameof(TRIALGRP) }); 
                    }
                }
                else
                {
                    yield return new ValidationResult("How was the treatment provided?", new[] { nameof(CARETRIAL) }); 
                }
            }
        }
    }
}
