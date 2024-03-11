using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B1FormFields : IFormFields
    {
        public double? HEIGHT { get; set; }
        public int? WEIGHT { get; set; }
        public int? WAIST1 { get; set; }
        public int? WAIST2 { get; set; }
        public int? HIP1 { get; set; }
        public int? HIP2 { get; set; }
        public int? BPSYSL1 { get; set; }
        public int? BPDIASL1 { get; set; }
        public int? BPSYSL2 { get; set; }
        public int? BPDIASL2 { get; set; }
        public int? BPSYSR1 { get; set; }
        public int? BPDIASR1 { get; set; }
        public int? BPSYSR2 { get; set; }
        public int? BPDIASR2 { get; set; }
        public int? HRATE { get; set; }

        public B1FormFields() { }
        public B1FormFields(FormDto dto)
        {
            if (dto is B1Dto)
            {
                var b1Dto = ((B1Dto)dto);

                HEIGHT = b1Dto.HEIGHT;
                WEIGHT = b1Dto.WEIGHT;
                WAIST1 = b1Dto.WAIST1;
                WAIST2 = b1Dto.WAIST2;
                HIP1 = b1Dto.HIP1;
                HIP2 = b1Dto.HIP2;
                BPSYSL1 = b1Dto.BPSYSL1;
                BPDIASL1 = b1Dto.BPDIASL1;
                BPSYSL2 = b1Dto.BPSYSL2;
                BPDIASL2 = b1Dto.BPDIASL2;
                BPSYSR1 = b1Dto.BPSYSR1;
                BPDIASR1 = b1Dto.BPDIASR1;
                BPSYSR2 = b1Dto.BPSYSR2;
                BPDIASR2 = b1Dto.BPDIASR2;
                HRATE = b1Dto.HRATE;
                // TODO map new fields
            }
        }

        public string GetDescription()
        {
            return "Evaluation Form - Physical";
        }

        public string GetVersion()
        {
            return "4.0";
        }
    }
}

