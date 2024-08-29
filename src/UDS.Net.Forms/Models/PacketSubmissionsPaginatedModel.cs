using System;
namespace UDS.Net.Forms.Models
{
    public class PacketSubmissionsModel
    {
        public bool CanCreateNewSubmission { get; set; } = false;
        public List<PacketSubmissionModel> List { get; set; } = new List<PacketSubmissionModel>();
    }
}

