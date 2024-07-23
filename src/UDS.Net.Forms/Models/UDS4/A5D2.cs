using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A5D2 : FormModel
    {
        [Display(Name = "Has participant smoked more than 100 cigarettes in their life?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? TOBAC100 { get; set; }
        [Display(Name = "Total years smoked")]
        [RegularExpression("^([1-7]?[0-9]|8[0-7]|99)$", ErrorMessage = "Valid range is 0-87 or 99")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? SMOKYRS { get; set; }
        [Display(Name = "Average number of packs smoked per day")]
        [RegularExpression("^([1-5]|9)$", ErrorMessage = "Valid range is 1-5 or 9")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? PACKSPER { get; set; }
        [Display(Name = "Has participant smoked within the last 30 days?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? TOBAC30 { get; set; }
        [Display(Name = "If the participant quit smoking, specify the age at which they last smoked (i.e., quit)")]
        [RegularExpression("^([89]|[1-9]\\d|10\\d|110||888|999)$", ErrorMessage = "Valid range is 8-110 or 888 or 999")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? QUITSMOK { get; set; }
        [Display(Name = "In the past 12 months, how often has the participant had a drink containing alcohol?")]
        [RegularExpression("^([0-4]|9)$", ErrorMessage = "Valid range is 0-4 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? ALCFREQYR { get; set; }
        [Display(Name = "On a day when the participant drinks alcoholic beverages, how many standard drinks does the participant typically consume?")]
        [RegularExpression("^([1-5]|9)$", ErrorMessage = "Valid range is 1-5 or 9")]
        [RequiredIfRange(nameof(ALCFREQYR), 1, 4, ErrorMessage = "Please specify.")]
        public int? ALCDRINKS { get; set; }
        [Display(Name = "In the past 12 months, how often did the participant have six or more drinks containing alcohol in one day?")]
        [RegularExpression("^([0-4]|9)$", ErrorMessage = "Valid range is 0-4 or 9")]
        [RequiredIfRange(nameof(ALCFREQYR), 1, 4, ErrorMessage = "Please specify.")]
        public int? ALCBINGE { get; set; }
        [Display(Name = "Participant used substances including prescription or recreational drugs that caused significant impairment in work, legal, driving, or social areas within the past 12 months")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? SUBSTYEAR { get; set; }
        [Display(Name = "Participant used substances including prescription or recreational drugs that caused significant impairment in work, legal, driving, or social areas prior to 12 months ago")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? SUBSTPAST { get; set; }
        [Display(Name = "In the past 12 months, how often has the participant consumed cannabis (edibles, smoked, or vaporized)?")]
        [RegularExpression("^([0-4]|9)$", ErrorMessage = "Valid range is 0-4 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CANNABIS { get; set; }
        [Display(Name = "Heart attack (heart artery blockage)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HRTATTACK { get; set; }
        [Display(Name = "More than one heart attack?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredIfRange(nameof(HRTATTACK), 1, 2, ErrorMessage = "Please specify.")]
        public int? HRTATTMULT { get; set; }
        [Display(Name = "Age at most recent heart attack")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(CVPACDEF), 1, 2, ErrorMessage = "Please specify.")]
        public int? HRTATTAGE { get; set; }
        [Display(Name = "Cardiac arrest (heart stopped)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CARDARREST { get; set; }
        [Display(Name = "Age at most recent cardiac arrest")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(CARDARREST), 1, 2, ErrorMessage = "Please specify.")]
        public int? CARDARRAGE { get; set; }
        [Display(Name = "Atrial fibrillation")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CVAFIB { get; set; }
        [Display(Name = "Coronary artery angioplasty / endarterectomy / stenting")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CVANGIO { get; set; }
        [Display(Name = "Coronary artery bypass procedure")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CVBYPASS { get; set; }
        [Display(Name = "Age at most recent coronary artery bypass surgery")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(CVBYPASS), 1, 2, ErrorMessage = "Please specify.")]
        public int? BYPASSAGE { get; set; }
        [Display(Name = "Pacemaker and/or defibrillator implantation")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CVPACDEF { get; set; }
        [Display(Name = "Age at first pacemaker and/or defibrillator implantation")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(HRTATTACK), 1, 2, ErrorMessage = "Please specify.")]
        public int? PACDEFAGE { get; set; }
        [Display(Name = "Congestive heart failure (including pulmonary edema)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CVCHF { get; set; }
        [Display(Name = "Heart valve replacement or repair")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CVHVALVE { get; set; }
        [Display(Name = "Age at most recent heart valve replacement or repair procedure")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(CVHVALVE), 1, 2, ErrorMessage = "Please specify.")]
        public int? VALVEAGE { get; set; }
        [Display(Name = "Other cardiovascular disease")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CVOTHR { get; set; }
        [Display(Name = "Specify other cardiovascular disease")]
        [MaxLength(60)]
        [RequiredIfRange(nameof(CVOTHR), 1, 2, ErrorMessage = "Please specify.")]
        public string? CVOTHRX { get; set; }
        [Display(Name = "Stroke by history, not exam (imaging is not required)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CBSTROKE { get; set; }
        [Display(Name = "More than one stroke?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredIfRange(nameof(CBSTROKE), 1, 2, ErrorMessage = "Please specify.")]
        public int? STROKMUL { get; set; }
        [Display(Name = "Age at most recent stroke")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(CBSTROKE), 1, 2, ErrorMessage = "Please specify.")]
        public int? STROKAGE { get; set; }
        [Display(Name = "What is status of stroke symptoms?")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(CBSTROKE), 1, 2, ErrorMessage = "Please specify.")]
        public int? STROKSTAT { get; set; }
        [Display(Name = "Carotid artery surgery or stenting?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredIfRange(nameof(CBSTROKE), 1, 2, ErrorMessage = "Please specify.")]
        public int? ANGIOCP { get; set; }
        [Display(Name = "Age at most recent carotid artery surgery or stenting")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(CBSTROKE), 1, 2, ErrorMessage = "Please specify.")]
        public int? CAROTIDAGE { get; set; }
        [Display(Name = "Transient ischemic attack (TIA)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CBTIA { get; set; }
        [Display(Name = "Age at most recent TIA")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(CBTIA), 1, 2, ErrorMessage = "Please specify.")]
        public int? TIAAGE { get; set; }
        [Display(Name = "Parkinson’s disease (PD)")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PD { get; set; }
        [Display(Name = "Age at estimated PD symptom onset")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIf(nameof(PD), "1", ErrorMessage = "Please specify.")]
        public int? PDAGE { get; set; }
        [Display(Name = "Other parkinsonism disorder (e.g., DLB)")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PDOTHR { get; set; }
        [Display(Name = "Age at parkinsonism disorder diagnosis")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIf(nameof(PDOTHR), "1", ErrorMessage = "Please specify.")]
        public int? PDOTHRAGE { get; set; }
        [Display(Name = "Epilepsy and/or history of seizures (excluding childhood febrile seizures)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? SEIZURES { get; set; }
        [Display(Name = "How many seizures has the participant had in the past 12 months?")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(SEIZURES), 1, 2, ErrorMessage = "Please specify.")]
        public int? SEIZNUM { get; set; }
        [Display(Name = "Age at first seizure (excluding childhood febrile seizures)")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIfRange(nameof(SEIZURES), 1, 2, ErrorMessage = "Please specify.")]
        public int? SEIZAGE { get; set; }
        [Display(Name = "Chronic headaches")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HEADACHE { get; set; }
        [Display(Name = "Multiple sclerosis")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? MS { get; set; }
        [Display(Name = "Normal-pressure hydrocephalus")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HYDROCEPH { get; set; }
        [Display(Name = "Repetitive head impacts (e.g. from contact sports, intimate partner violence, or military duty), regardless of whether it caused symptoms.")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HEADIMP { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: American football")]
        public bool? IMPAMFOOT { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Soccer")]
        public bool? IMPSOCCER { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Ice hockey")]
        public bool? IMPHOCKEY { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Boxing or mixed martial arts")]
        public bool? IMPBOXING { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Other contact sport")]
        public bool? IMPSPORT { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Intimate partner violence")]
        public bool? IMPIPV { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Military service")]
        public bool? IMPMILIT { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Physical assault")]
        public bool? IMPASSAULT { get; set; }
        [Display(Name = "Source of exposure for repeated hits to the head: Other cause (SPECIFY)")]
        public bool? IMPOTHER { get; set; }
        [MaxLength(60)]
        [RequiredIf(nameof(IMPOTHER), "true", ErrorMessage = "Please specify.")]
        public string? IMPOTHERX { get; set; }
        [Display(Name = "Indicate the total length of time in years that the participant was exposed to repeated hits to the head (e.g. playing American football for 7 years)")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIf(nameof(HEADIMP), "1", ErrorMessage = "Please specify.")]
        public int? IMPYEARS { get; set; }
        [Display(Name = "Head injury (e.g. in a vehicle accident, being hit by an object, in a fall, while playing sports or biking, in an assault, or during military service) that resulted in a period of feeling \"dazed or confused,\" being unable to recall details of the injury, or loss of consciousness (if multiple head injuries, consider most severe episode).")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HEADINJURY { get; set; }
        [Display(Name = "After a head injury, what was the longest period of time that the participant was unconscious?")]
        [RegularExpression("^([0-4]|8|9)$", ErrorMessage = "Valid range is 0-4 or 8 or 9")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? HEADINJUNC { get; set; }
        [Display(Name = "After a head injury, what was the longest period that the participant was \"dazed or confused\" or unable to recall details of the injury?")]
        [RegularExpression("^([0-4]|8|9)$", ErrorMessage = "Valid range is 0-4 or 8 or 9")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? HEADINJCON { get; set; }
        [Display(Name = "Total number of head injuries in which the participant felt \"dazed or confused\", unable to recall details of the injury or experienced loss of consciousness?")]
        [RegularExpression("^([0-4]|9)$", ErrorMessage = "Valid range is 0-4 or 9")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? HEADINJNUM { get; set; }
        [Display(Name = "Age of first head injury that resulted in a period of feeling \"dazed or confused,\" being unable to recall details of the injury, or loss of consciousness")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? FIRSTTBI { get; set; }
        [Display(Name = "Age of most recent head injury that resulted in a period of feeling \"dazed or confused,\" being unable to recall details of the injury, or loss of consciousness")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIf(nameof(TOBAC100), "1", ErrorMessage = "Please specify.")]
        public int? LASTTBI { get; set; }
        [Display(Name = "Diabetes")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? DIABETES { get; set; }
        [Display(Name = "Diabetes type")]
        [RegularExpression("^([1-3]|9)$", ErrorMessage = "Valid range is 1-3 or 9")]
        [RequiredIfRange(nameof(DIABETES), 1, 2, ErrorMessage = "Please specify.")]
        public int? DIABTYPE { get; set; }
        [Display(Name = "Diabetes treated with: Insulin")]
        public bool? DIABINS { get; set; }
        [Display(Name = "Diabetes treated with: Oral medications")]
        public bool? DIABMEDS { get; set; }
        [Display(Name = "Diabetes treated with: GLP-1 receptor activators")]
        public bool? DIABGLP1 { get; set; }
        [Display(Name = "Diabetes treated with: Other non-insulin, non-GLP-1 receptor activator injection medication")]
        public bool? DIABRECACT { get; set; }
        [Display(Name = "Diabetes treated with: Diet")]
        public bool? DIABDIET { get; set; }
        [Display(Name = "Diabetes treated with: Unknown")]
        public bool? DIABUNK { get; set; }
        [Display(Name = "Age at diabetes diagnosis")]
        [RequiredIfRange(nameof(DIABETES), 1, 2, ErrorMessage = "Please specify.")]
        public int? DIABAGE { get; set; }
        [Display(Name = "Hypertension (or taking medication for hypertension)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HYPERTEN { get; set; }
        [Display(Name = "Age at hypertension diagnosis")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(HYPERTEN), 1, 2, ErrorMessage = "Please specify.")]
        public int? HYPERTAGE { get; set; }
        [Display(Name = "Hypercholesterolemia (or taking medication for high cholesterol)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HYPERCHO { get; set; }
        [Display(Name = "Age at hypercholesterolemia diagnosis")]
        [RegularExpression("^(1\\d|[2-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 10-110 or 999")]
        [RequiredIfRange(nameof(HYPERCHO), 1, 2, ErrorMessage = "Please specify.")]
        public int? HYPERCHAGE { get; set; }
        [Display(Name = "B12 deficiency")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? B12DEF { get; set; }
        [Display(Name = "Thyroid disease")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? THYROID { get; set; }
        [Display(Name = "Arthritis")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? ARTHRIT { get; set; }
        [Display(Name = "Type of arthritis: Rheumatoid")]
        public bool? ARTHRRHEUM { get; set; }
        [Display(Name = "Type of arthritis: Osteoarthritis")]
        public bool? ARTHROSTEO { get; set; }
        [Display(Name = "Type of arthritis: Other (SPECIFY)")]
        public bool? ARTHROTHR { get; set; }
        [Display(Name = "Specify other type of arthritis")]
        [MaxLength(60)]
        [RequiredIf(nameof(ARTHROTHR), "true", ErrorMessage = "Please specify.")]
        public string? ARTHTYPX { get; set; }
        [Display(Name = "Type of arthritis: Unknown")]
        public bool? ARTHTYPUNK { get; set; }
        [Display(Name = "Upper extremity affected by arthritis")]
        public bool? ARTHUPEX { get; set; }
        [Display(Name = "Lower extremity affected by arthritis")]
        public bool? ARTHLOEX { get; set; }
        [Display(Name = "Spine affected by arthritis")]
        public bool? ARTHSPIN { get; set; }
        [Display(Name = "Region affected by arthritis unknown")]
        public bool? ARTHUNK { get; set; }
        [Display(Name = "Incontinence—urinary (occurring at least weekly)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? INCONTU { get; set; }
        [Display(Name = "Incontinence—bowel (occurring at least weekly)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? INCONTF { get; set; }
        [Display(Name = "Sleep apnea")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? APNEA { get; set; }
        [Display(Name = "Typical use of breathing machine (e.g. CPAP) at night over the past 12 months")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(APNEA), 1, 2, ErrorMessage = "Please specify.")]
        public int? CPAP { get; set; }
        [Display(Name = "Typical use of an oral device for sleep apnea at night over the past 12 months?")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(APNEA), 1, 2, ErrorMessage = "Please specify.")]
        public int? APNEAORAL { get; set; }
        [Display(Name = "REM sleep behavior disorder")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? RBD { get; set; }
        [Display(Name = "Hyposomnia/Insomnia (occurring at least weekly or requiring medication)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? INSOMN { get; set; }
        [Display(Name = "Other sleep disorder")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? OTHSLEEP { get; set; }
        [Display(Name = "Specify other sleep disorder")]
        [MaxLength(60)]
        [RequiredIfRange(nameof(OTHSLEEP), 1, 2, ErrorMessage = "Please specify.")]
        public string? OTHSLEEX { get; set; }
        [Display(Name = "Cancer, primary or metastatic (Report all known diagnoses. Exclude non-melanoma skin cancer.)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CANCERACTV { get; set; }
        [Display(Name = "Type of cancer: Primary/non-metastatic")]
        public bool? CANCERPRIM { get; set; }
        [Display(Name = "Type of cancer: Metastatic (CHECK ALL THAT APPLY)")]
        public bool? CANCERMETA { get; set; }
        [Display(Name = "Type of metastatic cancer: Metatstic to brain")]
        public bool? CANCMETBR { get; set; }
        [Display(Name = "Type of metastatic cancer: Metastatic to sites other than brain")]
        public bool? CANCMETOTH { get; set; }
        [Display(Name = "Type of cancer: Unknown")]
        public bool? CANCERUNK { get; set; }
        [Display(Name = "Primary site of cancer: Blood")]
        public bool? CANCBLOOD { get; set; }
        [Display(Name = "Primary site of cancer: Breast")]
        public bool? CANCBREAST { get; set; }
        [Display(Name = "Primary site of cancer: Colon")]
        public bool? CANCCOLON { get; set; }
        [Display(Name = "Primary site of cancer: Lung")]
        public bool? CANCLUNG { get; set; }
        [Display(Name = "Primary site of cancer: Prostate")]
        public bool? CANCPROST { get; set; }
        [Display(Name = "Primary site of cancer: Other (SPECIFY)")]
        public bool? CANCOTHER { get; set; }
        [Display(Name = "Specify other primary site of cancer")]
        [MaxLength(60)]
        [RequiredIf(nameof(CANCOTHER), "true", ErrorMessage = "Please specify.")]
        public string? CANCOTHERX { get; set; }
        [Display(Name = "Type of cancer treatment: Radiation")]
        public bool? CANCRAD { get; set; }
        [Display(Name = "Type of cancer treatment: Surgical resection")]
        public bool? CANCRESECT { get; set; }
        [Display(Name = "Type of cancer treatment: Immunotherapy")]
        public bool? CANCIMMUNO { get; set; }
        [Display(Name = "Type of cancer treatment: Bone marrow transplant")]
        public bool? CANCBONE { get; set; }
        [Display(Name = "Type of cancer treatment: Chemotherapy")]
        public bool? CANCCHEMO { get; set; }
        [Display(Name = "Type of cancer treatment: Hormone therapy")]
        public bool? CANCHORM { get; set; }
        [Display(Name = "Type of cancer treatment: Other (SPECIFY)")]
        public bool? CANCTROTH { get; set; }
        [Display(Name = "Specify other type of cancer treatment")]
        [MaxLength(60)]
        [RequiredIf(nameof(CANCTROTH), "true", ErrorMessage = "Please specify.")]
        public string? CANCTROTHX { get; set; }
        [Display(Name = "Age at most recent cancer diagnosis")]
        [RequiredIfRange(nameof(CANCERACTV), 1, 2, ErrorMessage = "Response required")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        public int? CANCERAGE { get; set; }
        [Display(Name = "COVID-19 infection")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? COVID19 { get; set; }
        [Display(Name = "COVID-19 infection requiring hospitalization?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        [RequiredIfRange(nameof(COVID19), 1, 2, ErrorMessage = "Please specify.")]
        public int? COVIDHOSP { get; set; }
        [Display(Name = "Asthma/COPD/pulmonary disease")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PULMONARY { get; set; }
        [Display(Name = "Chronic kidney disease")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? KIDNEY { get; set; }
        [Display(Name = "Age at chronic kidney disease diagnosis")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIfRange(nameof(KIDNEY), 1, 2, ErrorMessage = "Please specify.")]
        public int? KIDNEYAGE { get; set; }
        [Display(Name = "Liver disease")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? LIVER { get; set; }
        [Display(Name = "Age at liver disease diagnosis")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIfRange(nameof(LIVER), 1, 2, ErrorMessage = "Please specify.")]
        public int? LIVERAGE { get; set; }
        [Display(Name = "Peripheral vascular disease")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PVD { get; set; }
        [Display(Name = "Age at peripheral vascular disease diagnosis")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIfRange(nameof(PVD), 1, 2, ErrorMessage = "Please specify.")]
        public int? PVDAGE { get; set; }
        [Display(Name = "Human Immunodeficiency Virus")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HIVDIAG { get; set; }
        [Display(Name = "Age at HIV diagnosis")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredIfRange(nameof(HIVDIAG), 1, 2, ErrorMessage = "Please specify.")]
        public int? HIVAGE { get; set; }
        [Display(Name = "Other medical conditions or procedures")]
        [RegularExpression("^(\\d|[1-9]\\d|10\\d|110|999)$", ErrorMessage = "Valid range is 0-110 or 999")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? OTHERCOND { get; set; }
        [Display(Name = "Specify other medical conditions or procedures")]
        [RequiredIfRange(nameof(OTHERCOND), 1, 2, ErrorMessage = "Please specify.")]
        public string? OTHCONDX { get; set; }
        [Display(Name = "Major depressive disorder (DSM-5-TR criteria)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? MAJORDEP { get; set; }
        [Display(Name = "Other specified depressive disorder (DSm-5-TR criteria)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? OTHERDEP { get; set; }
        [Display(Name = "Choose if treated or untreated")]
        [RegularExpression("^([0-1])$", ErrorMessage = "Valid range is 0-1")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? DEPRTREAT { get; set; }
        [Display(Name = "Bipolar disorder(DSM - 5 - TR criteria)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? BIPOLAR { get; set; }
        [Display(Name = "Schizophrenia or other psychosis disorder (DSM-5-TR criteria)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? SCHIZ { get; set; }
        [Display(Name = "Anxiety disorder (DSM-5-TR criteria)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? ANXIETY { get; set; }
        [Display(Name = "Generalized Anxiety Disorder")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(ANXIETY), 1, 2, ErrorMessage = "Please specify.")]
        public int? GENERALANX { get; set; }
        [Display(Name = "Panic Disorder")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(ANXIETY), 1, 2, ErrorMessage = "Please specify.")]
        public int? PANICDIS { get; set; }
        [Display(Name = "Obsessive-compulsive disorder (OCD)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(ANXIETY), 1, 2, ErrorMessage = "Please specify.")]
        public int? OCD { get; set; }
        [Display(Name = "Other anxiety disorder")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredIfRange(nameof(ANXIETY), 1, 2, ErrorMessage = "Please specify.")]
        public int? OTHANXDIS { get; set; }
        [Display(Name = "Specify other anxiety disorder")]
        [MaxLength(60)]
        [RequiredIfRange(nameof(OTHANXDIS), 1, 2, ErrorMessage = "Please specify.")]
        public string? OTHANXDISX { get; set; }
        [Display(Name = "Post-traumatic stress disorder (PTSD) (DSM-5-TR criteria)")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PTSD { get; set; }
        [Display(Name = "Developmental neuropsychiatric disorders")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? NPSYDEV { get; set; }
        [Display(Name = "Other psychiatric disorders")]
        [RegularExpression("^([0-2]|9)$", ErrorMessage = "Valid range is 0-2 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PSYCDIS { get; set; }
        [Display(Name = "Specify other psychiatric disorders")]
        [MaxLength(60)]
        [RequiredIfRange(nameof(PSYCDIS), 1, 2, ErrorMessage = "Please specify.")]
        public string? PSYCDISX { get; set; }
        [Display(Name = "How old was the participant when they had their first menstrual period?")]
        [RegularExpression("^([5-9]|1\\d|2[0-5]|88|99)$", ErrorMessage = "Valid range is 5-25 or 88 or 99")]
        public int? MENARCHE { get; set; }
        [Display(Name = "How old was the participant when they had their last menstrual period?")]
        [RegularExpression("^(1\\d|[2-6]\\d|70||88|99)$", ErrorMessage = "Valid range is 10-70 or 88 or 99")]
        public int? NOMENSAGE { get; set; }
        [Display(Name = "Participant has stopped having menstrual periods due to natural menopause")]
        public bool? NOMENSNAT { get; set; }
        [Display(Name = "Participant has stopped having menstrual periods due to hysterectomy (surgical removal of uterus)")]
        public bool? NOMENSHYST { get; set; }
        [Display(Name = "Participant has stopped having menstrual periods due to surgical removal of both ovaries")]
        public bool? NOMENSSURG { get; set; }
        [Display(Name = "Participant has stopped having menstrual periods due to chemotherapy for cancer or another condition")]
        public bool? NOMENSCHEM { get; set; }
        [Display(Name = "Participant has stopped having menstrual periods due to radiation treatment or other damage/injury to reproductive organs")]
        public bool? NOMENSRAD { get; set; }
        [Display(Name = "Participant has stopped having menstrual periods due to hormonal supplements (e.g. the Pill, injections, Mirena, HRT)")]
        public bool? NOMENSHORM { get; set; }
        [Display(Name = "Participant has stopped having menstrual periods due to anti-estrogen medication")]
        public bool? NOMENSESTR { get; set; }
        [Display(Name = "Unsure of reason participant has stopped having menstrual periods")]
        public bool? NOMENSUNK { get; set; }
        [Display(Name = "Other reason participant has stopped having menstrual periods (SPECIFY)")]
        public bool? NOMENSOTH { get; set; }
        [Display(Name = "Specify other reason participant has stopped having menstrual periods")]
        [MaxLength(60)]
        [RequiredIf(nameof(NOMENSOTH), "true", ErrorMessage = "Please specify.")]
        public string? NOMENSOTHX { get; set; }
        [Display(Name = "Has the participant taken female hormone replacement pills or patches (e.g. estrogen)?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        public int? HRT { get; set; }
        [Display(Name = "Total number of years participant has taken female hormone replacement pills")]
        [RegularExpression("^(\\d|[1-6]\\d|70|99)$", ErrorMessage = "Valid range is 0-70 or 99")]
        public int? HRTYEARS { get; set; }
        [Display(Name = "Age at first use of female hormone replacement pills")]
        [RegularExpression("^(1\\d|[2-6]\\d|70|99)$", ErrorMessage = "Valid range is 10-70 or 99")]
        public int? HRTSTRTAGE { get; set; }
        [Display(Name = "Age at last use of female hormone replacement pills")]
        [RegularExpression("^(1\\d|[2-6]\\d|70||88|99)$", ErrorMessage = "Valid range is 10-70 or 88 or 99")]
        public int? HRTENDAGE { get; set; }
        [Display(Name = "Has the participant ever taken birth control pills?")]
        [RegularExpression("^(0|1|9)$", ErrorMessage = "Valid range is 0, 1, or 9")]
        public int? BCPILLS { get; set; }
        [Display(Name = "Total number of years participant has taken birth control pills")]
        [RegularExpression("^(\\d|[1-4]\\d|50|99)$", ErrorMessage = "Valid range is 0-50 or 99")]
        public int? BCPILLSYR { get; set; }
        [Display(Name = "Age at first use of birth control pills")]
        [RegularExpression("^(1\\d|[2-6]\\d|70|99)$", ErrorMessage = "Valid range is 10-70 or 99")]
        public int? BCSTARTAGE { get; set; }
        [Display(Name = "Age at last use of birth control pills")]
        [RegularExpression("^(1\\d|[2-6]\\d|70||88|99)$", ErrorMessage = "Valid range is 10-70 or 88 or 99")]
        public int? BCENDAGE { get; set; }

        [RequiredIf(nameof(HEADIMP), "1", ErrorMessage = "Please indicate at least one sources of exposure.")]
        [NotMapped]
        public bool? HEADIMPCheckboxes
        {
            get
            {
                if (IMPAMFOOT == true || IMPSOCCER == true || IMPHOCKEY == true || IMPBOXING == true || IMPSPORT == true || IMPIPV == true || IMPMILIT == true || IMPASSAULT == true || IMPOTHER == true)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredIfRange(nameof(DIABETES), 1, 2, ErrorMessage = "Please indicate at least one type of diabetes treatment")]
        [NotMapped]
        public bool? DIABETESTreatmentCheckboxes
        {
            get
            {
                if (DIABINS == true || DIABMEDS == true || DIABGLP1 == true || DIABRECACT == true || DIABDIET == true || DIABUNK == true)
                    return true;
                else
                    return null;
            }
        }

        [RequiredIfRange(nameof(ARTHRIT), 1, 2, ErrorMessage = "Please indicate at least one type of arthritis.")]
        [NotMapped]
        public bool? ARTHRITTypeCheckboxes
        {
            get
            {
                if (ARTHRRHEUM == true || ARTHROSTEO == true || ARTHROTHR == true || ARTHTYPUNK == true)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredIfRange(nameof(ARTHRIT), 1, 2, ErrorMessage = "Please indicate at least one region affected.")]
        [NotMapped]
        public bool? ARTHRITRegionsCheckboxes
        {
            get
            {
                if (ARTHUPEX == true || ARTHLOEX == true || ARTHSPIN == true || ARTHUNK == true)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredIfRange(nameof(CANCERACTV), 1, 2, ErrorMessage = "Please provide at least 1 type of cancer or type of metastatic cancer if indicated.")]
        [NotMapped]
        public bool? CANCERACTVTypeCheckboxes
        {
            get
            {
                if (CANCERPRIM == true || CANCERMETA == true || CANCERUNK == true)
                {
                    if (CANCERMETA == true)
                    {
                        if (CANCMETBR == true || CANCMETOTH == true)
                        {
                            return true;
                        }
                        else return null;
                    }
                    return true;
                }
                else return null;
            }
        }

        [RequiredIfRange(nameof(CANCERACTV), 1, 2, ErrorMessage = "Please indicate at least one site of cancer.")]
        [NotMapped]
        public bool? CANCERACTVSiteCheckboxes
        {
            get
            {
                if (CANCBLOOD == true || CANCBREAST == true || CANCCOLON == true || CANCLUNG == true || CANCPROST == true || CANCOTHER == true)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredIfRange(nameof(CANCERACTV), 1, 2, ErrorMessage = "Please indicate at least one treatment.")]
        [NotMapped]
        public bool? CANCERACTVTreatmentCheckboxes
        {
            get
            {
                if (CANCRAD == true || CANCRESECT == true || CANCIMMUNO == true || CANCBONE == true || CANCCHEMO == true || CANCHORM == true || CANCTROTH == true)
                {
                    return true;
                }
                else return null;
            }
        }

        [RequiredIfRange(nameof(NOMENSAGE), 10, 70, ErrorMessage = "Please indicate at least one reason.")]
        [NotMapped]
        public bool? NOMENSAGEStoppedReasonCheckboxes
        {
            get
            {
                if (NOMENSNAT == true || NOMENSHYST == true || NOMENSSURG == true || NOMENSCHEM == true || NOMENSRAD == true || NOMENSHORM == true || NOMENSESTR == true || NOMENSUNK == true || NOMENSOTH == true)
                {
                    return true;
                }
                else return null;
            }
        }
    }
}
