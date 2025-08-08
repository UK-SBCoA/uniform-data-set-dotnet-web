using Microsoft.EntityFrameworkCore;
using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class VisitService : IVisitService
    {
        private readonly TestDbContext _context;

        public VisitService(TestDbContext context)
        {
            _context = context;
        }

        public async Task<Visit> Add(string username, Visit entity)
        {
            var packet = new API.Entities.Packet
            {
                ParticipationId = 1,
                VISITNUM = entity.VISITNUM,
                FORMVER = entity.FORMVER,
                PACKET = "I",
                VISIT_DATE = entity.VISIT_DATE,
                INITIALS = entity.INITIALS,
                Status = API.Entities.PacketStatus.Pending,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy
            };

            _context.Packets.Add(packet);
            await _context.SaveChangesAsync();
            entity.Id = packet.Id;

            var count = await _context.Packets.CountAsync();

            return entity;
        }

        public async Task<int> Count(string username)
        {
            return await _context.Packets.CountAsync();
        }

        public async Task<Visit> GetById(string username, int id)
        {
            var count = await _context.Packets.CountAsync();
            var packet = await _context.Packets.FindAsync(id);

            if (packet == null)
            {
                return null;
            }
            return new Visit(packet.Id, packet.VISITNUM, 1, packet.FORMVER, Net.Services.Enums.PacketKind.I, packet.VISIT_DATE, packet.INITIALS, Net.Services.Enums.PacketStatus.Pending, packet.CreatedAt, packet.CreatedBy, packet.ModifiedBy, packet.DeletedBy, packet.IsDeleted, new List<Form>());
        }

        public Task<Visit> GetByIdWithSubmissions(string username, int id, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> GetByIdWithForm(string username, int id, string formId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Visit>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            return new List<Visit>();
        }

        public Task<Visit> Patch(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> Update(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> UpdateForm(string username, Visit entity, string formId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNextVisitNumber(string username, int participationId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetVisitCountByVersion(string username, int participationId, string version)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Visit>> ListByStatus(string username, int pageSize = 10, int pageIndex = 1, string[] statuses = null)
        {
            return new List<Visit>();
        }

        public async Task<int> CountByStatus(string username, string[] statuses = null)
        {
            return 1;
        }

        public Task<string> GetNextFormKind(string username, int visitId, string currentFormKind)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetFormOrder(string username, int visitId)
        {
            var packet = await GetById(username, visitId);
            return packet.Forms.OrderBy(f => f.Kind).Select(f => f.Kind).ToList();
        }

        public Task<Visit> PatchStatus(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Visit>> ListByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }
    }
}

