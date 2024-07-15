using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B6 : FormModel
    {
        [Display(Name = "Check this box and enter “88” below for the Total GDS Score if and only if the participant: 1.) does not attempt the GDS, or 2.) answers fewer than 12 questions.")]
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
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Total GDS Score is required.")]
        public int? GDS { get; set; }

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

