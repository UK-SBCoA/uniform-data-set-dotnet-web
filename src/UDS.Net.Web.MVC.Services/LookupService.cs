#define CODE_NOT_IMPLEMENTED
using System;
using UDS.Net.API.Client;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.Extensions;
using UDS.Net.Services.DomainModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Web.MVC.Services
{
    public class LookupService : ILookupService
    {
        private readonly IApiClient _apiClient;

        public LookupService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<DrugCodeLookup> LookupDrugCodes(int pageSize = 10, int pageIndex = 1)
        {
            var dto = await _apiClient.LookupClient.LookupDrugCodes(pageSize, pageIndex);

            return new DrugCodeLookup
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalResultsCount = dto.TotalResultsCount,
                DrugCodes = dto.Results.Select(r => new DrugCode
                {
                    RxNormId = r.RxNormId.ToString(),
                    DrugName = r.DrugName,
                    BrandName = r.BrandName,
                    IsPopular = r.IsPopular,
                    IsOverTheCounter = r.IsOverTheCounter
                }).ToList()
            };
        }

        public async Task<DrugCodeLookup> SearchDrugCodes(int pageSize = 10, int pageIndex = 1, bool onlyPopular = true, string searchTerm = "")
        {
            var dto = await _apiClient.LookupClient.SearchDrugCodes(pageSize, pageSize, onlyPopular, searchTerm);

            return new DrugCodeLookup
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalResultsCount = dto.TotalResultsCount,
                DrugCodes = dto.Results.Select(r => new DrugCode
                {
                    RxNormId = r.RxNormId.ToString(),
                    DrugName = r.DrugName,
                    BrandName = r.BrandName,
                    IsPopular = r.IsPopular,
                    IsOverTheCounter = r.IsOverTheCounter
                }).ToList()
            };
        }

        [Obsolete]
        public Task<DrugCodeLookup> Add(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public Task<DrugCodeLookup> GetById(string username, int id)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public Task<IEnumerable<DrugCodeLookup>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public Task<DrugCodeLookup> Patch(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public Task Remove(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public Task<DrugCodeLookup> Update(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }
    }
}

