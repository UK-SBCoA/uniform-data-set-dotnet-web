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
        public int? NORMEXAM { get; set; }

        [Display(Name = "Parkinsonian signs")]
        public int? PARKSIGN { get; set; }

        [Display(Name = "Resting tremor — left arm")]
        public int? RESTTRL { get; set; }

        [Display(Name = "Resting tremor — right arm")]
        public int? RESTTRR { get; set; }

        [Display(Name = "Slowing of fine motor movements — left side")]
        public int? SLOWINGL { get; set; }

        [Display(Name = "Slowing of fine motor movements — right side")]
        public int? SLOWINGR { get; set; }

        [Display(Name = "Rigidity — left arm")]
        public int? RIGIDL { get; set; }

        [Display(Name = "Rigidity — right arm")]
        public int? RIGIDR { get; set; }

        [Display(Name = "Bradykinesia")]
        public int? BRADY { get; set; }

        [Display(Name = "Parkinsonian gait disorder")]
        public int? PARKGAIT { get; set; }

        [Display(Name = "Postural instability")]
        public int? POSTINST { get; set; }

        [Display(Name = "Neurological sign considered by examiner to be most likely consistent with cerebrovascular disease")]
        public int? CVDSIGNS { get; set; }

        [Display(Name = "Cortical cognitive deficit (e.g., aphasia, apraxia, neglect)")]
        public int? CORTDEF { get; set; }

        [Display(Name = "Focal or other neurological findings consistent with SIVD (subcortical ischemic vascular dementia)")]
        public int? SIVDFIND { get; set; }

        [Display(Name = "Motor (may include weakness of combination of face, arm, and leg; reflex changes, etc.) — left side")]
        public int? CVDMOTL { get; set; }

        [Display(Name = "Motor (may include weakness of combination of face, arm, and leg; reflex changes, etc.) — right side")]
        public int? CVDMOTR { get; set; }

        [Display(Name = "Cortical visual field loss — left side")]
        public int? CORTVISL { get; set; }

        [Display(Name = "Cortical visual field loss — right side")]
        public int? CORTVISR { get; set; }

        [Display(Name = "Somatosensory loss — left side")]
        public int? SOMATL { get; set; }

        [Display(Name = "Somatosensory loss — right side")]
        public int? SOMATR { get; set; }

        [Display(Name = "Higher cortical visual problem suggesting posterior cortical atrophy (e.g., prosopagnosia, simultagnosia, Balint’s syndrome) or apraxia of gaze")]
        public int? POSTCORT { get; set; }

        [Display(Name = "Findings suggestive of progressive supranuclear palsy (PSP), corticobasal syndrome, or other related disorders")]
        public int? PSPCBS { get; set; }

        [Display(Name = "Eye movement changes consistent with PSP")]
        public int? EYEPSP { get; set; }

        [Display(Name = "Dysarthria consistent with PSP")]
        public int? DYSPSP { get; set; }

        [Display(Name = "Axial rigidity consistent with PSP")]
        public int? AXIALPSP { get; set; }

        [Display(Name = "Gait disorder consistent with PSP")]
        public int? GAITPSP { get; set; }

        [Display(Name = "Apraxia of speech")]
        public int? APRAXSP { get; set; }

        [Display(Name = "Apraxia consistent with CBS — left side")]
        public int? APRAXL { get; set; }

        [Display(Name = "Apraxia consistent with CBS — right side")]
        public int? APRAXR { get; set; }

        [Display(Name = "Cortical sensory deficits consistent with CBS — left side")]
        public int? CORTSENL { get; set; }

        [Display(Name = "Cortical sensory deficits consistent with CBS — right side")]
        public int? CORTSENR { get; set; }

        [Display(Name = "Ataxia consistent with CBS — left side")]
        public int? ATAXL { get; set; }

        [Display(Name = "Ataxia consistent with CBS — right side")]
        public int? ATAXR { get; set; }

        [Display(Name = "Alien limb consistent with CBS — left side")]
        public int? ALIENLML { get; set; }

        [Display(Name = "Alien limb consistent with CBS — right side")]
        public int? ALIENLMR { get; set; }

        [Display(Name = "Dystonia consistent with CBS, PSP, or related disorder — left side")]
        public int? DYSTONL { get; set; }

        [Display(Name = "Dystonia consistent with CBS, PSP, or related disorder — right side")]
        public int? DYSTONR { get; set; }

        [Display(Name = "Myoclonus consistent with CBS — left side")]
        public int? MYOCLLT { get; set; }

        [Display(Name = "Myoclonus consistent with CBS — right side")]
        public int? MYOCLRT { get; set; }

        [Display(Name = "Findings suggesting ALS (e.g., muscle wasting, fasciculations, upper motor and/or lower motor neuron signs)")]
        public int? ALSFIND { get; set; }

        [Display(Name = "Normal pressure hydrocephalus: gait apraxia")]
        public int? GAITNPH { get; set; }

        [Display(Name = "Other findings (e.g., cerebella ataxia, chorea, myoclonus) (NOTE: For this question, do not specify symptoms that have already been checked above)")]
        public int? OTHNEUR { get; set; }

        [Display(Name = "Yes (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHNEUR), "1", ErrorMessage = "Specify other findings")]
        [SpecialCharacter]
        public string? OTHNEURX { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

