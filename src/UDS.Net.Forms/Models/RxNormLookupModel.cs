using System;
namespace UDS.Net.Forms.Models
{
    public class RxNormLookupModel
    {
        public int Id { get; set; }

        public int ResultsCount { get; set; } = 0;

        public Dictionary<string, string> SearchResults { get; set; }

        public string SearchTerm { get; set; }

    }
}

