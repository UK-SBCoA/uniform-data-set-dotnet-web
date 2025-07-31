using System;
namespace UDS.Net.Forms.Models
{
    public class RxNormLookupModel
    {
        public int VisitId { get; set; }

        public int ResultsCount { get; set; } = 0;

        public string? SearchTerm { get; set; } = "";

        /// <summary>
        /// Used by _RxNormAutocompleteStream
        /// </summary>
        public List<string> AutocompleteResults { get; set; } = new List<string>();

        /// <summary>
        /// Used by _RxNormSelect
        /// </summary>
        public Dictionary<string, string> SearchResults { get; set; } = new Dictionary<string, string>();
    }
}

