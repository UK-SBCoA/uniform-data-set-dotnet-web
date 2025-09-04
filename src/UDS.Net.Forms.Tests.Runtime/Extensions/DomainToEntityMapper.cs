using System;
using UDS.Net.API.Extensions;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Extensions;

namespace UDS.Net.Forms.Tests.Runtime.Extensions
{
    public static class DomainToEntityMapper
    {
        public static void UpdateFromDomain(this UDS.Net.API.Entities.C2 existing, string formKind, UDS.Net.Services.DomainModels.Visit visit)
        {
            // formId should = C2 here
            var form = visit.Forms.Where(f => f.Kind == formKind).FirstOrDefault();

            var formDto = form.ToDto(formKind);

            // domain to dto
            var dto = (C2Dto)formDto;

            // this will update the entity with the updated properties
            existing.Update(dto);
        }

        public static void UpdateFromDomain(this UDS.Net.API.Entities.D1a existing, string formKind, UDS.Net.Services.DomainModels.Visit visit)
        {
            var form = visit.Forms.Where(f => f.Kind == formKind).FirstOrDefault();

            var formDto = form.ToDto(formKind);

            var dto = (D1aDto)formDto;

            existing.Update(dto);
        }
    }
}

