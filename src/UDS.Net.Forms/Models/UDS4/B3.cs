using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Models.UDS4
{
    public class B3 : FormModel
    {
        [Display(Name = "PDNORMAL")]
        public bool? PDNORMAL { get; set; }

        [Display(Name = "Speech")]
        public int? SPEECH { get; set; }

        [Display(Name = "Speech untestable (specify)")]
        [MaxLength(60)]
        public string? SPEECHX { get; set; }

        [Display(Name = "Facial expression")]
        public int? FACEXP { get; set; }

        [Display(Name = "Facial expression untestable (specify)")]
        [MaxLength(60)]
        public string? FACEXPX { get; set; }

        [Display(Name = "Tremor at rest - face, lips, chin")]
        public int? TRESTFAC { get; set; }

        [Display(Name = "Tremor at rest - face, lips, chin untestable (specify)")]
        [MaxLength(60)]
        public string? TRESTFAX { get; set; }

        [Display(Name = "Tremor at rest - right hand")]
        public int? TRESTRHD { get; set; }

        [Display(Name = "Tremor at rest - right hand untestable (specify)")]
        [MaxLength(60)]
        public string? TRESTRHX { get; set; }

        [Display(Name = "Tremor at rest - left hand")]
        public int? TRESTLHD { get; set; }

        [Display(Name = "Tremor at rest - left hand untestable (specify)")]
        [MaxLength(60)]
        public string? TRESTLHX { get; set; }

        [Display(Name = "Tremor at rest - right foot")]
        public int? TRESTRFT { get; set; }

        [Display(Name = "Tremor at rest - right foot untestable (specify)")]
        [MaxLength(60)]
        public string? TRESTRFX { get; set; }

        [Display(Name = "Tremor at rest - left foot")]
        public int? TRESTLFT { get; set; }

        [Display(Name = "Tremor at rest - left foot untestable (specify)")]
        [MaxLength(60)]
        public string? TRESTLFX { get; set; }

        [Display(Name = "Action or postural tremor of hands - right hand")]
        public int? TRACTRHD { get; set; }

        [Display(Name = "Action or postural tremor of hands - right hand untestable (specify)")]
        [MaxLength(60)]
        public string? TRACTRHX { get; set; }

        [Display(Name = "Action or postural tremor of hands - left hand")]
        public int? TRACTLHD { get; set; }

        [Display(Name = "Action or postural tremor of hands - left hand untestable (specify)")]
        [MaxLength(60)]
        public string? TRACTLHX { get; set; }

        [Display(Name = "Rigidity - neck")]
        public int? RIGDNECK { get; set; }

        [Display(Name = "Rigidity - neck untestable (specify)")]
        [MaxLength(60)]
        public string? RIGDNEX { get; set; }

        [Display(Name = "Rigidity - right upper extremity")]
        public int? RIGDUPRT { get; set; }

        [Display(Name = "Rigidity - right upper extremity untestable (specify)")]
        [MaxLength(60)]
        public string? RIGDUPRX { get; set; }

        [Display(Name = "Rigidity - left upper extremity")]
        public int? RIGDUPLF { get; set; }

        [Display(Name = "Rigidity - left upper extremity untestable (specify)")]
        [MaxLength(60)]
        public string? RIGDUPLX { get; set; }

        [Display(Name = "Rigidity - right lower extremity")]
        public int? RIGDLORT { get; set; }

        [Display(Name = "Rigidity - right lower extremity untestable (specify)")]
        [MaxLength(60)]
        public string? RIGDLORX { get; set; }

        [Display(Name = "Rigidity - left lower extremity")]
        public int? RIGDLOLF { get; set; }

        [Display(Name = "Rigidity - left lower extremity untestable (specify)")]
        [MaxLength(60)]
        public string? RIGDLOLX { get; set; }

        [Display(Name = "Finger taps - right hand")]
        public int? TAPSRT { get; set; }

        [Display(Name = "Finger taps - right hand untestable (specify)")]
        [MaxLength(60)]
        public string? TAPSRTX { get; set; }

        [Display(Name = "Finger taps - left hand")]
        public int? TAPSLF { get; set; }

        [Display(Name = "Finger taps - left hand untestable (specify)")]
        [MaxLength(60)]
        public string? TAPSLFX { get; set; }

        [Display(Name = "Hand movements - right hand")]
        public int? HANDMOVR { get; set; }

        [Display(Name = "Hand movements - right hand untestable (specify)")]
        [MaxLength(60)]
        public string? HANDMVRX { get; set; }

        [Display(Name = "Hand movements - left hand")]
        public int? HANDMOVL { get; set; }

        [Display(Name = "Hand movements - left hand untestable (specify)")]
        [MaxLength(60)]
        public string? HANDMVLX { get; set; }

        [Display(Name = "Rapid alternating movement of hands - right hand")]
        public int? HANDALTR { get; set; }

        [Display(Name = "Rapid alternating movement of hands - right hand untestable (specify)")]
        [MaxLength(60)]
        public string? HANDATRX { get; set; }

        [Display(Name = "Rapid alternating movement of hands - left hand")]
        public int? HANDALTL { get; set; }

        [Display(Name = "Rapid alternating movements of hands - left hand untestable (specify)")]
        [MaxLength(60)]
        public string? HANDATLX { get; set; }

        [Display(Name = "Leg agility - right leg")]
        public int? LEGRT { get; set; }

        [Display(Name = "Leg agility - right leg untestable (specify)")]
        [MaxLength(60)]
        public string? LEGRTX { get; set; }

        [Display(Name = "Leg agility - left leg")]
        public int? LEGLF { get; set; }

        [Display(Name = "Leg agility - left leg untestable (specify)")]
        [MaxLength(60)]
        public string? LEGLFX { get; set; }

        [Display(Name = "Arising from chair")]
        public int? ARISING { get; set; }

        [Display(Name = "Arising from chair untestable (specify)")]
        [MaxLength(60)]
        public string? ARISINGX { get; set; }

        [Display(Name = "Posture")]
        public int? POSTURE { get; set; }

        [Display(Name = "Posture untestable (specify)")]
        [MaxLength(60)]
        public string? POSTUREX { get; set; }

        [Display(Name = "Gait")]
        public int? GAIT { get; set; }

        [Display(Name = "Gait untestable (specify)")]
        [MaxLength(60)]
        public string? GAITX { get; set; }

        [Display(Name = "Posture stability")]
        public int? POSSTAB { get; set; }

        [Display(Name = "Posture stability untestable (specify)")]
        [MaxLength(60)]
        public string? POSSTABX { get; set; }

        [Display(Name = "Body bradykinesia and hypokinesia")]
        public int? BRADYKIN { get; set; }

        [Display(Name = "Body bradykinesia and hypokinesia untestable (specify)")]
        [MaxLength(60)]
        public string? BRADYKIX { get; set; }

        [Display(Name = "Total UPDRS Score")]
        public int? TOTALUPDRS { get; set; }

    }
}
