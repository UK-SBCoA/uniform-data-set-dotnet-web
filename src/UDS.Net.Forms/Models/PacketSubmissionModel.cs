using System.ComponentModel.DataAnnotations;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Models
{
    public class PacketSubmissionModel
    {
        public int Id { get; set; }

        public int VisitId { get; set; }

        [Required]
        [Display(Name = "Submission date")]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public int? ErrorCount { get; set; }

        public virtual PacketSubmissionErrorsPaginatedModel Errors { get; set; } = new PacketSubmissionErrorsPaginatedModel();
        public string GetFileName(string participantLegacyId, DateTime visitDate)
        {
            return $"UDS_{participantLegacyId}_{visitDate.Year}_EXPORTED_{SubmissionDate.ToFileTime()}.csv";
        }
    }
}

