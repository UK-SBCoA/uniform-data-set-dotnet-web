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
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? CANCER { get; set; }

        [Display(Name = "If yes, specify primary site")]
        [RequiredIf(nameof(CANCER), "1", ErrorMessage = "Specify primary site")]
        [RequiredIf(nameof(CANCER), "2", ErrorMessage = "Specify primary site")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? CANCSITE { get; set; }

        [Display(Name = "Diabetes")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? DIABET { get; set; }

        [Display(Name = "Myocardial infarct")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? MYOINF { get; set; }

        [Display(Name = "Congestive heart failure")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? CONGHRT { get; set; }

        [Display(Name = "Atrial fibrillation")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? AFIBRILL { get; set; }

        [Display(Name = "Hypertension")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? HYPERT { get; set; }

        [Display(Name = "Angina")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? ANGINA { get; set; }

        [Display(Name = "Hypercholesterolemia")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? HYPCHOL { get; set; }

        [Display(Name = "B12 deficiency")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? VB12DEF { get; set; }

        [Display(Name = "Thyroid disease")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? THYDIS { get; set; }

        [Display(Name = "Arthritis")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? ARTH { get; set; }

        [Display(Name = "If yes, what type?")]
        [RequiredIf(nameof(ARTH), "1", ErrorMessage = "Specify arthritis type")]
        public int? ARTYPE { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(ARTYPE), "3", ErrorMessage = "Specify arthritis")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? ARTYPEX { get; set; }

        [Display(Name = "Upper extremity")]
        public bool ARTUPEX { get; set; }

        [Display(Name = "Lower extremity")]
        public bool ARTLOEX { get; set; }

        [Display(Name = "Spine")]
        public bool ARTSPIN { get; set; }

        [Display(Name = "Unknown")]
        public bool ARTUNKN { get; set; }

        [Display(Name = "Incontinence — urinary")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? URINEINC { get; set; }

        [Display(Name = "Incontinence — bowel")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? BOWLINC { get; set; }

        [Display(Name = "Sleep apnea")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? SLEEPAP { get; set; }

        [Display(Name = "REM sleep behavior disorder (RBD)")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? REMDIS { get; set; }

        [Display(Name = "Hyposomnia/insomnia")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? HYPOSOM { get; set; }

        [Display(Name = "Other sleep disorder")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? SLEEPOTH { get; set; }

        [Display(Name = "Other sleep disorder (specify)")]
        [RequiredIf(nameof(SLEEPOTH), "1", ErrorMessage = "Specify antibody")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? SLEEPOTX { get; set; }

        [Display(Name = "Carotid procedure: angioplasty, endarterectomy, or stent")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? ANGIOCP { get; set; }

        [Display(Name = "Percutaneous coronary intervention: angioplasty and/or stent")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? ANGIOPCI { get; set; }

        [Display(Name = "Procedure: pacemaker and/or defibrillator")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? PACEMAKE { get; set; }

        [Display(Name = "Procedure: heart valve replacement or repair")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? HVALVE { get; set; }

        [Display(Name = "Antibody-mediated encephalopathy")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? ANTIENC { get; set; }

        [Display(Name = "Specify antibody")]
        [RequiredIf(nameof(ANTIENC), "1", ErrorMessage = "Specify antibody")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? ANTIENCX { get; set; }

        [Display(Name = "Other medical conditions or procedures not listed above")]
        [RequiredOnComplete(ErrorMessage = "Response required")]
        public int? OTHCOND { get; set; }

        [Display(Name = "If yes, specify")]
        [RequiredIf(nameof(OTHCOND), "1", ErrorMessage = "Specify other medical conditions or procedures")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? OTHCONDX { get; set; }

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

