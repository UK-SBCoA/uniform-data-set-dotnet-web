using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UDS.Net.Forms.Models
{
    public class M1SubmissionModel
    {
        public int Id { get; set; }

        public int M1Id { get; set; }

        [Required]
        [Display(Name = "Submission date")]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public int? ErrorCount { get; set; }

        public List<M1SubmissionErrorModel> Errors { get; set; } = new List<M1SubmissionErrorModel>();

        public string GetFileName(string participantLegacyId, DateTime visitDate)
        {
            return $"UDS_{participantLegacyId}_{visitDate.Year}_EXPORTED_{SubmissionDate.ToFileTime()}-uds.csv";
        }
    }
}