using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    public class B3 : FormModel
    {
        [Display(Name = "(Optional) If the clinician completes the UPDRS examination and determines all items are normal, check this box. If\nthis box is checked, all items will default to 0 in the database.")]
        public bool? PDNORMAL { get; set; }

        [Display(Name = "Speech")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? SPEECH { get; set; }

        [Display(Name = "Speech untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(SPEECH), "8", ErrorMessage = "Please specify")]
        public string? SPEECHX { get; set; }

        [Display(Name = "Facial expression")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? FACEXP { get; set; }

        [Display(Name = "Facial expression untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(FACEXP), "8", ErrorMessage = "Please specify")]
        public string? FACEXPX { get; set; }

        [Display(Name = "Tremor at rest - face, lips, chin")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TRESTFAC { get; set; }

        [Display(Name = "Tremor at rest - face, lips, chin untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TRESTFAC), "8", ErrorMessage = "Please specify")]
        public string? TRESTFAX { get; set; }

        [Display(Name = "Tremor at rest - right hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TRESTRHD { get; set; }

        [Display(Name = "Tremor at rest - right hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TRESTRHD), "8", ErrorMessage = "Please specify")]
        public string? TRESTRHX { get; set; }

        [Display(Name = "Tremor at rest - left hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TRESTLHD { get; set; }

        [Display(Name = "Tremor at rest - left hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TRESTLHD), "8", ErrorMessage = "Please specify")]
        public string? TRESTLHX { get; set; }

        [Display(Name = "Tremor at rest - right foot")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TRESTRFT { get; set; }

        [Display(Name = "Tremor at rest - right foot untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TRESTRFT), "8", ErrorMessage = "Please specify")]
        public string? TRESTRFX { get; set; }

        [Display(Name = "Tremor at rest - left foot")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TRESTLFT { get; set; }

        [Display(Name = "Tremor at rest - left foot untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TRESTLFT), "8", ErrorMessage = "Please specify")]
        public string? TRESTLFX { get; set; }

        [Display(Name = "Action or postural tremor of hands - right hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TRACTRHD { get; set; }

        [Display(Name = "Action or postural tremor of hands - right hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TRACTRHD), "8", ErrorMessage = "Please specify")]
        public string? TRACTRHX { get; set; }

        [Display(Name = "Action or postural tremor of hands - left hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TRACTLHD { get; set; }

        [Display(Name = "Action or postural tremor of hands - left hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TRACTLHD), "8", ErrorMessage = "Please specify")]
        public string? TRACTLHX { get; set; }

        [Display(Name = "Rigidity - neck")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? RIGDNECK { get; set; }

        [Display(Name = "Rigidity - neck untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(RIGDNECK), "8", ErrorMessage = "Please specify")]
        public string? RIGDNEX { get; set; }

        [Display(Name = "Rigidity - right upper extremity")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? RIGDUPRT { get; set; }

        [Display(Name = "Rigidity - right upper extremity untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(RIGDUPRT), "8", ErrorMessage = "Please specify")]
        public string? RIGDUPRX { get; set; }

        [Display(Name = "Rigidity - left upper extremity")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? RIGDUPLF { get; set; }

        [Display(Name = "Rigidity - left upper extremity untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(RIGDUPLF), "8", ErrorMessage = "Please specify")]
        public string? RIGDUPLX { get; set; }

        [Display(Name = "Rigidity - right lower extremity")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? RIGDLORT { get; set; }

        [Display(Name = "Rigidity - right lower extremity untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(RIGDLORT), "8", ErrorMessage = "Please specify")]
        public string? RIGDLORX { get; set; }

        [Display(Name = "Rigidity - left lower extremity")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? RIGDLOLF { get; set; }

        [Display(Name = "Rigidity - left lower extremity untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(RIGDLOLF), "8", ErrorMessage = "Please specify")]
        public string? RIGDLOLX { get; set; }

        [Display(Name = "Finger taps - right hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TAPSRT { get; set; }

        [Display(Name = "Finger taps - right hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TAPSRT), "8", ErrorMessage = "Please specify")]
        public string? TAPSRTX { get; set; }

        [Display(Name = "Finger taps - left hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TAPSLF { get; set; }

        [Display(Name = "Finger taps - left hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(TAPSLF), "8", ErrorMessage = "Please specify")]
        public string? TAPSLFX { get; set; }

        [Display(Name = "Hand movements - right hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? HANDMOVR { get; set; }

        [Display(Name = "Hand movements - right hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(HANDMOVR), "8", ErrorMessage = "Please specify")]
        public string? HANDMVRX { get; set; }

        [Display(Name = "Hand movements - left hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? HANDMOVL { get; set; }

        [Display(Name = "Hand movements - left hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(HANDMOVL), "8", ErrorMessage = "Please specify")]
        public string? HANDMVLX { get; set; }

        [Display(Name = "Rapid alternating movement of hands - right hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? HANDALTR { get; set; }

        [Display(Name = "Rapid alternating movement of hands - right hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(HANDALTR), "8", ErrorMessage = "Please specify")]
        public string? HANDATRX { get; set; }

        [Display(Name = "Rapid alternating movement of hands - left hand")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? HANDALTL { get; set; }

        [Display(Name = "Rapid alternating movements of hands - left hand untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(HANDALTL), "8", ErrorMessage = "Please specify")]
        public string? HANDATLX { get; set; }

        [Display(Name = "Leg agility - right leg")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? LEGRT { get; set; }

        [Display(Name = "Leg agility - right leg untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(LEGRT), "8", ErrorMessage = "Please specify")]
        public string? LEGRTX { get; set; }

        [Display(Name = "Leg agility - left leg")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? LEGLF { get; set; }

        [Display(Name = "Leg agility - left leg untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(LEGLF), "8", ErrorMessage = "Please specify")]
        public string? LEGLFX { get; set; }

        [Display(Name = "Arising from chair (participant attempts to rise from a straight-backed chair, with arms folded across chest)")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? ARISING { get; set; }

        [Display(Name = "Arising from chair untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(ARISING), "8", ErrorMessage = "Please specify")]
        public string? ARISINGX { get; set; }

        [Display(Name = "Posture (response to sudden, strong posterior displacement produced by pull on shoulders while participant erect with eyes open and feet slightly apart; participant is prepared)")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? POSTURE { get; set; }

        [Display(Name = "Posture untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(POSTURE), "8", ErrorMessage = "Please specify")]
        public string? POSTUREX { get; set; }

        [Display(Name = "Gait")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? GAIT { get; set; }

        [Display(Name = "Gait untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(GAIT), "8", ErrorMessage = "Please specify")]
        public string? GAITX { get; set; }

        [Display(Name = "Posture stability")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? POSSTAB { get; set; }

        [Display(Name = "Posture stability untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(POSSTAB), "8", ErrorMessage = "Please specify")]
        public string? POSSTABX { get; set; }

        [Display(Name = "Body bradykinesia and hypokinesia (combining slowness, hesitancy,decreased arm swing, small amplitude, and poverty of movement in general)")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? BRADYKIN { get; set; }

        [Display(Name = "Body bradykinesia and hypokinesia untestable (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(BRADYKIN), "8", ErrorMessage = "Please specify")]
        public string? BRADYKIX { get; set; }

        [Display(Name = "Total UPDRS Score")]
        [RequiredIf(nameof(PDNORMAL), "False", ErrorMessage = "Response required if question 1 (PDNORMAL) is unchecked")]
        public int? TOTALUPDRS { get; set; }

    }
}
