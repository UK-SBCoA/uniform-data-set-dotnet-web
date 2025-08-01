﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;
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
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? SATIS { get; set; }

        [Display(Name = "Have you dropped many of your activities and interests?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? DROPACT { get; set; }

        [Display(Name = "Do you feel that your life is empty?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? EMPTY { get; set; }

        [Display(Name = "Do you often get bored?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? BORED { get; set; }

        [Display(Name = "Are you in good spirits most of the time?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? SPIRITS { get; set; }

        [Display(Name = "Are you afraid that something bad is going to happen to you?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? AFRAID { get; set; }

        [Display(Name = "Do you feel happy most of the time?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? HAPPY { get; set; }

        [Display(Name = "Do you often feel helpless?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? HELPLESS { get; set; }

        [Display(Name = "Do you prefer to stay at home, rather than going out and doing new things?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? STAYHOME { get; set; }

        [Display(Name = "Do you feel you have more problems with memory than most?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? MEMPROB { get; set; }

        [Display(Name = "Do you think it is wonderful to be alive now?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? WONDRFUL { get; set; }

        [Display(Name = "Do you feel pretty worthless the way you are now?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? WRTHLESS { get; set; }

        [Display(Name = "Do you feel full of energy?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? ENERGY { get; set; }

        [Display(Name = "Do you feel that your situation is hopeless?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? HOPELESS { get; set; }

        [Display(Name = "Do you think that most people are better off than you are?")]
        [RequiredOnFinalized(ErrorMessage = "Answer required")]
        public int? BETTER { get; set; }

        [Display(Name = "Sum of all circled answers for Total GDS Score")]
        [RegularExpression("^([0-9]|1[0-5]|88)$", ErrorMessage = "(0-15, 88)")]
        [RequiredIf(nameof(NOGDS), "False", ErrorMessage = "Total GDS Score is required.")]
        public int? GDS { get; set; }

        [RequiredIf(nameof(NOGDS), "True", ErrorMessage = "If NOGDS checkbox is selected, then the total score must be 88")]
        [NotMapped]
        public bool? GDSNotCompleteChecked
        {
            get
            {
                if (GDS.HasValue && GDS.Value == 88)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredOnFinalized(ErrorMessage = "If fewer than 12 questions were answered NOGDS must be checked and the total score equal to \"88\"")]
        [NotMapped]
        public bool? NOGDSCheckedValidation
        {
            get
            {
                List<int?> GDSScoreValues = new List<int?>()
                {
                    SATIS,
                    DROPACT,
                    EMPTY,
                    BORED,
                    SPIRITS,
                    AFRAID,
                    HAPPY,
                    HELPLESS,
                    STAYHOME,
                    MEMPROB,
                    WONDRFUL,
                    WRTHLESS,
                    ENERGY,
                    HOPELESS,
                    BETTER
                };

                int answeredGDSCount = GDSScoreValues.Where(x => x.HasValue && x.Value != 9).Count();

                if (answeredGDSCount < 12 && (GDS != 88 || NOGDS != true))
                {
                    return null;
                }
                else if (answeredGDSCount >= 12 && (GDS == 88 || NOGDS == true))
                {
                    return null;
                }
                else
                {
                    return true;
                }
            }
        }

        [RequiredOnFinalized(ErrorMessage = "If NOGDS is selected the GDS total score must be equal to \"88\"")]
        [NotMapped]
        public bool? GDSSumAndNOGDSValidation
        {
            get
            {
                if (NOGDS && GDS.HasValue && GDS != 88)
                {
                    return null;
                }

                return true;
            }
        }

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

