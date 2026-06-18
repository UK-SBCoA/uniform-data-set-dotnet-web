using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class BulkErrorSubmissionItem
    {
        public PacketSubmissionErrorModel SubmissionError { get; set; }
        public PacketSubmissionErrorStatus PacketSubmissionErrorStatus { get; set; }
        public bool ConfirmImport { get; set; }
    }
}
