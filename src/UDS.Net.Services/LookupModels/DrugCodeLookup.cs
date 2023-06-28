using System;
using System.Collections.Generic;
using UDS.Net.Dto;

namespace UDS.Net.Services.LookupModels
{
    public class DrugCodeLookup
    {
        public string SearchTerm { get; set; }
        public object LookupParameters { get; set; }

        public List<DrugCode> DrugCodes { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalResultsCount { get; set; }

        public ErrorDto Error { get; set; }
    }
}

