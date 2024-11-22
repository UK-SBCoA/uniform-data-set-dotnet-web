﻿using System;
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
            var dto = await _apiClient.VisitClient.Post(entity.ToDto());

            return dto.ToDomain(username);
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
            var visitDtos = await _apiClient.VisitClient.Get(pageSize, pageIndex);

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
    }
}

