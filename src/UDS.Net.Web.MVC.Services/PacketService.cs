using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.API.Client;
using UDS.Net.Services;
using UDS.Net.Services.Extensions;
using UDS.Net.Services.DomainModels.Submission;
using Microsoft.Extensions.Configuration;
using System.Linq;
using UDS.Net.Services.Enums;

namespace UDS.Net.Web.MVC.Services
{
    public class PacketService : IPacketService
    {
        private readonly IApiClient _apiClient;
        private readonly IConfiguration _configuration;

        public PacketService(IApiClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
        }

        public async Task<Packet> Add(string username, Packet entity)
        {
            await _apiClient.PacketClient.Post(entity.ToDto());

            return entity;
        }

        public async Task<int> Count(string username)
        {
            return await _apiClient.PacketClient.Count();
        }

        public async Task<int> Count(string username, List<PacketStatus> statuses)
        {
            string[] stringStatuses = statuses.Select(s => s.ToString()).ToArray();

            return await _apiClient.PacketClient.CountByStatusAndAssignee(stringStatuses, "");
        }

        public async Task<Packet> GetById(string username, int id)
        {
            var packetDto = await _apiClient.PacketClient.Get(id);

            var adrcId = _configuration.GetSection("ADRC:Id");

            if (packetDto != null)
                return packetDto.ToDomain(username);

            throw new Exception("Packet not found");
        }

        public async Task<Packet> GetPacketWithForms(string username, int id)
        {
            var packetSubmissionDto = await _apiClient.PacketClient.GetPacketWithForms(id);

            var adrcId = _configuration.GetSection("ADRC:Id");

            if (packetSubmissionDto != null)
                return packetSubmissionDto.ToDomain(adrcId.Value);

            throw new Exception("Packet not found");
        }

        public async Task<IEnumerable<Packet>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            List<Packet> packets = new List<Packet>();

            var dto = await _apiClient.PacketClient.Get(pageSize, pageIndex);

            if (dto != null)
                packets = dto.Select(p => p.ToDomain(username)).ToList();

            return packets;
        }

        public async Task<List<Packet>> List(string username, List<PacketStatus> statuses, int pageSize = 10, int pageIndex = 1)
        {
            List<Packet> packets = new List<Packet>();

            string[] stringStatuses = statuses.Select(s => s.ToString()).ToArray();

            var dto = await _apiClient.PacketClient.GetPacketsByStatusAndAssignee(stringStatuses, "", pageSize, pageIndex);

            if (dto != null)
                packets = dto.Select(p => p.ToDomain(username)).ToList();

            return packets;
        }

        public Task<Packet> Patch(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Packet> Update(string username, Packet entity)
        {
            await _apiClient.PacketClient.Put(entity.Id, entity.ToDto());

            var packetDto = await _apiClient.PacketClient.Get(entity.Id);

            var adrcId = _configuration.GetSection("ADRC:Id");

            if (packetDto != null)
                return packetDto.ToDomain(username);

            throw new Exception("Packet not found");
        }

        public async Task<Packet> UpdatePacketSubmissionErrorCount(string username, Packet packetToEdit, int errorCount, int packetSubmissionId)
        {
            PacketSubmission submissionToEdit = packetToEdit.Submissions.Where(p => p.Id == packetSubmissionId).FirstOrDefault();

            if (submissionToEdit == null)
                throw new Exception("Packet submission not found");

            // get index of packet submission to edit
            int submissionEditIndex = packetToEdit.Submissions.IndexOf(submissionToEdit);

            packetToEdit.Submissions[submissionEditIndex].ErrorCount = errorCount;

            return await Update(username, packetToEdit);
        }
    }
}

