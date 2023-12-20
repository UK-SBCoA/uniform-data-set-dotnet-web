using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IParticipationService : IService<Participation>
    {
        Task<Milestone> AddMilestone(string name, int participationId, Milestone milestone);
        Task<Milestone> UpdateMilestone(int id, int milestoneId, Milestone milestone);
        Task<ParticipationDto> GetByLegacyId(string legacyId);
        Task<IEnumerable<Milestone>> GetMilestonesByParticipationId(int participationId);
    }
}

