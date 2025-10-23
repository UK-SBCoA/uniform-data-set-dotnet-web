using Microsoft.EntityFrameworkCore;
using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Forms.Tests.Runtime.Extensions;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    // As tests are added, add more functionality in two methods here:
    //     1. GetByIdWithForm
    //     2. UpdateForm
    // Also will need to add conversions in EntityToDomainMapper and DomainToEntityMapper
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
                // TODO Include related forms as tests are added
                var packet = await _context.Packets
                    .Include(v => v.A3)
                    .Include(v => v.A4a)
                    .Include(v => v.C2)
                    .Include(v => v.D1a)
                    .Where(v => v.Id == id)
                    .FirstOrDefaultAsync();

                if (packet != null)
                {
                    List<Form> forms = new List<Form>();

                    // TODO add more forms here as tests are added
                    if (packet.A3 != null)
                    {
                        var a3 = packet.A3.Convert(packet.Id, username);
                        forms.Add(a3);
                    }
                    if (packet.A4a != null)
                    {
                        var a4a = packet.A4a.Convert(packet.Id, username);
                        forms.Add(a4a);
                    }
                    if (packet.C2 != null)
                    {
                        // get the dto then convert to domain with UDS.Net.Services.Extensions
                        var c2 = packet.C2.Convert(packet.Id, username);
                        forms.Add(c2);
                    }
                    if (packet.D1a != null)
                    {
                        var d1a = packet.D1a.Convert(packet.Id, username);
                        forms.Add(d1a);
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

        public async Task<int> GetNextVisitNumber(string username, int participationId)
        {
            var mostRecent = await _context.Packets
                .Where(p => p.ParticipationId == participationId)
                .OrderByDescending(p => p.VISITNUM)
                .FirstOrDefaultAsync();

            if (mostRecent != null)
                return mostRecent.VISITNUM;
            else
                return 0;

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

            // TODO Include related forms as tests are added
            var packet = await _context.Packets
                .Include(p => p.A3)
                .Include(p => p.C2)
                .Include(p => p.D1a)
                .Where(p => p.Id == entity.Id)
                .FirstOrDefaultAsync();

            var form = entity.Forms.Where(f => f.Kind == formId).FirstOrDefault();

            // TODO Add more as tests are added
            if (formId == "A3")
            {
                if (packet.A3 == null)
                {
                    packet.A3 = new API.Entities.A3
                    {
                        PacketId = packet.Id,
                        CreatedAt = packet.CreatedAt,
                        CreatedBy = packet.CreatedBy,
                        ModifiedBy = packet.ModifiedBy
                    };
                }
                if (packet.A3.SIB1 == null)
                    packet.A3.SIB1 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB2 == null)
                    packet.A3.SIB2 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB3 == null)
                    packet.A3.SIB3 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB4 == null)
                    packet.A3.SIB4 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB5 == null)
                    packet.A3.SIB5 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB6 == null)
                    packet.A3.SIB6 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB7 == null)
                    packet.A3.SIB7 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB8 == null)
                    packet.A3.SIB8 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB9 == null)
                    packet.A3.SIB9 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB10 == null)
                    packet.A3.SIB10 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB11 == null)
                    packet.A3.SIB11 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB12 == null)
                    packet.A3.SIB12 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB13 == null)
                    packet.A3.SIB13 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB14 == null)
                    packet.A3.SIB14 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB15 == null)
                    packet.A3.SIB15 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB16 == null)
                    packet.A3.SIB16 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB17 == null)
                    packet.A3.SIB17 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB18 == null)
                    packet.A3.SIB18 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB19 == null)
                    packet.A3.SIB19 = new API.Entities.A3FamilyMember();
                if (packet.A3.SIB20 == null)
                    packet.A3.SIB20 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID1 == null)
                    packet.A3.KID1 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID2 == null)
                    packet.A3.KID2 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID3 == null)
                    packet.A3.KID3 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID4 == null)
                    packet.A3.KID4 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID5 == null)
                    packet.A3.KID5 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID6 == null)
                    packet.A3.KID6 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID7 == null)
                    packet.A3.KID7 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID8 == null)
                    packet.A3.KID8 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID9 == null)
                    packet.A3.KID9 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID10 == null)
                    packet.A3.KID10 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID11 == null)
                    packet.A3.KID11 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID12 == null)
                    packet.A3.KID12 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID13 == null)
                    packet.A3.KID13 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID14 == null)
                    packet.A3.KID14 = new API.Entities.A3FamilyMember();
                if (packet.A3.KID15 == null)
                    packet.A3.KID15 = new API.Entities.A3FamilyMember();

                var a3 = packet.A3;

                a3.UpdateFromDomain(formId, entity);

                await _context.SaveChangesAsync();
            }

            if (formId == "C2")
            {
                if (packet.C2 == null)
                {
                    // TODO if this is a new C2, then C2 in the db == null, so we need to instantiate it
                    packet.C2 = new API.Entities.C2
                    {
                        PacketId = packet.Id,
                        CreatedAt = packet.CreatedAt,
                        CreatedBy = packet.CreatedBy,
                        ModifiedBy = packet.ModifiedBy
                    };
                }
                var c2 = packet.C2;

                c2.UpdateFromDomain(formId, entity);

                await _context.SaveChangesAsync();
            }

            if (formId == "D1a")
            {
                if (packet.D1a == null)
                {
                    packet.D1a = new API.Entities.D1a
                    {
                        PacketId = packet.Id,
                        CreatedAt = packet.CreatedAt,
                        CreatedBy = packet.CreatedBy,
                        ModifiedBy = packet.ModifiedBy
                    };
                }
                var d1a = packet.D1a;

                d1a.UpdateFromDomain(formId, entity);

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

