using System;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    // Mock participations, we don't really need true persistence for these tests
    public class ParticipationService : IParticipationService
    {
        public ParticipationService()
        {
        }

        public async Task<Participation> Add(string username, Participation entity)
        {
            return new Participation
            {
                Id = 1,
                LegacyId = "1000",
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                IsDeleted = false,
                Status = "Enrolled",
                VisitCount = 0
            };
        }

        public async Task<int> Count(string username)
        {
            return 1;
        }

        public async Task<Participation> GetById(string username, int id, bool includeVisits = false)
        {
            return new Participation
            {
                Id = 1,
                LegacyId = "1000",
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                IsDeleted = false,
                Status = "Enrolled",
                VisitCount = 0
            };
        }

        public async Task<Participation> GetById(string username, int id)
        {
            return new Participation
            {
                Id = 1,
                LegacyId = "1000",
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                IsDeleted = false,
                Status = "Enrolled",
                VisitCount = 0
            };
        }

        public async Task<Participation> GetByLegacyId(string username, string legacyId)
        {
            return new Participation
            {
                Id = 1,
                LegacyId = "1000",
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                IsDeleted = false,
                Status = "Enrolled",
                VisitCount = 0
            };
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

