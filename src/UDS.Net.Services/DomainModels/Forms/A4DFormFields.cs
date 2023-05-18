using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4DFormFields : IFormFields
    {
        public string DRUGID { get; set; }

        public string GetDescription()
        {
            return "Medication";
        }

        public string GetVersion()
        {
            return "3.0";
        }

        public A4DFormFields(FormDto dto)
        {
            if (dto is A4DDto)
            {
                var a4DDto = (A4DDto)dto;

                this.DRUGID = a4DDto.DRUGID;
            }
        }
    }
}

