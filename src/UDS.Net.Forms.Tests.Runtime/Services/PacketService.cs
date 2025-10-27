using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UDS.Net.API.Extensions;
using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;
using UDS.Net.Services.Extensions;

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

        public async Task<int> Count(string username, List<PacketStatus> statuses)
        {
            var stringStatuses = statuses.Select(s => s.ToString()).ToList();

            var query = _context.Packets.AsQueryable();

            if (statuses != null && statuses.Any())
            {
                query = query.Where(p => stringStatuses.Contains(p.Status.ToString()));
            }

            return await query.CountAsync();
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

        public async Task<List<Packet>> List(string username, List<PacketStatus> statuses, int pageSize = 10, int pageIndex = 1)
        {
            var stringStatuses = statuses.Select(s => s.ToString()).ToList();

            var query = _context.Packets
                .Where(p => stringStatuses.Contains(p.Status.ToString()))
                .OrderBy(p => p.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            var entities = await query.ToListAsync();

            var count = await _context.Packets.CountAsync();

            var packets = entities.Select(p => p.ToPacketDto().ToDomain(username)).ToList();

            return packets;
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

