using System;
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
    public class ParticipationService : IParticipationService
    {
        private readonly IApiClient _apiClient;

        public ParticipationService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Participation> Add(string username, Participation entity)
        {
            var dto = await _apiClient.ParticipationClient.Post(entity.ToDto());

            return dto.ToDomain(username);
        }

        public async Task<int> Count(string username)
        {
            return await _apiClient.ParticipationClient.Count();
        }

        public async Task<Participation> GetById(string username, int id)
        {
            var participationDto = await _apiClient.ParticipationClient.Get(id);

            if (participationDto != null)
            {
                return participationDto.ToDomain(username);
            }
            throw new Exception("Participation not found.");
        }

        public async Task<Participation> GetByLegacyId(string username, string legacyId)
        {
            try
            {
                var participation = await _apiClient.ParticipationClient.GetByLegacyId(legacyId);

                return participation.ToDomain(username);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Participation> GetById(string username, int id, bool includeVisits = false)
        {
            if (includeVisits)
                return await GetById(username, id);

            var participationDto = await _apiClient.ParticipationClient.Get(id); // Other services can use includeVisits to determine whether the underlying service should include visits or not

            if (participationDto != null)
            {
                return participationDto.ToDomain(username);
            }
            throw new Exception("Participation not found.");
        }

        public async Task<IEnumerable<Participation>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            var participationDtos = await _apiClient.ParticipationClient.Get(pageSize, pageIndex);

            if (participationDtos != null)
            {
                return participationDtos.Select(p => p.ToDomain(username)).ToList();
            }

            return new List<Participation>();
        }

        public async Task<Participation> Patch(string username, Participation entity)
        {
            // TODO update participation
            return entity;
        }
        public async Task Remove(string username, Participation entity)
        {
        }
        public async Task<Participation> Update(string username, Participation entity)
        {
            // TODO update participation
            return entity;
        }
    }
}

