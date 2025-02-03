using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Services
{
    public interface ILookupService : IService<DrugCodeLookup>
    {
        Task<DrugCodeLookup> LookupDrugCodes(int pageSize = 10, int pageIndex = 1);

        Task<DrugCodeLookup> SearchDrugCodes(int pageSize = 10, int pageIndex = 1, string? searchTerm = "");

        Task<DrugCodeLookup> FindDrugCode(string rxCUI);

        Task<LookupCountryCodeDto> LookupCountryCode(string countryCode);

        Task<List<string>> LookupRxNormDisplayTerms();

        Task<List<RxNorm>> LookupRxNormApproximateMatches(string searchTerm, int pageSize = 20);

        Task<DrugCode> AddDrugCodeToLookup(DrugCode newDrugCode);
    }
}

