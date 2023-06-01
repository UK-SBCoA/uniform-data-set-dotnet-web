using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B4FormFields : IFormFields
    {
        public int? MEMORY { get; set; }
        public int? ORIENT { get; set; }
        public int? JUDGMENT { get; set; }
        public int? COMMUN { get; set; }
        public int? HOMEHOBB { get; set; }
        public int? PERSCARE { get; set; }
        public int? CDRSUM { get; set; }
        public int? CDRGLOB { get; set; }
        public int? COMPORT { get; set; }
        public int? CDRLANG { get; set; }

        public B4FormFields()
        {
        }
        public B4FormFields(FormDto dto)
        {
            if (dto is B4Dto)
            {
                var b4Dto = ((B4Dto)dto);

                MEMORY = b4Dto.MEMORY;
                ORIENT = b4Dto.ORIENT;
                JUDGMENT = b4Dto.JUDGMENT;
                COMMUN = b4Dto.COMMUN;
                HOMEHOBB = b4Dto.HOMEHOBB;
                PERSCARE = b4Dto.PERSCARE;
                CDRSUM = b4Dto.CDRSUM;
                CDRGLOB = b4Dto.CDRGLOB;
                COMPORT = b4Dto.COMPORT;
                CDRLANG = b4Dto.CDRLANG;
            }
        }
        public string GetDescription()
        {
            return "CDR Plus NACC FTLD";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

