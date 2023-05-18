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
            return entity;
            // TODO Add participation
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

        public async Task<IEnumerable<Participation>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            var participationDtos = await _apiClient.ParticipationClient.Get();

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

