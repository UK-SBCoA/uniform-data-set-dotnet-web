﻿using System;
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
            return "4.0";
        }

        public A4GFormFields() { }
        public A4GFormFields(FormDto dto) : this()
        {
            if (dto is A4Dto)
            {
                var a4GDto = (A4Dto)dto;

                this.ANYMEDS = a4GDto.ANYMEDS;

                if ((a4GDto.A4DetailsDtos != null && a4GDto.A4DetailsDtos.Count > 0))
                {
                    foreach (var details in a4GDto.A4DetailsDtos)
                    {
                        this.A4Ds.Add(new A4DFormFields()
                        {
                            RxNormId = details.ToString()
                        });
                    }
                }
            }
        }
    }
}

