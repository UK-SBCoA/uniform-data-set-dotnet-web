using System;
using UDS.Net.Dto;
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
                new Visit(1, 1, 1,"UDS3", "IVP", DateTime.Now, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"UDS3", "IVP", DateTime.Now, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"UDS3", "IVP", DateTime.Now, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"UDS3", "IVP", DateTime.Now, DateTime.Now, "email@uky.edu", "", "", false, null),
                new Visit(1, 1, 1,"UDS3", "IVP", DateTime.Now, DateTime.Now, "email@uky.edu", "", "", false, null)
            };
        }

    }
}

