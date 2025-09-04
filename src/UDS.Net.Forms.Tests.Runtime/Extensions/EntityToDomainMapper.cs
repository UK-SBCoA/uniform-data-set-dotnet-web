using System;
using UDS.Net.API.Extensions;
using UDS.Net.Services.Extensions;

namespace UDS.Net.Forms.Tests.Runtime.Extensions
{
    public static class EntityToDomainMapper
    {
        public static UDS.Net.Services.DomainModels.Form Convert(this UDS.Net.API.Entities.C2 entity, int visitId, string username)
        {
            var dto = entity.ToFullDto();

            var c2 = dto.ToDomain(visitId, username);

            return c2;
        }

        public static UDS.Net.Services.DomainModels.Form Convert(this UDS.Net.API.Entities.D1a entity, int visitId, string username)
        {
            var dto = entity.ToFullDto();

            var d1a = dto.ToDomain(visitId, username);

            return d1a;
        }
    }
}

