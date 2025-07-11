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

        // For autocomplete, NOTE: implement caching for 12-24 hours to avoid calling RxNav web api too frequently
        // https://lhncbc.nlm.nih.gov/RxNav/TermsofService.html
        Task<List<string>> LookupRxNormDisplayTerms(string searchTerm, int pageSize = 20, int pageIndex = 1);

        Task<List<RxNorm>> LookupRxNormApproximateMatches(string searchTerm, int pageSize = 20);

        Task<DrugCode> AddDrugCodeToLookup(DrugCode newDrugCode);
    }
}

