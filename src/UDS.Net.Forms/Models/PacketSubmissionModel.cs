using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models
{
    public class PacketSubmissionModel
    {
        public int Id { get; set; }

        public int PacketId { get; set; }

        [Required]
        [Display(Name = "Submission date")]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public int? ErrorCount { get; set; }

        public List<PacketSubmissionErrorModel> Errors { get; set; } = new List<PacketSubmissionErrorModel>();

        public string GetFileName(string participantLegacyId, DateTime visitDate)
        {
            return $"UDS_{participantLegacyId}_{visitDate.Year}_EXPORTED_{SubmissionDate.ToFileTime()}-uds.csv";
        }
    }
}

