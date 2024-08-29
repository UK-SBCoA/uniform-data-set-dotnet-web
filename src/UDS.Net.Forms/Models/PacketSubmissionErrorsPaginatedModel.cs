using System;
namespace UDS.Net.Forms.Models
{
    public class PacketSubmissionErrorsPaginatedModel : PaginatedModel
    {
        public int PacketSubmissionId { get; set; }

        public List<PacketSubmissionErrorModel> List { get; set; } = new List<PacketSubmissionErrorModel>();
    }
}

