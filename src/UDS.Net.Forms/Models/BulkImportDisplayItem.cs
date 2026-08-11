using System;
using System.Collections.Generic;
using System.Text;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Models
{
    public class BulkImportDisplayItem
    {
        public Packet? PacketToImport { get; set; }
        public PacketSubmission GetActiveSubmission => PacketToImport.Submissions.Last();
    }
}
