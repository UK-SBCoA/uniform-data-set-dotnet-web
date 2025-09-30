using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B8 : FormModel
    {
        [Display(Name = "Which of the following was completed on this participant?")]
        [RequiredOnFinalized]
        public int? NEUREXAM { get; set; }

        [Display(Name = "Were there abnormal exam findings?")]
        [RequiredIfRegex(nameof(NEUREXAM), "(1|2|3)", ErrorMessage = "Were there abnormal exam findings?")]
        public int? NORMNREXAM { get; set; }

        [Display(Name = "Parkinsonian Signs")]
        [RequiredIf(nameof(NORMNREXAM), "1", ErrorMessage = "Please indicate Parkinsonian Signs")]
        public int? PARKSIGN { get; set; }

        [Display(Name = "Slowing of fine motor movements")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? SLOWINGFM { get; set; }

        [Display(Name = "Limb tremor at rest")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? TREMREST { get; set; }

        [Display(Name = "Limb tremor - postural")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? TREMPOST { get; set; }

        [Display(Name = "Limb tremor - kinetic")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? TREMKINE { get; set; }

        [Display(Name = "Limb rigidity - arm")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? RIGIDARM { get; set; }

        [Display(Name = "Limb rigidity - leg")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? RIGIDLEG { get; set; }

        [Display(Name = "Limb dystonia - arm")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? DYSTARM { get; set; }

        [Display(Name = "Limb dystonia - leg")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? DYSTLEG { get; set; }

        [Display(Name = "Chorea")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? CHOREA { get; set; }

        [Display(Name = "Decrement in amplitude of fine motor movements")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? AMPMOTOR { get; set; }

        [Display(Name = "Axial rigidity")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? AXIALRIG { get; set; }

        [Display(Name = "Postural instability")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? POSTINST { get; set; }

        [Display(Name = "Facial masking")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? MASKING { get; set; }

        [Display(Name = "Stooped posture")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? STOOPED { get; set; }

        [Display(Name = "Cortical/Pyramidal/Other Signs")]
        [RequiredIfRegex(nameof(PARKSIGN), "(0|1|8)", ErrorMessage = "Please indicate Cortical/Pyramidal/Other Signs.")]
        public int? OTHERSIGN { get; set; }

        [Display(Name = "Limb apraxia")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? LIMBAPRAX { get; set; }

        [Display(Name = "Face or limb findings in UMN distribution")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? UMNDIST { get; set; }

        [Display(Name = "Face or limb findings in an LMN distribution")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? LMNDIST { get; set; }

        [Display(Name = "Visual field cut")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? VFIELDCUT { get; set; }

        [Display(Name = "Limb ataxia")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? LIMBATAX { get; set; }

        [Display(Name = "Myoclonus")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? MYOCLON { get; set; }

        [Display(Name = "Unilateral Somatosensory Loss (localized to the brain; disregard sensory changes localized to the spinal cord or peripheral nerves)")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? UNISOMATO { get; set; }

        [Display(Name = "Aphasia (disregard complaints of mild dysnomia if not viewed as reflecting a clinically significant change)")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? APHASIA { get; set; }

        [Display(Name = "Alien limb phenomenon")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? ALIENLIMB { get; set; }

        [Display(Name = "Hemispatial neglect")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? HSPATNEG { get; set; }

        [Display(Name = "Prosopagnosia")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? PSPOAGNO { get; set; }

        [Display(Name = "Simultanagnosia")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? SMTAGNO { get; set; }

        [Display(Name = "Optic ataxia")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? OPTICATAX { get; set; }

        [Display(Name = "Apraxia of gaze")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? APRAXGAZE { get; set; }

        [Display(Name = "Vertical +/- horizontal gaze palsy")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? VHGAZEPAL { get; set; }

        [Display(Name = "Dysarthria*")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? DYSARTH { get; set; }

        [Display(Name = "Apraxia of speech")]
        [RequiredIf(nameof(OTHERSIGN), "1", ErrorMessage = "Please indicate findings.")]
        public int? APRAXSP { get; set; }

        [Display(Name = "Gait")]
        [RequiredIfRegex(nameof(OTHERSIGN), "(0|1|8)", ErrorMessage = "Please indicate Gait.")]
        public int? GAITABN { get; set; }

        [Display(Name = "Finding")]
        [RequiredIf(nameof(GAITABN), "1", ErrorMessage = "Please indicate Gait findings.")]
        public int? GAITFIND { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(GAITFIND), "7", ErrorMessage = "Please indicate other finding")]
        public string? GAITOTHRX { get; set; }

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

