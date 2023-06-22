﻿using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A3FamilyMember
    {
        public int FamilyMemberIndex { get; set; }

        [Display(Name = "Birth month")]
        [BirthMonth(AllowUnknown = true)]
        public int? MOB { get; set; }

        [Display(Name = "Birth year")]
        [BirthYear(AllowUnknown = true)]
        public int? YOB { get; set; }

        [Display(Name = "Age at death")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|888|999)$", ErrorMessage = "Age at death must be 0-110, or 888 (N/A), or 999 (unknown)")]
        public int? AGD { get; set; }

        [Display(Name = "Primary neurological problem/psychiatric condition")]
        [RegularExpression("^([1-5]|8|9)$", ErrorMessage = "Neurological problem/psychiatric condition invalid. Please see reference.")]
        public int? NEU { get; set; }

        [Display(Name = "Primary Dx")]
        [Diagnosis]
        public int? PDX { get; set; }

        [Display(Name = "Method of evaluation")]
        [Range(1, 7)]
        public int? MOE { get; set; }

        [Display(Name = "Age of onset")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Age of onset must be 0-110, or 999 (unknown)")]
        public int? AGO { get; set; }

    }
}

