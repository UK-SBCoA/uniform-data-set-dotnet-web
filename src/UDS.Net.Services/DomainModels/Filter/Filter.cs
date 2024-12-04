using System.Collections.Generic;

namespace UDS.Net.Services.DomainModels.Filter
{
    public class Filter
    {
        public List<FilterItem> FilterList { get; set; } = new List<FilterItem>();
        public List<string> SelectedItems { get; set; } = new List<string>();
    }
}
