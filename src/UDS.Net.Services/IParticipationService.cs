﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IParticipationService : IService<Participation>
    {
        Task<ParticipationDto> GetByLegacyId(string legacyId);
        Task<IEnumerable<Milestone>> GetMilestonesByParticipationId(int participationId);
    }
}

