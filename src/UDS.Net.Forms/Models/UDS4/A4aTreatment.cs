using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A4aTreatment : FormModel
    {
        public int TreatmentIndex { get; set; }

        public bool? TARGETAB { get; set; }

        public bool? TARGETTAU { get; set; }

        public bool? TARGETINF { get; set; }

        public bool? TARGETSYN { get; set; }

        public bool? TARGETOTH { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? TARGETOTX { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? TRTTRIAL { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? NCTNUM { get; set; }

        public int? STARTMO { get; set; }

        public int? STARTYEAR { get; set; }

        public int? ENDMO { get; set; }

        public int? ENDYEAR { get; set; }

        public int? CARETRIAL { get; set; }

        public int? TRIALGRP { get; set; }


    }
}
