using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B9FormFields : IFormFields
    {
        public int? DECCOG { get; set; }
        public int? DECMOT { get; set; }
        public int? PSYCHSYM { get; set; }
        public int? DECCOGIN { get; set; }
        public int? DECMOTIN { get; set; }
        public int? PSYCHSYMIN { get; set; }
        public bool? DECCLIN { get; set; }
        public bool? DECCLCOG { get; set; }
        public int? COGMEM { get; set; }
        public int? COGORI { get; set; }
        public int? COGJUDG { get; set; }
        public int? COGLANG { get; set; }
        public int? COGVIS { get; set; }
        public int? COGATTN { get; set; }
        public int? COGFLUC { get; set; }
        public int? COGOTHR { get; set; }
        public string? COGOTHRX { get; set; }
        public int? COGAGE { get; set; }
        public int? COGMODE { get; set; }
        public string? COGMODEX { get; set; }
        public int? DECCLBE { get; set; }
        public int? BEAPATHY { get; set; }
        public int? BEDEP { get; set; }
        public int? BEANX { get; set; }
        public int? BEEUPH { get; set; }
        public int? BEIRRIT { get; set; }
        public int? BEAGIT { get; set; }
        public int? BEHAGE { get; set; }
        public int? BEVHALL { get; set; }
        public int? BEVPATT { get; set; }
        public int? BEVWELL { get; set; }
        public int? BEAHALL { get; set; }
        public int? BEAHSIMP { get; set; }
        public int? BEAHCOMP { get; set; }
        public int? BEDEL { get; set; }
        public int? BEAGGRS { get; set; }
        public int? PSYCHAGE { get; set; }
        public int? BEDISIN { get; set; }
        public int? BEPERCH { get; set; }
        public int? BEEMPATH { get; set; }
        public int? BEOBCOM { get; set; }
        public int? BEANGER { get; set; }
        public int? BESUBAB { get; set; }
        public bool? ALCUSE { get; set; }
        public bool? SEDUSE { get; set; }
        public bool? OPIATEUSE { get; set; }
        public bool? COCAINEUSE { get; set; }
        public bool? OTHSUBUSE { get; set; }
        public string? OTHSUBUSEX { get; set; }
        public int? PERCHAGE { get; set; }
        public int? BEREM { get; set; }
        public int? BEREMAGO { get; set; }
        public int? BEREMCONF { get; set; }
        public int? BEOTHR { get; set; }
        public string? BEOTHRX { get; set; }
        public int? BEMODE { get; set; }
        public string? BEMODEX { get; set; }
        public bool? DECCLMOT { get; set; }
        public int? MOGAIT { get; set; }
        public int? MOFALLS { get; set; }
        public int? MOSLOW { get; set; }
        public int? MOTREM { get; set; }
        public int? MOLIMB { get; set; }
        public int? MOFACE { get; set; }
        public int? MOSPEECH { get; set; }
        public int? MOTORAGE { get; set; }
        public int? MOMODE { get; set; }
        public string? MOMODEX { get; set; }
        public int? MOMOPARK { get; set; }
        public int? MOMOALS { get; set; }
        public int? COURSE { get; set; }
        public int? FRSTCHG { get; set; }

        public B9FormFields()
        {
        }
        public B9FormFields(FormDto dto)
        {
            if (dto is B9Dto)
            {
                var b9Dto = ((B9Dto)dto);
                COGMEM = b9Dto.COGMEM;
                COGORI = b9Dto.COGORI;
                COGJUDG = b9Dto.COGJUDG;
                COGLANG = b9Dto.COGLANG;
                COGVIS = b9Dto.COGVIS;
                COGATTN = b9Dto.COGATTN;
                COGFLUC = b9Dto.COGFLUC;
                COGOTHR = b9Dto.COGOTHR;
                COGOTHRX = b9Dto.COGOTHRX;
                COGMODE = b9Dto.COGMODE;
                COGMODEX = b9Dto.COGMODEX;
                DECCLBE = b9Dto.DECCLBE;
                BEAPATHY = b9Dto.BEAPATHY;
                BEDEP = b9Dto.BEDEP;
                BEVHALL = b9Dto.BEVHALL;
                BEVWELL = b9Dto.BEVWELL;
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
                BEMODE = b9Dto.BEMODE;
                BEMODEX = b9Dto.BEMODEX;
                MOGAIT = b9Dto.MOGAIT;
                MOFALLS = b9Dto.MOFALLS;
                MOTREM = b9Dto.MOTREM;
                MOSLOW = b9Dto.MOSLOW;
                MOMODE = b9Dto.MOMODE;
                MOMODEX = b9Dto.MOMODEX;
                MOMOPARK = b9Dto.MOMOPARK;
                MOMOALS = b9Dto.MOMOALS;
                COURSE = b9Dto.COURSE;
                FRSTCHG = b9Dto.FRSTCHG;
            }
        }
        public string GetDescription()
        {
            return "Clinician Judgment of Symptoms";
        }

        public string GetVersion()
        {
            return "4.0";
        }
    }
}

