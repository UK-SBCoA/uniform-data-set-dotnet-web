using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UDS.Net.Forms.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    public class D1c : FormModel
    {
        [RequiredOnFinalized]
        [Display(Name = "Were plasma biomarkers used in the etiologic diagnosis?")]
        public int? DXPLSMABIO { get; set; }

        [Display(Name = "p-tau 217 used in diagnosis")]
        public int? DXPTAU217 { get; set; }

        [RequiredIf(nameof(DXPTAU217), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "p-tau 217 result")]
        public int? PTAU217RS { get; set; }

        [RequiredIf(nameof(DXPTAU217), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were the p-tau 217 values used in the diagnosis analyzed?")]
        public int? PT217ANLYS { get; set; }

        [RequiredIf(nameof(DXPTAU217), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the plasma p-tau 217 sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? PT217INT { get; set; }

        [Display(Name = "%p-tau 217 used in diagnosis")]
        public int? DXPCPT217 { get; set; }

        [RequiredIf(nameof(DXPCPT217), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "%p-tau 217 result")]
        public int? PCPT217RS { get; set; }

        [RequiredIf(nameof(DXPCPT217), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the plasma %p-tau 217 sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? PCPT217INT { get; set; }

        [Display(Name = "Other plasma biomarker used in the diagnosis")]
        public int? DXOTHPLSMA { get; set; }

        [RequiredIf(nameof(DXOTHPLSMA), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Other plasma biomarker used in the diagnosis - Specify")]
        [MaxLength(60)]
        public string? DXOTHPLSMX { get; set; }

        [RequiredIf(nameof(DXOTHPLSMA), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Other plasma biomarker result")]
        public int? OTHPLSMARS { get; set; }

        [RequiredIf(nameof(DXOTHPLSMA), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were the other plasma biomarker values used in the diagnosis analyzed?")]
        public int? OPLSMANLYS { get; set; }

        [RequiredIf(nameof(DXOTHPLSMA), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the plasma sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? OPLSMAINT { get; set; }

        [RequiredOnFinalized]
        [Display(Name = "Were CSF biomarkers used in the etiologic diagnosis?")]
        public int? DXCSFBIO { get; set; }


        // 2. CSF Biomarkers

        [Display(Name = "p-tau 181/ Aβ42 used in diagnosis")]
        public int? DXPT181AB { get; set; }

        [RequiredIf(nameof(DXPT181AB), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "p-tau 181/ Aβ42 result")]
        public int? PT181ABRS { get; set; }

        [RequiredIf(nameof(DXPT181AB), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were the p-tau 181/ Aβ42 values used in the diagnosis analyzed?")]
        public int? PT181ABAYS { get; set; }

        [RequiredIf(nameof(DXPT181AB), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the CSF p-tau 181/ Aβ42 sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? PT181ABINT { get; set; }

        [Display(Name = "t-tau / Aβ42 used in the diagnosis")]
        public int? DXTTABETA { get; set; }

        [RequiredIf(nameof(DXTTABETA), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "t-tau / Aβ42 result")]
        public int? TTABETARS { get; set; }

        [RequiredIf(nameof(DXTTABETA), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the CSF t-tau / Aβ42 sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? TTABETAINT { get; set; }

        [Display(Name = "Aβ42/40 used in diagnosis")]
        public int? DXAB42AB40 { get; set; }

        [RequiredIf(nameof(DXAB42AB40), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Aβ42/40 result")]
        public int? AB42AB40RS { get; set; }

        [RequiredIf(nameof(DXAB42AB40), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were the Aβ42/40 values used in the diagnosis analyzed?")]
        public int? AB42AB40AY { get; set; }

        [RequiredIf(nameof(DXAB42AB40), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the Aβ42 / 40 sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? AB42AB40IT { get; set; }

        [Display(Name = "Other CSF biomarker used in diagnosis")]
        public int? DXOTHCSF { get; set; }

        [RequiredIf(nameof(DXOTHCSF), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Other CSF biomarker used in diagnosis - Specify")]
        [MaxLength(60)]
        public string? DXOTHCSFX { get; set; }

        [RequiredIf(nameof(DXOTHCSF), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Other CSF biomarker result")]
        public int? OTHCSFRS { get; set; }

        [RequiredIf(nameof(DXOTHCSF), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were the other CSF biomarker values used in the diagnosis analyzed?")]
        public int? OCSFANLYS { get; set; }

        [RequiredIf(nameof(DXOTHCSF), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the CSF sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? OCSFINT { get; set; }

        // 3. Amyloid PET

        [RequiredOnFinalized]
        [Display(Name = "Was Amyloid PET used in the etiologic diagnosis?")]
        public int? DXAPET { get; set; }

        [RequiredIf(nameof(DXAPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Amyloid PET result")]
        public int? APETRS { get; set; }

        [Display(Name = "How were amyloid PET results obtained - Visual Read")]
        public int? APETVIS { get; set; }

        [Display(Name = "How were amyloid PET results obtained - Quantitative")]
        public int? APETQUANT { get; set; }

        [RequiredIf(nameof(DXAPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were amyloid PET results obtained?")]
        public int? APETANLYS { get; set; }

        [RequiredIf(nameof(DXAPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the amyloid PET scan used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? APETINT { get; set; }

        // 4. Tau PET

        [RequiredOnFinalized]
        [Display(Name = "Was tau PET used in the etiologic diagnosis?")]
        public int? DXTAUPET { get; set; }

        [RequiredIf(nameof(DXTAUPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Tau PET MTL result")]
        public int? TPETMTLRS { get; set; }

        [Display(Name = "How were tau PET MTL results obtained - Visual Read")]
        public int? TPETMTLVIS { get; set; }

        [Display(Name = "How were tau PET MTL results obtained - Quantitative")]
        public int? TPETMTLQNT { get; set; }

        [RequiredIf(nameof(DXTAUPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were tau PET MTL results obtained?")]
        public int? TPETMTLAYS { get; set; }

        [RequiredIf(nameof(DXTAUPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Tau PET Neocortical result")]
        public int? TPETNEORS { get; set; }

        [Display(Name = "How were tau PET neocortical results obtained - Visual Read")]
        public int? TPETNEOVIS { get; set; }

        [Display(Name = "How were tau PET neocortical results obtained - Quantitative")]
        public int? TPETNEOQNT { get; set; }

        [RequiredIf(nameof(DXTAUPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were tau PET neocortical results obtained?")]
        public int? TPETNEOAYS { get; set; }

        [RequiredIf(nameof(DXTAUPET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the tau PET scan used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? DXTAUPTINT { get; set; }


        // 5. MRI / Ischemia / CAA

        [RequiredOnFinalized]
        [Display(Name = "Was infarction on MRI or WMH consistent with ischemia or blood products consistent with CAA used in the etiologic diagnosis?")]
        public int? INFORISCH { get; set; }

        [Display(Name = "Imaging result - Infarction on MRI")]
        public int? IMGRSINF { get; set; }

        [Display(Name = "Imaging result - Infarction on MRI - Lacunar")]
        public int? IMGRSINFLC { get; set; }

        [Display(Name = "Imaging result - Infarction on MRI - Cortical")]
        public int? IMGRSINFCT { get; set; }

        [Display(Name = "Imaging result - Microbleeds")]
        public int? IMGRSMICR { get; set; }

        [Display(Name = "Imaging result - WMH")]
        public int? IMGRSWMH { get; set; }

        [Display(Name = "Imaging result - Superficial siderosis")]
        public int? IMGRSSPSID { get; set; }

        [Display(Name = "Imaging result - Other (specify)")]
        public int? IMGRSOTH { get; set; }

        [RequiredIf(nameof(IMGRSOTH), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Other imaging result")]
        [MaxLength(60)]
        public string? IMGRSOTHX { get; set; }

        [RequiredIf(nameof(INFORISCH), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the imaging scan used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? IMGRSINT { get; set; }

        // 6. αSyn-SAA

        [RequiredOnFinalized]
        [Display(Name = "Was αSyn-SAA used in the etiologic diagnosis?")]
        public int? DXASYN { get; set; }

        [RequiredIf(nameof(DXASYN), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "αSyn-SAA result")]
        public int? ASYNRS { get; set; }

        [RequiredIf(nameof(DXASYN), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "αSyn-SAA assay")]
        public int? ASYNASSAY { get; set; }

        [RequiredIf(nameof(ASYNASSAY), "2", ErrorMessage = "Please specify.")]
        [Display(Name = "Other αSyn-SAA assay - Specify")]
        [MaxLength(60)]
        public string? ASYNASSAYX { get; set; }

        [RequiredIf(nameof(DXASYN), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Where were αSyn-SAA values obtained?")]
        [MaxLength(60)]
        public string? ASYNANLYSX { get; set; }

        [RequiredIf(nameof(DXASYN), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Was the αSyn-SAA sample used in the diagnosis from a date within +/- 12 months of the current UDS visit?")]
        public int? ASYNINT { get; set; }


        // 7. AA Biological Biomarker Criteria

        [RequiredOnFinalized]
        [Display(Name = "Did the participant meet the AA biological biomarker criteria for Alzheimer's based on a positive Core 1 biomarker?")]
        public int? AACRITMET { get; set; }

        // 8. Core 1 Biomarker Selection

        [Display(Name = "Which Core 1 biomarker was used to make this determination - Amyloid PET")]
        public int? CR1APET { get; set; }

        [Display(Name = "Which Core 1 biomarker was used to make this determination - p-tau217")]
        public int? CR1PTAU217 { get; set; }

        [Display(Name = "Which Core 1 biomarker was used to make this determination - %p-tau217")]
        public int? CR1PCPT217 { get; set; }

        [Display(Name = "Which Core 1 biomarker was used to make this determination - p-tau181/Aβ42")]
        public int? CR1PT181AB { get; set; }

        [Display(Name = "Which Core 1 biomarker was used to make this determination - t-tau/Aβ42")]
        public int? CR1TTABETA { get; set; }

        [Display(Name = "Which Core 1 biomarker was used to make this determination - Aβ42/40")]
        public int? C1AB42AB40 { get; set; }

        [Display(Name = "Which Core 1 biomarker was used to make this determination - Other")]
        public int? CR1OTH { get; set; }

        [RequiredIf(nameof(CR1OTH), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Other Core 1 biomarker was used to make this determination - Specify")]
        [MaxLength(60)]
        public string? CR1OTHX { get; set; }

        [RequiredIf(nameof(AACRITMET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Select the biological stage of the participant")]
        public int? BIOSTAGE { get; set; }

        [RequiredIf(nameof(AACRITMET), "1", ErrorMessage = "Please specify.")]
        [Display(Name = "Clinical AD stage")]
        public int? CLINSTAGE { get; set; }

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
