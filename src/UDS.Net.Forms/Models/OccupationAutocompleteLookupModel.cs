using System;
using System.Collections.Generic;

namespace UDS.Net.Forms.Models
{
    public class OccupationAutocompleteLookupModel
    {
        public int VisitId { get; set; }

        public string? SearchTerm { get; set; } = "";

        /// <summary>
        /// Used by _OccupationAutocompleteStream for display format "Code - Name"
        /// Key is the display text, Value is the code (numeric only)
        /// </summary>
        public Dictionary<string, string> SearchResults { get; set; } = new Dictionary<string, string>();

        public int ResultsCount { get; set; } = 0;
    }
}