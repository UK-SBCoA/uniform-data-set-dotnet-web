using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4DFormFields : IFormFields
    {
        public string RxNormId { get; set; }

        public DrugCode? DrugCode { get; set; } // Leave the option to return the full drug information from the data source

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
            return "Medication";
        }

        public string GetVersion()
        {
            return "4";
        }

        public A4DFormFields() { }
        public A4DFormFields(FormDto dto) : this()
        {
            // TODO map rxnormids
        }
    }
}

