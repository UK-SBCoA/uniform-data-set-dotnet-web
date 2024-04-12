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

        [Display(Name = "Diagnosis method—responses in this form are based on diagnosis by a:")]
        public int? DXMETHOD { get; set; }

        [Display(Name = "Does the participant have unimpaired cognition & behavior")]
        public int? NORMCOG { get; set; }

        [Display(Name = "Does the participant report 1) significant concerns about changes in cognition AND 2) no neuropsychological evidence of decline AND 3) no functional decline?")]
        public int? SCD { get; set; }

        [Display(Name = "As a clinician, are you confident that the subjective cognitive decline is clinically meaningful?")]
        public int? SCDDXCONF { get; set; }

        [Display(Name = "Does the participant meet criteria for dementia?")]
        public int? DEMENTED { get; set; }

        [Display(Name = "MCI criteria - Clinical concern about decline in cognition compared to participant’s prior level of lifelong or usual cognitive function")]
        public bool? MCICRITCLN { get; set; }

        [Display(Name = "MCI criteria - Impairment in one or more cognitive domains, compared to participant’s estimated prior level of lifelong or usual cognitive function, or supported by objective longitudinal neuropsychological evidence of decline")]
        public bool? MCICRITIMP { get; set; }

        [Display(Name = "MCI criteria - Largely preserved functional independence OR functional dependence that is not related to cognitive decline")]
        public bool? MCICRITFUN { get; set; }

        [Display(Name = "Does the participant meet criteria for MCI (amnestic or non-amnestic)?")]
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
        public string? IMPNOMCIOX { get; set; }

        [Display(Name = "Does the participant meet any criteria for cognitively impaired, not MCI/dementia?")]
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

        [Display(Name = "Does the participant meet criteria for MBI")]
        public int? MBI { get; set; }

        [Display(Name = "Motivation (e.g., apathy symptoms on Form B9)")]
        public int? BDOMMOT { get; set; }

        [Display(Name = "Affective regulation (e.g., anxiety, irritability, depression, and/or euphoria symptoms on Form B9)")]
        public int? BDOMAFREG { get; set; }

        [Display(Name = "Impulse control (e.g., obsessions/compulsions, personality change, and/or substance abuse symptoms on Form B9)")]
        public int? BDOMIMP { get; set; }

        [Display(Name = ". Social appropriateness (e.g., disinhibition, personality change, and/or loss of empathy symptoms on Form B9)")]
        public int? BDOMSOCIAL { get; set; }

        [Display(Name = "Thought content/perception (e.g., delusions and/or hallucinations on Form B9)")]
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
        public int? PPASYNT { get; set; }

        [Display(Name = "Behavioral variant frontotemporal (bvFTD) syndrome")]
        public bool? FTDSYN { get; set; }

        [Display(Name = "Lewy body syndrome")]
        public bool? LBDSYN { get; set; }

        [Display(Name = "Lewy body syndrome - type")]
        public int? LBDSYNT { get; set; }

        [Display(Name = "Non-amnestic multidomain syndrome, not PCA, PPA, bvFT, or DLB syndrome")]
        public bool? NAMNDEM { get; set; }

        [Display(Name = "Primary supranuclear palsy (PSP) syndrome")]
        public bool? PSPSYN { get; set; }

        [Display(Name = "Primary supranuclear palsy (PSP) syndrome - type")]
        public int? PSPSYNT { get; set; }

        [Display(Name = "Traumatic encephalopathy syndrome")]
        public bool? CTESYN { get; set; }

        [Display(Name = "Corticobasal syndrome (CBS)")]
        public bool? CBSSYN { get; set; }

        [Display(Name = "Multiple system atrophy (MSA) syndrome")]
        public bool? MSASYN { get; set; }

        [Display(Name = "Multiple system atrophy (MSA) syndrome - type")]
        public int? MSASYNT { get; set; }

        [Display(Name = "Other syndrome")]
        public bool? OTHSYN { get; set; }

        [Display(Name = "Other syndrome (specify)")]
        [MaxLength(60)]
        public string? OTHSYNX { get; set; }

        [Display(Name = "Clinical information (history, CDR)")]
        public bool? SYNINFCLIN { get; set; }

        [Display(Name = "Cognitive testing")]
        public bool? SYNINFCTST { get; set; }

        [Display(Name = "Biomarkers (MRI, PET, CSF, plasma)")]
        public bool? SYNINFBIOM { get; set; }

        [Display(Name = "Major depressive disorder (present)")]
        public bool? MAJDEPDX { get; set; }

        [Display(Name = "Major depressive disorder (primary/contributing/non-contributing)")]
        public int? MAJDEPDIF { get; set; }

        [Display(Name = "Other specified depressive disorder (present)")]
        public bool? OTHDEPDX { get; set; }

        [Display(Name = "Other specified depressive disorder (primary/contributing/non-contributing)")]
        public int? OTHDEPDIF { get; set; }

        [Display(Name = "Bipolar disorder (present)")]
        public bool? BIPOLDX { get; set; }

        [Display(Name = "1Bipolar disorder (primary/contributing/non-contributing)")]
        public int? BIPOLDIF { get; set; }

        [Display(Name = "Schizophrenia or other psychotic disorder (present)")]
        public bool? SCHIZOP { get; set; }

        [Display(Name = "Schizophrenia or other psychotic disorder (primary/contributing/non-contributing)")]
        public int? SCHIZOIF { get; set; }

        [Display(Name = "Anxiety disorder (present)")]
        public bool? ANXIET { get; set; }

        [Display(Name = "Anxiety disorder (primary/contributing/non-contributing)")]
        public bool? ANXIETIF { get; set; }

        [Display(Name = "Generalized Anxiety Disorder")]
        public bool? GENANX { get; set; }

        [Display(Name = "Panic Disorder")]
        public bool? PANICDISDX { get; set; }

        [Display(Name = "Obsessive-compulsive disorder (OCD)")]
        public bool? OCDDX { get; set; }

        [Display(Name = "Other anxiety disorder")]
        public bool? OTHANXD { get; set; }

        [Display(Name = "Other anxiety disorder (specify)")]
        [MaxLength(60)]
        public string? OTHANXDX { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD) (present)")]
        public bool? PTSDDX { get; set; }

        [Display(Name = "Post-traumatic stress disorder (PTSD) (primary/contributing/non-contributing)")]
        public int? PTSDDXIF { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder (ASD), attention-deficit hyperactivity disorder (ADHD), dyslexia) (present)")]
        public bool? NDEVDIS { get; set; }

        [Display(Name = "Developmental neuropsychiatric disorders (e.g., autism spectrum disorder (ASD), attention-deficit hyperactivity disorder (primary/contributing/non-contributing)")]
        public int? NDEVDISIF { get; set; }

        [Display(Name = "Delirium (present)")]
        public bool? DELIR { get; set; }

        [Display(Name = "Delirium (primary/contributing/non-contributing)")]
        public int? DELIRIF { get; set; }

        [Display(Name = "Other psychiatric disorder (present)")]
        public bool? OTHPSY { get; set; }

        [Display(Name = "Other psychiatric disorder (primary/contributing/non-contributing)")]
        public int? OTHPSYIF { get; set; }

        [Display(Name = "Other psychiatric disorder (specify)")]
        [MaxLength(60)]
        public string? OTHPSYX { get; set; }

        [Display(Name = "Traumatic brain injury (present)")]
        public bool? TBIDX { get; set; }

        [Display(Name = "Traumatic brain injury (primary/contributing/non-contributing)")]
        public int? TBIDXIF { get; set; }

        [Display(Name = "Epilepsy (present)")]
        public bool? EPILEP { get; set; }

        [Display(Name = "Epilepsy (primary/contributing/non-contributing)")]
        public int? EPILEPIF { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus (present)")]
        public bool? HYCEPH { get; set; }

        [Display(Name = "Normal-pressure hydrocephalus (primary/contributing/non-contributing)")]
        public int? HYCEPHIF { get; set; }

        [Display(Name = "CNS Neoplasm (present)")]
        public bool? NEOP { get; set; }

        [Display(Name = "CNS Neoplasm (primary/contributing/non-contributing)")]
        public int? NEOPIF { get; set; }

        [Display(Name = "CNS Neoplasm - benign or malignant")]
        public int? NEOPSTAT { get; set; }

        [Display(Name = "Human Immunodeficiency Virus (HIV) infection (present)")]
        public bool? HIV { get; set; }

        [Display(Name = "Human Immunodeficiency Virus (HIV) infection (primary/contributing/non-contributing)")]
        public int? HIVIF { get; set; }

        [Display(Name = "Post COVID-19 cognitive impairment (present)")]
        public bool? POSTC19 { get; set; }

        [Display(Name = "Post COVID-19 cognitive impairment (primary/contributing/non-contributing)")]
        public int? POSTC19IF { get; set; }

        [Display(Name = "Sleep apnea (i.e., obstructive, central, mixed or complex sleep apnea) (present)")]
        public bool? APNEADX { get; set; }

        [Display(Name = "Sleep apnea (i.e., obstructive, central, mixed or complex sleep apnea) (primary/contributing/non-contributing)")]
        public int? APNEADXIF { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, infectious conditions (not listed above), or systemic disease/medical illness (as indicated on Form A5/D2) (present)")]
        public bool? OTHCOGILL { get; set; }

        [Display(Name = "Cognitive impairment due to other neurologic, genetic, infectious conditions (not listed above), or systemic disease/medical illness (as indicated on Form A5/D2) (primary/contributing/non-contributing)")]
        public int? OTHCILLIF { get; set; }

        [Display(Name = "Specify cognitive impairment due to other neurologic, genetic, infection conditions or systemic disease")]
        [MaxLength(60)]
        public string? OTHCOGILLX { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse (present)")]
        public bool? ALCDEM { get; set; }

        [Display(Name = "Cognitive impairment due to alcohol abuse (primary/contributing/non-contributing)")]
        public int? ALCDEMIF { get; set; }

        [Display(Name = "Cognitive impairment due to substance use or abuse (present)")]
        public bool? IMPSUB { get; set; }

        [Display(Name = "Cognitive impairment due to substance use or abuse (primary/contributing/non-contributing)")]
        public int? IMPSUBIF { get; set; }

        [Display(Name = "Cognitive impairment due to medications (present)")]
        public bool? MEDS { get; set; }

        [Display(Name = "Cognitive impairment due to medications (primary/contributing/non-contributing)")]
        public int? MEDSIF { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS) (present)")]
        public bool? COGOTH { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        public int? COGOTHIF { get; set; }

        [Display(Name = "Cognitive impairment NOS (specify)")]
        [MaxLength(60)]
        public string? COGOTHX { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS) (present)")]
        public bool? COGOTH2 { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        public int? COGOTH2F { get; set; }

        [Display(Name = "Cognitive impairment NOS (specify)")]
        [MaxLength(60)]
        public string? COGOTH2X { get; set; }

        [Display(Name = "Cognitive impairment not otherwise specified (NOS) (present)")]
        public bool? COGOTH3 { get; set; }

        [Display(Name = "Cognitive impairment NOS (primary/contributing/non-contributing)")]
        public int? COGOTH3F { get; set; }

        [Display(Name = "Cognitive impairment NOS (specify)")]
        [MaxLength(60)]
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
