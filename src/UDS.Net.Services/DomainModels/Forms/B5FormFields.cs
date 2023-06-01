using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B5FormFields : IFormFields
    {
        public int? NPIQINF { get; set; }
        public string NPIQINFX { get; set; }
        public int? DEL { get; set; }
        public int? DELSEV { get; set; }
        public int? HALL { get; set; }
        public int? HALLSEV { get; set; }
        public int? AGIT { get; set; }
        public int? AGITSEV { get; set; }
        public int? DEPD { get; set; }
        public int? DEPDSEV { get; set; }
        public int? ANX { get; set; }
        public int? ANXSEV { get; set; }
        public int? ELAT { get; set; }
        public int? ELATSEV { get; set; }
        public int? APA { get; set; }
        public int? APASEV { get; set; }
        public int? DISN { get; set; }
        public int? DISNSEV { get; set; }
        public int? IRR { get; set; }
        public int? IRRSEV { get; set; }
        public int? MOT { get; set; }
        public int? MOTSEV { get; set; }
        public int? NITE { get; set; }
        public int? NITESEV { get; set; }
        public int? APP { get; set; }
        public int? APPSEV { get; set; }

        public B5FormFields() { }
        public B5FormFields(FormDto dto)
        {
            if (dto is B5Dto)
            {
                var b5Dto = ((B5Dto)dto);
                NPIQINF = b5Dto.NPIQINF;
                NPIQINFX = b5Dto.NPIQINFX;
                DEL = b5Dto.DEL;
                DELSEV = b5Dto.DELSEV;
                HALL = b5Dto.HALL;
                HALLSEV = b5Dto.HALLSEV;
                AGIT = b5Dto.AGIT;
                AGITSEV = b5Dto.AGITSEV;
                DEPD = b5Dto.DEPD;
                DEPDSEV = b5Dto.DEPDSEV;
                ANX = b5Dto.ANX;
                ANXSEV = b5Dto.ANXSEV;
                ELAT = b5Dto.ELAT;
                ELATSEV = b5Dto.ELATSEV;
                APA = b5Dto.APA;
                APASEV = b5Dto.APASEV;
                DISN = b5Dto.DISN;
                DISNSEV = b5Dto.DISNSEV;
                IRR = b5Dto.IRR;
                IRRSEV = b5Dto.IRRSEV;
                MOT = b5Dto.MOT;
                MOTSEV = b5Dto.MOTSEV;
                NITE = b5Dto.NITE;
                NITESEV = b5Dto.NITESEV;
                APP = b5Dto.APP;
                APPSEV = b5Dto.APPSEV;
            }
        }
        public string GetDescription()
        {
            return "NPI-Q";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

