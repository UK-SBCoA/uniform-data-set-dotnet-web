using System;
using UDS.Net.Dto;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4DFormFields : IFormFields
    {
        public int Id { get; set; }

        public string RxNormId { get; set; }

        public DrugCode? DrugCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public string GetDescription()
        {
            return "Medication";
        }

        public string GetVersion()
        {
            return "3.0";
        }

        public A4DFormFields() { }
        public A4DFormFields(FormDto dto) : this()
        {
            // TODO map rxnormids
        }
    }
}

