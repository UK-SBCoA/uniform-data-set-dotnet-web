using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.API.Client;
using UDS.Net.Services;
using UDS.Net.Services.Extensions;
using UDS.Net.Services.DomainModels.Submission;
using Microsoft.Extensions.Configuration;

namespace UDS.Net.Web.MVC.Services
{
    public class PacketSubmissionService : IPacketSubmissionService
    {
        private readonly IApiClient _apiClient;
        private readonly IConfiguration _configuration;

        public PacketSubmissionService(IApiClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
        }

        public async Task<PacketSubmission> Add(string username, PacketSubmission entity)
        {
            await _apiClient.PacketSubmissionClient.Post(entity.ToDto());

            return entity;
        }

        public async Task<int> Count(string username)
        {
            return await _apiClient.PacketSubmissionClient.Count();
        }

        public async Task<PacketSubmission> GetById(string username, int id)
        {
            var packetSubmissionDto = await _apiClient.PacketSubmissionClient.Get(id);

            var adrcId = _configuration.GetSection("ADRC:Id");

            if (packetSubmissionDto != null)
                return packetSubmissionDto.ToDomain(adrcId.Value);

            throw new Exception("Packet submission not found");
        }

        public async Task<PacketSubmission> GetPacketSubmissionWithForms(string username, int id)
        {
            var packetSubmissionDto = await _apiClient.PacketSubmissionClient.GetPacketSubmissionWithForms(id);

            var adrcId = _configuration.GetSection("ADRC:Id");

            if (packetSubmissionDto != null)
                return packetSubmissionDto.ToDomain(adrcId.Value);

            throw new Exception("Packet submission not found");
        }

        public async Task<IEnumerable<PacketSubmission>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            List<PacketSubmission> submissions = new List<PacketSubmission>();

            var dto = await _apiClient.PacketSubmissionClient.Get(pageSize, pageIndex);

            //if (dto != null)
            //    submissions = dto.ToDomain();

            return submissions;
        }

        public Task<PacketSubmission> Patch(string username, PacketSubmission entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, PacketSubmission entity)
        {
            throw new NotImplementedException();
        }

        public Task<PacketSubmission> Update(string username, PacketSubmission entity)
        {
            throw new NotImplementedException();
        }
    }
}

