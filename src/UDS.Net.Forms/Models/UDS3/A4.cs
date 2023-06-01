using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A4 : FormModel
    {
        [Display(Name = "")]
        public int? ANYMEDS { get; set; }

        public List<string> DrugIds { get; set; } = new List<string>();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

