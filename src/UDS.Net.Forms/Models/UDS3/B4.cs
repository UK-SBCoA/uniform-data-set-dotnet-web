using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B4 : FormModel
    {
        [Display(Name = "MEMORY")]
        public int? MEMORY { get; set; }

        [Display(Name = "ORIENTATION")]
        public int? ORIENT { get; set; }

        [Display(Name = "JUDGMENT AND PROBLEM SOLVING")]
        public int? JUDGMENT { get; set; }

        [Display(Name = "COMMUNITY AFFAIRS")]
        public int? COMMUN { get; set; }

        [Display(Name = "HOME AND HOBBIES")]
        public int? HOMEHOBB { get; set; }

        [Display(Name = "PERSONAL CARE")]
        public int? PERSCARE { get; set; }

        [Display(Name = "CDR SUM OF BOXES")]
        public int? CDRSUM { get; set; }

        [Display(Name = "GLOBAL CDR")]
        public int? CDRGLOB { get; set; }

        [Display(Name = "Behavior, comportment,and personality")]
        public int? COMPORT { get; set; }

        [Display(Name = "Language")]
        public int? CDRLANG { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

