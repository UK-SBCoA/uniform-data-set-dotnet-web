using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class B8 : FormModel
    {
        [Display(Name = "Were there abnormal neurological exam findings?")]
        [RequiredOnComplete]
        public int? NORMEXAM { get; set; }

        [Display(Name = "Parkinsonian signs")]
        [RequiredIf(nameof(NORMEXAM), "1", ErrorMessage = "Are parkinsonian signs indicated?")]
        public int? PARKSIGN { get; set; }

        [Display(Name = "Resting tremor — left arm")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify resting tremor - left arm")]
        public int? RESTTRL { get; set; }

        [Display(Name = "Resting tremor — right arm")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify resting tremor - right arm")]
        public int? RESTTRR { get; set; }

        [Display(Name = "Slowing of fine motor movements — left side")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify slowing of fine motor movements - left side")]
        public int? SLOWINGL { get; set; }

        [Display(Name = "Slowing of fine motor movements — right side")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify slowing of fine motor movements - right side")]
        public int? SLOWINGR { get; set; }

        [Display(Name = "Rigidity — left arm")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify rigidity - left arm")]
        public int? RIGIDL { get; set; }

        [Display(Name = "Rigidity — right arm")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify rigidity - right arm")]
        public int? RIGIDR { get; set; }

        [Display(Name = "Bradykinesia")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify bradykinesia indication.")]
        public int? BRADY { get; set; }

        [Display(Name = "Parkinsonian gait disorder")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify parkinsonian gait disorder indication.")]
        public int? PARKGAIT { get; set; }

        [Display(Name = "Postural instability")]
        [RequiredIf(nameof(PARKSIGN), "1", ErrorMessage = "Specify postural instability indication.")]
        public int? POSTINST { get; set; }

        [Display(Name = "Neurological sign considered by examiner to be most likely consistent with cerebrovascular disease")]
        [RequiredIf(nameof(NORMEXAM), "1", ErrorMessage = "Is cerrebrovascular disease indicated?")]
        public int? CVDSIGNS { get; set; }

        [Display(Name = "Cortical cognitive deficit (e.g., aphasia, apraxia, neglect)")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? CORTDEF { get; set; }

        [Display(Name = "Focal or other neurological findings consistent with SIVD (subcortical ischemic vascular dementia)")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? SIVDFIND { get; set; }

        [Display(Name = "Motor (may include weakness of combination of face, arm, and leg; reflex changes, etc.) — left side")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? CVDMOTL { get; set; }

        [Display(Name = "Motor (may include weakness of combination of face, arm, and leg; reflex changes, etc.) — right side")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? CVDMOTR { get; set; }

        [Display(Name = "Cortical visual field loss — left side")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? CORTVISL { get; set; }

        [Display(Name = "Cortical visual field loss — right side")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? CORTVISR { get; set; }

        [Display(Name = "Somatosensory loss — left side")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? SOMATL { get; set; }

        [Display(Name = "Somatosensory loss — right side")]
        [RequiredIf(nameof(CVDSIGNS), "1", ErrorMessage = "Answer is required.")]
        public int? SOMATR { get; set; }

        [Display(Name = "Higher cortical visual problem suggesting posterior cortical atrophy (e.g., prosopagnosia, simultagnosia, Balint’s syndrome) or apraxia of gaze")]
        [RequiredIf(nameof(NORMEXAM), "1", ErrorMessage = "Answer is required.")]
        public int? POSTCORT { get; set; }

        [Display(Name = "Findings suggestive of progressive supranuclear palsy (PSP), corticobasal syndrome, or other related disorders")]
        [RequiredIf(nameof(NORMEXAM), "1", ErrorMessage = "Answer is required.")]
        public int? PSPCBS { get; set; }

        [Display(Name = "Eye movement changes consistent with PSP")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? EYEPSP { get; set; }

        [Display(Name = "Dysarthria consistent with PSP")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? DYSPSP { get; set; }

        [Display(Name = "Axial rigidity consistent with PSP")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? AXIALPSP { get; set; }

        [Display(Name = "Gait disorder consistent with PSP")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? GAITPSP { get; set; }

        [Display(Name = "Apraxia of speech")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? APRAXSP { get; set; }

        [Display(Name = "Apraxia consistent with CBS — left side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? APRAXL { get; set; }

        [Display(Name = "Apraxia consistent with CBS — right side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? APRAXR { get; set; }

        [Display(Name = "Cortical sensory deficits consistent with CBS — left side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? CORTSENL { get; set; }

        [Display(Name = "Cortical sensory deficits consistent with CBS — right side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? CORTSENR { get; set; }

        [Display(Name = "Ataxia consistent with CBS — left side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? ATAXL { get; set; }

        [Display(Name = "Ataxia consistent with CBS — right side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? ATAXR { get; set; }

        [Display(Name = "Alien limb consistent with CBS — left side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? ALIENLML { get; set; }

        [Display(Name = "Alien limb consistent with CBS — right side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? ALIENLMR { get; set; }

        [Display(Name = "Dystonia consistent with CBS, PSP, or related disorder — left side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? DYSTONL { get; set; }

        [Display(Name = "Dystonia consistent with CBS, PSP, or related disorder — right side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? DYSTONR { get; set; }

        [Display(Name = "Myoclonus consistent with CBS — left side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? MYOCLLT { get; set; }

        [Display(Name = "Myoclonus consistent with CBS — right side")]
        [RequiredIf(nameof(PSPCBS), "1", ErrorMessage = "Answer is required.")]
        public int? MYOCLRT { get; set; }

        [Display(Name = "Findings suggesting ALS (e.g., muscle wasting, fasciculations, upper motor and/or lower motor neuron signs)")]
        [RequiredIf(nameof(NORMEXAM), "1", ErrorMessage = "Answer is required.")]
        public int? ALSFIND { get; set; }

        [Display(Name = "Normal pressure hydrocephalus: gait apraxia")]
        [RequiredIf(nameof(NORMEXAM), "1", ErrorMessage = "Answer is required.")]
        public int? GAITNPH { get; set; }

        [Display(Name = "Other findings (e.g., cerebella ataxia, chorea, myoclonus) (NOTE: For this question, do not specify symptoms that have already been checked above)")]
        [RequiredIf(nameof(NORMEXAM), "1", ErrorMessage = "Indicate other finding.")]
        [RequiredIf(nameof(NORMEXAM), "2", ErrorMessage = "Indicate other finding.")]
        public int? OTHNEUR { get; set; }

        [Display(Name = "Yes (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHNEUR), "1", ErrorMessage = "Specify other findings")]
        [SpecialCharacter]
        public string? OTHNEURX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == Services.Enums.FormStatus.Complete)
            {
                if (NORMEXAM.HasValue)
                {
                    if (NORMEXAM.Value == 1)
                    {
                        // at least one of the syndromes must be indicated
                        int count = 0;

                        if (PARKSIGN.HasValue && PARKSIGN.Value == 1)
                            count++;

                        if (CVDSIGNS.HasValue && CVDSIGNS.Value == 1)
                            count++;

                        if (POSTCORT.HasValue && POSTCORT.Value == 1)
                            count++;

                        if (PSPCBS.HasValue && PSPCBS.Value == 1)
                            count++;

                        if (ALSFIND.HasValue && ALSFIND.Value == 1)
                            count++;

                        if (GAITNPH.HasValue && GAITNPH.Value == 1)
                            count++;

                        if (OTHNEUR.HasValue && OTHNEUR.Value == 1)
                            count++;

                        if (count == 0)
                            yield return new ValidationResult("If abnormal findings were consistent with syndromes, at least one must be selected.", new[] { nameof(NORMEXAM) });

                    }
                    else if (NORMEXAM.Value == 2)
                    {
                        if (OTHNEUR.HasValue && OTHNEUR != 1)
                            yield return new ValidationResult("If abnormal findings were consistent with age-associated changes or irrelevant to dementing disorders, finding must be indicated.", new[] { nameof(OTHNEUR) });
                    }
                }
            }

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

