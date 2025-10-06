using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class PacketSubmissionErrorModel
    {
        public int Id { get; set; }

        public int PacketSubmissionId { get; set; }

        public string FormKind { get; set; } = "";

        public string Message { get; set; } = "";

        public string AssignedTo { get; set; } = "";

        public PacketSubmissionErrorLevel Level { get; set; }

        public string ResolvedBy { get; set; } = "";
        public string? Location { get; set; }
        public string? Value { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}

