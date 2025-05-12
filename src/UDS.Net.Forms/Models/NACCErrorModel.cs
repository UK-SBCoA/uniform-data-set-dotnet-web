
using CsvHelper.Configuration.Attributes;

namespace UDS.Net.Forms.Models
{
    public class NACCErrorModel
    {
        [Index(0)]
        public string Timestamp { get; set; }
        [Index(1)]
        public string Type { get; set; }
        [Index(2)]
        public string Location { get; set; }
        [Index(3)]
        public string File { get; set; }
        [Index(4)]
        public string Value { get; set; }
        [Index(5)]
        public string Message { get; set; }
        [Index(6)]
        public string Ptid { get; set; }
        [Index(7)]
        public string Visitnum { get; set; }
        [Index(8)]
        public string Approved { get; set; }
    }
}
