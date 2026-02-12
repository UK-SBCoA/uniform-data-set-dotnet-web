using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class MilestoneService : IMilestoneService
    {
        public MilestoneService()
        {
        }

        public Task<Milestone> Add(string username, Milestone entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Milestone>> Find(string username, int participationId, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Milestone> GetByIdAsync(string name, int id)
        {
            throw new NotImplementedException();
        }
        public Task<Milestone> GetById(string username, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Milestone>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Milestone> Patch(string username, Milestone entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Milestone entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Milestone>> FindByLegacyId(string username, string legacyId, string[] statuses)
        {
            throw new NotImplementedException();
        }

        Task<Milestone> IMilestoneService.GetMostRecentSubmission(string username)
        {
            throw new NotImplementedException();
        }
    }
}

