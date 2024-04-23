using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;


namespace UDS.Net.Forms.Models.UDS4
{
    public class D1a : FormModel
    {
        [RequiredOnComplete]
        [Display(Name = "Diagnosis method—responses in this form are based on diagnosis by a:")]
        public int? DXMETHOD { get; set; }

        [RequiredOnComplete]
        [Display(Name = "Does the participant have: 1. Unimpaired cognition (e.g., cognitive performance and functional status (i.e., CDR) judged to be unimpaired)? AND2. Unimpaired behavior (i.e., the participant does not exhibit behavior sufficient to diagnose MBI – see MBI section starting at\nQ7) or dementia due to FTLD or LBD and/or FTLD behavior and language domains=0?")]
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

        [RequiredIf(nameof(DEMENTED), "0", ErrorMessage = "Please indicate the type of cognitive impairment  (Question 5a-5e).")]
        [NotMapped]
        public bool? MCIClinicalCriteriaIndicated
        {
            get
            {
                if ((MCICRITCLN.HasValue && MCICRITCLN.Value == true) ||
                    (MCICRITIMP.HasValue && MCICRITIMP.Value == true) ||
                    (MCICRITFUN.HasValue && MCICRITFUN.Value == true))
                {
                    return true;
                }
                else return null;
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
        [RequiredIf(nameof(IMPNOMCIO), "true", ErrorMessage = "Please specify.")]
        public string? IMPNOMCIOX { get; set; }

        [RequiredIf(nameof(MCI), "0", ErrorMessage = "Please indicate the type of cognitive impairment  (Question 5a-5e).")]
        [NotMapped]
        public bool? CognitivelyImpairedIndicated
        {
            get
            {
                if ((IMPNOMCIFU.HasValue && IMPNOMCIFU.Value == true) ||
                    (IMPNOMCICG.HasValue && IMPNOMCICG.Value == true) ||
                    (IMPNOMCLCD.HasValue && IMPNOMCLCD.Value == true) ||
                    (IMPNOMCIO.HasValue && IMPNOMCIO.Value == true))
                {
                    return true;
                }
                else return null;
            }
        }

        [Display(Name = "Does the participant meet any criteria for cognitively impaired, not MCI/dementia?")]
        [RequiredIf(nameof(MCI), "0", ErrorMessage = "Please specify.")]
        public bool? IMPNOMCI { get; set; }

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

        [RequiredIf(nameof(MCI), "1", ErrorMessage = "Please indicate the type of cognitive impairment  (Question 5a-5e).")]
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
                    (CDOMBEH.HasValue && CDOMBEH.Value == true))
                {
                    return true;
                }
                else return null;
            }
        }

        [Display(Name = "Does the participant meet criteria for MBI (If participant meets criteria for\ndementia an MBI diagnosis is excluded.)")]
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

        [Display(Name = "Amnestic predominant syndrome")]
        public bool? AMNDEM { get; set; }

        [Display(Name = "Dysexecutive predominant syndrome")]
        public bool? DYEXECSYN { get; set; }

        [Display(Name = "Primary visual presentation (such as posterior cortical atrophy (PCA) syndrome)")]
        public bool? PCA { get; set; }

        [Display(Name = "Primary progressive aphasia (PPA) syndrome")]
        public bool? PPASYN { get; set; }

        [Display(Name = "Primary progressive aphasia (PPA) syndrome - type")]
        [RequiredIf(nameof(PPASYN), "1", ErrorMessage = "Please specify.")]
        public int? PPASYNT { get; set; }

        [Display(Name = "Behavioral variant frontotemporal (bvFTD) syndrome")]
        public bool? FTDSYN { get; set; }

        [Display(Name = "Lewy body syndrome")]
        public bool? LBDSYN { get; set; }

        [Display(Name = "Lewy body syndrome - type")]
        [RequiredIf(nameof(LBDSYN), "1", ErrorMessage = "Please specify.")]
        public int? LBDSYNT { get; set; }

        [Display(Name = "Non-amnestic multidomain syndrome, not PCA, PPA, bvFT, or DLB syndrome")]
        public bool? NAMNDEM { get; set; }

        [Display(Name = "Primary supranuclear palsy (PSP) syndrome")]
        public bool? PSPSYN { get; set; }

