using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.TagHelpers;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A4aTreatment
    {
        public int TreatmentIndex { get; set; }

        [Display(Name = "Amyloid beta")]
        public bool? TARGETAB { get; set; }

        [Display(Name = "Tau")]
        public bool? TARGETTAU { get; set; }

        [Display(Name = "Inflammation")]
        public bool? TARGETINF { get; set; }

        [Display(Name = "Synaptic plasticity/neuroprotection")]
        public bool? TARGETSYN { get; set; }

        [Display(Name = "Other target(s)")]
        public bool? TARGETOTH { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        //[RequiredOnComplete(ErrorMessage = "Please specify other target.")]
        public string? TARGETOTX { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? TRTTRIAL { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? NCTNUM { get; set; }

        [Range(1, 12)]
        public int? STARTMO { get; set; }

        public int? STARTYEAR { get; set; }

        [RegularExpression("^([1-9]|1[0-2]|88|99)$", ErrorMessage = "Valid range is 1 - 12 or 88 or 99")]
        public int? ENDMO { get; set; }


        public int? ENDYEAR { get; set; }

        public int? CARETRIAL { get; set; }

        public int? TRIALGRP { get; set; }

        public List<RadioListItem> CARETRIALListItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Clinical care", "1"),
            new RadioListItem("Clinical trial", "2"),
            new RadioListItem("Clinical care and clinical trial", "3")
        };

        public List<RadioListItem> TRIALGRPistItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Active treatment", "1"),
            new RadioListItem("Placebo", "2"),
            new RadioListItem("Unknown", "9")
        };
    }
}
