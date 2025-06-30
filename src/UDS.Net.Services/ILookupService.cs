using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Services
{
    public interface ILookupService : IService<DrugCodeLookup>
    {
        Task<DrugCodeLookup> LookupDrugCodes(int pageSize = 10, int pageIndex = 1, bool? includePopular = null, bool? includeOverTheCounter = null);

        Task<DrugCodeLookup> SearchDrugCodes(int pageSize = 10, int pageIndex = 1, string? searchTerm = "");

        Task<DrugCodeLookup> FindDrugCode(string rxCUI);

        Task<DrugCodeLookup> FindDrugCodes(string[] rxCUIs);

        Task<LookupCountryCodeDto> LookupCountryCode(string countryCode);

        Task<List<string>> LookupRxNormDisplayTerms();

        Task<List<RxNorm>> LookupRxNormApproximateMatches(string searchTerm, int pageSize = 20);

        Task<DrugCode> AddDrugCodeToLookup(DrugCode newDrugCode);
    }
}