        [Display(Name = "Primary supranuclear palsy (PSP) syndrome - type")]
        [RequiredIf(nameof(PSPSYN), "1", ErrorMessage = "Please specify.")]
        public int? PSPSYNT { get; set; }

        [Display(Name = "Traumatic encephalopathy syndrome")]
        public bool? CTESYN { get; set; }

        [Display(Name = "Corticobasal syndrome (CBS)")]
        public bool? CBSSYN { get; set; }

        [Display(Name = "Multiple system atrophy (MSA) syndrome")]
        public bool? MSASYN { get; set; }

        [Display(Name = "Multiple system atrophy (MSA) syndrome - type")]
        [RequiredIf(nameof(MSASYN), "1", ErrorMessage = "Please specify.")]
        public int? MSASYNT { get; set; }

        [Display(Name = "Other syndrome")]
        public bool? OTHSYN { get; set; }

        [Display(Name = "Other syndrome (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHSYN), "true", ErrorMessage = "Please specify.")]
        public string? OTHSYNX { get; set; }

        [Display(Name = "Clinical information (history, CDR)")]
        public bool? SYNINFCLIN { get; set; }

        [Display(Name = "Cognitive testing")]
        public bool? SYNINFCTST { get; set; }

        [Display(Name = "Biomarkers (MRI, PET, CSF, plasma)")]
        public bool? SYNINFBIOM { get; set; }

        [Display(Name = "Major depressive disorder")]
        public bool? MAJDEPDX { get; set; }

        [Display(Name = "Major depressive disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(MAJDEPDX), "True", ErrorMessage = "Please indicate")]
        public int? MAJDEPDIF { get; set; }

        [Display(Name = "Other specified depressive disorder")]
        public bool? OTHDEPDX { get; set; }

        [Display(Name = "Other specified depressive disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(OTHDEPDX), "True", ErrorMessage = "Please indicate")]
        public int? OTHDEPDIF { get; set; }

        [Display(Name = "Bipolar disorder")]
        public bool? BIPOLDX { get; set; }

        [Display(Name = "1Bipolar disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(BIPOLDX), "True", ErrorMessage = "Please indicate")]
        public int? BIPOLDIF { get; set; }

        [Display(Name = "Schizophrenia or other psychotic disorder")]
        public bool? SCHIZOP { get; set; }

        [Display(Name = "Schizophrenia or other psychotic disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(SCHIZOP), "True", ErrorMessage = "Please indicate")]
        public int? SCHIZOIF { get; set; }

        [Display(Name = "Anxiety disorder")]
        public bool? ANXIET { get; set; }

        [Display(Name = "Anxiety disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(ANXIET), "True", ErrorMessage = "Please indicate")]
        public bool? ANXIETIF { get; set; }

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

        [RequiredIf(nameof(ANXIET), "true", ErrorMessage = "Please indicate the type of cognitive impairment  (Question 5a-5e).")]
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
        [RequiredIf(nameof(PTSDDX), "True", ErrorMessage = "Please indicate")]
        public int? PTSDDXIF { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder (ASD), attention-deficit hyperactivity disorder (ADHD), dyslexia)")]
        public bool? NDEVDIS { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder (ASD), attention-deficit hyperactivity disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(NDEVDIS), "True", ErrorMessage = "Please indicate")]
        public int? NDEVDISIF { get; set; }

        [Display(Name = "Delirium")]
        public bool? DELIR { get; set; }

        [Display(Name = "Delirium (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(DELIR), "True", ErrorMessage = "Please indicate")]
        public int? DELIRIF { get; set; }

        [Display(Name = "Other psychiatric disorder")]
        public bool? OTHPSY { get; set; }

        [Display(Name = "Other psychiatric disorder (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(OTHPSY), "True", ErrorMessage = "Please indicate")]
        public int? OTHPSYIF { get; set; }

        [Display(Name = "Other psychiatric disorder (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHPSY), "True", ErrorMessage = "Please indicate")]
        public string? OTHPSYX { get; set; }

        [Display(Name = "Traumatic brain injury")]
        public bool? TBIDX { get; set; }

        [Display(Name = "Traumatic brain injury (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(TBIDX), "True", ErrorMessage = "Please indicate")]
        public int? TBIDXIF { get; set; }

        [Display(Name = "Epilepsy")]
        public bool? EPILEP { get; set; }

        [Display(Name = "Epilepsy (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(EPILEP), "True", ErrorMessage = "Please indicate")]
        public int? EPILEPIF { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus")]
        public bool? HYCEPH { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(HYCEPH), "True", ErrorMessage = "Please indicate")]
        public int? HYCEPHIF { get; set; }

        [Display(Name = "CNS Neoplasm")]
        public bool? NEOP { get; set; }

        [Display(Name = "CNS Neoplasm (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(NEOP), "True", ErrorMessage = "Please indicate")]
        public int? NEOPIF { get; set; }

        [Display(Name = "CNS Neoplasm - benign or malignant")]
        [RequiredIf(nameof(NEOP), "True", ErrorMessage = "Please indicate")]
        public int? NEOPSTAT { get; set; }

        [Display(Name = "Human Immunodeficiency Virus (HIV) infection")]
        public bool? HIV { get; set; }

        [Display(Name = "Human Immunodeficiency Virus (HIV) infection (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(HIV), "True", ErrorMessage = "Please indicate")]
        public int? HIVIF { get; set; }

        [Display(Name = "Post COVID-19 cognitive impairment")]
        public bool? POSTC19 { get; set; }

        [Display(Name = "Post COVID-19 cognitive impairment (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(POSTC19), "True", ErrorMessage = "Please indicate")]
        public int? POSTC19IF { get; set; }

        [Display(Name = "Sleep apnea (i.e., obstructive, central, mixed or complex sleep apnea)")]
        public bool? APNEADX { get; set; }

        [Display(Name = "Sleep apnea (i.e., obstructive, central, mixed or complex sleep apnea) (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(APNEADX), "True", ErrorMessage = "Please indicate")]
        public int? APNEADXIF { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, infectious conditions (not listed above), or systemic disease/medical illness (as indicated on Form A5/D2)")]
        public bool? OTHCOGILL { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, infectious conditions (not listed above), or systemic disease/medical illness (as indicated on Form A5/D2) (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(OTHCOGILL), "True", ErrorMessage = "Please indicate")]
        public int? OTHCILLIF { get; set; }

        [Display(Name = "Specify cognitive impairment due to other neurologic, genetic, infection conditions or systemic disease")]
        [MaxLength(60)]
        [RequiredIf(nameof(OTHCOGILL), "True", ErrorMessage = "Please indicate")]
        public string? OTHCOGILLX { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse")]
        public bool? ALCDEM { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(ALCDEM), "True", ErrorMessage = "Please indicate")]
        public int? ALCDEMIF { get; set; }

        [Display(Name = "Cognitive impairment due to substance use or abuse")]
        public bool? IMPSUB { get; set; }

        [Display(Name = "Cognitive impairment due to substance use or abuse (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(IMPSUB), "True", ErrorMessage = "Please indicate")]
        public int? IMPSUBIF { get; set; }

        [Display(Name = "Cognitive impairment due to medications")]
        public bool? MEDS { get; set; }

        [Display(Name = "Cognitive impairment due to medications (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(MEDS), "True", ErrorMessage = "Please indicate")]
        public int? MEDSIF { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS)")]
        public bool? COGOTH { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(COGOTH), "True", ErrorMessage = "Please indicate")]
        public int? COGOTHIF { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH), "True", ErrorMessage = "Please indicate")]
        public string? COGOTHX { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS)")]
        public bool? COGOTH2 { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(COGOTH2), "True", ErrorMessage = "Please indicate")]
        public int? COGOTH2F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH2), "True", ErrorMessage = "Please indicate")]
        public string? COGOTH2X { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS)")]
        public bool? COGOTH3 { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        [RequiredIf(nameof(COGOTH3), "True", ErrorMessage = "Please indicate")]
        public int? COGOTH3F { get; set; }

        [Display(Name = "If Present, specify")]
        [MaxLength(60)]
        [RequiredIf(nameof(COGOTH3), "True", ErrorMessage = "Please indicate")]
        public string? COGOTH3X { get; set; }

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
