using System.Threading.Tasks;
using UDS.Net.Dto;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Services
{
    public interface ILookupService : IService<DrugCodeLookup>
    {
        Task<DrugCodeLookup> LookupDrugCodes(int pageSize = 10, int pageIndex = 1);

        Task<DrugCodeLookup> SearchDrugCodes(int pageSize = 10, int pageIndex = 1, bool onlyPopular = true, string? searchTerm = "");

        Task<LookupCountryCodeDto> LookupCountryCode(string countryCode);

    }
}

