
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class D1cFormFields : IFormFields
    {
        // 1. Plasma Biomarkers
        public int? DXPLSMABIO { get; set; }
        public int? DXPTAU217 { get; set; }
        public int? PTAU217RS { get; set; }
        public int? PT217ANLYS { get; set; }
        public int? PT217INT { get; set; }
        public int? DXPCPT217 { get; set; }
        public int? PCPT217RS { get; set; }
        public int? PCPT217INT { get; set; }
        public int? DXOTHPLSMA { get; set; }
        public string DXOTHPLSMX { get; set; }
        public int? OTHPLSMARS { get; set; }
        public int? OPLSMANLYS { get; set; }
        public int? OPLSMAINT { get; set; }

        // 2. CSF Biomarkers
        public int? DXCSFBIO { get; set; }
        public int? DXPT181AB { get; set; }
        public int? PT181ABRS { get; set; }
        public int? PT181ABAYS { get; set; }
        public int? PT181ABINT { get; set; }
        public int? DXTTABETA { get; set; }
        public int? TTABETARS { get; set; }
        public int? TTABETAINT { get; set; }
        public int? DXAB42AB40 { get; set; }
        public int? AB42AB40RS { get; set; }
        public int? AB42AB40AY { get; set; }
        public int? AB42AB40IT { get; set; }
        public int? DXOTHCSF { get; set; }
        public string DXOTHCSFX { get; set; }
        public int? OTHCSFRS { get; set; }
        public int? OCSFANLYS { get; set; }
        public int? OCSFINT { get; set; }

        // 3. Amyloid PET
        public int? DXAPET { get; set; }
        public int? APETRS { get; set; }
        public int? APETVIS { get; set; }
        public int? APETQUANT { get; set; }
        public int? APETANLYS { get; set; }
        public int? APETINT { get; set; }

        // 4. Tau PET
        public int? DXTAUPET { get; set; }
        public int? TPETMTLRS { get; set; }
        public int? TPETMTLVIS { get; set; }
        public int? TPETMTLQNT { get; set; }
        public int? TPETMTLAYS { get; set; }
        public int? TPETNEORS { get; set; }
        public int? TPETNEOVIS { get; set; }
        public int? TPETNEOQNT { get; set; }
        public int? TPETNEOAYS { get; set; }
        public int? DXTAUPTINT { get; set; }

        // 5. MRI / Ischemia / CAA
        public int? INFORISCH { get; set; }
        public int? IMGRSINF { get; set; }
        public int? IMGRSINFLC { get; set; }
        public int? IMGRSINFCT { get; set; }
        public int? IMGRSMICR { get; set; }
        public int? IMGRSWMH { get; set; }
        public int? IMGRSSPSID { get; set; }
        public int? IMGRSOTH { get; set; }
        public string IMGRSOTHX { get; set; }
        public int? IMGRSINT { get; set; }

        // 6. Alpha Synuclein Seed Amplification Assay
        public int? DXASYN { get; set; }
        public int? ASYNRS { get; set; }
        public int? ASYNASSAY { get; set; }
        public string ASYNASSAYX { get; set; }
        public string ASYNANLYSX { get; set; }
        public int? ASYNINT { get; set; }

        // 7. AA Biological Biomarker Criteria
        public int? AACRITMET { get; set; }

        // 8. Core 1 Biomarker Selection
        public int? CR1APET { get; set; }
        public int? CR1PTAU217 { get; set; }
        public int? CR1PCPT217 { get; set; }
        public int? CR1PT181AB { get; set; }
        public int? CR1TTABETA { get; set; }
        public int? C1AB42AB40 { get; set; }
        public int? CR1OTH { get; set; }
        public string CR1OTHX { get; set; }

        // 9. Biological Stage
        public int? BIOSTAGE { get; set; }

        // 10. Clinical AD Stage
        public int? CLINSTAGE { get; set; }

        // Form Configuration
        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.InPerson, FormMode.Remote };
            }
        }

        public IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes
        {
            get
            {
                return new List<NotIncludedReasonCode>();
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video };
            }
        }

        public IEnumerable<AdministrationFormat> AdministrationFormats
        {
            get
            {
                return new List<AdministrationFormat>() { };
            }
        }

        public string GetDescription()
        {
            return "Plasma and CSF Biomarkers and Etiologic Diagnosis";
        }

        public string GetVersion()
        {
            return "4";
        }

        public D1cFormFields() { }

        public D1cFormFields(FormDto dto) : this()
        {
            if (dto is D1cDto)
            {
                var d1cDto = ((D1cDto)dto);
                // 1. Plasma Biomarkers
                DXPLSMABIO = d1cDto.DXPLSMABIO;
                DXPTAU217 = d1cDto.DXPTAU217;
                PTAU217RS = d1cDto.PTAU217RS;
                PT217ANLYS = d1cDto.PT217ANLYS;
                PT217INT = d1cDto.PT217INT;
                DXPCPT217 = d1cDto.DXPCPT217;
                PCPT217RS = d1cDto.PCPT217RS;
                PCPT217INT = d1cDto.PCPT217INT;
                DXOTHPLSMA = d1cDto.DXOTHPLSMA;
                DXOTHPLSMX = d1cDto.DXOTHPLSMX;
                OTHPLSMARS = d1cDto.OTHPLSMARS;
                OPLSMANLYS = d1cDto.OPLSMANLYS;
                OPLSMAINT = d1cDto.OPLSMAINT;

                // 2. CSF Biomarkers
                DXCSFBIO = d1cDto.DXCSFBIO;
                DXPT181AB = d1cDto.DXPT181AB;
                PT181ABRS = d1cDto.PT181ABRS;
                PT181ABAYS = d1cDto.PT181ABAYS;
                PT181ABINT = d1cDto.PT181ABINT;
                DXTTABETA = d1cDto.DXTTABETA;
                TTABETARS = d1cDto.TTABETARS;
                TTABETAINT = d1cDto.TTABETAINT;
                DXAB42AB40 = d1cDto.DXAB42AB40;
                AB42AB40RS = d1cDto.AB42AB40RS;
                AB42AB40AY = d1cDto.AB42AB40AY;
                AB42AB40IT = d1cDto.AB42AB40IT;
                DXOTHCSF = d1cDto.DXOTHCSF;
                DXOTHCSFX = d1cDto.DXOTHCSFX;
                OTHCSFRS = d1cDto.OTHCSFRS;
                OCSFANLYS = d1cDto.OCSFANLYS;
                OCSFINT = d1cDto.OCSFINT;

                // 3. Amyloid PET
                DXAPET = d1cDto.DXAPET;
                APETRS = d1cDto.APETRS;
                APETVIS = d1cDto.APETVIS;
                APETQUANT = d1cDto.APETQUANT;
                APETANLYS = d1cDto.APETANLYS;
                APETINT = d1cDto.APETINT;

                // 4. Tau PET
                DXTAUPET = d1cDto.DXTAUPET;
                TPETMTLRS = d1cDto.TPETMTLRS;
                TPETMTLVIS = d1cDto.TPETMTLVIS;
                TPETMTLQNT = d1cDto.TPETMTLQNT;
                TPETMTLAYS = d1cDto.TPETMTLAYS;
                TPETNEORS = d1cDto.TPETNEORS;
                TPETNEOVIS = d1cDto.TPETNEOVIS;
                TPETNEOQNT = d1cDto.TPETNEOQNT;
                TPETNEOAYS = d1cDto.TPETNEOAYS;
                DXTAUPTINT = d1cDto.DXTAUPTINT;

                // 5. MRI / Ischemia / CAA
                INFORISCH = d1cDto.INFORISCH;
                IMGRSINF = d1cDto.IMGRSINF;
                IMGRSINFLC = d1cDto.IMGRSINFLC;
                IMGRSINFCT = d1cDto.IMGRSINFCT;
                IMGRSMICR = d1cDto.IMGRSMICR;
                IMGRSWMH = d1cDto.IMGRSWMH;
                IMGRSSPSID = d1cDto.IMGRSSPSID;
                IMGRSOTH = d1cDto.IMGRSOTH;
                IMGRSOTHX = d1cDto.IMGRSOTHX;
                IMGRSINT = d1cDto.IMGRSINT;

                // 6. Alpha Synuclein Seed Amplification Assay
                DXASYN = d1cDto.DXASYN;
                ASYNRS = d1cDto.ASYNRS;
                ASYNASSAY = d1cDto.ASYNASSAY;
                ASYNASSAYX = d1cDto.ASYNASSAYX;
                ASYNANLYSX = d1cDto.ASYNANLYSX;
                ASYNINT = d1cDto.ASYNINT;

                // 7. AA Biological Biomarker Criteria
                AACRITMET = d1cDto.AACRITMET;

                // 8. Core 1 Biomarker Selection
                CR1APET = d1cDto.CR1APET;
                CR1PTAU217 = d1cDto.CR1PTAU217;
                CR1PCPT217 = d1cDto.CR1PCPT217;
                CR1PT181AB = d1cDto.CR1PT181AB;
                CR1TTABETA = d1cDto.CR1TTABETA;
                C1AB42AB40 = d1cDto.C1AB42AB40;
                CR1OTH = d1cDto.CR1OTH;
                CR1OTHX = d1cDto.CR1OTHX;

                // 9. Biological Stage
                BIOSTAGE = d1cDto.BIOSTAGE;

                // 10. Clinical AD Stage
                CLINSTAGE = d1cDto.CLINSTAGE;
            }
        }
    }
}
