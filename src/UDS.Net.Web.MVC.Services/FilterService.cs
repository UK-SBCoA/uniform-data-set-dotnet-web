using System.Linq;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Filter;

namespace UDS.Net.Web.MVC.Services
{
    public class FilterService : IFilterService
    {
        public Filter SetFilterData(string[] filterQuery, Filter filter)
        {
            //if filterQuery is null, then select all filter options and end method
            if (filterQuery == null || filterQuery.Length == 0)
            {
                for (var i = 0; i < filter.FilterList.Count(); i++)
                {
                    filter.FilterList[i].Selected = true;
                    filter.SelectedItems.Add(filter.FilterList[i].Text.ToString());
                }

                return filter;
            }

            //can be sent a single comma delimeted string item in filterQuery and an array
            //If it is a delimeted string, seperate into array
            if (filterQuery.Count() == 1)
            {
                filterQuery = filterQuery[0].Split(',');
            }

            for (var i = 0; i < filter.FilterList.Count(); i++)
            {
                foreach (var item in filterQuery)
                {
                    if (filter.FilterList[i].Text == item)
                    {
                        filter.FilterList[i].Selected = true;
                        filter.SelectedItems.Add(filter.FilterList[i].Text.ToString());
                    }
                }
            }

            return filter;
        }
    }
}
