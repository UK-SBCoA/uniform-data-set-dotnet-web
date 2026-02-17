using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDS.Net.API.Client;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
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

        public async Task<IEnumerable<Milestone>> FindByLegacyId(string username, string legacyId, string[] statuses)
        {
            var dtos = await _apiClient.MilestoneClient
                .GetMilestonesByLegacyIdAndStatus(legacyId, statuses);

            return dtos.ToDomain();
        }

        public Task<Milestone> GetByIdAsync(string username, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Milestone> GetMostRecentSubmission(string username)
        {
            var milestoneDtos = await _apiClient.MilestoneClient.Get(1000, 1);

            var milestones = milestoneDtos.ToDomain();

            var milestoneWithLatestSubmission = milestones
                .Where(m => m.M1Submissions != null && m.M1Submissions.Any())
                .Select(m => new
                {
                    Milestone = m,
                    LatestSubmission = m.M1Submissions
                        .OrderByDescending(s => s.SubmissionDate)
                        .First()
                })
                .OrderByDescending(x => x.LatestSubmission.SubmissionDate)
                .FirstOrDefault();

            return milestoneWithLatestSubmission?.Milestone;
        }

        public async Task<M1Submission> CreateSubmissionAsync(string username, int milestoneId)
        {
            var milestone = await GetById(username, milestoneId);

            if (milestone == null)
                throw new Exception("Milestone not found.");

            string adrcId = milestone.Id.ToString();
            var now = DateTime.UtcNow;

            var submission = new M1Submission(
                id: 0,
                adrcId: adrcId,
                submissionDate: now,
                m1Id: milestone.Id,
                createdAt: now,
                createdBy: username,
                modifiedBy: "",
                deletedBy: "",
                isDeleted: false,
                errorCount: 0
            );

            milestone.M1Submissions ??= new List<M1Submission>();
            milestone.M1Submissions.Add(submission);

            await Update(username, milestone);

            return submission;
        }

        Task IMilestoneService.CreateSubmissionAsync(string username, int milestoneId)
        {
            return CreateSubmissionAsync(username, milestoneId);
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

