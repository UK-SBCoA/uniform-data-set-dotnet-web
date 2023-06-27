using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class D2 : FormModel
    {
        [Display(Name = "Cancer (excluding non-melanoma skin cancer), primary or metastatic")]
        public int? CANCER { get; set; }

        [Display(Name = "If yes, specify primary site")]
        [RequiredIf(nameof(CANCER), "1", ErrorMessage = "Specify primary site")]
        [RequiredIf(nameof(CANCER), "2", ErrorMessage = "Specify primary site")]
        [MaxLength(60)]
        public string? CANCSITE { get; set; }

        [Display(Name = "Diabetes")]
        public int? DIABET { get; set; }

        [Display(Name = "Myocardial infarct")]
        public int? MYOINF { get; set; }

        [Display(Name = "Congestive heart failure")]
        public int? CONGHRT { get; set; }

        [Display(Name = "Atrial fibrillation")]
        public int? AFIBRILL { get; set; }

        [Display(Name = "Hypertension")]
        public int? HYPERT { get; set; }

        [Display(Name = "Angina")]
        public int? ANGINA { get; set; }

        [Display(Name = "Hypercholesterolemia")]
        public int? HYPCHOL { get; set; }

        [Display(Name = "B12 deficiency")]
        public int? VB12DEF { get; set; }

        [Display(Name = "Thyroid disease")]
        public int? THYDIS { get; set; }

        [Display(Name = "Arthritis")]
        public int? ARTH { get; set; }

        [Display(Name = "If yes, what type?")]
        [RequiredIf(nameof(ARTH), "1", ErrorMessage = "Specify arthritis type")]
        public int? ARTYPE { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(ARTYPE), "3", ErrorMessage = "Specify arthritis")]
        [MaxLength(60)]
        public string? ARTYPEX { get; set; }

        [Display(Name = "Upper extremity")]
        public int? ARTUPEX { get; set; }

        [Display(Name = "Lower extremity")]
        public int? ARTLOEX { get; set; }

        [Display(Name = "Spine")]
        public int? ARTSPIN { get; set; }

        [Display(Name = "Unknown")]
        public int? ARTUNKN { get; set; }

        [Display(Name = "Incontinence — urinary")]
        public int? URINEINC { get; set; }

        [Display(Name = "Incontinence — bowel")]
        public int? BOWLINC { get; set; }

        [Display(Name = "Sleep apnea")]
        public int? SLEEPAP { get; set; }

        [Display(Name = "REM sleep behavior disorder (RBD)")]
        public int? REMDIS { get; set; }

        [Display(Name = "Hyposomnia/insomnia")]
        public int? HYPOSOM { get; set; }

        [Display(Name = "Other sleep disorder")]
        public int? SLEEPOTH { get; set; }

        [Display(Name = "Other sleep disorder (specify)")]
        [RequiredIf(nameof(SLEEPOTH), "1", ErrorMessage = "Specify antibody")]
        [MaxLength(60)]
        public string? SLEEPOTX { get; set; }

        [Display(Name = "Carotid procedure: angioplasty, endarterectomy, or stent")]
        public int? ANGIOCP { get; set; }

        [Display(Name = "Percutaneous coronary intervention: angioplasty and/or stent")]
        public int? ANGIOPCI { get; set; }

        [Display(Name = "Procedure: pacemaker and/or defibrillator")]
        public int? PACEMAKE { get; set; }

        [Display(Name = "Procedure: heart valve replacement or repair")]
        public int? HVALVE { get; set; }

        [Display(Name = "Antibody-mediated encephalopathy")]
        public int? ANTIENC { get; set; }

        [Display(Name = "Antibody-mediated encephalopathy")]
        [RequiredIf(nameof(ANTIENC), "1", ErrorMessage = "Specify antibody")]
        [MaxLength(60)]
        public string? ANTIENCX { get; set; }

        [Display(Name = "Other medical conditions or procedures not listed above")]
        public int? OTHCOND { get; set; }

        [Display(Name = "If yes, specify")]
        [RequiredIf(nameof(OTHCOND), "1", ErrorMessage = "Specify other medical conditions or procedures")]
        [MaxLength(60)]
        public string? OTHCONDX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

