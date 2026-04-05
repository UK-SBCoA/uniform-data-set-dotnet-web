using System;
using System.Collections.Generic;
using System.Text;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class NACCError
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
        public string ImportedBy { get; set; }
    }
}
