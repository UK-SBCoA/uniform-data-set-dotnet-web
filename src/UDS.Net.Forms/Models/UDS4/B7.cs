﻿using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B7 : FormModel
    {
        [Display(Name = "Writing checks, paying bills, or balancing a checkbook")]
        [RequiredOnFinalized]
        public int? BILLS { get; set; }

        [Display(Name = "Assembling tax records, business affairs, or other papers")]
        [RequiredOnFinalized]
        public int? TAXES { get; set; }

        [Display(Name = "Shopping alone for clothes, household necessities, or groceries")]
        [RequiredOnFinalized]
        public int? SHOPPING { get; set; }

        [Display(Name = "Playing a game of skill such as bridge or chess, working on a hobby")]
        [RequiredOnFinalized]
        public int? GAMES { get; set; }

        [Display(Name = "Heating water, making a cup of coffee, turning off the stove")]
        [RequiredOnFinalized]
        public int? STOVE { get; set; }

        [Display(Name = "Preparing a balanced meal")]
        [RequiredOnFinalized]
        public int? MEALPREP { get; set; }

        [Display(Name = "Keeping track of current events")]
        [RequiredOnFinalized]
        public int? EVENTS { get; set; }

        [Display(Name = "Paying attention to and understanding a TV program, book, or magazine")]
        [RequiredOnFinalized]
        public int? PAYATTN { get; set; }

        [Display(Name = "Remembering appointments, family occasions, holidays, medications")]
        [RequiredOnFinalized]
        public int? REMDATES { get; set; }

        [Display(Name = "Traveling out of the neighborhood, driving, or arranging to take public transportation")]
        [RequiredOnFinalized]
        public int? TRAVEL { get; set; }

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

