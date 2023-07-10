using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class D1 : FormModel
    {
        [Display(Name = "Diagnosis method — responses in this form are based on diagnosis by")]
        public int? DXMETHOD { get; set; }

        [Display(Name = "Does the subject have normal cognition (global CDR=0 and/or neuropsychological testing within normal range) and normal behavior (i.e., the subject does not exhibit behavior sufficient to diagnose I or dementia due to FTLD or LBD)?")]
        public int? NORMCOG { get; set; }

        [Display(Name = "Does the subject meet the criteria for dementia?")]
        public int? DEMENTED { get; set; }

        [Display(Name = "Amnestic multidomain dementia syndrome")]
        public bool AMNDEM { get; set; }

        [Display(Name = "Posterior cortical atrophy syndrome (or primary visual presentation)")]
        public bool PCA { get; set; }

        [Display(Name = "If PPA present")]
        public bool PPASYN { get; set; }

        [Display(Name = "Please indicate PPA type")]
        [RequiredIf(nameof(PPASYN), "True", ErrorMessage = "Please indicate PPA type.")]
        public int? PPASYNT { get; set; }

        [Display(Name = "Behavioral variant FTD (bvFTD) syndrome")]
        public bool FTDSYN { get; set; }

        [Display(Name = "Lewy body dementia syndrome")]
        public bool LBDSYN { get; set; }

        [Display(Name = "Non-amnestic multidomain dementia, not PCA, PPA, bvFTD, or DLB syndrome")]
        public bool NAMNDEM { get; set; }

        [RequiredIf(nameof(DEMENTED), "True", ErrorMessage = "Please select one or more cognitive/behavioral syndromes.")]
        [NotMapped]
        public bool? DementiaSyndromeIndicated
        {
            get
            {
                if (AMNDEM || PCA || PPASYN || FTDSYN || LBDSYN || NAMNDEM)
                {
                    return true;
                }
                else return null;
            }
        }

        [Display(Name = "Amnestic MCI, single domain (aMCI SD)")]
        public bool MCIAMEM { get; set; }

        [Display(Name = "Amnestic MCI, multiple domains (aMCI MD)")]
        public bool MCIAPLUS { get; set; }

        [Display(Name = "Language")]
        public bool? MCIAPLAN { get; set; }

        [Display(Name = "Attention")]
        public bool? MCIAPATT { get; set; }

        [Display(Name = "Executive")]
        public bool? MCIAPEX { get; set; }

        [Display(Name = "Visuospatial")]
        public bool? MCIAPVIS { get; set; }

        [RequiredIf(nameof(MCIAPLUS), "True", ErrorMessage = "Please at least ONE additional affected domain.")]
        [NotMapped]
        public bool? AmnesticMCIMultipleDomainsIndicated
        {
            get
            {
                if (MCIAPLAN.HasValue && MCIAPATT.HasValue && MCIAPEX.HasValue && MCIAPVIS.HasValue)
                {
                    if (MCIAPLAN.Value || MCIAPATT.Value || MCIAPEX.Value || MCIAPVIS.Value)
                    {
                        return true;
                    }
                }
                return null;
            }
        }

        [Display(Name = "Non-amnestic MCI, single domain (naMCI SD)")]
        public bool MCINON1 { get; set; }

        [Display(Name = "Language")]
        public bool? MCIN1LAN { get; set; }

        [Display(Name = "Attention")]
        public bool? MCIN1ATT { get; set; }

        [Display(Name = "Executive")]
        public bool? MCIN1EX { get; set; }

        [Display(Name = "Visuospatial")]
        public bool? MCIN1VIS { get; set; }

        [RequiredIf(nameof(MCINON1), "True", ErrorMessage = "Please select ONE affected domain.")]
        [NotMapped]
        public bool? NonAmnesticMCISingleDomainIndicated
        {
            get
            {
                if (MCIN1LAN.HasValue && MCIN1ATT.HasValue && MCIN1EX.HasValue && MCIN1VIS.HasValue)
                {
                    int counter = 0;
                    if (MCIN1LAN.Value)
                    {
                        counter++;
                    }
                    if (MCIN1ATT.Value)
                    {
                        counter++;
                    }
                    if (MCIN1EX.Value)
                    {
                        counter++;
                    }
                    if (MCIN1VIS.Value)
                    {
                        counter++;
                    }
                    if (counter == 1)
                    {
                        return true;
                    }
                }
                return null;
            }
        }

        [Display(Name = "Non-amnestic MCI, multiple domains (naMCI MD)")]
        public bool MCINON2 { get; set; }

        [Display(Name = "Language")]
        public bool? MCIN2LAN { get; set; }

        [Display(Name = "Attention")]
        public bool? MCIN2ATT { get; set; }

        [Display(Name = "Executive")]
        public bool? MCIN2EX { get; set; }

        [Display(Name = "Visuospatial")]
        public bool? MCIN2VIS { get; set; }

        [RequiredIf(nameof(MCINON2), "True", ErrorMessage = "Please select at least TWO affected domains.")]
        [NotMapped]
        public bool? NonAmnesticMCIMultipleDomainsIndicated
        {
            get
            {
                if (MCIN2LAN.HasValue && MCIN2ATT.HasValue && MCIN2EX.HasValue && MCIN2VIS.HasValue)
                {
                    int counter = 0;
                    if (MCIN2LAN.Value)
                    {
                        counter++;
                    }
                    if (MCIN2ATT.Value)
                    {
                        counter++;
                    }
                    if (MCIN2EX.Value)
                    {
                        counter++;
                    }
                    if (MCIN2VIS.Value)
                    {
                        counter++;
                    }
                    if (counter >= 2)
                    {
                        return true;
                    }
                }
                return null;
            }
        }


        [Display(Name = "Cognitively impaired, not MCI")]
        public bool IMPNOMCI { get; set; }

        [Display(Name = "Abnormally elevated amyloid on PET")]
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
        public int? OTHBIOM { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(OTHBIOM), "1", ErrorMessage = "Please specify other biomarker findings.")]
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
        [RequiredIf(nameof(OTHMUT), "1", ErrorMessage = "Please specify other imaging findings.")]
        [MaxLength(60)]
        public string? OTHMUTX { get; set; }

        [Display(Name = "Alzheimer's disease")]
        public bool ALZDIS { get; set; }

        [Display(Name = "Alzheimer’s disease, primary or contributing")]
        [RequiredIf(nameof(ALZDIS), "True", ErrorMessage = "Indicate diagnosis for Alzheimer's disease.")]
        public int? ALZDISIF { get; set; }

        [Display(Name = "Lewy body disease")]
        public bool LBDIS { get; set; }

        [Display(Name = "Lewy body disease, primary or contributing")]
        [RequiredIf(nameof(LBDIS), "True", ErrorMessage = "Indicate diagnosis for Lewy body disease.")]
        public int? LBDIF { get; set; }

        [Display(Name = "Parkinson's disease")]
        public bool PARK { get; set; }

        [Display(Name = "Multiple system atrophy")]
        public bool MSA { get; set; }

        [Display(Name = "Multiple system atrophy nprimary or contributing")]
        [RequiredIf(nameof(MSA), "True", ErrorMessage = "Indicate diagnosis for Multiple system atrophy.")]
        public int? MSAIF { get; set; }

        [Display(Name = "Progressive supranuclear palsy (PSP)")]
        public bool PSP { get; set; }

        [Display(Name = "Progressive supranuclear palsy (PSP), primary or contributing")]
        [RequiredIf(nameof(PSP), "True", ErrorMessage = "Indicate diagnosis for Progressive supranuclear palsy (PSP).")]
        public int? PSPIF { get; set; }

        [Display(Name = "Corticobasal degeneration (CBD)")]
        public bool CORT { get; set; }

        [Display(Name = "Corticobasal degeneration (CBD), primary or contributing")]
        [RequiredIf(nameof(CORT), "True", ErrorMessage = "Indicate diagnosis for Corticobasal degeneration (CBD).")]
        public int? CORTIF { get; set; }

        [Display(Name = "FTLD with motor neuron disease")]
        public bool FTLDMO { get; set; }

        [Display(Name = "FTLD with motor neuron disease, primary or contributing")]
        [RequiredIf(nameof(FTLDMO), "True", ErrorMessage = "Indicate diagnosis for FTLD with motor neuron disease.")]
        public int? FTLDMOIF { get; set; }

        [Display(Name = "FTLD NOS")]
        public bool FTLDNOS { get; set; }

        [Display(Name = "FTLD NOS, primary or contributing")]
        [RequiredIf(nameof(FTLDNOS), "True", ErrorMessage = "Indicate diagnosis for FTLD NOS.")]
        public int? FTLDNOIF { get; set; }

        [Display(Name = "If FTLD (Questions 14a – 14d) is Present, specify FTLD subtype")]
        [RequiredIf(nameof(PSPIF), "True", ErrorMessage = "Please indicate FTLD subtype")]
        [RequiredIf(nameof(CORT), "True", ErrorMessage = "Please indicate FTLD subtype")]
        [RequiredIf(nameof(FTLDMO), "True", ErrorMessage = "Please indicate FTLD subtype")]
        [RequiredIf(nameof(FTLDNOS), "True", ErrorMessage = "Please indicate FTLD subtype")]
        public int? FTLDSUBT { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(FTLDSUBT), "3", ErrorMessage = "Please specify FTLD subtype")]
        [MaxLength(60)]
        public string? FTLDSUBX { get; set; }

        [Display(Name = "Vascular brain injury (based on clinical or imaging evidence)")]
        public bool CVD { get; set; }

        [Display(Name = "Vascular brain injury, primary or contributing")]
        [RequiredIf(nameof(CVD), "True", ErrorMessage = "Indicate diagnosis for Vascular brain injury.")]
        public int? CVDIF { get; set; }

        [Display(Name = "Previous symptomatic stroke?")]
        [RequiredIf(nameof(CVD), "True", ErrorMessage = "Please indicate")]
        public int? PREVSTK { get; set; }

        [Display(Name = "Temporal relationship between stroke and cognitive decline?")]
        [RequiredIf(nameof(PREVSTK), "1", ErrorMessage = "Please indicate")]
        public int? STROKDEC { get; set; }

        [Display(Name = "Confirmation of stroke by neuroimaging?")]
        [RequiredIf(nameof(PREVSTK), "1", ErrorMessage = "Please indicate")]
        public int? STKIMAG { get; set; }

        [Display(Name = "Is there imaging evidence of cystic infarction in cognitive network(s)?")]
        [RequiredIf(nameof(CVD), "True", ErrorMessage = "Please indicate")]
        public int? INFNETW { get; set; }

        [Display(Name = "Is there imaging evidence of cystic infarction, imaging evidence of extensive white matter hyperintensity (CHS grade 7–8+), and impairment in executive function?")]
        [RequiredIf(nameof(CVD), "True", ErrorMessage = "Please indicate")]
        public int? INFWMH { get; set; }

        [Display(Name = "Essential tremor")]
        public bool ESSTREM { get; set; }

        [Display(Name = "Essential tremor, primary or contributing")]
        [RequiredIf(nameof(ESSTREM), "True", ErrorMessage = "Indicate diagnosis for Essential tremor.")]
        public int? ESSTREIF { get; set; }

        [Display(Name = "Down syndrome")]
        public bool DOWNS { get; set; }

        [Display(Name = "Down syndrome, primary or contributing")]
        [RequiredIf(nameof(DOWNS), "True", ErrorMessage = "Indicate diagnosis for Down syndrome.")]
        public int? DOWNSIF { get; set; }

        [Display(Name = "Huntington's disease")]
        public bool HUNT { get; set; }

        [Display(Name = "Huntington’s disease, primary or contributing")]
        [RequiredIf(nameof(HUNT), "True", ErrorMessage = "Indicate diagnosis for Huntington's disease.")]
        public int? HUNTIF { get; set; }

        [Display(Name = "Prion disease (CJD, other)")]
        public bool PRION { get; set; }

        [Display(Name = "Prion disease, primary or contributing")]
        [RequiredIf(nameof(PRION), "True", ErrorMessage = "Indicate diagnosis for Prion disease (CJD, other).")]
        public int? PRIONIF { get; set; }

        [Display(Name = "Traumatic brain injury")]
        public bool BRNINJ { get; set; }

        [Display(Name = "Traumatic brain injury, primary or contributing")]
        [RequiredIf(nameof(BRNINJ), "True", ErrorMessage = "Indicate diagnosis for Traumatic brain injury.")]
        public int? BRNINJIF { get; set; }

        [Display(Name = "If Present, does the subject have symptoms consistent with chronic traumatic encephalopathy?")]
        [RequiredIf(nameof(BRNINJ), "True", ErrorMessage = "Please indicate")]
        public int? BRNINCTE { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus")]
        public bool HYCEPH { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus, primary or contributing")]
        [RequiredIf(nameof(HYCEPH), "True", ErrorMessage = "Indicate diagnosis for Normal-pressure hydrocephalus.")]
        public int? HYCEPHIF { get; set; }

        [Display(Name = "Epilepsy")]
        public bool EPILEP { get; set; }

        [Display(Name = "Epilepsy, primary or contributing")]
        [RequiredIf(nameof(EPILEP), "True", ErrorMessage = "Indicate diagnosis for Epilepsy.")]
        public int? EPILEPIF { get; set; }

        [Display(Name = "CNS neoplasm")]
        public bool NEOP { get; set; }

        [Display(Name = "CNS neoplasm, primary or contributing")]
        [RequiredIf(nameof(NEOP), "True", ErrorMessage = "Indicate diagnosis for CNS neoplasm.")]
        public int? NEOPIF { get; set; }

        [Display(Name = "CNS neoplasm, benign or malignant?")]
        [RequiredIf(nameof(NEOP), "True", ErrorMessage = "Please indicate")]
        public int? NEOPSTAT { get; set; }

        [Display(Name = "Human immunodeficiency virus (HIV)")]
        public bool HIV { get; set; }

        [Display(Name = "Human immunodeficiency virus (HIV), primary or contributing")]
        [RequiredIf(nameof(HIV), "True", ErrorMessage = "Indicate diagnosis for Human immunodeficiency virus (HIV).")]
        public int? HIVIF { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, or infectious conditions not listed above")]
        public bool OTHCOG { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, or infectious conditions not listed above, primary or contributing")]
        [RequiredIf(nameof(OTHCOG), "True", ErrorMessage = "Indicate diagnosis for Other cognitive impairment.")]
        public int? OTHCOGIF { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(OTHCOG), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        public string? OTHCOGX { get; set; }

        [Display(Name = "Active depression")]
        public bool DEP { get; set; }

        [Display(Name = "Active depression, primary or contributing")]
        [RequiredIf(nameof(DEP), "True", ErrorMessage = "Indicate diagnosis for Active depression.")]
        public int? DEPIF { get; set; }

        [Display(Name = "If Present, select one")]
        [RequiredIf(nameof(DEP), "True", ErrorMessage = "Please indicate")]
        public int? DEPTREAT { get; set; }

        [Display(Name = "Bipolar disorder")]
        public bool BIPOLDX { get; set; }

        [Display(Name = "Bipolar disorder, primary or contributing")]
        [RequiredIf(nameof(BIPOLDX), "True", ErrorMessage = "Indicate diagnosis for Bipolar disorder.")]
        public int? BIPOLDIF { get; set; }

        [Display(Name = "Schizophrenia or other psychosis")]
        public bool SCHIZOP { get; set; }

        [Display(Name = "Schizophrenia or other psychosis, primary or contributing")]
        [RequiredIf(nameof(SCHIZOP), "True", ErrorMessage = "Indicate diagnosis for Schizophrenia or other psychosis.")]
        public int? SCHIZOIF { get; set; }

        [Display(Name = "Anxiety disorder")]
        public bool ANXIET { get; set; }

        [Display(Name = "Anxiety disorder, primary or contributing")]
        [RequiredIf(nameof(ANXIET), "True", ErrorMessage = "Indicate diagnosis for Anxiety disorder.")]
        public int? ANXIETIF { get; set; }

        [Display(Name = "Delirium")]
        public bool DELIR { get; set; }

        [Display(Name = "Delirium, primary or contributing")]
        [RequiredIf(nameof(DELIR), "True", ErrorMessage = "Indicate diagnosis for Delirium.")]
        public int? DELIRIF { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD)")]
        public bool PTSDDX { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD), primary or contributing")]
        [RequiredIf(nameof(PTSDDX), "True", ErrorMessage = "Indicate diagnosis for Post-traumatic stress disorder (PTSD).")]
        public int? PTSDDXIF { get; set; }

        [Display(Name = "Other psychiatric disease")]
        public bool OTHPSY { get; set; }

        [Display(Name = "Other psychiatric disease, primary or contributing")]
        [RequiredIf(nameof(OTHPSY), "True", ErrorMessage = "Indicate diagnosis for Other psychiatric disease.")]
        public int? OTHPSYIF { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(OTHPSY), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        public string? OTHPSYX { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse")]
        public bool ALCDEM { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse, primary or contributing")]
        [RequiredIf(nameof(ALCDEM), "True", ErrorMessage = "Indicate diagnosis for Cognitive impairment due to alcohol abuse.")]
        public int? ALCDEMIF { get; set; }

        [Display(Name = "Current alcohol abuse")]
        [RequiredIf(nameof(ALCDEM), "True", ErrorMessage = "Please indicate")]
        public int? ALCABUSE { get; set; }

        [Display(Name = "Cognitive impairment due to other substance abuse")]
        public bool IMPSUB { get; set; }

        [Display(Name = "Cognitive impairment due to other substance abuse, primary or contributing")]
        [RequiredIf(nameof(IMPSUB), "True", ErrorMessage = "Indicate diagnosis for Cognitive impairment due to other substance abuse.")]
        public int? IMPSUBIF { get; set; }

        [Display(Name = "Cognitive impairment due to systemic disease/medical illness (as indicated on Form D2)")]
        public bool DYSILL { get; set; }

        [Display(Name = "Cognitive impairment due to systemic disease/nmedical illness, primary or contributing")]
        [RequiredIf(nameof(DYSILL), "True", ErrorMessage = "Indicate diagnosis for Cognitive impairment due to systemic disease/medical illness (as indicated on Form D2).")]
        public int? DYSILLIF { get; set; }

        [Display(Name = "Cognitive impairment due to medications")]
        public bool MEDS { get; set; }

        [Display(Name = "Cognitive impairment due to medications, primary or contributing")]
        [RequiredIf(nameof(MEDS), "True", ErrorMessage = "Indicate diagnosis for Cognitive impairment due to medications.")]
        public int? MEDSIF { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool COGOTH { get; set; }

        [Display(Name = "Cognitive impairment NOS, primary or contributing")]
        [RequiredIf(nameof(COGOTH), "True", ErrorMessage = "Indicate diagnosis for Cognitive impairment NOS.")]
        public int? COGOTHIF { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(COGOTH), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        public string? COGOTHX { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool COGOTH2 { get; set; }

        [Display(Name = "Cognitive impairment NOS, primary or contributing")]
        [RequiredIf(nameof(COGOTH2), "True", ErrorMessage = "Indicate diagnosis for Cognitive impairment NOS.")]
        public int? COGOTH2F { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(COGOTH2), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        public string? COGOTH2X { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool COGOTH3 { get; set; }

        [Display(Name = "Cognitive impairment NOS, primary or contributing")]
        [RequiredIf(nameof(COGOTH3), "True", ErrorMessage = "Indicate diagnosis for Cognitive impairment NOS.")]
        public int? COGOTH3F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH3), "True", ErrorMessage = "Please indicate")]
        public string? COGOTH3X { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

