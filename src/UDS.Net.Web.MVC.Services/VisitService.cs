using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDS.Net.API.Client;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.Enums;
using UDS.Net.Services.Extensions;

namespace UDS.Net.Web.MVC.Services
{
    /// <summary>
    /// This service uses this API client and maps to domain model used in
    /// the component librar
    /// </summary>
    public class VisitService : IVisitService
    {
        private readonly IApiClient _apiClient;

        public VisitService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Visit> Add(string username, Visit entity)
        {
            var dto = await _apiClient.VisitClient.Post(entity.ToDto());

            return dto.ToDomain(username);
        }

        public async Task<int> Count(string username)
        {
            return await _apiClient.VisitClient.Count();
        }

        public async Task<int> CountByStatus(string username, string[] statuses = null)
        {
            return await _apiClient.VisitClient.GetCountOfVisitsAtStatus(statuses);
        }

        public async Task<int> CountByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate)
        {
            return await _apiClient.VisitClient.GetCountOfVisitsAtDateRangeAndStatus(statuses, startDate, endDate);
        }

        public async Task<Visit> GetById(string username, int id)
        {
            var visitDto = await _apiClient.VisitClient.Get(id);

            if (visitDto != null)
            {
                return visitDto.ToDomain(username);
            }
            throw new Exception("Visit not found");
        }

        public async Task<Visit> GetByIdWithForm(string username, int id, string formId)
        {
            var visitDto = await _apiClient.VisitClient.GetWithForm(id, formId);

            if (visitDto != null)
            {
                return visitDto.ToDomain(username); // converting to domain object implements business rules for shown forms
            }

            throw new Exception("Visit with form not found");
        }

        public async Task<IEnumerable<Visit>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            var visitDtos = await _apiClient.VisitClient.Get(pageSize, pageIndex);

            if (visitDtos != null)
            {
                return visitDtos.Select(d => d.ToDomain(username)).ToList();
            }

            return new List<Visit>();
        }

        public async Task<IEnumerable<Visit>> ListByStatus(string username, int pageSize = 10, int pageIndex = 1, string[] filterItems = null)
        {
            if (filterItems != null)
            {
                var visitDtos = await _apiClient.VisitClient.GetVisitsAtStatus(filterItems, pageSize, pageIndex);

                if (visitDtos != null)
                {
                    return visitDtos.Select(d => d.ToDomain(username)).ToList();
                }
            }

            return new List<Visit>();
        }

        public async Task<List<Visit>> ListByDateRangeAndStatus(string username, string[] statuses, DateTime? startDate, DateTime? endDate, int pageSize = 10, int pageIndex = 1)
        {
            var visitDtos = await _apiClient.VisitClient.GetVisitsAtDateRangeAndStatus(statuses, startDate, endDate, pageSize, pageIndex);

            if (visitDtos != null)
            {
                return visitDtos.Select(d => d.ToDomain(username)).ToList();
            }

            return new List<Visit>();
        }

        public async Task<Visit> Patch(string username, Visit entity)
        {
            // TODO update visit
            return entity;
        }

        public async Task Remove(string username, Visit entity)
        {
        }

        private async Task<Visit> UpdateVisit(string username, VisitDto dto)
        {
            if (dto.IsDeleted)
            {
                dto.DeletedBy = username;
            }
            else
                dto.ModifiedBy = username;

            await _apiClient.VisitClient.Put(dto.Id, dto);

            var updatedDto = await _apiClient.VisitClient.Get(dto.Id);

            return updatedDto.ToDomain(username);
        }

        public async Task<Visit> Update(string username, Visit entity)
        {
            var dto = entity.ToDto();
            return await UpdateVisit(username, dto);
        }

        public async Task<Visit> UpdateForm(string username, Visit entity, string formId)
        {
            var dto = entity.ToDto(formId);
            return await UpdateVisit(username, dto);
        }

        public async Task<int> GetNextVisitNumber(string username, int participationId)
        {
            var participation = await _apiClient.ParticipationClient.Get(participationId);

            return participation.LastVisitNumber + 1;
        }

        public async Task<int> GetVisitCountByVersion(string username, int participationId, string version)
        {
            if (version.Contains("4"))
            {
                var participation = await _apiClient.ParticipationClient.Get(participationId);

                return participation.VisitCount;
            }
            else
                throw new NotImplementedException("The developer must update with functionality to support pre-UDS version 4.");
        }

        public async Task<string> GetNextFormKind(string username, int visitId, string currentFormKind)
        {
            var ordering = await GetFormOrder(username, visitId);

            string nextFormId = "";

            for (int i = 0; i < ordering.Count(); i++)
            {
                if (ordering[i] == currentFormKind)
                {
                    // check if there is a next form
                    if (i + 1 < ordering.Count())
                    {
                        nextFormId = ordering[i + 1];
                        break;
                    }
                }

            }

            return nextFormId;
        }

        public async Task<List<string>> GetFormOrder(string username, int visitId)
        {
            // In this implementation we are sorting by kind alphabetically, but other organizations may want the flexibilty to order forms by another parameter.
            var visit = await GetById(username, visitId);
            return visit.Forms.OrderBy(f => f.Kind).Select(f => f.Kind).ToList();
        }

        public async Task<Visit> PatchStatus(string username, Visit entity)
        {
            if (entity == null)
                return null;

            var dto = await _apiClient.VisitClient.Put(entity.Id, entity.ToDto());

            return dto.ToDomain(username);
        }
    }
}

