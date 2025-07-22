using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Tests.Services
{
    public class VisitService : IVisitService
    {
        public List<Visit> Visits { get; set; } = new List<Visit>();

        public VisitService()
        {
            Visits = GetSeedingVisits();
        }

        public Task<Visit> Add(string username, Visit entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Visit> GetById(string username, int id)
        {
            throw new NotImplementedException();
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
            return Visits;
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

        public static List<Visit> GetSeedingVisits()
        {
            return new List<Visit>()
            {
                new Visit(1, 1, 1,"4", Net.Services.Enums.PacketKind.I, DateTime.Now, "TST", Net.Services.Enums.PacketStatus.Pending, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"4", Net.Services.Enums.PacketKind.I, DateTime.Now, "TST", Net.Services.Enums.PacketStatus.Pending, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"4", Net.Services.Enums.PacketKind.I, DateTime.Now, "TST", Net.Services.Enums.PacketStatus.Pending, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"4", Net.Services.Enums.PacketKind.I, DateTime.Now, "TST", Net.Services.Enums.PacketStatus.Pending, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"4", Net.Services.Enums.PacketKind.I, DateTime.Now, "TST", Net.Services.Enums.PacketStatus.Pending, DateTime.Now, "email@uky.edu", "", "", false, null)
            };
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
            return Visits;
        }

        public async Task<int> CountByStatus(string username, string[] statuses = null)
        {
            return 5;
        }

        public Task<string> GetNextFormKind(string username, int visitId, string currentFormKind)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFormOrder(string username, int visitId)
        {
            throw new NotImplementedException();
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

