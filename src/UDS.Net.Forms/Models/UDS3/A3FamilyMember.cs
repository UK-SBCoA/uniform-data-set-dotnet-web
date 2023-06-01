using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A3FamilyMember
    {
        public int FamilyMemberIndex { get; set; }

        [Display(Name = "")]
        public int? MOB { get; set; }

        [Display(Name = "")]
        public int? YOB { get; set; }

        [Display(Name = "")]
        public int? AGD { get; set; }

        [Display(Name = "")]
        public int? NEU { get; set; }

        [Display(Name = "")]
        public int? PDX { get; set; }

        [Display(Name = "")]
        public int? MOE { get; set; }

        [Display(Name = "")]
        public int? AGO { get; set; }

    }
}

