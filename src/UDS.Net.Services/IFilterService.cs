using UDS.Net.Services.DomainModels.Filter;

namespace UDS.Net.Services
{
    public interface IFilterService
    {
        public Filter SetFilterData(string[] filterQuery, Filter filter);
    }
}
