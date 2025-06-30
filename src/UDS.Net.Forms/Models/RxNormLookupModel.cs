using System;
namespace UDS.Net.Forms.Models
{
    public class RxNormLookupModel
    {
        public int VisitId { get; set; }

        public int Id { get; set; }

        public int ResultsCount { get; set; } = 0;

        public Dictionary<string, string> SearchResults { get; set; } = new Dictionary<string, string>();

        public string SearchTerm { get; set; }

    }
}

