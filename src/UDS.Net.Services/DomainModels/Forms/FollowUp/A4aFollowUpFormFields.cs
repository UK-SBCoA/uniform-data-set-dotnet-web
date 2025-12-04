using System;
using System.Collections.Generic;
using System.Reflection;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms.FollowUp
{
    public class A4aFollowUpFormFields : A4aFormFields
    {
        public int? NEWADEVENT { get; set; }
        public int? NEWTREAT { get; set; }

        public A4aFollowUpFormFields() : base()
        {
        }

        public A4aFollowUpFormFields(FormDto dto) : base(dto)
        {
            if (dto is A3Dto)
            {
                //NEWTREAT = dto.NEWTREAT;
                //NEWADEVENT = dto.NEWADEVENT;
            }
        }
    }
}
