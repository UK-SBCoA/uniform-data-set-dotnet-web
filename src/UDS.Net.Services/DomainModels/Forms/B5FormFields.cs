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
        public B5FormFields()
        {
        }
        public B5FormFields(FormDto dto)
        {
            if (dto is B5Dto)
            {
                var b5Dto = ((B5Dto)dto);
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

