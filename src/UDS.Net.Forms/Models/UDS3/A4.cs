using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A4 : FormModel
    {
        [Display(Name = "Is the participant currently taking any medications?")]
        public int? ANYMEDS { get; set; }

        public List<DrugCodeModel> DrugIds { get; set; } = new List<DrugCodeModel>();

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

