using System;
using UDS.Net.Dto;
using UDS.Net.Services;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class LookupService : ILookupService
    {
        public LookupService()
        {
        }

        public Task<DrugCodeLookup> Add(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }

        public Task<DrugCode> AddDrugCodeToLookup(DrugCode newDrugCode)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        public Task<DrugCodeLookup> FindDrugCode(string rxCUI)
        {
            throw new NotImplementedException();
        }

        public Task<DrugCodeLookup> FindDrugCodes(string[] rxCUIs)
        {
            throw new NotImplementedException();
        }

        public Task<DrugCodeLookup> GetById(string username, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DrugCodeLookup>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<LookupCountryCodeDto> LookupCountryCode(string countryCode)
        {
            throw new NotImplementedException();
        }

        public Task<DrugCodeLookup> LookupDrugCodes(int pageSize = 10, int pageIndex = 1, bool? includePopular = null, bool? includeOverTheCounter = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<RxNorm>> LookupRxNormApproximateMatches(string searchTerm, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> LookupRxNormDisplayTerms(string searchTerm, int pageSize = 20, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<DrugCodeLookup> Patch(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }

        public Task<DrugCodeLookup> SearchDrugCodes(int pageSize = 10, int pageIndex = 1, string? searchTerm = "")
        {
            throw new NotImplementedException();
        }

        public Task<DrugCodeLookup> Update(string username, DrugCodeLookup entity)
        {
            throw new NotImplementedException();
        }
    }
}

