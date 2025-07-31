using System;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class PacketService : IPacketService
    {
        public PacketService()
        {
        }

        public Task<Packet> Add(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(string username, List<PacketStatus> statuses)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> GetById(string username, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> GetPacketWithForms(string username, int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Packet>> List(string username, List<PacketStatus> statuses, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Packet>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> Patch(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> Update(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> UpdatePacketSubmissionErrors(string username, Packet packetToEdit, int packetSubmissionId, List<PacketSubmissionError> errors)
        {
            throw new NotImplementedException();
        }
    }
}

