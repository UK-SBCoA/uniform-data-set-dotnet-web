using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IParticipationService : IService<Participation>
    {
        Task<Participation> GetByLegacyId(string username, string legacyId);
        Task<Participation> GetById(string username, int id, bool includeVisits = false);
    }
}

