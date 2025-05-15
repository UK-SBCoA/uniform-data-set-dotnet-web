
using CsvHelper.Configuration.Attributes;

namespace UDS.Net.Forms.Models
{
    public class NACCErrorModel
    {
        public string Timestamp { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public string File { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
        public string Ptid { get; set; }
        public string Visitnum { get; set; }
        public string Approved { get; set; }
    }
}
