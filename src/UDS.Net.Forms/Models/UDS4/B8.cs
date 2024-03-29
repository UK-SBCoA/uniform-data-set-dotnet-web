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
        [RequiredOnComplete]
        public int? NEUREXAM { get; set; }

        [Display(Name = "Were there abnormal exam findings?")]
        public int? NORMNREXAM { get; set; }

        [Display(Name = "Parkinsonian Signs")]
        public int? PARKSIGN { get; set; }

        [Display(Name = "Slowing of fine motor movements")]
        public int? SLOWINGFM { get; set; }

        [Display(Name = "Limb tremor at rest")]
        public int? TREMREST { get; set; }

        [Display(Name = "Limb tremor - postural")]
        public int? TREMPOST { get; set; }

        [Display(Name = "Limb tremor - kinetic")]
        public int? TREMKINE { get; set; }

        [Display(Name = "Limb rigidity - arm")]
        public int? RIGIDARM { get; set; }

        [Display(Name = "Limb rigidity - leg")]
        public int? RIGIDLEG { get; set; }

        [Display(Name = "Limb dystonia - arm")]
        public int? DYSTARM { get; set; }

        [Display(Name = "Limb dystonia - leg")]
        public int? DYSTLEG { get; set; }

        [Display(Name = "Chorea")]
        public int? CHOREA { get; set; }

        [Display(Name = "Decrement in amplitude of fine motor movements")]
        public int? AMPMOTOR { get; set; }

        [Display(Name = "Axial rigidity")]
        public int? AXIALRIG { get; set; }

        [Display(Name = "Postural instability")]
        public int? POSTINST { get; set; }

        [Display(Name = "Facial masking")]
        public int? MASKING { get; set; }

        [Display(Name = "Stooped posture")]
        public int? STOOPED { get; set; }

        [Display(Name = "Cortical/Pyramidal/Other Signs")]
        public int? OTHERSIGN { get; set; }

        [Display(Name = "Limb apraxia")]
        public int? LIMBAPRAX { get; set; }

        [Display(Name = "Face or limb findings in UMN distribution")]
        public int? UMNDIST { get; set; }

        [Display(Name = "Face or limb findings in an LMN distribution")]
        public int? LMNDIST { get; set; }

        [Display(Name = "Visual field cut")]
        public int? VFIELDCUT { get; set; }

        [Display(Name = "Limb ataxia")]
        public int? LIMBATAX { get; set; }

        [Display(Name = "Myoclonus")]
        public int? MYOCLON { get; set; }

        [Display(Name = "Unilateral Somatosensory Loss (localized to the brain; disregard sensory changes localized to the spinal cord or peripheral nerves)")]
        public int? UNISOMATO { get; set; }

        [Display(Name = "Aphasia (disregard complaints of mild dysnomia if not viewed as reflecting a clinically significant change)")]
        public int? APHASIA { get; set; }

        [Display(Name = "Alien limb phenomenon")]
        public int? ALIENLIMB { get; set; }

        [Display(Name = "Hemispatial neglect")]
        public int? HSPATNEG { get; set; }

        [Display(Name = "Prosopagnosia")]
        public int? PSPOAGNO { get; set; }

        [Display(Name = "Simultanagnosia")]
        public int? SMTAGNO { get; set; }

        [Display(Name = "Optic ataxia")]
        public int? OPTICATAX { get; set; }

        [Display(Name = "Apraxia of gaze")]
        public int? APRAXGAZE { get; set; }

        [Display(Name = "Vertical +/- horizontal gaze palsy")]
        public int? VHGAZEPAL { get; set; }

        [Display(Name = "Dysarthria*")]
        public int? DYSARTH { get; set; }

        [Display(Name = "Apraxia of speech")]
        public int? APRAXSP { get; set; }

        [Display(Name = "Gait")]
        public int? GAITABN { get; set; }

        [Display(Name = "Finding")]
        public int? GAITFIND { get; set; }

        [MaxLength(60)]
        [ProhibitedCharacters]
        [RequiredIf(nameof(GAITFIND), "7", ErrorMessage = "Please indicate other finding")]
        public string? GAITOTHRX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (Status == Services.Enums.FormStatus.Complete)
            //{
            //    if (NORMEXAM.HasValue)
            //    {
            //        if (NORMEXAM.Value == 1)
            //        {
            //            // at least one of the syndromes must be indicated
            //            int count = 0;

            //            if (PARKSIGN.HasValue && PARKSIGN.Value == 1)
            //                count++;

            //            if (CVDSIGNS.HasValue && CVDSIGNS.Value == 1)
            //                count++;

            //            if (POSTCORT.HasValue && POSTCORT.Value == 1)
            //                count++;

            //            if (PSPCBS.HasValue && PSPCBS.Value == 1)
            //                count++;

            //            if (ALSFIND.HasValue && ALSFIND.Value == 1)
            //                count++;

            //            if (GAITNPH.HasValue && GAITNPH.Value == 1)
            //                count++;

            //            if (OTHNEUR.HasValue && OTHNEUR.Value == 1)
            //                count++;

            //            if (count == 0)
            //                yield return new ValidationResult("If abnormal findings were consistent with syndromes, at least one must be selected.", new[] { nameof(NORMEXAM) });

            //        }
            //        else if (NORMEXAM.Value == 2)
            //        {
            //            if (OTHNEUR.HasValue && OTHNEUR != 1)
            //                yield return new ValidationResult("If abnormal findings were consistent with age-associated changes or irrelevant to dementing disorders, finding must be indicated.", new[] { nameof(OTHNEUR) });
            //        }
            //    }
            //}

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

