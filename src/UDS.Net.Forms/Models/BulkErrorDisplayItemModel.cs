using System;
using System.Collections.Generic;
using System.Text;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Models
{
    public class BulkErrorDisplayItemModel
    {
        public Packet ImportPacket { get; set; }
        public bool ConfirmImport { get; set; }
    }
}
