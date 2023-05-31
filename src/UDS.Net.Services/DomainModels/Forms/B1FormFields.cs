using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B1FormFields : IFormFields
    {
        public int? HEIGHT { get; set; }
        public int? WEIGHT { get; set; }
        public int? BPSYS { get; set; }
        public int? BPDIAS { get; set; }
        public int? HRATE { get; set; }
        public int? VISION { get; set; }
        public int? VISCORR { get; set; }
        public int? VISWCORR { get; set; }
        public int? HEARING { get; set; }
        public int? HEARAID { get; set; }
        public int? HEARWAID { get; set; }

        public B1FormFields() { }
        public B1FormFields(FormDto dto)
        {
            if (dto is B1Dto)
            {
                var b1Dto = ((B1Dto)dto);
            }
        }

        public string GetDescription()
        {
            return "Evaluation Form - Physical";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

