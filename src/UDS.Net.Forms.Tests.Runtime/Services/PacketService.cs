using System;
using Microsoft.EntityFrameworkCore;
using UDS.Net.API.Extensions;
using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Services;
using UDS.Net.Services.Extensions;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class PacketService : IPacketService
    {
        private readonly TestDbContext _context;

        public PacketService(TestDbContext context)
        {
            _context = context;
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

        public async Task<Packet> GetById(string username, int id)
        {
            var count = await _context.Packets.CountAsync();
            var packet = await _context.Packets.FindAsync(id);

            if (packet == null)
            {
                return null;
            }

            var dto = packet.ToPacketDto();

            return dto.ToDomain(username);
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