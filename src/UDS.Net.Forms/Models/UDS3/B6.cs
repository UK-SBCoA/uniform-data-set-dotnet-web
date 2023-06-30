using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B6 : FormModel
    {
        [Display(Name = "Check this box if the subject is not able to complete the GDS, based on the clinician's best judgment")]
        public bool NOGDS { get; set; }

        [Display(Name = "Are you basically satisifed with your life?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? SATIS { get; set; }

        [Display(Name = "Have you dropped many of your activities and interests?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? DROPACT { get; set; }

        [Display(Name = "Do you feel that your life is empty?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? EMPTY { get; set; }

        [Display(Name = "Do you often get bored?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? BORED { get; set; }

        [Display(Name = "Are you in good spirits most of the time?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? SPIRITS { get; set; }

        [Display(Name = "Are you afraid that something bad is going to happen to you?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? AFRAID { get; set; }

        [Display(Name = "Do you feel happy most of the time?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? HAPPY { get; set; }

        [Display(Name = "Do you often feel helpless?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? HELPLESS { get; set; }

        [Display(Name = "Do you prefer to stay at home, rather than going out and doing new things?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? STAYHOME { get; set; }

        [Display(Name = "Do you feel you have more problems with memory than most?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? MEMPROB { get; set; }

        [Display(Name = "Do you think it is wonderful to be alive now?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? WONDRFUL { get; set; }

        [Display(Name = "Do you feel pretty worthless the way you are now?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? WRTHLESS { get; set; }

        [Display(Name = "Do you feel full of energy?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? ENERGY { get; set; }

        [Display(Name = "Do you feel that your situation is hopeless?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? HOPELESS { get; set; }

        [Display(Name = "Do you think that most people are better off than you are?")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Answer required")]
        public int? BETTER { get; set; }

        [Display(Name = "Sum of all circled answers for Total GDS Score")]
        [RegularExpression("^([1-9]|1[0-5]|88)$", ErrorMessage = "(0-15, 88)")]
        public int? GDS { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

