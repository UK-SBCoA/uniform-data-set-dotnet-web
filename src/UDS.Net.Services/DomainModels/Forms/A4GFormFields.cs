using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4GFormFields : IFormFields
    {
        public int? ANYMEDS { get; set; }

        public List<A4DFormFields> A4Ds { get; set; } = new List<A4DFormFields>();

        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.InPerson, FormMode.Remote };
            }
        }

        public IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes
        {
            get
            {
                return new List<NotIncludedReasonCode>() { };
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video };
            }
        }

        public IEnumerable<AdministrationFormat> AdministrationFormats
        {
            get
            {
                return new List<AdministrationFormat>() { };
            }
        }

        public string GetDescription()
        {
            return "Participant Medications";
        }

        public string GetVersion()
        {
            return "4";
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

