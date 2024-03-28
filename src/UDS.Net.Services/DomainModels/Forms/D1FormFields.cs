using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class D1FormFields : IFormFields
    {
        public int? DXMETHOD { get; set; }
        public int? NORMCOG { get; set; }
        public int? DEMENTED { get; set; }
        public int? AMNDEM { get; set; }
        public int? PCA { get; set; }
        public int? PPASYN { get; set; }
        public int? PPASYNT { get; set; }
        public int? FTDSYN { get; set; }
        public int? LBDSYN { get; set; }
        public int? NAMNDEM { get; set; }
        public int? MCIAMEM { get; set; }
        public int? MCIAPLUS { get; set; }
        public int? MCIAPLAN { get; set; }
        public int? MCIAPATT { get; set; }
        public int? MCIAPEX { get; set; }
        public int? MCIAPVIS { get; set; }
        public int? MCINON1 { get; set; }
        public int? MCIN1LAN { get; set; }
        public int? MCIN1ATT { get; set; }
        public int? MCIN1EX { get; set; }
        public int? MCIN1VIS { get; set; }
        public int? MCINON2 { get; set; }
        public int? MCIN2LAN { get; set; }
        public int? MCIN2ATT { get; set; }
        public int? MCIN2EX { get; set; }
        public int? MCIN2VIS { get; set; }
        public int? IMPNOMCI { get; set; }
        public int? AMYLPET { get; set; }
        public int? AMYLCSF { get; set; }
        public int? FDGAD { get; set; }
        public int? HIPPATR { get; set; }
        public int? TAUPETAD { get; set; }
        public int? CSFTAU { get; set; }
        public int? FDGFTLD { get; set; }
        public int? TPETFTLD { get; set; }
        public int? MRFTLD { get; set; }
        public int? DATSCAN { get; set; }
        public int? OTHBIOM { get; set; }
        public string OTHBIOMX { get; set; }
        public int? IMAGLINF { get; set; }
        public int? IMAGLAC { get; set; }
        public int? IMAGMACH { get; set; }
        public int? IMAGMICH { get; set; }
        public int? IMAGMWMH { get; set; }
        public int? IMAGEWMH { get; set; }
        public int? ADMUT { get; set; }
        public int? FTLDMUT { get; set; }
        public int? OTHMUT { get; set; }
        public string OTHMUTX { get; set; }
        public int? ALZDIS { get; set; }
        public int? ALZDISIF { get; set; }
        public int? LBDIS { get; set; }
        public int? LBDIF { get; set; }
        public int? PARK { get; set; }
        public int? MSA { get; set; }
        public int? MSAIF { get; set; }
        public int? PSP { get; set; }
        public int? PSPIF { get; set; }
        public int? CORT { get; set; }
        public int? CORTIF { get; set; }
        public int? FTLDMO { get; set; }
        public int? FTLDMOIF { get; set; }
        public int? FTLDNOS { get; set; }
        public int? FTLDNOIF { get; set; }
        public int? FTLDSUBT { get; set; }
        public string FTLDSUBX { get; set; }
        public int? CVD { get; set; }
        public int? CVDIF { get; set; }
        public int? PREVSTK { get; set; }
        public int? STROKDEC { get; set; }
        public int? STKIMAG { get; set; }
        public int? INFNETW { get; set; }
        public int? INFWMH { get; set; }
        public int? ESSTREM { get; set; }
        public int? ESSTREIF { get; set; }
        public int? DOWNS { get; set; }
        public int? DOWNSIF { get; set; }
        public int? HUNT { get; set; }
        public int? HUNTIF { get; set; }
        public int? PRION { get; set; }
        public int? PRIONIF { get; set; }
        public int? BRNINJ { get; set; }
        public int? BRNINJIF { get; set; }
        public int? BRNINCTE { get; set; }
        public int? HYCEPH { get; set; }
        public int? HYCEPHIF { get; set; }
        public int? EPILEP { get; set; }
        public int? EPILEPIF { get; set; }
        public int? NEOP { get; set; }
        public int? NEOPIF { get; set; }
        public int? NEOPSTAT { get; set; }
        public int? HIV { get; set; }
        public int? HIVIF { get; set; }
        public int? OTHCOG { get; set; }
        public int? OTHCOGIF { get; set; }
        public string OTHCOGX { get; set; }
        public int? DEP { get; set; }
        public int? DEPIF { get; set; }
        public int? DEPTREAT { get; set; }
        public int? BIPOLDX { get; set; }
        public int? BIPOLDIF { get; set; }
        public int? SCHIZOP { get; set; }
        public int? SCHIZOIF { get; set; }
        public int? ANXIET { get; set; }
        public int? ANXIETIF { get; set; }
        public int? DELIR { get; set; }
        public int? DELIRIF { get; set; }
        public int? PTSDDX { get; set; }
        public int? PTSDDXIF { get; set; }
        public int? OTHPSY { get; set; }
        public int? OTHPSYIF { get; set; }
        public string OTHPSYX { get; set; }
        public int? ALCDEMIF { get; set; }
        public int? ALCABUSE { get; set; }
        public int? IMPSUB { get; set; }
        public int? IMPSUBIF { get; set; }
        public int? DYSILL { get; set; }
        public int? DYSILLIF { get; set; }
        public int? MEDS { get; set; }
        public int? MEDSIF { get; set; }
        public int? COGOTH { get; set; }
        public int? COGOTHIF { get; set; }
        public string COGOTHX { get; set; }
        public int? COGOTH2 { get; set; }
        public int? COGOTH2F { get; set; }
        public string COGOTH2X { get; set; }
        public int? COGOTH3 { get; set; }
        public int? COGOTH3F { get; set; }
        public string COGOTH3X { get; set; }

        public D1FormFields() { }
        public D1FormFields(FormDto dto)
        {
            if (dto is D1Dto)
            {
                var d1Dto = ((D1Dto)dto);
                DXMETHOD = d1Dto.DXMETHOD;
                NORMCOG = d1Dto.NORMCOG;
                DEMENTED = d1Dto.DEMENTED;
                AMNDEM = d1Dto.AMNDEM;
                PCA = d1Dto.PCA;
                PPASYN = d1Dto.PPASYN;
                PPASYNT = d1Dto.PPASYNT;
                FTDSYN = d1Dto.FTDSYN;
                LBDSYN = d1Dto.LBDSYN;
                NAMNDEM = d1Dto.NAMNDEM;
                MCIAMEM = d1Dto.MCIAMEM;
                MCIAPLUS = d1Dto.MCIAPLUS;
                MCIAPLAN = d1Dto.MCIAPLAN;
                MCIAPATT = d1Dto.MCIAPATT;
                MCIAPEX = d1Dto.MCIAPEX;
                MCIAPVIS = d1Dto.MCIAPVIS;
                MCINON1 = d1Dto.MCINON1;
                MCIN1LAN = d1Dto.MCIN1LAN;
                MCIN1ATT = d1Dto.MCIN1ATT;
                MCIN1EX = d1Dto.MCIN1EX;
                MCIN1VIS = d1Dto.MCIN1VIS;
                MCINON2 = d1Dto.MCINON2;
                MCIN2LAN = d1Dto.MCIN2LAN;
                MCIN2ATT = d1Dto.MCIN2ATT;
                MCIN2EX = d1Dto.MCIN2EX;
                MCIN2VIS = d1Dto.MCIN2VIS;
                IMPNOMCI = d1Dto.IMPNOMCI;
                AMYLPET = d1Dto.AMYLPET;
                AMYLCSF = d1Dto.AMYLCSF;
                FDGAD = d1Dto.FDGAD;
                HIPPATR = d1Dto.HIPPATR;
                TAUPETAD = d1Dto.TAUPETAD;
                CSFTAU = d1Dto.CSFTAU;
                FDGFTLD = d1Dto.FDGFTLD;
                TPETFTLD = d1Dto.TPETFTLD;
                MRFTLD = d1Dto.MRFTLD;
                DATSCAN = d1Dto.DATSCAN;
                OTHBIOM = d1Dto.OTHBIOM;
                OTHBIOMX = d1Dto.OTHBIOMX;
                IMAGLINF = d1Dto.IMAGLINF;
                IMAGLAC = d1Dto.IMAGLAC;
                IMAGMACH = d1Dto.IMAGMACH;
                IMAGMICH = d1Dto.IMAGMICH;
                IMAGMWMH = d1Dto.IMAGMWMH;
                IMAGEWMH = d1Dto.IMAGEWMH;
                ADMUT = d1Dto.ADMUT;
                FTLDMUT = d1Dto.FTLDMUT;
                OTHMUT = d1Dto.OTHMUT;
                OTHMUTX = d1Dto.OTHMUTX;
                ALZDIS = d1Dto.ALZDIS;
                ALZDISIF = d1Dto.ALZDISIF;
                LBDIS = d1Dto.LBDIS;
                LBDIF = d1Dto.LBDIF;
                PARK = d1Dto.PARK;
                MSA = d1Dto.MSA;
                MSAIF = d1Dto.MSAIF;
                PSP = d1Dto.PSP;
                PSPIF = d1Dto.PSPIF;
                CORT = d1Dto.CORT;
                CORTIF = d1Dto.CORTIF;
                FTLDMO = d1Dto.FTLDMO;
                FTLDMOIF = d1Dto.FTLDMOIF;
                FTLDNOS = d1Dto.FTLDNOS;
                FTLDNOIF = d1Dto.FTLDNOIF;
                FTLDSUBT = d1Dto.FTLDSUBT;
                FTLDSUBX = d1Dto.FTLDSUBX;
                CVD = d1Dto.CVD;
                CVDIF = d1Dto.CVDIF;
                PREVSTK = d1Dto.PREVSTK;
                STROKDEC = d1Dto.STROKDEC;
                STKIMAG = d1Dto.STKIMAG;
                INFNETW = d1Dto.INFNETW;
                INFWMH = d1Dto.INFWMH;
                ESSTREM = d1Dto.ESSTREM;
                ESSTREIF = d1Dto.ESSTREIF;
                DOWNS = d1Dto.DOWNS;
                DOWNSIF = d1Dto.DOWNSIF;
                HUNT = d1Dto.HUNT;
                HUNTIF = d1Dto.HUNTIF;
                PRION = d1Dto.PRION;
                PRIONIF = d1Dto.PRIONIF;
                BRNINJ = d1Dto.BRNINJ;
                BRNINJIF = d1Dto.BRNINJIF;
                BRNINCTE = d1Dto.BRNINCTE;
                HYCEPH = d1Dto.HYCEPH;
                HYCEPHIF = d1Dto.HYCEPHIF;
                EPILEP = d1Dto.EPILEP;
                EPILEPIF = d1Dto.EPILEPIF;
                NEOP = d1Dto.NEOP;
                NEOPIF = d1Dto.NEOPIF;
                NEOPSTAT = d1Dto.NEOPSTAT;
                HIV = d1Dto.HIV;
                HIVIF = d1Dto.HIVIF;
                OTHCOG = d1Dto.OTHCOG;
                OTHCOGIF = d1Dto.OTHCOGIF;
                OTHCOGX = d1Dto.OTHCOGX;
                DEP = d1Dto.DEP;
                DEPIF = d1Dto.DEPIF;
                DEPTREAT = d1Dto.DEPTREAT;
                BIPOLDX = d1Dto.BIPOLDX;
                BIPOLDIF = d1Dto.BIPOLDIF;
                SCHIZOP = d1Dto.SCHIZOP;
                SCHIZOIF = d1Dto.SCHIZOIF;
                ANXIET = d1Dto.ANXIET;
                ANXIETIF = d1Dto.ANXIETIF;
                DELIR = d1Dto.DELIR;
                DELIRIF = d1Dto.DELIRIF;
                PTSDDX = d1Dto.PTSDDX;
                PTSDDXIF = d1Dto.PTSDDXIF;
                OTHPSY = d1Dto.OTHPSY;
                OTHPSYIF = d1Dto.OTHPSYIF;
                OTHPSYX = d1Dto.OTHPSYX;
                ALCDEMIF = d1Dto.ALCDEMIF;
                ALCABUSE = d1Dto.ALCABUSE;
                IMPSUB = d1Dto.IMPSUB;
                IMPSUBIF = d1Dto.IMPSUBIF;
                DYSILL = d1Dto.DYSILL;
                DYSILLIF = d1Dto.DYSILLIF;
                MEDS = d1Dto.MEDS;
                MEDSIF = d1Dto.MEDSIF;
                COGOTH = d1Dto.COGOTH;
                COGOTHIF = d1Dto.COGOTHIF;
                COGOTHX = d1Dto.COGOTHX;
                COGOTH2 = d1Dto.COGOTH2;
                COGOTH2F = d1Dto.COGOTH2F;
                COGOTH2X = d1Dto.COGOTH2X;
                COGOTH3 = d1Dto.COGOTH3;
                COGOTH3F = d1Dto.COGOTH3F;
                COGOTH3X = d1Dto.COGOTH3X;
            }
        }
        public string GetDescription()
        {
            return "Clinician Diagnosis";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

