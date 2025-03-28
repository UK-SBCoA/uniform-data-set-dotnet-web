﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IMilestoneService : IService<Milestone>
    {
        Task<IEnumerable<Milestone>> Find(string username, int participationId, int pageSize = 10, int pageIndex = 1);
    }
}

