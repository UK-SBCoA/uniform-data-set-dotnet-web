using System;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IVisitService : IService<Visit>
    {
        Task<Visit> GetByIdWithForm(string username, int id, string formId);

        Task<Visit> GetByIdWithSubmissions(string username, int id, int pageSize = 10, int pageIndex = 1);

        Task<Visit> UpdateForm(string username, Visit entity, string formId);
    }
}

