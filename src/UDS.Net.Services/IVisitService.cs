using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services
{
    public interface IVisitService : IService<Visit>
    {
        Task<Visit> GetByIdWithForm(string username, int id, string formId);

        Task<Visit> GetByVisitNumberWithForm(string username, int participationId, int visitNumber, string formKind);

        Task<Visit> UpdateForm(string username, Visit entity, string formId);

        Task<List<string>> GetFormOrder(string username, int visitId);

        Task<string> GetNextFormKind(string username, int visitId, string currentFormKind);

        Task<int> GetNextVisitNumber(string username, int participationId);

        Task<int> GetVisitCountByVersion(string username, int participationId, string version);

        Task<IEnumerable<Visit>> ListByStatus(string username, int pageSize = 10, int pageIndex = 1, string[] filterItems = null);

        Task<int> CountByStatus(string username, string[] statuses = null);

        Task<List<Visit>> ListByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate, int pageSize = 10, int pageIndex = 1);

        Task<int> CountByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate);

        /// <summary>
        /// Only updates the status on the visit
        /// </summary>
        /// <param name="username">User modifying the status</param>
        /// <param name="entity">Visit with the new status</param>
        /// <returns>Updated visit</returns>
        Task<Visit> PatchStatus(string username, Visit entity);
    }
}

