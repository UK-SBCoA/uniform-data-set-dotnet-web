using System;
namespace UDS.Net.Forms.Models
{
    public class PacketSubmissionModel
    {

        public virtual IList<PacketSubmissionErrorModel> Errors { get; set; } = new List<PacketSubmissionErrorModel>();
    }
}

