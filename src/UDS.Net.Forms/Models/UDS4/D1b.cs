using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4

{
    public class D1b : FormModel
    {
        [RequiredOnFinalized(ErrorMessage = "Please specify if any biomarker results were used to support the current etiological diagnosis.")]
        [Display(Name = "Were any biomarker results used to support the current etiological diagnosis?")]
        public int? BIOMARKDX { get; set; }

        [RequiredIf(nameof(BIOMARKDX), "1", ErrorMessage = "Please indicate.")]
        [Display(Name = "Fluid Biomarkers - Were fluid biomarkers used for assessing the etiological diagnosis?")]
        public int? FLUIDBIOM { get; set; }

        [RequiredIf(nameof(FLUIDBIOM), "1", ErrorMessage = "Please indicate.")]
        [RequiredIf(nameof(FLUIDBIOM), "3", ErrorMessage = "Please indicate.")]
        [Display(Name = "Consistent with AD")]
        public int? BLOODAD { get; set; }

        [RequiredIf(nameof(FLUIDBIOM), "1", ErrorMessage = "Please indicate.")]
        [RequiredIf(nameof(FLUIDBIOM), "3", ErrorMessage = "Please indicate.")]
        [Display(Name = "Consistent with FTLD")]
        public int? BLOODFTLD { get; set; }

        [RequiredIf(nameof(FLUIDBIOM), "1", ErrorMessage = "Please indicate.")]
        [RequiredIf(nameof(FLUIDBIOM), "3", ErrorMessage = "Please indicate.")]
        [Display(Name = "Consistent with LBD")]
        public int? BLOODLBD { get; set; }

        [RequiredIf(nameof(FLUIDBIOM), "1", ErrorMessage = "Please indicate.")]
        [RequiredIf(nameof(FLUIDBIOM), "3", ErrorMessage = "Please indicate.")]
        [Display(Name = "Consistent with other etiology")]
        public int? BLOODOTH { get; set; }

        [RequiredIf(nameof(BLOODOTH), "1", ErrorMessage = "Please indicate.")]
        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? BLOODOTHX { get; set; }

        [RequiredIfRange(nameof(FLUIDBIOM), 2, 3, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with AD")]
        public int? CSFAD { get; set; }

        [RequiredIfRange(nameof(FLUIDBIOM), 2, 3, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with FTLD")]
        public int? CSFFTLD { get; set; }

        [RequiredIfRange(nameof(FLUIDBIOM), 2, 3, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with LBD")]
        public int? CSFLBD { get; set; }

        [RequiredIfRange(nameof(FLUIDBIOM), 2, 3, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with other etiology")]
        public int? CSFOTH { get; set; }

        [RequiredIf(nameof(CSFOTH), "1", ErrorMessage = "Please indicate.")]
        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? CSFOTHX { get; set; }

        [RequiredIfRange(nameof(FLUIDBIOM), 0, 3, ErrorMessage = "Please specify.")]
        [Display(Name = "Imaging - Was imaging used for assessing etiological diagnosis?")]
        public int? IMAGINGDX { get; set; }

        [RequiredIf(nameof(IMAGINGDX), "1", ErrorMessage = "Please indicate.")]
        [RequiredIf(nameof(IMAGINGDX), "3", ErrorMessage = "Please indicate.")]
        [Display(Name = "Tracer-based PET - Were tracer-based PET measures used in assessing an etiological diagnosis?")]
        public int? PETDX { get; set; }

        [RequiredIfRange(nameof(PETDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Elevated amyloid")]
        public int? AMYLPET { get; set; }

        [RequiredIfRange(nameof(PETDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Elevated tau pathology")]
        public int? TAUPET { get; set; }

        [RequiredIfRange(nameof(PETDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "FDG PET - Was FDG PET data or information used to support an etiological diagnosis?")]
        public int? FDGPETDX { get; set; }

        [RequiredIfRange(nameof(FDGPETDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with AD")]
        public int? FDGAD { get; set; }

        [RequiredIfRange(nameof(FDGPETDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with FTLD")]
        public int? FDGFTLD { get; set; }

        [RequiredIfRange(nameof(FDGPETDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with LBD")]
        public int? FDGLBD { get; set; }

        [RequiredIfRange(nameof(FDGPETDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with other etiology")]
        public int? FDGOTH { get; set; }

        [RequiredIf(nameof(FDGOTH), "1", ErrorMessage = "Please indicate.")]
        [Display(Name = "Consistent with other etiology (specify)")]
        [MaxLength(60)]
        public string? FDGOTHX { get; set; }

        // TODO when is DATSCANDX required?
        [RequiredIfRange(nameof(FDGPETDX), 0, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Dopamine Transporter (DAT) Scan - Was DAT Scan data or information used to support an etiological diagnosis?")]
        public int? DATSCANDX { get; set; }

        // TODO when is TRACOTHDX required?
        [RequiredIfRange(nameof(DATSCANDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Other tracer-based imaging - Were other tracer-based imaging used to support an etiological diagnosis?")]
        public int? TRACOTHDX { get; set; }

        [RequiredIfRange(nameof(TRACOTHDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "(specify)")]
        [MaxLength(60)]
        public string? TRACOTHDXX { get; set; }

        [RequiredIfRange(nameof(TRACOTHDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with AD")]
        public int? TRACERAD { get; set; }

        [RequiredIfRange(nameof(TRACOTHDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with FTLD")]
        public int? TRACERFTLD { get; set; }

        [RequiredIfRange(nameof(TRACOTHDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with LBD")]
        public int? TRACERLBD { get; set; }

        [RequiredIfRange(nameof(TRACOTHDX), 1, 2, ErrorMessage = "Please specify.")]
        [Display(Name = "Consistent with other etiology")]
        public int? TRACEROTH { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [RequiredIf(nameof(TRACEROTH), "1", ErrorMessage = "Please indicate other etiology.")]
        [MaxLength(60)]
        public string? TRACEROTHX { get; set; }

        // TODO need custom validation property to check against TRACOTHDX scenarios and TRACERAD, TRACERFTLD, TRACERLBD, TRACEROTH

        [Display(Name = "Structural Imaging (i.e., MRI or CT) - Was structural imaging data or information used to support an etiological diagnosis?")]
        [RequiredIfRange(nameof(TRACOTHDX), 0, 2, ErrorMessage = "Please specify.")]
        [RequiredIf(nameof(IMAGINGDX), "2", ErrorMessage = "Please indicate if imaging supports an etiological diagnosis.")]
        public int? STRUCTDX { get; set; }

        [Display(Name = "Atrophy pattern consistent with AD")]
        [RequiredIfRange(nameof(STRUCTDX), 1, 2, ErrorMessage = "Please specify if imaging consistent with AD.")]
        public int? STRUCTAD { get; set; }

        [Display(Name = "Atrophy pattern consistent with FTLD")]
        [RequiredIfRange(nameof(STRUCTDX), 1, 2, ErrorMessage = "Please specify if imaging consistent with FTLD.")]
        public int? STRUCTFTLD { get; set; }

        [Display(Name = "Consistent with cerebrovascular disease (CVD)")]
        [RequiredIfRange(nameof(STRUCTDX), 1, 2, ErrorMessage = "Please specify if imaging consistent with CVD.")]
        public int? STRUCTCVD { get; set; }

        [Display(Name = "Large vessel infarct(s)")]
        [RequiredIf(nameof(STRUCTCVD), "1", ErrorMessage = "Please indicate large vessel infarct(s).")]
        public int? IMAGLINF { get; set; }

        [Display(Name = "Lacunar infarct(s)")]
        [RequiredIf(nameof(STRUCTCVD), "1", ErrorMessage = "Please indicate lacunar infarct(s).")]
        public int? IMAGLAC { get; set; }

        [Display(Name = "Macrohemorrhage(s)")]
        [RequiredIf(nameof(STRUCTCVD), "1", ErrorMessage = "Please indicate macrohemorrhage(s).")]
        public int? IMAGMACH { get; set; }

        [Display(Name = "Microhemorrhage(s)")]
        [RequiredIf(nameof(STRUCTCVD), "1", ErrorMessage = "Please indicate microphemorrhage(s).")]
        public int? IMAGMICH { get; set; }

        [Display(Name = "White matter hyperintensity")]
        [RequiredIf(nameof(STRUCTCVD), "1", ErrorMessage = "Please indicate white matter hyperintensity.")]
        public int? IMAGWMH { get; set; }

        // If IMAGWMH = 1 yes, choose severity
        [Display(Name = "White matter hyperintensity severity)")]
        [RequiredIf(nameof(IMAGWMH), "1", ErrorMessage = "Please indicate white matter hyperintensity severity.")]
        public int? IMAGWMHSEV { get; set; }

        [Display(Name = "Other biomarker modality - Was another biomarker modality used to support an etiological diagnosis?")]
        [RequiredIf(nameof(BIOMARKDX), "1", ErrorMessage = "Please indicate.")]
        public int? OTHBIOM1 { get; set; }

        [Display(Name = "(specify)")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        [MaxLength(60)]
        public string? OTHBIOMX1 { get; set; }

        [Display(Name = "Consistent with AD")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMAD1 { get; set; }

        [Display(Name = "Consistent with FTLD")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMFTLD1 { get; set; }

        [Display(Name = "Consistent with LBD")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMLBD1 { get; set; }

        [Display(Name = "Consistent with other etiology")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMOTH1 { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [RequiredIf(nameof(BIOMOTH1), "1", ErrorMessage = "Please indicate.")]
        [MaxLength(60)]
        public string? BIOMOTHX1 { get; set; }

        [Display(Name = "Was another biomarker modality used to support an etiological diagnosis?")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? OTHBIOM2 { get; set; }

        [Display(Name = "(specify)")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        [MaxLength(60)]
        public string? OTHBIOMX2 { get; set; }

        [Display(Name = "Consistent with AD")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMAD2 { get; set; }

        [Display(Name = "Consistent with FTLD")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMFTLD2 { get; set; }

        [Display(Name = "Consistent with LBD")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMLBD2 { get; set; }

        [Display(Name = "Consistent with other etiology")]
        [RequiredIfRange(nameof(OTHBIOM1), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMOTH2 { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [RequiredIf(nameof(BIOMOTH2), "1", ErrorMessage = "Please indicate.")]
        [MaxLength(60)]
        public string? BIOMOTHX2 { get; set; }

        [Display(Name = "Was another biomarker modality used to support an etiological diagnosis?")]
        [RequiredIfRange(nameof(OTHBIOM2), 1, 2, ErrorMessage = "Please specify.")]
        public int? OTHBIOM3 { get; set; }

        [Display(Name = "(specify)")]
        [RequiredIfRange(nameof(OTHBIOM3), 1, 2, ErrorMessage = "Please specify.")]
        [MaxLength(60)]
        public string? OTHBIOMX3 { get; set; }

        [Display(Name = "Consistent with AD")]
        [RequiredIfRange(nameof(OTHBIOM3), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMAD3 { get; set; }

        [Display(Name = "Consistent with FTLD")]
        [RequiredIfRange(nameof(OTHBIOM3), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMFTLD3 { get; set; }

        [Display(Name = "Consistent with LBD")]
        [RequiredIfRange(nameof(OTHBIOM3), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMLBD3 { get; set; }

        [Display(Name = "Consistent with other etiology")]
        [RequiredIfRange(nameof(OTHBIOM3), 1, 2, ErrorMessage = "Please specify.")]
        public int? BIOMOTH3 { get; set; }

        [Display(Name = "Consistent with other etiology (specify)")]
        [RequiredIf(nameof(BIOMOTH3), "1", ErrorMessage = "Please indicate.")]
        [MaxLength(60)]
        public string? BIOMOTHX3 { get; set; }

        [Display(Name = "Is there an autosomal dominant pathogenic variant to support an etiological diagnosis?")]
        [RequiredIf(nameof(BIOMARKDX), "1", ErrorMessage = "Please indicate.")]
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

        [RequiredIf(nameof(FTLD), "True", ErrorMessage = "Please select one.")]
        [NotMapped]
        public bool? FTLDIndicated
        {
            get
            {
                int counter = 0;
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
                if (counter == 1)
                {
                    return true;
                }
                return null;
            }
        }

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

        [Display(Name = "If FTLD (QUESTION 14) is present, specify FTLD subtype:")]
        [RequiredIf(nameof(FTLD), "True", ErrorMessage = "Please select one.")]
        public int? FTLDSUBT { get; set; }

        [Display(Name = "Other FTLD subtype (specify)")]
        [RequiredIf(nameof(FTLDSUBT), "3", ErrorMessage = "Please indicate.")]
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

        [Display(Name = "If CTE (QUESTION 17) is present, specify certainty:")]
        [RequiredIf(nameof(CTE), "True", ErrorMessage = "Value required")]
        public int? CTECERT { get; set; }

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
        [RequiredIf(nameof(OTHCOG), "True", ErrorMessage = "Please indicate.")]
        [MaxLength(60)]
        public string? OTHCOGX { get; set; }

        [RequiredOnFinalized(ErrorMessage = "Only one diagnosis should be selected as Primary.")]
        [NotMapped]
        public bool? PrimaryDiagnosesIndicated
        {
            get
            {
                int counter = 0;
                if ((ALZDIS == true) && (ALZDISIF == 1))
                {
                    counter++;
                }
                if ((LBDIS == true) && (LBDIF == 1))
                {
                    counter++;
                }
                if (FTLD == true)
                {
                    counter++;
                }
                if ((CVD == true) && (CVDIF == 1))
                {
                    counter++;
                }
                if ((MSA == true) && (MSAIF == 1))
                {
                    counter++;
                }
                if ((CTE == true) && (CTEIF == 1))
                {
                    counter++;
                }
                if ((DOWNS == true) && (DOWNSIF == 1))
                {
                    counter++;
                }
                if ((HUNT == true) && (HUNTIF == 1))
                {
                    counter++;
                }
                if ((PRION == true) && (PRIONIF == 1))
                {
                    counter++;
                }
                if ((CAA == true) && (CAAIF == 1))
                {
                    counter++;
                }
                if ((LATE == true) && (LATEIF == 1))
                {
                    counter++;
                }
                if ((OTHCOG == true) && (OTHCOGIF == 1))
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

