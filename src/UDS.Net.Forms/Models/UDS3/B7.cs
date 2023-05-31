using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    public class B7 : FormModel
    {

        public int? BILLS { get; set; }

        public int? TAXES { get; set; }

        public int? SHOPPING { get; set; }

        public int? GAMES { get; set; }

        public int? STOVE { get; set; }

        public int? MEALPREP { get; set; }

        public int? EVENTS { get; set; }

        public int? PAYATTN { get; set; }

        public int? REMDATES { get; set; }

        public int? TRAVEL { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

