using System;
using System.Net;
using System.Text.Json;
using UDS.Net.API.Client;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.Extensions;
using UDS.Net.Services.DomainModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
            // TODO Add visit using client
            //entity.ToDto();
            //_apiClient.VisitClient.Post()
            return entity;
        }

        public async Task<int> Count(string username)
        {
            return await _apiClient.VisitClient.Count();
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
            var visitDtos = await _apiClient.VisitClient.Get();

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

        public async Task<Visit> Update(string username, Visit entity)
        {
            var dto = entity.ToDto();

            await _apiClient.VisitClient.Put(entity.Id, dto);

            var updatedDto = await _apiClient.VisitClient.Get(entity.Id);

            return updatedDto.ToDomain(username);
        }
    }
}

