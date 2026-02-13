using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.API.Entities;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IMilestoneService : IService<Milestone>
    {
        Task<IEnumerable<Milestone>> Find(string username, int participationId, int pageSize = 10, int pageIndex = 1);

        Task<IEnumerable<Milestone>> FindByLegacyId(string username, string legacyId, string[] statuses);

        Task<Milestone> GetByIdAsync(string name, int id);
        Task<Milestone> GetMostRecentSubmission(string username);
        Task CreateSubmissionAsync(string username, int milestoneId);
    }
}

