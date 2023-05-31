using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B9FormFields : IFormFields
    {
        public int? DECSUB { get; set; }
        public int? DECIN { get; set; }
        public int? DECCLCOG { get; set; }
        public int? COGMEM { get; set; }
        public int? COGORI { get; set; }
        public int? COGJUDG { get; set; }
        public int? COGLANG { get; set; }
        public int? COGVIS { get; set; }
        public int? COGATTN { get; set; }
        public int? COGFLUC { get; set; }
        public int? COGFLAGO { get; set; }
        public int? COGOTHR { get; set; }
        public string COGOTHRX { get; set; }
        public int? COGFPRED { get; set; }
        public string COGFPREX { get; set; }
        public int? COGMODE { get; set; }
        public string COGMODEX { get; set; }
        public int? DECAGE { get; set; }
        public int? DECCLBE { get; set; }
        public int? BEAPATHY { get; set; }
        public int? BEDEP { get; set; }
        public int? BEVHALL { get; set; }
        public int? BEVWELL { get; set; }
        public int? BEVHAGO { get; set; }
        public int? BEAHALL { get; set; }
        public int? BEDEL { get; set; }
        public int? BEDISIN { get; set; }
        public int? BEIRRIT { get; set; }
        public int? BEAGIT { get; set; }
        public int? BEPERCH { get; set; }
        public int? BEREM { get; set; }
        public int? BEREMAGO { get; set; }
        public int? BEANX { get; set; }
        public int? BEOTHR { get; set; }
        public string BEOTHRX { get; set; }
        public int? BEFPRED { get; set; }
        public string BEFPREDX { get; set; }
        public int? BEMODE { get; set; }
        public string BEMODEX { get; set; }
        public int? BEAGE { get; set; }
        public int? DECCLMOT { get; set; }
        public int? MOGAIT { get; set; }
        public int? MOFALLS { get; set; }
        public int? MOTREM { get; set; }
        public int? MOSLOW { get; set; }
        public int? MOFRST { get; set; }
        public int? MOMODE { get; set; }
        public string MOMODEX { get; set; }
        public int? MOMOPARK { get; set; }
        public int? PARKAGE { get; set; }
        public int? MOMOALS { get; set; }
        public int? ALSAGE { get; set; }
        public int? MOAGE { get; set; }
        public int? COURSE { get; set; }
        public int? FRSTCHG { get; set; }
        public int? LBDEVAL { get; set; }
        public int? FTLDEVAL { get; set; }

        public B9FormFields()
        {
        }
        public B9FormFields(FormDto dto)
        {
            if (dto is B9Dto)
            {
                var b9Dto = ((B9Dto)dto);
                DECSUB = b9Dto.DECSUB;
                DECIN = b9Dto.DECIN;
                DECCLCOG = b9Dto.DECCLCOG;
                COGMEM = b9Dto.COGMEM;
                COGORI = b9Dto.COGORI;
                COGJUDG = b9Dto.COGJUDG;
                COGLANG = b9Dto.COGLANG;
                COGVIS = b9Dto.COGVIS;
                COGATTN = b9Dto.COGATTN;
                COGFLUC = b9Dto.COGFLUC;
                COGFLAGO = b9Dto.COGFLAGO;
                COGOTHR = b9Dto.COGOTHR;
                COGOTHRX = b9Dto.COGOTHRX;
                COGFPRED = b9Dto.COGFPRED;
                COGFPREX = b9Dto.COGFPREX;
                COGMODE = b9Dto.COGMODE;
                COGMODEX = b9Dto.COGMODEX;
                DECAGE = b9Dto.DECAGE;
                DECCLBE = b9Dto.DECCLBE;
                BEAPATHY = b9Dto.BEAPATHY;
                BEDEP = b9Dto.BEDEP;
                BEVHALL = b9Dto.BEVHALL;
                BEVWELL = b9Dto.BEVWELL;
                BEVHAGO = b9Dto.BEVHAGO;
                BEAHALL = b9Dto.BEAHALL;
                BEDEL = b9Dto.BEDEL;
                BEDISIN = b9Dto.BEDISIN;
                BEIRRIT = b9Dto.BEDISIN;
                BEAGIT = b9Dto.BEAGIT;
                BEPERCH = b9Dto.BEAGIT;
                BEREM = b9Dto.BEREM;
                BEREMAGO = b9Dto.BEREMAGO;
                BEANX = b9Dto.BEANX;
                BEOTHR = b9Dto.BEOTHR;
                BEOTHRX = b9Dto.BEOTHRX;
                BEFPRED = b9Dto.BEFPRED;
                BEFPREDX = b9Dto.BEFPREDX;
                BEMODE = b9Dto.BEMODE;
                BEMODEX = b9Dto.BEMODEX;
                BEAGE = b9Dto.BEAGE;
                DECCLMOT = b9Dto.DECCLMOT;
                MOGAIT = b9Dto.MOGAIT;
                MOFALLS = b9Dto.MOFALLS;
                MOTREM = b9Dto.MOTREM;
                MOSLOW = b9Dto.MOSLOW;
                MOFRST = b9Dto.MOFRST;
                MOMODE = b9Dto.MOMODE;
                MOMODEX = b9Dto.MOMODEX;
                MOMOPARK = b9Dto.MOMOPARK;
                PARKAGE = b9Dto.PARKAGE;
                MOMOALS = b9Dto.MOMOALS;
                ALSAGE = b9Dto.ALSAGE;
                MOAGE = b9Dto.MOAGE;
                COURSE = b9Dto.COURSE;
                FRSTCHG = b9Dto.FRSTCHG;
                LBDEVAL = b9Dto.LBDEVAL;
                FTLDEVAL = b9Dto.FTLDEVAL;
            }
        }
        public string GetDescription()
        {
            return "Clinician Judgment of Symptoms";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

