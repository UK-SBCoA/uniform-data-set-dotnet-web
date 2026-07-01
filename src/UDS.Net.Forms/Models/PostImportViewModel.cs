using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Models
{
    public class PostImportViewModel
    {
        public required List<Packet> UpdatedPackets { get; set; } = new List<Packet>();
        public required List<Packet> RemainingSubmittedPackets { get; set; } = new List<Packet>();
    }
}
