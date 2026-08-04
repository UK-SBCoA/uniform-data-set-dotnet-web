using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class BulkImportConfirmItem
    {
        public List<PacketSubmissionErrorModel> SubmissionErrors { get; set; } = new List<PacketSubmissionErrorModel>();
        public bool ConfirmImport { get; set; }
        public PacketStatus PacketStatus { get; set; }
    }
}
