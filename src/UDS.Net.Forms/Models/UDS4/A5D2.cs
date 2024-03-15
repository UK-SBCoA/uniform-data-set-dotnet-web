using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A5D2 : FormModel
    {
        [Display(Name = "Has participant smoked more than 100 cigarettes in their life?")]
        public int? TOBAC100 { get; set; }
        [Display(Name = "Total years smoked")]
        public int? SMOKYRS { get; set; }
        [Display(Name = "Average number of packs smoked per day")]
        public int? PACKSPER { get; set; }
        [Display(Name = "Has participant smoked within the last 30 days?")]
        public int? TOBAC30 { get; set; }
        [Display(Name = "If the participant quit smoking, specify the age at which they last smoked (i.e., quit)")]
        public int? QUITSMOK { get; set; }
        [Display(Name = "In the past 12 months, how often has the participant had a drink containing alcohol?")]
        public int? ALCFREQYR { get; set; }
        [Display(Name = "On a day when the participant drinks alcoholic beverages, how many standard drinks does the participant typically consume?")]
        public int? ALCDRINKS { get; set; }
        [Display(Name = "In the past 12 months, how often did the participant have six or more drinks containing alcohol in one day?")]
        public int? ALCBINGE { get; set; }
        [Display(Name = "Participant used substances including prescription or recreational drugs that caused significant impairment in work, legal, driving, or social areas within the past 12 months")]
        public int? SUBSTYEAR { get; set; }
        [Display(Name = "Participant used substances including prescription or recreational drugs that caused significant impairment in work, legal, driving, or social areas prior to 12 months ago")]
        public int? SUBSTPAST { get; set; }
        [Display(Name = "In the past 12 months, how often has the participant consumed cannabis (edibles, smoked, or vaporized)?")]
        public int? CANNABIS { get; set; }
        [Display(Name = "Heart attack (heart artery blockage)")]
        public int? HRTATTACK { get; set; }
        [Display(Name = "More than one heart attack?")]
        public int? HRTATTMULT { get; set; }
        [Display(Name = "Age at most recent heart attack")]
        public int? HRTATTAGE { get; set; }
        [Display(Name = "Cardiac arrest (heart stopped)")]
        public int? CARDARREST { get; set; }
        [Display(Name = "Age at most recent cardiac arrest")]
        public int? CARDARRAGE { get; set; }
        [Display(Name = "Atrial fibrillation")]
        public int? CVAFIB { get; set; }
        [Display(Name = "Coronary artery angioplasty / endarterectomy / stenting")]
        public int? CVANGIO { get; set; }
        [Display(Name = "Coronary artery bypass procedure")]
        public int? CVBYPASS { get; set; }
        [Display(Name = "Age at most recent coronary artery bypass surgery")]
        public int? BYPASSAGE { get; set; }
        [Display(Name = "Pacemaker and/or defibrillator implantation")]
        public int? CVPACDEF { get; set; }
        [Display(Name = "Age at first pacemaker and/or defibrillator implantation")]
        public int? PACDEFAGE { get; set; }
        [Display(Name = "Congestive heart failure (including pulmonary edema)")]
        public int? CVCHF { get; set; }
        [Display(Name = "Heart valve replacement or repair")]
        public int? CVHVALVE { get; set; }
        [Display(Name = "Age at most recent heart valve replacement or repair procedure")]
        public int? VALVEAGE { get; set; }
        [Display(Name = "Other cardiovascular disease")]
        public int? CVOTHR { get; set; }
        [Display(Name = "Specify other cardiovascular disease")]
        [MaxLength(60)]
        public string? CVOTHRX { get; set; }
        [Display(Name = "Stroke by history, not exam (imaging is not required)")]
        public int? CBSTROKE { get; set; }
        [Display(Name = "More than one stroke?")]
        public int? STROKMUL { get; set; }
        [Display(Name = "Age at most recent stroke")]
        public int? STROKAGE { get; set; }
        [Display(Name = "What is status of stroke symptoms?")]
        public int? STROKSTAT { get; set; }
        [Display(Name = "Carotid artery surgery or stenting?")]
        public int? ANGIOCP { get; set; }
        [Display(Name = "Age at most recent carotid artery surgery or stenting")]
        public int? CAROTIDAGE { get; set; }
        [Display(Name = "Transient ischemic attack (TIA)")]
        public int? CBTIA { get; set; }
        [Display(Name = "Age at most recent TIA")]
        public int? TIAAGE { get; set; }
        [Display(Name = "Parkinson’s disease (PD)")]
        public int? PD { get; set; }
        [Display(Name = "Age at estimated PD symptom onset")]
        public int? PDAGE { get; set; }
        [Display(Name = "Other parkinsonism disorder (e.g., DLB)")]
        public int? PDOTHR { get; set; }
        [Display(Name = "Age at parkinsonism disorder diagnosis")]
        public int? PDOTHRAGE { get; set; }
        [Display(Name = "Epilepsy and/or history of seizures (excluding childhood febrile seizures)")]
        public int? SEIZURES { get; set; }
        [Display(Name = "How many seizures has the participant had in the past 12 months?")]
        public int? SEIZNUM { get; set; }
        [Display(Name = "Age at first seizure (excluding childhood febrile seizures)")]
        public int? SEIZAGE { get; set; }
        [Display(Name = "Chronic headaches")]
        public int? HEADACHE { get; set; }
        [Display(Name = "Multiple sclerosis")]
        public int? MS { get; set; }
        [Display(Name = "Normal-pressure hydrocephalus")]
        public int? HYDROCEPH { get; set; }
        [Display(Name = "Repetitive head impacts (e.g. from contact sports, intimate partner violence, or military duty), regardless of whether it caused symptoms.")]
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
        [Display(Name = "Source of exposure for repeated hits to the head: Other cause")]
        public bool? IMPOTHER { get; set; }
        [MaxLength(60)]
        public string? IMPOTHERX { get; set; }
        [Display(Name = "The total length of time in years that the participant was exposed to repeated hits to the head (e.g. playing American football for 7 years)")]
        public int? IMPYEARS { get; set; }
        [Display(Name = "Head injury (e.g. in a vehicle accident, being hit by an object...)")]
        public int? HEADINJURY { get; set; }
        [Display(Name = "After a head injury, what was the longest period of time that the participant was unconscious?")]
        public int? HEADINJUNC { get; set; }
        [Display(Name = "After a head injury, what was the longest period...")]
        public int? HEADINJCON { get; set; }
        [Display(Name = "Total number of head injuries")]
        public int? HEADINJNUM { get; set; }
        [Display(Name = "Age of first head injury that resulted in a period of feeling \"dazed or confused,\" being unable to recall details of the injury, or loss of consciousness")]
        public int? FIRSTTBI { get; set; }
        [Display(Name = "Age of most recent head injury that resulted in a period of feeling \"dazed or confused,\" being unable to recall details of the injury, or loss of consciousness")]
        public int? LASTTBI { get; set; }
        [Display(Name = "Diabetes")]
        public int? DIABETES { get; set; }
        [Display(Name = "Diabetes type")]
        public int? DIABTYPE { get; set; }
        [Display(Name = "Diabetes treated with: Insulin")]
        public bool? DIABINS { get; set; }
        [Display(Name = "Diabetes treated with: Oral medications")]
        public bool? DIABMEDS { get; set; }
        [Display(Name = "Diabetes treated with: Diet")]
        public bool? DIABDIET { get; set; }
        [Display(Name = "Diabetes treated with: Unknown")]
        public bool? DIABUNK { get; set; }
        [Display(Name = "Age at diabetes diagnosis")]
        public int? DIABAGE { get; set; }
        [Display(Name = "Hypertension (or taking medication for hypertension)")]
        public int? HYPERTEN { get; set; }
        [Display(Name = "Age at hypertension diagnosis")]
        public int? HYPERTAGE { get; set; }
        [Display(Name = "Hypercholesterolemia (or taking medication for high cholesterol)")]
        public int? HYPERCHO { get; set; }
        [Display(Name = "Age at hypercholesterolemia diagnosis")]
        public int? HYPERCHAGE { get; set; }
        [Display(Name = "B12 deficiency")]
        public int? B12DEF { get; set; }
        [Display(Name = "Thyroid disease")]
        public int? THYROID { get; set; }
        [Display(Name = "Arthritis")]
        public int? ARTHRIT { get; set; }
        [Display(Name = "Type of arthritis: Rheumatoid")]
        public bool? ARTHRRHEUM { get; set; }
        [Display(Name = "Type of arthritis: Osteoarthritis")]
        public bool? ARTHROSTEO { get; set; }
        [Display(Name = "Type of arthritis: Other")]
        public bool? ARTHROTHR { get; set; }
        [Display(Name = "Specify other type of arthritis")]
        [MaxLength(60)]
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
        public int? INCONTU { get; set; }
        [Display(Name = "Incontinence—bowel (occurring at least weekly)")]
        public int? INCONTF { get; set; }
        [Display(Name = "Sleep apnea")]
        public int? APNEA { get; set; }
        [Display(Name = "Typical use of breathing machine (e.g. CPAP) at night over the past 12 months")]
        public int? CPAP { get; set; }
        [Display(Name = "Typical use of an oral device for sleep apnea at night over the past 12 months?")]
        public int? APNEAORAL { get; set; }
        [Display(Name = "REM sleep behavior disorder")]
        public int? RBD { get; set; }
        [Display(Name = "Hyposomnia/Insomnia (occurring at least weekly or requiring medication)")]
        public int? INSOMN { get; set; }
        [Display(Name = "Other sleep disorder")]
        public int? OTHSLEEP { get; set; }
        [Display(Name = "Specify other sleep disorder")]
        [MaxLength(60)]
        public string? OTHSLEEX { get; set; }
        [Display(Name = "Cancer, primary or metastatic (Report all known diagnoses. Exclude non-melanoma skin cancer.)")]
        public int? CANCER { get; set; }
        [Display(Name = "Type of cancer: Primary/non-metastatic")]
        public bool? CANCERPRIM { get; set; }
        [Display(Name = "Type of cancer: Metastatic")]
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
        [Display(Name = "Primary site of cancer: Other")]
        public bool? CANCOTHER { get; set; }
        [Display(Name = "Specify other primary site of cancer")]
        [MaxLength]
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
        [Display(Name = "Type of cancer treatment: Other")]
        public bool? CANCTROTH { get; set; }
        [Display(Name = "Specify other type of cancer treatment")]
        [MaxLength(60)]
        public string? CANCTROTHX { get; set; }
        [Display(Name = "Age at most recent cancer diagnosis")]
        public int? CANCERAGE { get; set; }
        [Display(Name = "COVID-19 infection")]
        public int? COVID19 { get; set; }
        [Display(Name = "COVID-19 infection requiring hospitalization?")]
        public int? COVIDHOSP { get; set; }
        [Display(Name = "Asthma/COPD/pulmonary disease")]
        public int? PULMONARY { get; set; }
        [Display(Name = "Chronic kidney disease")]
        public int? KIDNEY { get; set; }
        [Display(Name = "Age at chronic kidney disease diagnosis")]
        public int? KIDNEYAGE { get; set; }
        [Display(Name = "Liver disease")]
        public int? LIVER { get; set; }
        [Display(Name = "Age at liver disease diagnosis")]
        public int? LIVERAGE { get; set; }
        [Display(Name = "Peripheral vascular disease")]
        public int? PVD { get; set; }
        [Display(Name = "Age at peripheral vascular disease diagnosis")]
        public int? PVDAGE { get; set; }
        [Display(Name = "Human Immunodeficiency Virus")]
        public int? HIVDIAG { get; set; }
        [Display(Name = "Age at HIV diagnosis")]
        public int? HIVAGE { get; set; }
        [Display(Name = "Other medical conditions or procedures")]
        public int? OTHCOND { get; set; }
        [Display(Name = "Specify other medical conditions or procedures")]
        public string? OTHCONDX { get; set; }
        [Display(Name = "Major depressive disorder (DSM-5-TR criteria)")]
        public int? MAJORDEP { get; set; }
        [Display(Name = "Other specified depressive disorder (DSm-5-TR criteria)")]
        public int? OTHERDEP { get; set; }
        [Display(Name = "Choose if treated or untreated")]
        public bool? DEPRTREAT { get; set; }
        [Display(Name = "Bipolar disorder(DSM - 5 - TR criteria)")]
        public int? BIPOLAR { get; set; }
        [Display(Name = "Schizophrenia or other psychosis disorder (DSM-5-TR criteria)")]
        public int? SCHIZ { get; set; }
        [Display(Name = "Anxiety disorder (DSM-5-TR criteria)")]
        public int? ANXIETY { get; set; }
        [Display(Name = "Generalized Anxiety Disorder")]
        public int? GENERALANX { get; set; }
        [Display(Name = "Panic Disorder")]
        public int? PANICDIS { get; set; }
        [Display(Name = "Obsessive-compulsive disorder (OCD)")]
        public int? OCD { get; set; }
        [Display(Name = "Other anxiety disorder")]
        public int? OTHANXDIS { get; set; }
        [Display(Name = "Specify other anxiety disorder")]
        [MaxLength(60)]
        public string? OTHANXDISX { get; set; }
        [Display(Name = "Post-traumatic stress disorder (PTSD) (DSM-5-TR criteria)")]
        public int? PTSD { get; set; }
        [Display(Name = "Developmental neuropsychiatric disorders")]
        public int? NPSYDEV { get; set; }
        [Display(Name = "Other psychiatric disorders")]
        public int? PSYCDIS { get; set; }
        [Display(Name = "Specify other psychiatric disorders")]
        [MaxLength(60)]
        public string? PSYCDISX { get; set; }
        [Display(Name = "How old was the participant when they had their first menstrual period?")]
        public int? MENARCHE { get; set; }
        [Display(Name = "How old was the participant when they had their last menstrual period?")]
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
        [Display(Name = "Other reason participant has stopped having menstrual periods")]
        public bool? NOMENSOTH { get; set; }
        [Display(Name = "Specify other reason participant has stopped having menstrual periods")]
        [MaxLength(60)]
        public string? NOMENSOTHX { get; set; }
        [Display(Name = "Has the participant taken female hormone replacement pills or patches (e.g. estrogen)?")]
        public int? HRT { get; set; }
        [Display(Name = "Total number of years participant has taken female hormone replacement pills")]
        public int? HRTYEARS { get; set; }
        [Display(Name = "Age at first use of female hormone replacement pills")]
        public int? HRTSTRTAGE { get; set; }
        [Display(Name = "Age at last use of female hormone replacement pills")]
        public int? HRTENDAGE { get; set; }
        [Display(Name = "Has the participant ever taken birth control pills?")]
        public int? BCPILLS { get; set; }
        [Display(Name = "Total number of years participant has taken birth control pills")]
        public int? BCPILLSYR { get; set; }
        [Display(Name = "Age at first use of birth control pills")]
        public int? BCSTARTAGE { get; set; }
        [Display(Name = "Age at last use of birth control pills")]
        public int? BCENDAGE { get; set; }
    }
}
