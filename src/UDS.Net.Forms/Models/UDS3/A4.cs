using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A4 : FormModel
    {
        [Display(Name = "Is the participant currently taking any medications?")]
        [RequiredOnComplete]
        public int? ANYMEDS { get; set; }

        public List<DrugCodeModel> DrugIds { get; set; } = new List<DrugCodeModel>();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == Services.Enums.FormStatus.Complete)
            {
                if (ANYMEDS.HasValue && ANYMEDS.Value == 1)
                {
                    if (DrugIds.Count() == 0)
                    {
                        yield return new ValidationResult("If participant is currently taking medications you must indicate the drug id(s).", new[] { nameof(ANYMEDS) });

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

