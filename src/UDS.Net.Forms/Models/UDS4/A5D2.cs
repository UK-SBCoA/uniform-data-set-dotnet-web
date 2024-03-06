using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A5D2 : FormModel
    {
        [Comment("Has participant smoked more than 100 cigarettes in their life?")]
        public int? TOBAC100 { get; set; }
        [Comment("Total years smoked")]
        public int? SMOKYRS { get; set; }
        [Comment("Average number of packs smoked per day")]
        public int? PACKSPER { get; set; }
        [Comment("Has participant smoked within the last 30 days?")]
        public int? TOBAC30 { get; set; }
        [Comment("If the participant quit smoking, specify the age at which they last smoked (i.e., quit)")]
        public int? QUITSMOK { get; set; }
        [Comment("In the past 12 months, how often has the participant had a drink containing alcohol?")]
        public int? ALCFREQYR { get; set; }
        [Comment("On a day when the participant drinks alcoholic beverages, how many standard drinks does the participant typically consume?")]
        public int? ALCDRINKS { get; set; }
        [Comment("In the past 12 months, how often did the participant have six or more drinks containing alcohol in one day?")]
        public int? ALCBINGE { get; set; }
        [Comment("Participant used substances including prescription or recreational drugs that caused significant impairment in work, legal, driving, or social areas within the past 12 months")]
        public int? SUBSTYEAR { get; set; }
        [Comment("Participant used substances including prescription or recreational drugs that caused significant impairment in work, legal, driving, or social areas prior to 12 months ago")]
        public int? SUBSTPAST { get; set; }
        [Comment("In the past 12 months, how often has the participant consumed cannabis (edibles, smoked, or vaporized)?")]
        public int? CANNABIS { get; set; }
        [Comment("Heart attack (heart artery blockage)")]
        public int? HRTATTACK { get; set; }
        [Comment("More than one heart attack?")]
        public int? HRTATTMULT { get; set; }
        [Comment("Age at most recent heart attack")]
        public int? HRTATTAGE { get; set; }
        [Comment("Cardiac arrest (heart stopped)")]
        public int? CARDARREST { get; set; }
        [Comment("Age at most recent cardiac arrest")]
        public int? CARDARRAGE { get; set; }
        [Comment("Atrial fibrillation")]
        public int? CVAFIB { get; set; }
        [Comment("Coronary artery angioplasty / endarterectomy / stenting")]
        public int? CVANGIO { get; set; }
        [Comment("Coronary artery bypass procedure")]
        public int? CVBYPASS { get; set; }
        [Comment("Age at most recent coronary artery bypass surgery")]
        public int? BYPASSAGE { get; set; }
        [Comment("Pacemaker and/or defibrillator implantation")]
        public int? CVPACDEF { get; set; }
        [Comment("Age at first pacemaker and/or defibrillator implantation")]
        public int? PACDEFAGE { get; set; }
        [Comment("Congestive heart failure (including pulmonary edema)")]
        public int? CVCHF { get; set; }
        [Comment("Heart valve replacement or repair")]
        public int? CVHVALVE { get; set; }
        [Comment("Age at most recent heart valve replacement or repair procedure")]
        public int? VALVEAGE { get; set; }
        [Comment("Other cardiovascular disease")]
        public int? CVOTHR { get; set; }
        [Comment("Specify other cardiovascular disease")]
        [MaxLength(60)]
        public string? CVOTHRX { get; set; }
        [Comment("Stroke by history, not exam (imaging is not required)")]
        public int? CBSTROKE { get; set; }
        [Comment("More than one stroke?")]
        public int? STROKMUL { get; set; }
        [Comment("Age at most recent stroke")]
        public int? STROKAGE { get; set; }
        [Comment("What is status of stroke symptoms?")]
        public int? STROKSTAT { get; set; }
        [Comment("Carotid artery surgery or stenting?")]
        public int? ANGIOCP { get; set; }
        [Comment("Age at most recent carotid artery surgery or stenting")]
        public int? CAROTIDAGE { get; set; }
        [Comment("Transient ischemic attack (TIA)")]
        public int? CBTIA { get; set; }
        [Comment("Age at most recent TIA")]
        public int? TIAAGE { get; set; }
        [Comment("Parkinson’s disease (PD)")]
        public int? PD { get; set; }
        [Comment("Age at estimated PD symptom onset")]
        public int? PDAGE { get; set; }
        [Comment("Other parkinsonism disorder (e.g., DLB)")]
        public int? PDOTHR { get; set; }
        [Comment("Age at parkinsonism disorder diagnosis")]
        public int? PDOTHRAGE { get; set; }
        [Comment("Epilepsy and/or history of seizures (excluding childhood febrile seizures)")]
        public int? SEIZURES { get; set; }
        [Comment("How many seizures has the participant had in the past 12 months?")]
        public int? SEIZNUM { get; set; }
        [Comment("Age at first seizure (excluding childhood febrile seizures)")]
        public int? SEIZAGE { get; set; }
        [Comment("Chronic headaches")]
        public int? HEADACHE { get; set; }
        [Comment("Multiple sclerosis")]
        public int? MS { get; set; }
        [Comment("Normal-pressure hydrocephalus")]
        public int? HYDROCEPH { get; set; }
        [Comment("epetitive head impacts (e.g. from contact sports, intimate partner violence, or military duty), regardless of whether it caused symptoms.")]
        public int? HEADIMP { get; set; }
        [Comment("Source of exposure for repeated hits to the head: American football")]
        public bool? IMPAMFOOT { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Soccer")]
        public bool? IMPSOCCER { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Ice hockey")]
        public bool? IMPHOCKEY { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Boxing or mixed martial arts")]
        public bool? IMPBOXING { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Other contact sport")]
        public bool? IMPSPORT { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Intimate partner violence")]
        public bool? IMPIPV { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Military service")]
        public bool? IMPMILIT { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Physical assault")]
        public bool? IMPASSAULT { get; set; }
        [Comment("Source of exposure for repeated hits to the head: Other cause")]
        public bool? IMPOTHER { get; set; }
        [Comment("Specify other source of exposure for repeated hits to the head")]
        [MaxLength(60)]
        public string? IMPOTHERX { get; set; }
        [Comment("The total length of time in years that the participant was exposed to repeated hits to the head (e.g. playing American football for 7 years)")]
        public int? IMPYEARS { get; set; }
        [Comment("Head injury (e.g. in a vehicle accident, being hit by an object...)")]
        public int? HEADINJURY { get; set; }
        [Comment("After a head injury, what was the longest period of time that the participant was unconscious?")]
        public int? HEADINJUNC { get; set; }
        [Comment("After a head injury, what was the longest period...")]
        public int? HEADINJCON { get; set; }
        [Comment("Total number of head injuries")]
        public int? HEADINJNUM { get; set; }
        [Comment("Age of first head injury")]
        public int? FIRSTTBI { get; set; }
        [Comment("Age of most recent head injury")]
        public int? LASTTBI { get; set; }
        [Comment("Diabetes")]
        public int? DIABETES { get; set; }
        [Comment("Diabetes type")]
        public int? DIABTYPE { get; set; }
        [Comment("Diabetes treated with: Insulin")]
        public bool? DIABINS { get; set; }
        [Comment("Diabetes treated with: Oral medications")]
        public bool? DIABMEDS { get; set; }
        [Comment("Diabetes treated with: Diet")]
        public bool? DIABDIET { get; set; }
        [Comment("Diabetes treated with: Unknown")]
        public bool? DIABUNK { get; set; }
        [Comment("Age at diabetes diagnosis")]
        public int? DIABAGE { get; set; }
        [Comment("Hypertension (or taking medication for hypertension)")]
        public int? HYPERTEN { get; set; }
        [Comment("Age at hypertension diagnosis")]
        public int? HYPERTAGE { get; set; }
        [Comment("Hypercholesterolemia (or taking medication for high cholesterol)")]
        public int? HYPERCHO { get; set; }
        [Comment("Age at hypercholesterolemia diagnosis")]
        public int? HYPERCHAGE { get; set; }
        [Comment("B12 deficiency")]
        public int? B12DEF { get; set; }
        [Comment("Thyroid disease")]
        public int? THYROID { get; set; }
        [Comment("Arthritis")]
        public int? ARTHRIT { get; set; }
        [Comment("Type of arthritis: Rheumatoid")]
        public bool? ARTHRRHEUM { get; set; }
        [Comment("Type of arthritis: Osteoarthritis")]
        public bool? ARTHROSTEO { get; set; }
        [Comment("Type of arthritis: Other")]
        public bool? ARTHROTHR { get; set; }
        [Comment("Specify other type of arthritis")]
        [MaxLength(60)]
        public string? ARTHTYPX { get; set; }
        [Comment("Type of arthritis: Unknown")]
        public bool? ARTHTYPUNK { get; set; }
        [Comment("Upper extremity affected by arthritis")]
        public bool? ARTHUPEX { get; set; }
        [Comment("Lower extremity affected by arthritis")]
        public bool? ARTHLOEX { get; set; }
        [Comment("Spine affected by arthritis")]
        public bool? ARTHSPIN { get; set; }
        [Comment("Region affected by arthritis unknown")]
        public bool? ARTHUNK { get; set; }
        [Comment("Incontinence—urinary (occurring at least weekly)")]
        public int? INCONTU { get; set; }
        [Comment("Incontinence—bowel (occurring at least weekly)")]
        public int? INCONTF { get; set; }
        [Comment("Sleep apnea")]
        public int? APNEA { get; set; }
        [Comment("Typical use of breathing machine (e.g. CPAP) at night over the past 12 months")]
        public int? CPAP { get; set; }
        [Comment("Typical use of an oral device for sleep apnea at night over the past 12 months?")]
        public int? APNEAORAL { get; set; }
        [Comment("REM sleep behavior disorder")]
        public int? RBD { get; set; }
        [Comment("Hyposomnia/Insomnia (occurring at least weekly or requiring medication)")]
        public int? INSOMN { get; set; }
        [Comment("Other sleep disorder")]
        public int? OTHSLEEP { get; set; }
        [Comment("Specify other sleep disorder")]
        [MaxLength(60)]
        public string? OTHSLEEX { get; set; }
        [Comment("Cancer, primary or metastatic (Report all known diagnoses. Exclude non-melanoma skin cancer.)")]
        public int? CANCER { get; set; }
        [Comment("Type of cancer: Primary/non-metastatic")]
        public bool? CANCERPRIM { get; set; }
        [Comment("Type of cancer: Metastatic")]
        public bool? CANCERMETA { get; set; }
        [Comment("Type of metastatic cancer: Metatstic to brain")]
        public bool? CANCMETBR { get; set; }
        [Comment("Type of metastatic cancer: Metastatic to sites other than brain")]
        public bool? CANCMETOTH { get; set; }
        [Comment("Type of cancer: Unknown")]
        public bool? CANCERUNK { get; set; }
        [Comment("Primary site of cancer: Blood")]
        public bool? CANCBLOOD { get; set; }
        [Comment("Primary site of cancer: Breast")]
        public bool? CANCBREAST { get; set; }
        [Comment("Primary site of cancer: Colon")]
        public bool? CANCCOLON { get; set; }
        [Comment("Primary site of cancer: Lung")]
        public bool? CANCLUNG { get; set; }
        [Comment("Primary site of cancer: Prostate")]
        public bool? CANCPROST { get; set; }
        [Comment("Primary site of cancer: Other")]
        public bool? CANCOTHER { get; set; }
        [Comment("Specify other primary site of cancer")]
        [MaxLength]
        public string? CANCOTHERX { get; set; }
        [Comment("Type of cancer treatment: Radiation")]
        public bool? CANCRAD { get; set; }
        [Comment("Type of cancer treatment: Surgical resection")]
        public bool? CANCRESECT { get; set; }
        [Comment("Type of cancer treatment: Immunotherapy")]
        public bool? CANCIMMUNO { get; set; }
        [Comment("Type of cancer treatment: Bone marrow transplant")]
        public bool? CANCBONE { get; set; }
        [Comment("Type of cancer treatment: Chemotherapy")]
        public bool? CANCCHEMO { get; set; }
        [Comment("Type of cancer treatment: Hormone therapy")]
        public bool? CANCHORM { get; set; }
        [Comment("Type of cancer treatment: Other")]
        public bool? CANCTROTH { get; set; }
        [Comment("Specify other type of cancer treatment")]
        [MaxLength(60)]
        public string? CANCTROTHX { get; set; }
        [Comment("Age at most recent cancer diagnosis")]
        public int? CANCERAGE { get; set; }
        [Comment("COVID-19 infection")]
        public int? COVID19 { get; set; }
        [Comment("COVID-19 infection requiring hospitalization?")]
        public int? COVIDHOSP { get; set; }
        [Comment("Asthma/COPD/pulmonary disease")]
        public int? PULMONARY { get; set; }
        [Comment("Chronic kidney disease")]
        public int? KIDNEY { get; set; }
        [Comment("Age at chronic kidney disease diagnosis")]
        public int? KIDNEYAGE { get; set; }
        [Comment("Liver disease")]
        public int? LIVER { get; set; }
        [Comment("Age at liver disease diagnosis")]
        public int? LIVERAGE { get; set; }
        [Comment("Peripheral vascular disease")]
        public int? PVD { get; set; }
        [Comment("Age at peripheral vascular disease diagnosis")]
        public int? PVDAGE { get; set; }
        [Comment("Human Immunodeficiency Virus")]
        public int? HIVDIAG { get; set; }
        [Comment("Age at HIV diagnosis")]
        public int? HIVAGE { get; set; }
        [Comment("Other medical conditions or procedures")]
        public int? OTHCOND { get; set; }
        [Comment("Specify other medical conditions or procedures")]
        public string? OTHCONDX { get; set; }
        [Comment("Major depressive disorder (DSM-5-TR criteria)")]
        public int? MAJORDEP { get; set; }
        [Comment("Other specified depressive disorder (DSm-5-TR criteria)")]
        public int? OTHERDEP { get; set; }
        [Comment("Choose if treated or untreated")]
        public bool? DEPRTREAT { get; set; }
        [Comment("Bipolar disorder(DSM - 5 - TR criteria)")]
        public int? BIPOLAR { get; set; }
        [Comment("Schizophrenia or other psychosis disorder (DSM-5-TR criteria)")]
        public int? SCHIZ { get; set; }
        [Comment("Anxiety disorder (DSM-5-TR criteria)")]
        public int? ANXIETY { get; set; }
        [Comment("Generalized Anxiety Disorder")]
        public int? GENERALANX { get; set; }
        [Comment("Panic Disorder")]
        public int? PANICDIS { get; set; }
        [Comment("Obsessive-compulsive disorder (OCD)")]
        public int? OCD { get; set; }
        [Comment("Other anxiety disorder")]
        public int? OTHANXDIS { get; set; }
        [Comment("Specify other anxiety disorder")]
        [MaxLength(60)]
        public string? OTHANXDISX { get; set; }
        [Comment("Post-traumatic stress disorder (PTSD) (DSM-5-TR criteria)")]
        public int? PTSD { get; set; }
        [Comment("Developmental neuropsychiatric disorders")]
        public int? NPSYDEV { get; set; }
        [Comment("Other psychiatric disorders")]
        public int? PSYCDIS { get; set; }
        [Comment("Specify other psychiatric disorders")]
        [MaxLength(60)]
        public string? PSYCDISX { get; set; }
        [Comment("How old was the participant when they had their first menstrual period?")]
        public int? MENARCHE { get; set; }
        [Comment("How old was the participant when they had their last menstrual period?")]
        public int? NOMENSAGE { get; set; }
        [Comment("Participant has stopped having menstrual periods due to natural menopause")]
        public bool? NOMENSNAT { get; set; }
        [Comment("Participant has stopped having menstrual periods due to hysterectomy (surgical removal of uterus)")]
        public bool? NOMENSHYST { get; set; }
        [Comment("Participant has stopped having menstrual periods due to surgical removal of both ovaries")]
        public bool? NOMENSSURG { get; set; }
        [Comment("Participant has stopped having menstrual periods due to chemotherapy for cancer or another condition")]
        public bool? NOMENSCHEM { get; set; }
        [Comment("Participant has stopped having menstrual periods due to radiation treatment or other damage/injury to reproductive organs")]
        public bool? NOMENSRAD { get; set; }
        [Comment("Participant has stopped having menstrual periods due to hormonal supplements (e.g. the Pill, injections, Mirena, HRT)")]
        public bool? NOMENSHORM { get; set; }
        [Comment("Participant has stopped having menstrual periods due to anti-estrogen medication")]
        public bool? NOMENSESTR { get; set; }
        [Comment("Unsure of reason participant has stopped having menstrual periods")]
        public bool? NOMENSUNK { get; set; }
        [Comment("Other reason participant has stopped having menstrual periods")]
        public bool? NOMENSOTH { get; set; }
        [Comment("Specify other reason participant has stopped having menstrual periods")]
        [MaxLength(60)]
        public string? NOMENSOTHX { get; set; }
        [Comment("Has the participant taken female hormone replacement pills or patches (e.g. estrogen)?")]
        public int? HRT { get; set; }
        [Comment("Total number of years participant has taken female hormone replacement pills")]
        public int? HRTYEARS { get; set; }
        [Comment("Age at first use of female hormone replacement pills")]
        public int? HRTSTRTAGE { get; set; }
        [Comment("Age at last use of female hormone replacement pills")]
        public int? HRTENDAGE { get; set; }
        [Comment("Has the participant ever taken birth control pills?")]
        public int? BCPILLS { get; set; }
        [Comment("Total number of years participant has taken birth control pills")]
        public int? BCPILLSYR { get; set; }
        [Comment("Age at first use of birth control pills")]
        public int? BCSTARTAGE { get; set; }
        [Comment("Age at last use of birth control pills")]
        public int? BCENDAGE { get; set; }
    }
}
