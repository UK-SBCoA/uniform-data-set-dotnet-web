using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms.FollowUp
{
    public class A2FollowUpFormFields : A2FormFields
    {
        public int? NEWINF { get; set; }

        public A2FollowUpFormFields() : base() { }
        public A2FollowUpFormFields(FormDto dto) : base(dto)
        {
            if (dto is A2Dto)
            {
                var a2Dto = ((A2Dto)dto);
                this.NEWINF = a2Dto.NEWINF == true ? 1 : a2Dto.NEWINF == false ? 0 : (int?)null;
            }
        }
    }
}

