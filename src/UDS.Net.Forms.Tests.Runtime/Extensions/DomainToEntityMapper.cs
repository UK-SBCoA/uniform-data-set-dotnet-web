using System;
using UDS.Net.API.Extensions;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Extensions;

namespace UDS.Net.Forms.Tests.Runtime.Extensions
{
    public static class DomainToEntityMapper
    {
        public static UDS.Net.API.Entities.C2 UpdateEntityFromDomain(this UDS.Net.Services.DomainModels.Visit visit, string formId, UDS.Net.API.Entities.C2 existing)
        {
            // formId should = C2 here
            var form = visit.Forms.Where(f => f.Kind == formId).FirstOrDefault();

            var formDto = form.ToDto("C2");

            // domain to dto
            var dto = (C2Dto)formDto;

            // this will update the entity with the updated properties
            existing.Update(dto);

            return existing;
        }
    }
}

