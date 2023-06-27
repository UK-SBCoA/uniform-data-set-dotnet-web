using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B6 : FormModel
    {
        [Display(Name = "Check this box if the subject is not able to complete the GDS, based on the clinician's best judgment")]
        [Range(0, 1, ErrorMessage = "0,1)")]
        public int? NOGDS { get; set; }

        [Display(Name = "Are you basically satisifed with your life?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? SATIS { get; set; }

        [Display(Name = "Have you dropped many of your activities and interests?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? DROPACT { get; set; }

        [Display(Name = "Do you feel that your life is empty?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? EMPTY { get; set; }

        [Display(Name = "Do you often get bored?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? BORED { get; set; }

        [Display(Name = "Are you in good spirits most of the time?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? SPIRITS { get; set; }

        [Display(Name = "Are you afraid that something bad is going to happen to you?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? AFRAID { get; set; }

        [Display(Name = "Do you feel happy most of the time?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? HAPPY { get; set; }

        [Display(Name = "Do you often feel helpless?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? HELPLESS { get; set; }

        [Display(Name = "Do you prefer to stay at homne, rather than going out and doing new things?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? STAYHOME { get; set; }

        [Display(Name = "Do you feel you have more problems with memory than most?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? MEMPROB { get; set; }

        [Display(Name = "Do you think it is wonderful to be alive now?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? WONDRFUL { get; set; }

        [Display(Name = "Do you feel pretty worthless the way you are now?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? WRTHLESS { get; set; }

        [Display(Name = "Do you feel full of energy?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? ENERGY { get; set; }

        [Display(Name = "Do you feel that your situation is hopeless?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? HOPELESS { get; set; }

        [Display(Name = "Do you think that most people are better off than you are?")]
        [RegularExpression("(0|1|9)", ErrorMessage = "(0-1, 9)")]
        public int? BETTER { get; set; }

        [Display(Name = "Sum of all circled answers for Total GDS Score")]
        [RegularExpression("(1[0-5]|88)", ErrorMessage = "(0-15, 88)")]
        public int? GDS { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

