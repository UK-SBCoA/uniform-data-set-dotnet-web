using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    [Obsolete]
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
                return new List<RemoteModality>(); // form is required for I
            }
        }

        public D1FormFields() { }
        public D1FormFields(FormDto dto)
        {
        }
        public string GetDescription()
        {
            return "Clinician Diagnosis";
        }

        public string GetVersion()
        {
            return "4";
        }
    }
}

