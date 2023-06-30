using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class D1 : FormModel
    {
        [Display(Name = "Diagnosis method — responses in this form are based on diagnosis by")]
        public int? DXMETHOD { get; set; }

        [Display(Name = "Does the subject have normal cognition (global CDR=0 and/or neuropsychological testing within normal range) and normal behavior (i.e., the subject does not exhibit behavior sufficient to diagnose MCI or dementia due to FTLD or LBD)?")]
        public bool? NORMCOG { get; set; }

        [Display(Name = "Does the subject meet the criteria for dementia?")]
        public bool? DEMENTED { get; set; }

        [Display(Name = "Amnestic multidomain dementia syndrome")]
        public bool? AMNDEM { get; set; }

        [Display(Name = "Posterior cortical atrophy syndrome (or primary visual presentation)")]
        public bool? PCA { get; set; }

        [Display(Name = "Primary progressive aphasia (PPA) syndrome")]
        public bool? PPASYN { get; set; }

        [Display(Name = "Please indicate PPA type")]
        public int? PPASYNT { get; set; }

        [Display(Name = "Behavioral variant FTD (bvFTD) syndrome")]
        public bool? FTDSYN { get; set; }

        [Display(Name = "Lewy body dementia syndrome")]
        public bool? LBDSYN { get; set; }

        [Display(Name = "Non-amnestic multidomain dementia, not PCA, PPA, bvFTD, or DLB syndrome")]
        public bool? NAMNDEM { get; set; }

        [Display(Name = "Amnestic MCI, single domain (aMCI SD)")]
        public bool? MCIAMEM { get; set; }

        [Display(Name = "Amnestic MCI, multiple domains (aMCI MD)")]
        public bool? MCIAPLUS { get; set; }

        [Display(Name = "Language")]
        public bool? MCIAPLAN { get; set; }

        [Display(Name = "Attention")]
        public bool? MCIAPATT { get; set; }

        [Display(Name = "Executive")]
        public bool? MCIAPEX { get; set; }

        [Display(Name = "Visuospatial")]
        public bool? MCIAPVIS { get; set; }

        [Display(Name = "Non-amnestic MCI, single domain (naMCI SD)")]
        public bool? MCINON1 { get; set; }

        [Display(Name = "Language")]
        public bool? MCIN1LAN { get; set; }

        [Display(Name = "Attention")]
        public bool? MCIN1ATT { get; set; }

        [Display(Name = "Executive")]
        public bool? MCIN1EX { get; set; }

        [Display(Name = "Visuospatial")]
        public bool? MCIN1VIS { get; set; }

        [Display(Name = "Non-amnestic MCI, multiple domains (naMCI MD)")]
        public bool? MCINON2 { get; set; }

        [Display(Name = "Language")]
        public bool? MCIN2LAN { get; set; }

        [Display(Name = "Attention")]
        public bool? MCIN2ATT { get; set; }

        [Display(Name = "Executive")]
        public bool? MCIN2EX { get; set; }

        [Display(Name = "Visuospatial")]
        public bool? MCIN2VIS { get; set; }

        [Display(Name = "IMPNOMCI")]
        public bool? IMPNOMCI { get; set; }

        [Display(Name = "AMYLPET")]
        public int? AMYLPET { get; set; }

        [Display(Name = "Abnormally low amyloid in CSF")]
        public int? AMYLCSF { get; set; }

        [Display(Name = "FDG-PET pattern of AD")]
        public int? FDGAD { get; set; }

        [Display(Name = "Hippocampal atrophy")]
        public int? HIPPATR { get; set; }

        [Display(Name = "Tau PET evidence for AD")]
        public int? TAUPETAD { get; set; }

        [Display(Name = "Abnormally elevated CSF tau or ptau")]
        public int? CSFTAU { get; set; }

        [Display(Name = "FDG-PET evidence for frontal or anterior temporal hypometabolism for FTLD")]
        public int? FDGFTLD { get; set; }

        [Display(Name = "Tau PET evidence for FTLD")]
        public int? TPETFTLD { get; set; }

        [Display(Name = "Structural MR evidence for frontal or anterior temporal atrophy for FTLD")]
        public int? MRFTLD { get; set; }

        [Display(Name = "Dopamine transporter scan (DATscan) evidence for Lewy body disease")]
        public int? DATSCAN { get; set; }

        [Display(Name = "Other (specify)")]
        public bool? OTHBIOM { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? OTHBIOMX { get; set; }

        [Display(Name = "Large vessel infarct(s)")]
        public int? IMAGLINF { get; set; }

        [Display(Name = "Lacunar infarct(s)")]
        public int? IMAGLAC { get; set; }

        [Display(Name = "Macrohemorrhage(s)")]
        public int? IMAGMACH { get; set; }

        [Display(Name = "Microhemorrhage(s)")]
        public int? IMAGMICH { get; set; }

        [Display(Name = "Moderate white-matter hyperintensity (CHS score 5–6)")]
        public int? IMAGMWMH { get; set; }

        [Display(Name = "Extensive white-matter hyperintensity (CHS score 7–8+)")]
        public int? IMAGEWMH { get; set; }

        [Display(Name = "Does the subject have a dominantly inherited AD mutation (PSEN1, PSEN2, APP)")]
        public int? ADMUT { get; set; }

        [Display(Name = "Does the subject have a hereditary FTLD mutation (e.g., GRN, VCP, TARBP, FUS, C9orf72, CHMP2B, MAPT)?")]
        public int? FTLDMUT { get; set; }

        [Display(Name = "Does the subject have a hereditary mutation other than an AD or FTLD mutation?")]
        public int? OTHMUT { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? OTHMUTX { get; set; }

        [Display(Name = "Alzheimer's disease")]
        public bool? ALZDIS { get; set; }

        [Display(Name = "")]
        public int? ALZDISIF { get; set; }

        [Display(Name = "Lewy body disease")]
        public bool? LBDIS { get; set; }

        [Display(Name = "")]
        public int? LBDIF { get; set; }

        [Display(Name = "Parkinson's disease")]
        public bool? PARK { get; set; }

        [Display(Name = "Multiple system atrophy")]
        public bool? MSA { get; set; }

        [Display(Name = "")]
        public int? MSAIF { get; set; }

        [Display(Name = "Progressive supranuclear palsy (PSP)")]
        public bool? PSP { get; set; }

        [Display(Name = "")]
        public int? PSPIF { get; set; }

        [Display(Name = "Corticobasal degeneration (CBD)")]
        public bool? CORT { get; set; }

        [Display(Name = "")]
        public int? CORTIF { get; set; }

        [Display(Name = "FTLD with motor neuron disease")]
        public bool? FTLDMO { get; set; }

        [Display(Name = "")]
        public int? FTLDMOIF { get; set; }

        [Display(Name = "FTLD NOS")]
        public bool? FTLDNOS { get; set; }

        [Display(Name = "")]
        public int? FTLDNOIF { get; set; }

        [Display(Name = "If FTLD (Questions 14a – 14d) is Present, specify FTLD subtype")]
        public int? FTLDSUBT { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? FTLDSUBX { get; set; }

        [Display(Name = "Vascular brain injury (based on clinical or imaging evidence)")]
        public bool? CVD { get; set; }

        [Display(Name = "")]
        public int? CVDIF { get; set; }

        [Display(Name = "Previous symptomatic stroke?")]
        public bool? PREVSTK { get; set; }

        [Display(Name = "Temporal relationship between stroke and cognitive decline?")]
        public bool? STROKDEC { get; set; }

        [Display(Name = "Confirmation of stroke by neuroimaging?")]
        public int? STKIMAG { get; set; }

        [Display(Name = "Is there imaging evidence of cystic infarction in cognitive network(s)?")]
        public int? INFNETW { get; set; }

        [Display(Name = "Is there imaging evidence of cystic infarction, imaging evidence of extensive white matter hyperintensity (CHS grade 7–8+), and impairment in executive function?")]
        public int? INFWMH { get; set; }

        [Display(Name = "Essential tremor")]
        public bool? ESSTREM { get; set; }

        [Display(Name = "")]
        public int? ESSTREIF { get; set; }

        [Display(Name = "Down syndrome")]
        public bool? DOWNS { get; set; }

        [Display(Name = "")]
        public int? DOWNSIF { get; set; }

        [Display(Name = "Huntington's disease")]
        public bool? HUNT { get; set; }

        [Display(Name = "")]
        public int? HUNTIF { get; set; }

        [Display(Name = "Prion disease (CJD, other)")]
        public bool? PRION { get; set; }

        [Display(Name = "")]
        public int? PRIONIF { get; set; }

        [Display(Name = "Traumatic brain injury")]
        public bool? BRNINJ { get; set; }

        [Display(Name = "")]
        public int? BRNINJIF { get; set; }

        [Display(Name = "If Present, does the subject have symptoms consistent with chronic traumatic encephalopathy?")]
        public int? BRNINCTE { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus")]
        public bool? HYCEPH { get; set; }

        [Display(Name = "")]
        public int? HYCEPHIF { get; set; }

        [Display(Name = "Epilepsy")]
        public bool? EPILEP { get; set; }

        [Display(Name = "")]
        public int? EPILEPIF { get; set; }

        [Display(Name = "CNS neoplasm")]
        public bool? NEOP { get; set; }

        [Display(Name = "")]
        public int? NEOPIF { get; set; }

        [Display(Name = "")]
        public int? NEOPSTAT { get; set; }

        [Display(Name = "Human immunodeficiency virus (HIV)")]
        public bool? HIV { get; set; }

        [Display(Name = "")]
        public int? HIVIF { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, or infectious conditions not listed above")]
        public int? OTHCOG { get; set; }

        [Display(Name = "")]
        public int? OTHCOGIF { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        public string? OTHCOGX { get; set; }

        [Display(Name = "Active depression")]
        public bool? DEP { get; set; }

        [Display(Name = "")]
        public int? DEPIF { get; set; }

        [Display(Name = "If Present, select one")]
        public bool? DEPTREAT { get; set; }

        [Display(Name = "Bipolar disorder")]
        public bool? BIPOLDX { get; set; }

        [Display(Name = "")]
        public int? BIPOLDIF { get; set; }

        [Display(Name = "Schizophrenia or other psychosis")]
        public bool? SCHIZOP { get; set; }

        [Display(Name = "")]
        public int? SCHIZOIF { get; set; }

        [Display(Name = "Anxiety disorder")]
        public bool? ANXIET { get; set; }

        [Display(Name = "")]
        public int? ANXIETIF { get; set; }

        [Display(Name = "Delirium")]
        public bool? DELIR { get; set; }

        [Display(Name = "")]
        public int? DELIRIF { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD)")]
        public bool? PTSDDX { get; set; }

        [Display(Name = "")]
        public int? PTSDDXIF { get; set; }

        [Display(Name = "Other psychiatric disease")]
        public bool? OTHPSY { get; set; }

        [Display(Name = "")]
        public int? OTHPSYIF { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        public string? OTHPSYX { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse")]
        public bool? ALCDEM { get; set; }

        [Display(Name = "")]
        public int? ALCDEMIF { get; set; }

        [Display(Name = "Current alcohol abuse")]
        public int? ALCABUSE { get; set; }

        [Display(Name = "Cognitive impairment due to other substance abuse")]
        public bool? IMPSUB { get; set; }

        [Display(Name = "")]
        public int? IMPSUBIF { get; set; }

        [Display(Name = "Cognitive impairment due to systemic disease/medical illness (as indicated on Form D2)")]
        public bool? DYSILL { get; set; }

        [Display(Name = "")]
        public int? DYSILLIF { get; set; }

        [Display(Name = "Cognitive impairment due to medications")]
        public bool? MEDS { get; set; }

        [Display(Name = "")]
        public int? MEDSIF { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool? COGOTH { get; set; }

        [Display(Name = "")]
        public int? COGOTHIF { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        public string? COGOTHX { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool? COGOTH2 { get; set; }

        [Display(Name = "")]
        public int? COGOTH2F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        public string? COGOTH2X { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool? COGOTH3 { get; set; }

        [Display(Name = "")]
        public int? COGOTH3F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        public string? COGOTH3X { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

