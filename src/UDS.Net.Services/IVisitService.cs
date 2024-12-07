﻿using System;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IVisitService : IService<Visit>
    {
        Task<Visit> GetByIdWithForm(string username, int id, string formId);

        Task<Visit> UpdateForm(string username, Visit entity, string formId);

        Task<int> GetNextVisitNumber(string username, int participationId);

        Task<int> GetVisitCountByVersion(string username, int participationId, string version);
    }
}

