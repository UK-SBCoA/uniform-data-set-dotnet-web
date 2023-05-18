using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace UDS.Net.Forms.Models.UDS3
{
    public class A3 : FormModel
    {
        [Display(Name = "Are there affected first-degree relatives (biological parents, full siblings, or biological children)?")]
        [RegularExpression("^(0|1|9)$")]
        public int? AFFFAMM { get; set; } // initial visits

        public int? NWINFMUT { get; set; } // follow-up visits

        [Display(Name = "In this family, is there evidence for an AD mutation? If Yes, select predominant mutation.")]
        [RegularExpression("^(0-3|8|9)$")]
        public int? FADMUT { get; set; }

        [Display(Name = "If Yes, Other (specify)")]
        [MaxLength(60)]
        public string FADMUTX { get; set; }

        [Display(Name = "Source of evidence for AD mutation")]
        [RegularExpression("^(1-3|8|9)$")]
        public int? FADMUSO { get; set; }

        [Display(Name = "If other, (specify)")]
        [MaxLength(60)]
        public string FADMUSOX { get; set; }

        [Display(Name = "In this family, is there evidence for an FTLD mutation? If Yes, select predominant mutation")]
        [RegularExpression("^(0-4|8|9)$")]
        public int? FFTDMUT { get; set; }

        [Display(Name = "If Yes, Other (specify)")]
        [MaxLength(60)]
        public string FFTDMUTX { get; set; }

        [Display(Name = "Source of evidence for FTLD mutation")]
        [RegularExpression("^(1-3|8|9)$")]
        public int? FFTDMUSO { get; set; }

        [Display(Name = "If other, (specify)")]
        [MaxLength(60)]
        public string FFTDMUSX { get; set; }

        [Display(Name = "In this family, is there evidence for a mutation other than an AD or FTLD mutation?")]
        [RegularExpression("^(0|1|9)$")]
        public int? FOTHMUT { get; set; }

        [Display(Name = "If Yes, specify")]
        [MaxLength(60)]
        public string FOTHMUTX { get; set; }

        [Display(Name = "Source of evidence for other mutation")]
        [RegularExpression("^(1-3|8|9)$")]
        public int? FOTHMUSO { get; set; }

        [Display(Name = "If other, specify")]
        [MaxLength(60)]
        public string FOTHMUSX { get; set; }

        [Display(Name = "Mother — birth month")]
        [RegularExpression("^(1-12|99)$")]
        public int? MOMMOB { get; set; }

        [Display(Name = "Mother — birth year")]
        [Remote("ValidateYear", "A3", "UDS3")]
        public int? MOMYOB { get; set; }

        [Display(Name = "Mother — age at death")]
        [RegularExpression("^(0-110|888|999)$")]
        public int? MOMDAGE { get; set; }

        [Display(Name = "Mother — neurological problem")]
        [RegularExpression("^(1-5|8|9)$")]
        public int? MOMNEUR { get; set; }

        [Display(Name = "Mother — primary diagnosis")]
        [RegularExpression("^(40-490|999)$")]
        public int? MOMPRDX { get; set; }

        [Display(Name = "Mother — method of evaluation")]
        [RegularExpression("^(1-7)$")]
        public int? MOMMOE { get; set; }

        [Display(Name = "Mother — age of onset")]
        [RegularExpression("^(0-110|999)$")]
        public int? MOMAGEO { get; set; }

        public int? DADMOB { get; set; }
        public int? DADYOB { get; set; }
        public int? DADDAGE { get; set; }
        public int? DADNEUR { get; set; }
        public int? DADPRDX { get; set; }
        public int? DADMOE { get; set; }
        public int? DADAGEO { get; set; }
        public int? SIBS { get; set; }
        public int? KIDS { get; set; }
    }
}

