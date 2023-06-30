using System;
using UDS.Net.Dto;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4DFormFields : IFormFields
    {
        public int Id { get; set; }

        public string DRUGID { get; set; }

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
            if (dto is A4DDto)
            {
                var a4DDto = (A4DDto)dto;

                this.DRUGID = a4DDto.DRUGID;
                this.Id = a4DDto.Id;
                this.CreatedAt = a4DDto.CreatedAt;
                this.CreatedBy = a4DDto.CreatedBy;
                this.ModifiedBy = a4DDto.ModifiedBy;
                this.DeletedBy = a4DDto.DeletedBy;
                this.IsDeleted = a4DDto.IsDeleted;

                if (a4DDto.DrugCodeLookup != null)
                {
                    this.DrugCode = new DrugCode
                    {
                        DrugId = a4DDto.DrugCodeLookup.DrugId,
                        DrugName = a4DDto.DrugCodeLookup.DrugName,
                        BrandName = a4DDto.DrugCodeLookup.BrandName,
                        IsOverTheCounter = a4DDto.DrugCodeLookup.IsOverTheCounter,
                        IsPopular = a4DDto.DrugCodeLookup.IsPopular
                    };
                }
            }
        }
    }
}

