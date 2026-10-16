using System;
using System.Collections.Generic;
using System.Text;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Services.DomainModels
{
    public class PacketExportItemModel
    {
        public Packet Packet { get; set; }
        public Visit? PreviousVisit { get; set; }
        public int CountOfVisits { get; set; }
        public bool IncludeD1cColumns { get; set; }
    }
}
