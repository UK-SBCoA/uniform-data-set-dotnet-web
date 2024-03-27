using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    // TODO remove
    [Obsolete]
    public class D2FormFields : IFormFields
    {
        public int? CANCER { get; set; }
        public string CANCSITE { get; set; }
        public int? DIABET { get; set; }
        public int? MYOINF { get; set; }
        public int? CONGHRT { get; set; }
        public int? AFIBRILL { get; set; }
        public int? HYPERT { get; set; }
        public int? ANGINA { get; set; }
        public int? HYPCHOL { get; set; }
        public int? VB12DEF { get; set; }
        public int? THYDIS { get; set; }
        public int? ARTH { get; set; }
        public int? ARTYPE { get; set; }
        public string ARTYPEX { get; set; }
        public int? ARTUPEX { get; set; }
        public int? ARTLOEX { get; set; }
        public int? ARTSPIN { get; set; }
        public int? ARTUNKN { get; set; }
        public int? URINEINC { get; set; }
        public int? BOWLINC { get; set; }
        public int? SLEEPAP { get; set; }
        public int? REMDIS { get; set; }
        public int? HYPOSOM { get; set; }
        public int? SLEEPOTH { get; set; }
        public string SLEEPOTX { get; set; }
        public int? ANGIOCP { get; set; }
        public int? ANGIOPCI { get; set; }
        public int? PACEMAKE { get; set; }
        public int? HVALVE { get; set; }
        public int? ANTIENC { get; set; }
        public string ANTIENCX { get; set; }
        public int? OTHCOND { get; set; }
        public string OTHCONDX { get; set; }

        public D2FormFields()
        {
        }
        public D2FormFields(FormDto dto)
        {
        }

        public string GetDescription()
        {
            return "Clinician-assessed Medical Conditions";
        }

        public string GetVersion()
        {
            return "4.0";
        }
    }
}

