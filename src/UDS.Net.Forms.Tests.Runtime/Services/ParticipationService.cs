using System;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class ParticipationService : IParticipationService
    {
        public ParticipationService()
        {
        }

        public Task<Participation> Add(string username, Participation entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Participation> GetById(string username, int id, bool includeVisits = false)
        {
            throw new NotImplementedException();
        }

        public Task<Participation> GetById(string username, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Participation> GetByLegacyId(string username, string legacyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participation>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Participation> Patch(string username, Participation entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Participation entity)
        {
            throw new NotImplementedException();
        }

        public Task<Participation> Update(string username, Participation entity)
        {
            throw new NotImplementedException();
        }
    }
}

