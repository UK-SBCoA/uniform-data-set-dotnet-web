#define CODE_NOT_IMPLEMENTED
using System;
using UDS.Net.API.Client;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.Extensions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Services.LookupModels;
using rxNorm.Net.Api.Wrapper;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;

namespace UDS.Net.Web.MVC.Services
{
    public class LookupService : ILookupService
    {
        private readonly IApiClient _apiClient;
        private readonly IRxNormClient _rxNormClient;
        private readonly IMemoryCache _cache;

        public LookupService(IApiClient apiClient, IRxNormClient rxNormClient, IMemoryCache cache)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            _rxNormClient = rxNormClient ?? throw new ArgumentNullException(nameof(rxNormClient));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<DrugCodeLookup> LookupDrugCodes(int pageSize = 10, int pageIndex = 1, bool? includePopular = null, bool? includeOverTheCounter = null)
        {
            var dto = await _apiClient.LookupClient.LookupDrugCodes(pageSize, pageIndex, includePopular, includeOverTheCounter);

            return new DrugCodeLookup
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalResultsCount = dto.TotalResultsCount,
                DrugCodes = dto.Results.Select(r => r.ToDomain()).ToList()
            };
        }

        public async Task<DrugCodeLookup> SearchDrugCodes(int pageSize = 10, int pageIndex = 1, string searchTerm = "")
        {
            var dto = await _apiClient.LookupClient.SearchDrugCodes(pageSize, pageSize, searchTerm);

            return new DrugCodeLookup
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalResultsCount = dto.TotalResultsCount,
                DrugCodes = dto.Results.Select(r => r.ToDomain()).ToList()
            };
        }

        public async Task<DrugCodeLookup> FindDrugCode(string rxCUI)
        {
            if (!String.IsNullOrWhiteSpace(rxCUI))
            {
                var rxCUIs = new string[] { rxCUI };

                return await FindDrugCodes(rxCUIs);
            }

            return new DrugCodeLookup
            {
                PageSize = 1,
                PageIndex = 1,
                TotalResultsCount = 0,
                DrugCodes = new List<DrugCode>()
            };
        }

        public async Task<DrugCodeLookup> FindDrugCodes(string[] rxCUIs)
        {
            if (rxCUIs != null && rxCUIs.Count() > 0)
            {
                var search = new List<int>();
                foreach (var cui in rxCUIs)
                {
                    if (Int32.TryParse(cui, out int rxNormId))
                    {
                        search.Add(rxNormId);
                    }
                }

                var dto = await _apiClient.LookupClient.FindDrugCodes(search.ToArray());
                if (dto != null)
                {
                    if (dto.TotalResultsCount > 0 && dto.Results != null && dto.Results.Count() > 0)
                    {
                        return new DrugCodeLookup
                        {
                            PageSize = dto.TotalResultsCount,
                            PageIndex = 1,
                            TotalResultsCount = dto.TotalResultsCount,
                            DrugCodes = dto.Results.Select(d => d.ToDomain()).ToList()
                        };
                    }
                }
            }

            return new DrugCodeLookup
            {
                PageSize = 1,
                PageIndex = 1,
                TotalResultsCount = 0,
                DrugCodes = new List<DrugCode>()
            };
        }

        public async Task<DrugCode> AddDrugCodeToLookup(DrugCode newDrugCode)
        {
            var dto = newDrugCode.ToDto();

            var added = await _apiClient.LookupClient.AddDrugCode(dto);

            return added.ToDomain();
        }

        public async Task<LookupCountryCodeDto> LookupCountryCode(string countryCode)
        {
            var dto = await _apiClient.LookupClient.LookupCountryCode(countryCode);

            return new LookupCountryCodeDto
            {
                Id = dto.Id,
                Code = dto.Code,
                Country = dto.Country,
                IsActive = dto.IsActive,
                ReasonChangedCode = dto.ReasonChangedCode,
                Error = dto.Error
            };
        }

        public async Task<List<string>> LookupRxNormDisplayTerms(string searchTerm, int pageSize = 20, int pageIndex = 1)
        {
            string[] results = null;

            string cacheKey = "RxNormDisplayTerms";

            if (!_cache.TryGetValue(cacheKey, out results))
            {
                results = await _rxNormClient.GetDisplayTermsAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(12));

                _cache.Set(cacheKey, results, cacheEntryOptions);
            }

            if (results == null)
                return new List<string>();
            else
                return results
                    .Where(r => !String.IsNullOrWhiteSpace(r) && r.ToLower().StartsWith(searchTerm.ToLower().Trim()))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public async Task<List<RxNorm>> LookupRxNormApproximateMatches(string searchTerm, int pageSize = 20)
        {
            try
            {
                var matches = await _rxNormClient.GetApproximateMatches(searchTerm, false, pageSize);
                if (matches != null)
                {
                    return matches.Select(m => new RxNorm
                    {
                        Name = m.Name,
                        RxCUI = m.RxCUI
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<RxNorm>() {new RxNorm
                {
                    Name = "Error with RxNorm Web API",
                    RxCUI = ex.Message
                }};
            }
            return new List<RxNorm>();
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

