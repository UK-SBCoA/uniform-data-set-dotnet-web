using System;
namespace UDS.Net.Services.LookupModels
{
    public class DrugCode
    {
        public string DrugId { get; set; }

        public string DrugName { get; set; }

        public string BrandName { get; set; }

        public bool IsOverTheCounter { get; set; }

        public bool IsPopular { get; set; }
    }
}

