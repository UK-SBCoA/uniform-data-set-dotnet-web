using System;
namespace UDS.Net.Forms.Models
{
    public class PacketModel : VisitModel
    {
        public virtual IList<PacketSubmissionModel> PacketSubmissions { get; set; } = new List<PacketSubmissionModel>();

        public PacketSubmissionModel NewPacketSubmission { get; set; }
    }
}

