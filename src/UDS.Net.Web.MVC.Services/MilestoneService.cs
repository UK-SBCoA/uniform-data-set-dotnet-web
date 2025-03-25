using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.API.Client;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.Extensions;

namespace UDS.Net.Web.MVC.Services
{
    public class MilestoneService : IMilestoneService
    {
        private readonly IApiClient _apiClient;

        public MilestoneService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // Previously AddMilestone
        public async Task<Milestone> Add(string username, Milestone entity)
        {
            await _apiClient.MilestoneClient.Post(entity.ToDto());

            return entity;
        }

        public async Task<int> Count(string username)
        {
            return await _apiClient.MilestoneClient.Count();
        }

        // Previously GetMilestoneById(int id, int formId)
        public async Task<Milestone> GetById(string username, int id)
        {
            M1Dto milestone = await _apiClient.MilestoneClient.Get(id);

            return milestone.ToDomain();
        }

        public async Task<IEnumerable<Milestone>> Find(string username, int participationId, int pageSize = 10, int pageIndex = 1)
        {
            IEnumerable<M1Dto> milestones = await _apiClient.MilestoneClient.GetMilestonesByParticipation(participationId, pageSize, pageIndex);

            return milestones.ToDomain();
        }

        public async Task<IEnumerable<Milestone>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            IEnumerable<M1Dto> milestones = await _apiClient.MilestoneClient.Get(pageSize, pageIndex);

            return milestones.ToDomain();
        }

        public Task<Milestone> Patch(string username, Milestone entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Milestone entity)
        {
            throw new NotImplementedException();
        }

        // Previously UpdateMilestone(int id, int formId, Milestone milestone)
        public async Task<Milestone> Update(string username, Milestone entity)
        {
            await _apiClient.MilestoneClient.Put(entity.Id, entity.ToDto());

            return entity;
        }
    }
}

