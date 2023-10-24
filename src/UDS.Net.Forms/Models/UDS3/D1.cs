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
        #region Section 1  Cognitive and behavioral status
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

        [RequiredIf(nameof(DEMENTED), "1", ErrorMessage = "Please select one or more cognitive/behavioral syndromes.")]
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

        [RequiredIf(nameof(DEMENTED), "0", ErrorMessage = "Please indicate the type of cognitive impairment  (Question 5a-5e).")]
        [NotMapped]
        public bool? DementiaSyndromeNotIndicated
        {
            get
            {
                if (MCIAMEM || MCIAPLUS || MCINON1 || MCINON2 || IMPNOMCI)
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
        public int? MCIAPLAN { get; set; }

        [Display(Name = "Attention")]
        public int? MCIAPATT { get; set; }

        [Display(Name = "Executive")]
        public int? MCIAPEX { get; set; }

        [Display(Name = "Visuospatial")]
        public int? MCIAPVIS { get; set; }

        [RequiredIf(nameof(MCIAPLUS), "True", ErrorMessage = "Please select at least ONE additional affected domain.")]
        [NotMapped]
        public bool? AmnesticMCIMultipleDomainsIndicated
        {
            get
            {
                if (MCIAPLAN == 1 || MCIAPATT == 1 || MCIAPEX == 1 || MCIAPVIS == 1)
                {
                    return true;
                }
                else
                {
                    return null;
                }
            }
        }

        [Display(Name = "Non-amnestic MCI, single domain (naMCI SD)")]
        public bool MCINON1 { get; set; }

        [Display(Name = "Language")]
        public int? MCIN1LAN { get; set; }

        [Display(Name = "Attention")]
        public int? MCIN1ATT { get; set; }

        [Display(Name = "Executive")]
        public int? MCIN1EX { get; set; }

        [Display(Name = "Visuospatial")]
        public int? MCIN1VIS { get; set; }

        [RequiredIf(nameof(MCINON1), "True", ErrorMessage = "Please select ONE affected domain.")]
        [NotMapped]
        public bool? NonAmnesticMCISingleDomainIndicated
        {
            get
            {
                int counter = 0;
                if (MCIN1LAN == 1)
                {
                    counter++;
                }
                if (MCIN1ATT == 1)
                {
                    counter++;
                }
                if (MCIN1EX == 1)
                {
                    counter++;
                }
                if (MCIN1VIS == 1)
                {
                    counter++;
                }
                if (counter == 1)
                {
                    return true;
                }
                return null;
            }

        }

        [Display(Name = "Non-amnestic MCI, multiple domains (naMCI MD)")]
        public bool MCINON2 { get; set; }

        [Display(Name = "Language")]
        public int? MCIN2LAN { get; set; }

        [Display(Name = "Attention")]
        public int? MCIN2ATT { get; set; }

        [Display(Name = "Executive")]
        public int? MCIN2EX { get; set; }

        [Display(Name = "Visuospatial")]
        public int? MCIN2VIS { get; set; }

        [RequiredIf(nameof(MCINON2), "True", ErrorMessage = "Please select at least TWO affected domains.")]
        [NotMapped]
        public bool? NonAmnesticMCIMultipleDomainsIndicated
        {
            get
            {
                int counter = 0;
                if (MCIN2LAN == 1)
                {
                    counter++;
                }
                if (MCIN2ATT == 1)
                {
                    counter++;
                }
                if (MCIN2EX == 1)
                {
                    counter++;
                }
                if (MCIN2VIS == 1)
                {
                    counter++;
                }
                if (counter >= 2)
                {
                    return true;
                }
                return null;
            }
        }


        [Display(Name = "Cognitively impaired, not MCI")]
        public bool IMPNOMCI { get; set; }

        #endregion
        #region Section 2   Biomarkers, imaging and genetics
        [Display(Name = "Abnormally elevated amyloid on PET")]
        [RequiredOnComplete]
        public int? AMYLPET { get; set; }

        [Display(Name = "Abnormally low amyloid in CSF")]
        [RequiredOnComplete]
        public int? AMYLCSF { get; set; }

        [Display(Name = "FDG-PET pattern of AD")]
        [RequiredOnComplete]
        public int? FDGAD { get; set; }

        [Display(Name = "Hippocampal atrophy")]
        [RequiredOnComplete]
        public int? HIPPATR { get; set; }

        [Display(Name = "Tau PET evidence for AD")]
        [RequiredOnComplete]
        public int? TAUPETAD { get; set; }

        [Display(Name = "Abnormally elevated CSF tau or ptau")]
        [RequiredOnComplete]
        public int? CSFTAU { get; set; }

        [Display(Name = "FDG-PET evidence for frontal or anterior temporal hypometabolism for FTLD")]
        [RequiredOnComplete]
        public int? FDGFTLD { get; set; }

        [Display(Name = "Tau PET evidence for FTLD")]
        [RequiredOnComplete]
        public int? TPETFTLD { get; set; }

        [Display(Name = "Structural MR evidence for frontal or anterior temporal atrophy for FTLD")]
        [RequiredOnComplete]
        public int? MRFTLD { get; set; }

        [Display(Name = "Dopamine transporter scan (DATscan) evidence for Lewy body disease")]
        [RequiredOnComplete]
        public int? DATSCAN { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredOnComplete]
        public int? OTHBIOM { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(OTHBIOM), "1", ErrorMessage = "Please specify other biomarker findings.")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? OTHBIOMX { get; set; }

        [Display(Name = "Large vessel infarct(s)")]
        [RequiredOnComplete]
        public int? IMAGLINF { get; set; }

        [Display(Name = "Lacunar infarct(s)")]
        [RequiredOnComplete]
        public int? IMAGLAC { get; set; }

        [Display(Name = "Macrohemorrhage(s)")]
        [RequiredOnComplete]
        public int? IMAGMACH { get; set; }

        [Display(Name = "Microhemorrhage(s)")]
        [RequiredOnComplete]
        public int? IMAGMICH { get; set; }

        [Display(Name = "Moderate white-matter hyperintensity (CHS score 5–6)")]
        [RequiredOnComplete]
        public int? IMAGMWMH { get; set; }

        [Display(Name = "Extensive white-matter hyperintensity (CHS score 7–8+)")]
        [RequiredOnComplete]
        public int? IMAGEWMH { get; set; }

        [Display(Name = "Does the subject have a dominantly inherited AD mutation (PSEN1, PSEN2, APP)")]
        [RequiredOnComplete]
        public int? ADMUT { get; set; }

        [Display(Name = "Does the subject have a hereditary FTLD mutation (e.g., GRN, VCP, TARBP, FUS, C9orf72, CHMP2B, MAPT)?")]
        [RequiredOnComplete]
        public int? FTLDMUT { get; set; }

        [Display(Name = "Does the subject have a hereditary mutation other than an AD or FTLD mutation?")]
        [RequiredOnComplete]
        public int? OTHMUT { get; set; }

        [Display(Name = "Other (specify)")]
        [RequiredIf(nameof(OTHMUT), "1", ErrorMessage = "Please specify other imaging findings.")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? OTHMUTX { get; set; }

        #endregion

        #region One Primary Diagnosis Allowed Questions 11a-39a
        [RequiredOnComplete(ErrorMessage = "In Section 3, only ONE diagnosis should be indicated as primary.")]
        [NotMapped]
        public bool? OnePrimaryDiagnosisAllowed
        {
            get
            {
                int counter = 0;

                if (ALZDISIF.HasValue && ALZDISIF == 1)
                {
                    counter++;
                }
                if (LBDIF.HasValue && LBDIF == 1)
                {
                    counter++;
                }

                if (MSAIF.HasValue && MSAIF == 1)
                {
                    counter++;
                }
                if (PSPIF.HasValue && PSPIF == 1)
                {
                    counter++;
                }
                if (CORTIF.HasValue && CORTIF == 1)
                {
                    counter++;
                }

                if (FTLDMOIF.HasValue && FTLDMOIF == 1)
                {
                    counter++;
                }
                if (FTLDNOIF.HasValue && FTLDNOIF == 1)
                {
                    counter++;
                }
                if (CVDIF.HasValue && CVDIF == 1)
                {
                    counter++;
                }
                if (ESSTREIF.HasValue && ESSTREIF == 1)
                {
                    counter++;
                }
                if (DOWNSIF.HasValue && DOWNSIF == 1)
                {
                    counter++;
                }
                if (HUNTIF.HasValue && HUNTIF == 1)
                {
                    counter++;
                }

                if (PRIONIF.HasValue && PRIONIF == 1)
                {
                    counter++;
                }

                {
                    if (BRNINJIF.HasValue && BRNINJIF == 1)
                        counter++;
                }

                if (HYCEPHIF.HasValue && HYCEPHIF == 1)
                {
                    counter++;
                }

                if (EPILEPIF.HasValue && EPILEPIF == 1)
                {
                    counter++;
                }

                if (NEOPIF.HasValue && NEOPIF == 1)
                {
                    counter++;
                }

                if (HIVIF.HasValue && HIVIF == 1)
                {
                    counter++;
                }

                if (OTHCOGIF.HasValue && OTHCOGIF == 1)
                {
                    counter++;
                }

                if (DEPIF.HasValue && DEPIF == 1)
                {
                    counter++;
                }

                if (BIPOLDIF.HasValue && BIPOLDIF == 1)
                {
                    counter++;
                }

                if (SCHIZOIF.HasValue && SCHIZOIF == 1)
                {
                    counter++;
                }

                if (ANXIETIF.HasValue && ANXIETIF == 1)
                {
                    counter++;
                }

                if (DELIRIF.HasValue && DELIRIF == 1)
                {
                    counter++;
                }

                if (PTSDDXIF.HasValue && PTSDDXIF == 1)
                {
                    counter++;
                }

                if (OTHPSYIF.HasValue && OTHPSYIF == 1)
                {
                    counter++;
                }

                if (ALCDEMIF.HasValue && ALCDEMIF == 1)
                {
                    counter++;
                }

                if (IMPSUBIF.HasValue && IMPSUBIF == 1)
                {
                    counter++;
                }

                if (DYSILLIF.HasValue && DYSILLIF == 1)
                {
                    counter++;
                }

                if (MEDSIF.HasValue && MEDSIF == 1)
                {
                    counter++;
                }

                if (COGOTHIF.HasValue && COGOTHIF == 1)
                {
                    counter++;
                }

                if (COGOTH2F.HasValue && COGOTH2F == 1)
                {
                    counter++;
                }

                if (COGOTH3F.HasValue && COGOTH3F == 1)
                {
                    counter++;
                }


                if (counter == 1)
                {
                    return true;
                }

                else
                {
                    if (NORMCOG.HasValue && NORMCOG == 1 && counter == 0)
                    {
                        return true;
                    }
                    return null;
                }
            }
        }

        #endregion

        #region At Least One Or More Diagnoses Present Questions 11-39

        [RequiredOnComplete(ErrorMessage = "In Section 3, if the particpant does not have normal cognition, at least ONE diagnosis should be indicated as present.")]
        [NotMapped]
        public bool? OneDiagnosesPresent
        {
            get
            {
                int counter = 0;

                if (ALZDIS == true)
                {
                    counter++;
                }
                if (LBDIS == true)
                {
                    counter++;
                }

                if (MSA == true)
                {
                    counter++;
                }
                if (PSP == true)
                {
                    counter++;
                }
                if (CORT == true)
                {
                    counter++;
                }

                if (FTLDMO == true)
                {
                    counter++;
                }
                if (FTLDNOS == true)
                {
                    counter++;
                }
                if (CVD == true)
                {
                    counter++;
                }
                if (ESSTREM == true)
                {
                    counter++;
                }
                if (DOWNS == true)
                {
                    counter++;
                }
                if (HUNT == true)
                {
                    counter++;
                }

                if (PRION == true)
                {
                    counter++;
                }

                if (BRNINJ == true)
                {
                    counter++;
                }

                if (HYCEPH == true)
                {
                    counter++;
                }

                if (EPILEP == true)
                {
                    counter++;
                }

                if (NEOP == true)
                {
                    counter++;
                }

                if (HIV == true)
                {
                    counter++;
                }

                if (OTHCOG == true)
                {
                    counter++;
                }

                if (DEP == true)
                {
                    counter++;
                }

                if (BIPOLDX == true)
                {
                    counter++;
                }

                if (SCHIZOP == true)
                {
                    counter++;
                }

                if (ANXIET == true)
                {
                    counter++;
                }

                if (DELIR == true)
                {
                    counter++;
                }

                if (PTSDDX == true)
                {
                    counter++;
                }

                if (OTHPSY == true)
                {
                    counter++;
                }

                if (ALCDEM == true)
                {
                    counter++;
                }

                if (IMPSUB == true)
                {
                    counter++;
                }

                if (DYSILL == true)
                {
                    counter++;
                }

                if (MEDS == true)
                {
                    counter++;
                }

                if (COGOTH == true)
                {
                    counter++;
                }

                if (COGOTH2 == true)
                {
                    counter++;
                }

                if (COGOTH3 == true)
                {
                    counter++;
                }

                if (counter >= 1)
                {
                    return true;
                }

                else
                {
                    if (NORMCOG.HasValue && NORMCOG == 1)
                    {
                        return true;
                    }
                    return null;
                }

            }
        }

        #endregion

        #region  Section 3 Etiologic Diagnoses
        [Display(Name = "Alzheimer's disease")]
        public bool ALZDIS { get; set; }

        [Display(Name = "Alzheimer’s disease, primary or contributing")]
        public int? ALZDISIF { get; set; }

        [Display(Name = "Lewy body disease")]
        public bool LBDIS { get; set; }

        [Display(Name = "Lewy body disease, primary or contributing")]
        public int? LBDIF { get; set; }

        [Display(Name = "Parkinson's disease")]
        public bool PARK { get; set; }

        [Display(Name = "Multiple system atrophy")]
        public bool MSA { get; set; }

        [Display(Name = "Multiple system atrophy nprimary or contributing")]
        public int? MSAIF { get; set; }

        [Display(Name = "Progressive supranuclear palsy (PSP)")]
        public bool PSP { get; set; }

        [Display(Name = "Progressive supranuclear palsy (PSP), primary or contributing")]
        public int? PSPIF { get; set; }

        [Display(Name = "Corticobasal degeneration (CBD)")]
        public bool CORT { get; set; }

        [Display(Name = "Corticobasal degeneration (CBD), primary or contributing")]
        public int? CORTIF { get; set; }

        [Display(Name = "FTLD with motor neuron disease")]
        public bool FTLDMO { get; set; }

        [Display(Name = "FTLD with motor neuron disease, primary or contributing")]
        public int? FTLDMOIF { get; set; }

        [Display(Name = "FTLD NOS")]
        public bool FTLDNOS { get; set; }

        [Display(Name = "FTLD NOS, primary or contributing")]
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
        [ProhibitedCharacters]
        public string? FTLDSUBX { get; set; }

        [Display(Name = "Vascular brain injury (based on clinical or imaging evidence)")]
        public bool CVD { get; set; }

        [Display(Name = "Vascular brain injury, primary or contributing")]
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
        public int? ESSTREIF { get; set; }

        [Display(Name = "Down syndrome")]
        public bool DOWNS { get; set; }

        [Display(Name = "Down syndrome, primary or contributing")]
        public int? DOWNSIF { get; set; }

        [Display(Name = "Huntington's disease")]
        public bool HUNT { get; set; }

        [Display(Name = "Huntington’s disease, primary or contributing")]
        public int? HUNTIF { get; set; }

        [Display(Name = "Prion disease (CJD, other)")]
        public bool PRION { get; set; }

        [Display(Name = "Prion disease, primary or contributing")]
        public int? PRIONIF { get; set; }

        [Display(Name = "Traumatic brain injury")]
        public bool BRNINJ { get; set; }

        [Display(Name = "Traumatic brain injury, primary or contributing")]
        public int? BRNINJIF { get; set; }

        [Display(Name = "If Present, does the subject have symptoms consistent with chronic traumatic encephalopathy?")]
        [RequiredIf(nameof(BRNINJ), "True", ErrorMessage = "Please indicate")]
        public int? BRNINCTE { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus")]
        public bool HYCEPH { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus, primary or contributing")]
        public int? HYCEPHIF { get; set; }

        [Display(Name = "Epilepsy")]
        public bool EPILEP { get; set; }

        [Display(Name = "Epilepsy, primary or contributing")]
        public int? EPILEPIF { get; set; }

        [Display(Name = "CNS neoplasm")]
        public bool NEOP { get; set; }

        [Display(Name = "CNS neoplasm, primary or contributing")]
        public int? NEOPIF { get; set; }

        [Display(Name = "CNS neoplasm, benign or malignant?")]
        [RequiredIf(nameof(NEOP), "True", ErrorMessage = "Please indicate")]
        public int? NEOPSTAT { get; set; }

        [Display(Name = "Human immunodeficiency virus (HIV)")]
        public bool HIV { get; set; }

        [Display(Name = "Human immunodeficiency virus (HIV), primary or contributing")]
        public int? HIVIF { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, or infectious conditions not listed above")]
        public bool OTHCOG { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, or infectious conditions not listed above, primary or contributing")]
        public int? OTHCOGIF { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(OTHCOG), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? OTHCOGX { get; set; }

        [Display(Name = "Active depression")]
        public bool DEP { get; set; }

        [Display(Name = "Active depression, primary or contributing")]
        public int? DEPIF { get; set; }

        [Display(Name = "If Present, select one")]
        [RequiredIf(nameof(DEP), "True", ErrorMessage = "Please indicate")]
        public int? DEPTREAT { get; set; }

        [Display(Name = "Bipolar disorder")]
        public bool BIPOLDX { get; set; }

        [Display(Name = "Bipolar disorder, primary or contributing")]
        public int? BIPOLDIF { get; set; }

        [Display(Name = "Schizophrenia or other psychosis")]
        public bool SCHIZOP { get; set; }

        [Display(Name = "Schizophrenia or other psychosis, primary or contributing")]
        public int? SCHIZOIF { get; set; }

        [Display(Name = "Anxiety disorder")]
        public bool ANXIET { get; set; }

        [Display(Name = "Anxiety disorder, primary or contributing")]
        public int? ANXIETIF { get; set; }

        [Display(Name = "Delirium")]
        public bool DELIR { get; set; }

        [Display(Name = "Delirium, primary or contributing")]
        public int? DELIRIF { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD)")]
        public bool PTSDDX { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD), primary or contributing")]
        public int? PTSDDXIF { get; set; }

        [Display(Name = "Other psychiatric disease")]
        public bool OTHPSY { get; set; }

        [Display(Name = "Other psychiatric disease, primary or contributing")]
        public int? OTHPSYIF { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(OTHPSY), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? OTHPSYX { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse")]
        public bool ALCDEM { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse, primary or contributing")]
        public int? ALCDEMIF { get; set; }

        [Display(Name = "Current alcohol abuse")]
        [RequiredIf(nameof(ALCDEM), "True", ErrorMessage = "Please indicate")]
        public int? ALCABUSE { get; set; }

        [Display(Name = "Cognitive impairment due to other substance abuse")]
        public bool IMPSUB { get; set; }

        [Display(Name = "Cognitive impairment due to other substance abuse, primary or contributing")]
        public int? IMPSUBIF { get; set; }

        [Display(Name = "Cognitive impairment due to systemic disease/medical illness (as indicated on Form D2)")]
        public bool DYSILL { get; set; }

        [Display(Name = "Cognitive impairment due to systemic disease/nmedical illness, primary or contributing")]
        public int? DYSILLIF { get; set; }

        [Display(Name = "Cognitive impairment due to medications")]
        public bool MEDS { get; set; }

        [Display(Name = "Cognitive impairment due to medications, primary or contributing")]
        public int? MEDSIF { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool COGOTH { get; set; }

        [Display(Name = "Cognitive impairment NOS, primary or contributing")]
        public int? COGOTHIF { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(COGOTH), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? COGOTHX { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool COGOTH2 { get; set; }

        [Display(Name = "Cognitive impairment NOS, primary or contributing")]
        public int? COGOTH2F { get; set; }

        [Display(Name = "If Present, specify")]
        [RequiredIf(nameof(COGOTH2), "True", ErrorMessage = "Please indicate")]
        [MaxLength(60)]
        [ProhibitedCharacters]
        public string? COGOTH2X { get; set; }

        [Display(Name = "Cognitive impairment NOS")]
        public bool COGOTH3 { get; set; }

        [Display(Name = "Cognitive impairment NOS, primary or contributing")]
        public int? COGOTH3F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH3), "True", ErrorMessage = "Please indicate")]
        [ProhibitedCharacters]
        public string? COGOTH3X { get; set; }

        #endregion
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

