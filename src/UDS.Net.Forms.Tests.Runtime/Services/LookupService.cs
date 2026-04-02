using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class LookupService : ILookupService
    {
        private readonly List<DrugCode> _drugCodes = new();
        private readonly List<LookupCountryCodeDto> _countries = new();

        public LookupService()
        {
            // Common drugs
            _drugCodes.Add(new DrugCode { RxNormId = "12345", DrugName = "Aspirin", BrandName = "Bayer", IsOverTheCounter = true, IsPopular = true });
            _drugCodes.Add(new DrugCode { RxNormId = "23456", DrugName = "Ibuprofen", BrandName = "Advil", IsOverTheCounter = true, IsPopular = true });

            // test-case drugs
            _drugCodes.Add(new DrugCode { RxNormId = "34567", DrugName = "Acetazolamide", BrandName = "Diamox", IsOverTheCounter = false, IsPopular = false });
            _drugCodes.Add(new DrugCode { RxNormId = "45678", DrugName = "Chlorzoxazone", BrandName = "Parafon Forte", IsOverTheCounter = false, IsPopular = false });
            _drugCodes.Add(new DrugCode { RxNormId = "56789", DrugName = "Guanfacine", BrandName = "Intuniv", IsOverTheCounter = false, IsPopular = false });
            _drugCodes.Add(new DrugCode { RxNormId = "67890", DrugName = "Voriconazole", BrandName = "Vfend", IsOverTheCounter = false, IsPopular = false });

            // Country codes
            _countries.Add(new LookupCountryCodeDto { Id = 1, Code = "US", Country = "United States", IsActive = true });
            _countries.Add(new LookupCountryCodeDto { Id = 2, Code = "CA", Country = "Canada", IsActive = true });
            _countries.Add(new LookupCountryCodeDto { Id = 3, Code = "MX", Country = "Mexico", IsActive = true });
            _countries.Add(new LookupCountryCodeDto { Id = 4, Code = "GB", Country = "United Kingdom", IsActive = true });
        }

        public Task<DrugCodeLookup> LookupDrugCodes(int pageSize = 10, int pageIndex = 1, bool? includePopular = null, bool? includeOverTheCounter = null)
        {
            var paged = _drugCodes.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return Task.FromResult(new DrugCodeLookup
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalResultsCount = _drugCodes.Count,
                DrugCodes = paged
            });
        }

        public Task<DrugCodeLookup> SearchDrugCodes(int pageSize = 10, int pageIndex = 1, string searchTerm = "")
        {
            var filtered = _drugCodes
                .Where(d => d.DrugName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var paged = filtered.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return Task.FromResult(new DrugCodeLookup
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalResultsCount = filtered.Count,
                DrugCodes = paged
            });
        }

        public Task<DrugCodeLookup> FindDrugCode(string rxCUI)
        {
            var match = _drugCodes.FirstOrDefault(d => d.RxNormId == rxCUI);
            return Task.FromResult(new DrugCodeLookup
            {
                PageSize = 1,
                PageIndex = 1,
                TotalResultsCount = match != null ? 1 : 0,
                DrugCodes = match != null ? new List<DrugCode> { match } : new List<DrugCode>()
            });
        }

        public Task<DrugCodeLookup> FindDrugCodes(string[] rxCUIs)
        {
            var matches = _drugCodes.Where(d => rxCUIs.Contains(d.RxNormId)).ToList();
            return Task.FromResult(new DrugCodeLookup
            {
                PageSize = matches.Count,
                PageIndex = 1,
                TotalResultsCount = matches.Count,
                DrugCodes = matches
            });
        }

        public Task<DrugCode> AddDrugCodeToLookup(DrugCode newDrugCode)
        {
            _drugCodes.Add(newDrugCode);
            return Task.FromResult(newDrugCode);
        }

        public Task<LookupCountryCodeDto> LookupCountryCode(string countryCode)
        {
            var match = _countries.FirstOrDefault(c => c.Code == countryCode);
            return Task.FromResult(match);
        }

        public Task<List<string>> LookupRxNormDisplayTerms(string searchTerm, int pageSize = 20, int pageIndex = 1)
        {
            var allTerms = _drugCodes.Select(d => d.DrugName).ToList();
            var filtered = allTerms
                .Where(t => t.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase))
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Task.FromResult(filtered);
        }

        public Task<List<RxNorm>> LookupRxNormApproximateMatches(string searchTerm, int pageSize = 20)
        {
            var allTerms = _drugCodes.Select(d => new RxNorm { Name = d.DrugName, RxCUI = d.RxNormId }).ToList();
            var matches = allTerms.Where(d => d.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                                  .Take(pageSize)
                                  .ToList();
            return Task.FromResult(matches);
        }

        // Obsolete / Test-only methods
        public Task<DrugCodeLookup> Add(string username, DrugCodeLookup entity) => throw new NotImplementedException();
        public Task<int> Count(string username) => Task.FromResult(_drugCodes.Count);
        public Task<DrugCodeLookup> Update(string username, DrugCodeLookup entity) => throw new NotImplementedException();
        public Task<DrugCodeLookup> Patch(string username, DrugCodeLookup entity) => throw new NotImplementedException();
        public Task Remove(string username, DrugCodeLookup entity) => throw new NotImplementedException();
        public Task<IEnumerable<DrugCodeLookup>> List(string username, int pageSize = 10, int pageIndex = 1) => throw new NotImplementedException();
        public Task<DrugCodeLookup> GetById(string username, int id) => throw new NotImplementedException();
    }
}