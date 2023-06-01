using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B8 : FormModel
    {
        [Display(Name = "")]
        public int? NORMEXAM { get; set; }

        [Display(Name = "")]
        public int? PARKSIGN { get; set; }

        [Display(Name = "")]
        public int? RESTTRL { get; set; }

        [Display(Name = "")]
        public int? RESTTRR { get; set; }

        [Display(Name = "")]
        public int? SLOWINGL { get; set; }

        [Display(Name = "")]
        public int? SLOWINGR { get; set; }

        [Display(Name = "")]
        public int? RIGIDL { get; set; }

        [Display(Name = "")]
        public int? RIGIDR { get; set; }

        [Display(Name = "")]
        public int? BRADY { get; set; }

        [Display(Name = "")]
        public int? PARKGAIT { get; set; }

        [Display(Name = "")]
        public int? POSTINST { get; set; }

        [Display(Name = "")]
        public int? CVDSIGNS { get; set; }

        [Display(Name = "")]
        public int? CORTDEF { get; set; }

        [Display(Name = "")]
        public int? SIVDFIND { get; set; }

        [Display(Name = "")]
        public int? CVDMOTL { get; set; }

        [Display(Name = "")]
        public int? CVDMOTR { get; set; }

        [Display(Name = "")]
        public int? CORTVISL { get; set; }

        [Display(Name = "")]
        public int? CORTVISR { get; set; }

        [Display(Name = "")]
        public int? SOMATL { get; set; }

        [Display(Name = "")]
        public int? SOMATR { get; set; }

        [Display(Name = "")]
        public int? POSTCORT { get; set; }

        [Display(Name = "")]
        public int? PSPCBS { get; set; }

        [Display(Name = "")]
        public int? EYEPSP { get; set; }

        [Display(Name = "")]
        public int? DYSPSP { get; set; }

        [Display(Name = "")]
        public int? AXIALPSP { get; set; }

        [Display(Name = "")]
        public int? GAITPSP { get; set; }

        [Display(Name = "")]
        public int? APRAXSP { get; set; }

        [Display(Name = "")]
        public int? APRAXL { get; set; }

        [Display(Name = "")]
        public int? APRAXR { get; set; }

        [Display(Name = "")]
        public int? CORTSENL { get; set; }

        [Display(Name = "")]
        public int? CORTSENR { get; set; }

        [Display(Name = "")]
        public int? ATAXL { get; set; }

        [Display(Name = "")]
        public int? ATAXR { get; set; }

        [Display(Name = "")]
        public int? ALIENLML { get; set; }

        [Display(Name = "")]
        public int? ALIENLMR { get; set; }

        [Display(Name = "")]
        public int? DYSTONL { get; set; }

        [Display(Name = "")]
        public int? DYSTONR { get; set; }

        [Display(Name = "")]
        public int? MYOCLLT { get; set; }

        [Display(Name = "")]
        public int? MYOCLRT { get; set; }

        [Display(Name = "")]
        public int? ALSFIND { get; set; }

        [Display(Name = "")]
        public int? GAITNPH { get; set; }

        [Display(Name = "")]
        public int? OTHNEUR { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? OTHNEURX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

