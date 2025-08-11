using Microsoft.EntityFrameworkCore;
using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Forms.Tests.Runtime.Extensions;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

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

        public async Task<Visit> GetByIdWithForm(string username, int id, string formId)
        {
            if (!String.IsNullOrWhiteSpace(formId))
            {
                var packet = await _context.Packets
                    .Include(v => v.C2)
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync();

                if (packet != null)
                {
                    List<Form> forms = new List<Form>();

                    // TODO add more forms here as tests are added
                    if (packet.C2 != null)
                    {
                        // get the dto then convert to domain with UDS.Net.Services.Extensions
                        var c2 = packet.C2.Convert(packet.Id, username);
                        forms.Add(c2);
                    }

                    var visit = new Visit(packet.Id, packet.VISITNUM, 1, packet.FORMVER, Net.Services.Enums.PacketKind.I, packet.VISIT_DATE, packet.INITIALS, Net.Services.Enums.PacketStatus.Pending, packet.CreatedAt, packet.CreatedBy, packet.ModifiedBy, packet.DeletedBy, packet.IsDeleted, forms);

                    return visit;
                }
            }

            return null;
        }

        public async Task<List<string>> GetFormOrder(string username, int visitId)
        {
            var packet = await GetById(username, visitId);
            return packet.Forms.OrderBy(f => f.Kind).Select(f => f.Kind).ToList();
        }

        public async Task<string> GetNextFormKind(string username, int visitId, string currentFormKind)
        {
            return "B1";
        }

        public Task<int> GetNextVisitNumber(string username, int participationId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetVisitCountByVersion(string username, int participationId, string version)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Visit>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            return new List<Visit>();
        }

        public async Task<IEnumerable<Visit>> ListByStatus(string username, int pageSize = 10, int pageIndex = 1, string[] statuses = null)
        {
            return new List<Visit>();
        }

        public async Task<int> CountByStatus(string username, string[] statuses = null)
        {
            return 1;
        }

        public Task<List<Visit>> ListByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }



        public Task<Visit> Patch(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> PatchStatus(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> Update(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Visit> UpdateForm(string username, Visit entity, string formId)
        {
            if (String.IsNullOrWhiteSpace(formId))
                return null;

            var packet = await _context.Packets.FindAsync(entity.Id);

            if (formId == "C2")
            {
                packet = await _context.Packets
                    .Include(p => p.C2)
                    .Where(p => p.Id == entity.Id)
                    .FirstOrDefaultAsync();

                var form = entity.Forms.Where(f => f.Kind == formId).FirstOrDefault();

                if (packet.C2 == null)
                {
                    // TODO if this is a new C2, then C2 in the db == null, so we need to instantiate it
                    packet.C2 = new API.Entities.C2
                    {
                        PacketId = packet.Id
                    };
                }
                var c2 = packet.C2;

                entity.UpdateEntityFromDomain(formId, c2);

                // c2 should be updated here
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public Task Remove(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

    }
}

