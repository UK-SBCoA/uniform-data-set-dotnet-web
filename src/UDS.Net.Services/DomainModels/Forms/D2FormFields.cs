using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
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
            if (dto is D2Dto)
            {
                var d2Dto = ((D2Dto)dto);
                CANCER = d2Dto.CANCER;
                CANCSITE = d2Dto.CANCSITE;
                DIABET = d2Dto.DIABET;
                MYOINF = d2Dto.MYOINF;
                CONGHRT = d2Dto.CONGHRT;
                AFIBRILL = d2Dto.AFIBRILL;
                HYPERT = d2Dto.HYPERT;
                ANGINA = d2Dto.ANGINA;
                HYPCHOL = d2Dto.HYPCHOL;
                VB12DEF = d2Dto.VB12DEF;
                THYDIS = d2Dto.THYDIS;
                ARTH = d2Dto.ARTH;
                ARTYPE = d2Dto.ARTYPE;
                ARTYPEX = d2Dto.ARTYPEX;
                ARTUPEX = d2Dto.ARTUPEX;
                ARTLOEX = d2Dto.ARTLOEX;
                ARTSPIN = d2Dto.ARTSPIN;
                ARTUNKN = d2Dto.ARTUNKN;
                URINEINC = d2Dto.URINEINC;
                BOWLINC = d2Dto.BOWLINC;
                SLEEPAP = d2Dto.SLEEPAP;
                REMDIS = d2Dto.REMDIS;
                HYPOSOM = d2Dto.HYPOSOM;
                SLEEPOTH = d2Dto.SLEEPOTH;
                SLEEPOTX = d2Dto.SLEEPOTX;
                ANGIOCP = d2Dto.ANGIOCP;
                ANGIOPCI = d2Dto.ANGIOPCI;
                PACEMAKE = d2Dto.PACEMAKE;
                HVALVE = d2Dto.HVALVE;
                ANTIENC = d2Dto.ANTIENC;
                ANTIENCX = d2Dto.ANTIENCX;
                OTHCOND = d2Dto.OTHCOND;
                OTHCONDX = d2Dto.OTHCONDX;
            }
        }

        public string GetDescription()
        {
            return "Clinician-assessed Medical Conditions";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

