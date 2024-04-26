using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4

{
    public class D1b : FormModel
    {
        [Display(Name = "Were any biomarker results used to support the current etiological diagnosis?")]
        public int? BIOMARKDX { get; set; }

        [Display(Name = "Fluid Biomarkers - Were fluid biomarkers used for assessing the etiological diagnosis?")]
        public int? FLUIDBIOM { get; set; }

        [Display(Name = "Consistent with AD")]
        public int? BLOODAD { get; set; }

        [Display(Name = "Consistent with FTLD")]
        public int? BLOODFTLD { get; set; }

        [Display(Name = "Consistent with LBD")]
        public int? BLOODLBD { get; set; }

        [Display(Name = "Consistent with other etiology")]
        public int? BLOODOTH { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? BLOODOTHX { get; set; }

        [Display(Name = "Consistent with AD")]
        public int? CSFAD { get; set; }

        [Display(Name = "Consistent with FTLD")]
        public int? CSFFTLD { get; set; }

        [Display(Name = "Consistent with LBD")]
        public int? CSFLBD { get; set; }

        [Display(Name = "Consistent with other etiology")]
        public int? CSFOTH { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? CSFOTHX { get; set; }

        [Display(Name = "Imaging - Was imaging used for assessing etiological diagnosis?")]
        public int? IMAGINGDX { get; set; }

        [Display(Name = "Tracer-based PET - Were tracer-based PET measures used in assessing an etiological diagnosis?")]
        public int? PETDX { get; set; }

        [Display(Name = "Elevated amyloid")]
        public int? AMYLPET { get; set; }

        [Display(Name = "Elevated tau pathology")]
        public int? TAUPET { get; set; }

        [Display(Name = "FDG PET - Was FDG PET data or information used to support an etiological diagnosis?")]
        public int? FDGPETDX { get; set; }

        [Display(Name = "Consistent with AD")]
        public int? FDGAD { get; set; }

        [Display(Name = "Consistent with FTLD")]
        public int? FDGFTLD { get; set; }

        [Display(Name = "Consistent with LBD")]
        public int? FDGLBD { get; set; }

        [Display(Name = "Consistent with other etiology")]
        public int? FDGOTH { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? FDGOTHX { get; set; }

        [Display(Name = "Dopamine Transporter (DAT) Scan - Was DAT Scan data or information used to support an etiological diagnosis?")]
        public int? DATSCANDX { get; set; }

        [Display(Name = "ther tracer-based imaging - Were other tracer-based imaging used to support an etiological diagnosis?")]
        public int? TRACOTHDX { get; set; }

        [Display(Name = "Other tracer-based imaging - Were other tracer-based imaging used to support an etiological diagnosis? (specify)")]
        [MaxLength(60)]
        public string? TRACOTHDXX { get; set; }

        [Display(Name = "Consistent with AD")]
        public int? TRACERAD { get; set; }

        [Display(Name = "Consistent with FTLD")]
        public int? TRACERFTLD { get; set; }

        [Display(Name = "Consistent with LBD")]
        public int? TRACERLBD { get; set; }

        [Display(Name = "Consistent with other etiology")]
        public int? TRACEROTH { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? TRACEROTHX { get; set; }

        [Display(Name = "Structural Imaging (i.e., MRI or CT) - Was structural imaging data or information used to support an etiological diagnosis?")]
        public int? STRUCTDX { get; set; }

        [Display(Name = "Atrophy pattern consistent with AD")]
        public int? STRUCTAD { get; set; }

        [Display(Name = "Atrophy pattern consistent with FTLD")]
        public int? STRUCTFTLD { get; set; }

        [Display(Name = "Consistent with cerebrovascular disease (CVD)")]
        public int? STRUCTCVD { get; set; }

        [Display(Name = "Large vessel infarct(s)")]
        public int? IMAGLINF { get; set; }

        [Display(Name = "Lacunar infarct(s)")]
        public int? IMAGLAC { get; set; }

        [Display(Name = "Macrohemorrhage(s)")]
        public int? IMAGMACH { get; set; }

        [Display(Name = "Microhemorrhage(s)")]
        public int? IMAGMICH { get; set; }

        [Display(Name = "Moderate white-matter hyperintensity (CHS score 5-6)")]
        public int? IMAGMWMH { get; set; }

        [Display(Name = "Extensive white-matter hyperintensity (CHS score 7-8+)")]
        public int? IMAGEWMH { get; set; }

        [Display(Name = "Other biomarker modality - Was another biomarker modality used to support an etiological diagnosis?")]
        public int? OTHBIOM1 { get; set; }

        [Display(Name = "(specify)")]
        [MaxLength(60)]
        public string? OTHBIOMX1 { get; set; }

        [Display(Name = "Consistent with AD")]
        public int? BIOMAD1 { get; set; }

        [Display(Name = "Consistent with FTLD")]
        public int? BIOMFTLD1 { get; set; }

        [Display(Name = "Consistent with LBD")]
        public int? BIOMLBD1 { get; set; }

        [Display(Name = "Consistent with other etiology")]
        public int? BIOMOTH1 { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? BIOMOTHX1 { get; set; }

        [Display(Name = "Was another biomarker modality used to support an etiological diagnosis?")]
        public int? OTHBIOM2 { get; set; }

        [Display(Name = "(specify)")]
        [MaxLength(60)]
        public string? OTHBIOMX2 { get; set; }

        [Display(Name = "Consistent with AD")]
        public int? BIOMAD2 { get; set; }

        [Display(Name = "Consistent with FTLD")]
        public int? BIOMFTLD2 { get; set; }

        [Display(Name = "Consistent with LBD")]
        public int? BIOMLBD2 { get; set; }

        [Display(Name = "Consistent with other etiology")]
        public int? BIOMOTH2 { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? BIOMOTHX2 { get; set; }

        [Display(Name = "Was another biomarker modality used to support an etiological diagnosis?")]
        public int? OTHBIOM3 { get; set; }

        [Display(Name = "(specify)")]
        [MaxLength(60)]
        public string? OTHBIOMX3 { get; set; }

        [Display(Name = "Consistent with AD")]
        public int? BIOMAD3 { get; set; }

        [Display(Name = "Consistent with FTLD")]
        public int? BIOMFTLD3 { get; set; }

        [Display(Name = "Consistent with LBD")]
        public int? BIOMLBD3 { get; set; }

        [Display(Name = "Consistent with other etiology")]
        public int? BIOMOTH3 { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? BIOMOTHX3 { get; set; }

        [Display(Name = "Is there an autosomal dominant pathogenic variant to support an etiological diagnosis?")]
        public int? AUTDOMMUT { get; set; }

        [Display(Name = "Alzheimer's disease")]
        public bool? ALZDIS { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Alzheimer's disease")]
        public int? ALZDISIF { get; set; }

        [Display(Name = "Lewy body disease")]
        public bool? LBDIS { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Lewy body disease")]
        public int? LBDIF { get; set; }

        [Display(Name = "Frontotemporal lobar degeneration")]
        public bool? FTLD { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Frontotemporal lobar degeneration")]
        public int? FTLDIF { get; set; }

        [Display(Name = "Primary supranuclear palsy (PSP)")]
        public bool? PSP { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Primary supranuclear palsy (PSP)")]
        public int? PSPIF { get; set; }

        [Display(Name = "Corticobasal degeneration (CBD)")]
        public bool? CORT { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Corticobasal degeneration (CBD)")]
        public int? CORTIF { get; set; }

        [Display(Name = "FTLD with motor neuron disease")]
        public bool? FTLDMO { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - FTLD with motor neuron disease")]
        public int? FTLDMOIF { get; set; }

        [Display(Name = "FTLD not otherwise specified (NOS)")]
        public bool? FTLDNOS { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - FTLD not otherwise specified (NOS)")]
        public int? FTLDNOIF { get; set; }

        [Display(Name = "FTLD subtype")]
        public int? FTLDSUBT { get; set; }

        [Display(Name = "Other FTLD subtype (specify)")]
        [MaxLength(60)]
        public string? FTLDSUBX { get; set; }

        [Display(Name = "Vascular brain injury (based on clinical and imaging evidence according to your Center's standards)")]
        public bool? CVD { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Vascular brain injury")]
        public int? CVDIF { get; set; }

        [Display(Name = "Multiple system atrophy")]
        public bool? MSA { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Multiple system atrophy")]
        public int? MSAIF { get; set; }

        [Display(Name = "Chronic traumatic encephalopathy")]
        public bool? CTE { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Chronic traumatic encephalopathy")]
        public int? CTEIF { get; set; }

        [Display(Name = "Down syndrome")]
        public bool? DOWNS { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Down syndrome")]
        public int? DOWNSIF { get; set; }

        [Display(Name = "Huntington's disease")]
        public bool? HUNT { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Huntington's disease")]
        public int? HUNTIF { get; set; }

        [Display(Name = "Prion disease (CJD, other)")]
        public bool? PRION { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Prion disease (CJD, other)")]
        public int? PRIONIF { get; set; }

        [Display(Name = "Cerebral amyloid angiopathy")]
        public bool? CAA { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Cerebral amyloid angiopathy")]
        public int? CAAIF { get; set; }

        [Display(Name = "LATE: Limbic-predominant age-related TDP-43 encephalopathy")]
        public bool? LATE { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - LATE")]
        public int? LATEIF { get; set; }

        [Display(Name = "Other")]
        public bool? OTHCOG { get; set; }

        [Display(Name = "Primary, contributing, or non-contributing - Other")]
        public int? OTHCOGIF { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? OTHCOGX { get; set; }

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

