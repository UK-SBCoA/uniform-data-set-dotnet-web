using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Security.Claims;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    public class D1a : FormModel
    {
        [RequiredOnFinalized]
        [Display(Name = "Diagnosis method—responses in this form are based on diagnosis by a:")]
        public int? DXMETHOD { get; set; }

        [RequiredOnFinalized]
        [Display(Name = "Does the participant have: 1. Unimpaired cognition (e.g., cognitive performance and functional status (i.e., CDR) judged to be unimpaired)? AND 2. Unimpaired behavior (i.e., the participant does not exhibit behavior sufficient to diagnose MBI – see MBI section starting at\nQ7) or dementia due to FTLD or LBD and/or FTLD behavior and language domains=0?")]
        public int? NORMCOG { get; set; }

        [RequiredIf(nameof(NORMCOG), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Does the participant report 1) significant concerns about changes in cognition AND 2) no neuropsychological evidence of decline AND 3) no functional decline?")]
        public int? SCD { get; set; }

        [RequiredIf(nameof(SCD), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "As a clinician, are you confident that the subjective cognitive decline is clinically meaningful?")]
        public int? SCDDXCONF { get; set; }

        [RequiredIf(nameof(NORMCOG), "0", ErrorMessage = "Please specify.")]
        [Display(Name = "Does the participant meet criteria for dementia?")]
        public int? DEMENTED { get; set; }

        [Display(Name = "Clinical concern about decline in cognition compared to participant’s prior level of lifelong or usual cognitive function")]
        public bool? MCICRITCLN { get; set; }

        [Display(Name = "Impairment in one or more cognitive domains, compared to participant’s estimated prior level of lifelong or usual cognitive function, or supported by objective longitudinal neuropsychological evidence of decline")]
        public bool? MCICRITIMP { get; set; }

        [Display(Name = "Largely preserved functional independence OR functional dependence that is not related to cognitive decline")]
        public bool? MCICRITFUN { get; set; }

        [NotMapped]
        [RequiredIf(nameof(DEMENTED), "0", ErrorMessage = "If all three criteria in question 4 are checked, choose 1=MCI. If less than 3 criteria are met, choose 0=No.")]
        public bool? MCICriteriaValidation
        {
            get
            {
                if(MCI.HasValue)
                {
                    var criteriaCount = 0;

                    criteriaCount += MCICRITCLN.HasValue && MCICRITCLN.Value == true ? 1 : 0;
                    criteriaCount += MCICRITIMP.HasValue && MCICRITIMP.Value == true ? 1 : 0;
                    criteriaCount += MCICRITFUN.HasValue && MCICRITFUN.Value == true ? 1 : 0;

                    if (criteriaCount == 3)
                    {
                        return MCI.Value == 1 ? true : null;
                    } 
                    
                    if(criteriaCount == 0)
                    {
                        return MCI.Value == 0 ? true : null;
                    }
                }

                return true;
            }
        }


        [RequiredIf(nameof(DEMENTED), "0", ErrorMessage = "Please specify.")]
        [Display(Name = "Does the participant meet all three of the above criteria for MCI (amnestic or non-amnestic)?")]
        public int? MCI { get; set; }

        [Display(Name = "Evidence of functional impairment (e.g., CDR SB>0 and/or FAS>0), but available cognitive testing is judged to be normal")]
        public bool? IMPNOMCIFU { get; set; }

        [Display(Name = "Cognitive testing is abnormal but no clinical concern or functional decline (e.g., CDR SB=0 and FAS=0)")]
        public bool? IMPNOMCICG { get; set; }

        [Display(Name = "Longstanding cognitive difficulties, not representing a change from their usual function")]
        public bool? IMPNOMCLCD { get; set; }

        [Display(Name = "Other")]
        public bool? IMPNOMCIO { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(IMPNOMCIO), "True", ErrorMessage = "Please specify.")]
        public string? IMPNOMCIOX { get; set; }

        //If any of the criteria in Q5 are met, or if only some of the MCI criteria from Q4 are met, choose 1=Yes
        // this looks like q5 criteria CAN be unchecked? 

        //[RequiredIf(nameof(MCI), "0", ErrorMessage = "Please  check all applicable criteria for cognitively impaired, not MCI/dementia in")]
        //[NotMapped]
        //public bool? CognitivelyImpairedIndicated
        //{
        //    get
        //    {
        //        if ((IMPNOMCIFU.HasValue && IMPNOMCIFU.Value == true) ||
        //            (IMPNOMCICG.HasValue && IMPNOMCICG.Value == true) ||
        //            (IMPNOMCLCD.HasValue && IMPNOMCLCD.Value == true) ||
        //            (IMPNOMCIO.HasValue && IMPNOMCIO.Value == true))
        //        {
        //            return true;
        //        }
        //        else return null;
        //    }
        //}

        [RequiredIf(nameof(MCI), "0", ErrorMessage = "If any of the criteria in Q5 are met, or if only some of the MCI criteria from Q4 are met, choose 1=Yes for Q5b. Note, if only the third MCI criteria is met in Q4, select 0=No for Q5b.")]
        [NotMapped]
        public bool? IMPNOMCICriteriaValidation
        {
            get
            {
                if (IMPNOMCI.HasValue)
                {
                    var IMPNOMCICriteriaCount = 0;

                    IMPNOMCICriteriaCount += IMPNOMCIFU.HasValue && IMPNOMCIFU.Value == true ? 1 : 0;
                    IMPNOMCICriteriaCount += IMPNOMCICG.HasValue && IMPNOMCICG.Value == true ? 1 : 0;
                    IMPNOMCICriteriaCount += IMPNOMCLCD.HasValue && IMPNOMCLCD.Value == true ? 1 : 0;
                    IMPNOMCICriteriaCount += IMPNOMCIO.HasValue && IMPNOMCIO.Value == true ? 1 : 0;

                    if (IMPNOMCICriteriaCount > 0)
                    {
                        return IMPNOMCI.Value == 1 ? true : null;
                    }

                    if (IMPNOMCICriteriaCount <= 0)
                    {
                        var MCICriteriaCount = 0;

                        MCICriteriaCount += MCICRITCLN.HasValue && MCICRITCLN.Value == true ? 1 : 0;
                        MCICriteriaCount += MCICRITIMP.HasValue && MCICRITIMP.Value == true ? 1 : 0;
                        MCICriteriaCount += MCICRITFUN.HasValue && MCICRITFUN.Value == true ? 1 : 0;

                        if (MCICriteriaCount == 1 && MCICRITFUN.HasValue && MCICRITFUN.Value == true)
                        {
                            return IMPNOMCI.Value == 0 ? true : null;
                        }

                        if (MCICriteriaCount > 0)
                        {
                            return IMPNOMCI.Value == 1 ? true : null;
                        }
                    }
                }

                return null;
            }
        }

        [Display(Name = "Does the participant meet any criteria for cognitively impaired, not MCI/dementia?")]
        [RequiredIf(nameof(MCI), "0", ErrorMessage = "Please specify.")]
        public int? IMPNOMCI { get; set; }

        [Display(Name = "Memory")]
        public bool? CDOMMEM { get; set; }

        [Display(Name = "Language")]
        public bool? CDOMLANG { get; set; }

        [Display(Name = "Attention")]
        public bool? CDOMATTN { get; set; }

        [Display(Name = "Executive")]
        public bool? CDOMEXEC { get; set; }

        [Display(Name = "Visuospatial")]
        public bool? CDOMVISU { get; set; }

        [Display(Name = "Behavioral")]
        public bool? CDOMBEH { get; set; }

        [Display(Name = "Apraxia")]
        public bool? CDOMAPRAX { get; set; }

        [RequiredIf(nameof(DEMENTED), "1", ErrorMessage = "Please check one or more Affected Domain.")]
        [RequiredIf(nameof(MCI), "1", ErrorMessage = "Please check one or more Affected Domain.")]
        [NotMapped]
        public bool? AffectedDomainsIndicated
        {
            get
            {
                if ((CDOMMEM.HasValue && CDOMMEM.Value == true) ||
                    (CDOMLANG.HasValue && CDOMLANG.Value == true) ||
                    (CDOMATTN.HasValue && CDOMATTN.Value == true) ||
                    (CDOMEXEC.HasValue && CDOMEXEC.Value == true) ||
                    (CDOMVISU.HasValue && CDOMVISU.Value == true) ||
                    (CDOMBEH.HasValue && CDOMBEH.Value == true) ||
                    (CDOMAPRAX.HasValue && CDOMAPRAX.Value == true))
                {
                    return true;
                }
                else return null;
            }
        }

        [Display(Name = "Does the participant meet criteria for MBI (If participant meets criteria for dementia an MBI diagnosis is excluded.)")]
        [RequiredIf(nameof(IMPNOMCI), "0", ErrorMessage = "Please specify.")]
        [RequiredIf(nameof(IMPNOMCI), "1", ErrorMessage = "Please specify.")]
        public int? MBI { get; set; }

        [Display(Name = "Motivation (e.g., apathy symptoms on Form B9)")]
        [RequiredIf(nameof(MBI), "1", ErrorMessage = "Please specify.")]
        public int? BDOMMOT { get; set; }

        [Display(Name = "Affective regulation (e.g., anxiety, irritability, depression, and/or euphoria symptoms on Form B9)")]
        [RequiredIf(nameof(MBI), "1", ErrorMessage = "Please specify.")]
        public int? BDOMAFREG { get; set; }

        [Display(Name = "Impulse control (e.g., obsessions/compulsions, personality change, and/or substance abuse symptoms on Form B9)")]
        [RequiredIf(nameof(MBI), "1", ErrorMessage = "Please specify.")]
        public int? BDOMIMP { get; set; }

        [Display(Name = ". Social appropriateness (e.g., disinhibition, personality change, and/or loss of empathy symptoms on Form B9)")]
        [RequiredIf(nameof(MBI), "1", ErrorMessage = "Please specify.")]
        public int? BDOMSOCIAL { get; set; }

        [Display(Name = "Thought content/perception (e.g., delusions and/or hallucinations on Form B9)")]
        [RequiredIf(nameof(MBI), "1", ErrorMessage = "Please specify.")]
        public int? BDOMTHTS { get; set; }

        [RequiredIf(nameof(MBI), "0", ErrorMessage = "Please specify.")]
        [RequiredIf(nameof(MBI), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Is there a predominant clinical syndrome?")]
        public int? PREDOMSYN { get; set; }

        [RequiredIf(nameof(PREDOMSYN), "1", ErrorMessage = "If a predominant clinical syndrome was present in question 8, a dementia syndrome must be marked as present")]
        [NotMapped]
        public bool? PREDOMSYNSyndromePresent
        {
            get
            {
                if (PREDOMSYN == 1)
                {
                    //one of the 8 sub qustions must be present
                    var PREDOMSYNSyndromeCount = 0;

                    if (AMNDEM.HasValue && AMNDEM.Value == true) PREDOMSYNSyndromeCount++;
                    if (DYEXECSYN.HasValue && DYEXECSYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (PCA.HasValue && PCA.Value == true) PREDOMSYNSyndromeCount++;
                    if (PPASYN.HasValue && PPASYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (FTDSYN.HasValue && FTDSYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (LBDSYN.HasValue && LBDSYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (NAMNDEM.HasValue && NAMNDEM.Value == true) PREDOMSYNSyndromeCount++;
                    if (PSPSYN.HasValue && PSPSYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (CTESYN.HasValue && CTESYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (CBSSYN.HasValue && CBSSYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (MSASYN.HasValue && MSASYN.Value == true) PREDOMSYNSyndromeCount++;
                    if (OTHSYN.HasValue && OTHSYN.Value == true) PREDOMSYNSyndromeCount++;

                    if (PREDOMSYNSyndromeCount == 0)
                    {
                        return null;
                    }
                }

                return true;
            }
        }

        [Display(Name = "Amnestic predominant syndrome")]
        public bool? AMNDEM { get; set; }

        [Display(Name = "Dysexecutive predominant syndrome")]
        public bool? DYEXECSYN { get; set; }

        [Display(Name = "Primary visual presentation (such as posterior cortical atrophy (PCA) syndrome)")]
        public bool? PCA { get; set; }

        [Display(Name = "Primary progressive aphasia (PPA) syndrome")]
        public bool? PPASYN { get; set; }

        [Display(Name = "Primary progressive aphasia (PPA) syndrome - type")]
        [RequiredIf(nameof(PPASYN), "True", ErrorMessage = "Please specify.")]
        public int? PPASYNT { get; set; }

        [Display(Name = "Behavioral variant frontotemporal (bvFTD) syndrome")]
        public bool? FTDSYN { get; set; }

        [Display(Name = "Lewy body syndrome")]
        public bool? LBDSYN { get; set; }

        [Display(Name = "Lewy body syndrome - type")]
        [RequiredIf(nameof(LBDSYN), "True", ErrorMessage = "Please specify.")]
        public int? LBDSYNT { get; set; }

        [Display(Name = "Non-amnestic multidomain syndrome, not PCA, PPA, bvFT, or DLB syndrome")]
        public bool? NAMNDEM { get; set; }

        [Display(Name = "Primary supranuclear palsy (PSP) syndrome")]
        public bool? PSPSYN { get; set; }

        [Display(Name = "Primary supranuclear palsy (PSP) syndrome - type")]
        [RequiredIf(nameof(PSPSYN), "True", ErrorMessage = "Please specify.")]
        public int? PSPSYNT { get; set; }

        [Display(Name = "Traumatic encephalopathy syndrome")]
        public bool? CTESYN { get; set; }

        [Display(Name = "Corticobasal syndrome (CBS)")]
        public bool? CBSSYN { get; set; }

        [Display(Name = "Multiple system atrophy (MSA) syndrome")]
        public bool? MSASYN { get; set; }

        [Display(Name = "Multiple system atrophy (MSA) syndrome - type")]
        [RequiredIf(nameof(MSASYN), "True", ErrorMessage = "Please specify.")]
        public int? MSASYNT { get; set; }

        [Display(Name = "Other syndrome")]
        public bool? OTHSYN { get; set; }

        [Display(Name = "Other syndrome (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHSYN), "True", ErrorMessage = "Please specify.")]
        public string? OTHSYNX { get; set; }

        [Display(Name = "Clinical information (history, CDR)")]
        public bool? SYNINFCLIN { get; set; }

        [Display(Name = "Cognitive testing")]
        public bool? SYNINFCTST { get; set; }

        [Display(Name = "Biomarkers (MRI, PET, CSF, plasma)")]
        public bool? SYNINFBIOM { get; set; }

        [RequiredIf(nameof(PREDOMSYN), "1", ErrorMessage = "If a predominant clinical syndrome was present in question 8, a source must be selected.")]
        [NotMapped]
        public bool? SourceIndicated
        {
            get
            {
                if ((SYNINFCLIN.HasValue && SYNINFCLIN.Value == true) ||
                    (SYNINFCTST.HasValue && SYNINFCTST.Value == true) ||
                    (SYNINFBIOM.HasValue && SYNINFBIOM.Value == true))
                {
                    return true;
                }
                else return null;
            }
        }

        [Display(Name = "Major depressive disorder")]
        public bool? MAJDEPDX { get; set; }

        [Display(Name = "Major depressive disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(MAJDEPDX), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? MAJDEPDIF { get; set; }

        [Display(Name = "Other specified depressive disorder")]
        public bool? OTHDEPDX { get; set; }

        [Display(Name = "Other specified depressive disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(OTHDEPDX), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? OTHDEPDIF { get; set; }

        [Display(Name = "Bipolar disorder")]
        public bool? BIPOLDX { get; set; }

        [Display(Name = "1Bipolar disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(BIPOLDX), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? BIPOLDIF { get; set; }

        [Display(Name = "Schizophrenia or other psychotic disorder")]
        public bool? SCHIZOP { get; set; }

        [Display(Name = "Schizophrenia or other psychotic disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(SCHIZOP), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? SCHIZOIF { get; set; }

        [Display(Name = "Anxiety disorder")]
        public bool? ANXIET { get; set; }

        [Display(Name = "Anxiety disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(ANXIET), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? ANXIETIF { get; set; }

        [Display(Name = "Generalized Anxiety Disorder")]
        public bool? GENANX { get; set; }

        [Display(Name = "Panic Disorder")]
        public bool? PANICDISDX { get; set; }

        [Display(Name = "Obsessive-compulsive disorder (OCD)")]
        public bool? OCDDX { get; set; }

        [Display(Name = "Other anxiety disorder")]
        public bool? OTHANXD { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? OTHANXDX { get; set; }

        [RequiredIf(nameof(ANXIET), "True", ErrorMessage = "Please check one or more Anxiety disorder")]
        [NotMapped]
        public bool? AnxietyDisorderIndicated
        {
            get
            {
                if ((GENANX.HasValue && GENANX.Value == true) ||
                    (PANICDISDX.HasValue && PANICDISDX.Value == true) ||
                    (OCDDX.HasValue && OCDDX.Value == true) ||
                    (OTHANXD.HasValue && OTHANXD.Value == true))
                {
                    return true;
                }
                else return null;
            }
        }

        [Display(Name = "Post-traumatic stress disorder (PTSD)")]
        public bool? PTSDDX { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD) (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(PTSDDX), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? PTSDDXIF { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder (ASD), attention-deficit hyperactivity disorder (ADHD), dyslexia)")]
        public bool? NDEVDIS { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder (ASD), attention-deficit hyperactivity disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(NDEVDIS), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? NDEVDISIF { get; set; }

        [Display(Name = "Delirium")]
        public bool? DELIR { get; set; }

        [Display(Name = "Delirium (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(DELIR), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? DELIRIF { get; set; }

        [Display(Name = "Other psychiatric disorder")]
        public bool? OTHPSY { get; set; }

        [Display(Name = "Other psychiatric disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(OTHPSY), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? OTHPSYIF { get; set; }

        [Display(Name = "Other psychiatric disorder (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHPSY), "True", ErrorMessage = "Please indicate")]
        public string? OTHPSYX { get; set; }

        [Display(Name = "Traumatic brain injury")]
        public bool? TBIDX { get; set; }

        [Display(Name = "Traumatic brain injury (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(TBIDX), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? TBIDXIF { get; set; }

        [Display(Name = "Epilepsy")]
        public bool? EPILEP { get; set; }

        [Display(Name = "Epilepsy (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(EPILEP), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? EPILEPIF { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus")]
        public bool? HYCEPH { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(HYCEPH), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? HYCEPHIF { get; set; }

        [Display(Name = "CNS Neoplasm")]
        public bool? NEOP { get; set; }

        [Display(Name = "CNS Neoplasm (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(NEOP), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? NEOPIF { get; set; }

        [Display(Name = "CNS Neoplasm - benign or malignant")]
        [RequiredIf(nameof(NEOP), "True", ErrorMessage = "Please indicate")]
        public int? NEOPSTAT { get; set; }

        [Display(Name = "Human Immunodeficiency Virus (HIV) infection")]
        public bool? HIV { get; set; }

        [Display(Name = "Human Immunodeficiency Virus (HIV) infection (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(HIV), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? HIVIF { get; set; }

        [Display(Name = "Post COVID-19 cognitive impairment")]
        public bool? POSTC19 { get; set; }

        [Display(Name = "Post COVID-19 cognitive impairment (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(POSTC19), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? POSTC19IF { get; set; }

        [Display(Name = "Sleep apnea (i.e., obstructive, central, mixed or complex sleep apnea)")]
        public bool? APNEADX { get; set; }

        [Display(Name = "Sleep apnea (i.e., obstructive, central, mixed or complex sleep apnea) (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(APNEADX), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? APNEADXIF { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, infectious conditions (not listed above), or systemic disease/medical illness (as indicated on Form A5/D2)")]
        public bool? OTHCOGILL { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, infectious conditions (not listed above), or systemic disease/medical illness (as indicated on Form A5/D2) (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(OTHCOGILL), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? OTHCILLIF { get; set; }

        [Display(Name = "Specify cognitive impairment due to other neurologic, genetic, infection conditions or systemic disease")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHCOGILL), "True", ErrorMessage = "Please indicate")]
        public string? OTHCOGILLX { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse")]
        public bool? ALCDEM { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(ALCDEM), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? ALCDEMIF { get; set; }

        [Display(Name = "Cognitive impairment due to substance use or abuse")]
        public bool? IMPSUB { get; set; }

        [Display(Name = "Cognitive impairment due to substance use or abuse (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(IMPSUB), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? IMPSUBIF { get; set; }

        [Display(Name = "Cognitive impairment due to medications")]
        public bool? MEDS { get; set; }

        [Display(Name = "Cognitive impairment due to medications (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(MEDS), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? MEDSIF { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS)")]
        public bool? COGOTH { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(COGOTH), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? COGOTHIF { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH), "True", ErrorMessage = "Please indicate")]
        public string? COGOTHX { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS)")]
        public bool? COGOTH2 { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(COGOTH2), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? COGOTH2F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH2), "True", ErrorMessage = "Please indicate")]
        public string? COGOTH2X { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS)")]
        public bool? COGOTH3 { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(COGOTH3), "True", ErrorMessage = "Please indicate if given condition is a primary, contributing, or non-contributing.")]
        public int? COGOTH3F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH3), "True", ErrorMessage = "Please indicate")]
        public string? COGOTH3X { get; set; }

        [RequiredIf(nameof(PREDOMSYN), "0", ErrorMessage = "If a predominant clinical syndrome was not present in question 8, a condition must be selected.")]
        [NotMapped]
        public bool? PresentSyndromeIndicated
        {
            get
            {
                int counter = 0;
                if (MAJDEPDX == true)
                {
                    counter++;
                }
                if (OTHDEPDX == true)
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
                if (PTSDDX == true)
                {
                    counter++;
                }
                if (NDEVDIS == true)
                {
                    counter++;
                }
                if (DELIR == true)
                {
                    counter++;
                }
                if (OTHPSY == true)
                {
                    counter++;
                }
                if (TBIDX == true)
                {
                    counter++;
                }
                if (EPILEP == true)
                {
                    counter++;
                }
                if (HYCEPH == true)
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
                if (POSTC19 == true)
                {
                    counter++;
                }
                if (APNEADX == true)
                {
                    counter++;
                }
                if (OTHCOGILL == true)
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
                
                return null;
            }
        }

        [RequiredOnFinalized(ErrorMessage = "Only one diagnosis should be selected as Primary.")]
        [NotMapped]
        public bool? PrimaryDiagnosesIndicated
        {
            get
            {
                int counter = 0;
                if ((MAJDEPDX == true) && (MAJDEPDIF == 1))
                {
                    counter++;
                }
                if ((OTHDEPDX == true) && (OTHDEPDIF == 1))
                {
                    counter++;
                }
                if ((BIPOLDX == true) && (BIPOLDIF == 1))
                {
                    counter++;
                }
                if ((SCHIZOP == true) && (SCHIZOIF == 1))
                {
                    counter++;
                }
                if ((ANXIET == true) && (ANXIETIF == 1))
                {
                    counter++;
                }
                if ((PTSDDX == true) && (PTSDDXIF == 1))
                {
                    counter++;
                }
                if ((NDEVDIS == true) && (NDEVDISIF == 1))
                {
                    counter++;
                }
                if ((DELIR == true) && (DELIRIF == 1))
                {
                    counter++;
                }
                if ((OTHPSY == true) && (OTHPSYIF == 1))
                {
                    counter++;
                }
                if ((TBIDX == true) && (TBIDXIF == 1))
                {
                    counter++;
                }
                if ((EPILEP == true) && (EPILEPIF == 1))
                {
                    counter++;
                }
                if ((HYCEPH == true) && (HYCEPHIF == 1))
                {
                    counter++;
                }
                if ((NEOP == true) && (NEOPIF == 1))
                {
                    counter++;
                }
                if ((HIV == true) && (HIVIF == 1))
                {
                    counter++;
                }
                if ((POSTC19 == true) && (POSTC19IF == 1))
                {
                    counter++;
                }
                if ((APNEADX == true) && (APNEADXIF == 1))
                {
                    counter++;
                }
                if ((OTHCOGILL == true) && (OTHCILLIF == 1))
                {
                    counter++;
                }
                if ((ALCDEM == true) && (ALCDEMIF == 1))
                {
                    counter++;
                }
                if ((IMPSUB == true) && (IMPSUBIF == 1))
                {
                    counter++;
                }
                if ((MEDS == true) && (MEDSIF == 1))
                {
                    counter++;
                }
                if ((COGOTH == true) && (COGOTHIF == 1))
                {
                    counter++;
                }
                if ((COGOTH2 == true) && (COGOTH2F == 1))
                {
                    counter++;
                }
                if ((COGOTH3 == true) && (COGOTH3F == 1))
                {
                    counter++;
                }
                if (counter <= 1)
                {
                    return true;
                }
                return null;
            }
        }

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