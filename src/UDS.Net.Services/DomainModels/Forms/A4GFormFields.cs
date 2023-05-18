using System;
using System.Collections.Generic;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4GFormFields : IFormFields
    {
        public int? ANYMEDS { get; set; }

        public List<A4DFormFields> A4Ds { get; set; } = new List<A4DFormFields>();

        public string GetDescription()
        {
            return "Participant medications";
        }

        public string GetVersion()
        {
            return "3.0";
        }

        public A4GFormFields(FormDto dto)
        {
            if (dto is A4GDto)
            {
                var a4GDto = (A4GDto)dto;

                this.ANYMEDS = a4GDto.ANYMEDS;

                foreach (var a4DDto in a4GDto.A4Dtos)
                {
                    A4Ds.Add(new A4DFormFields(a4DDto));
                }
            }
        }
    }
}

