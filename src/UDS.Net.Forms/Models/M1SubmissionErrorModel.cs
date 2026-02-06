using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class M1SubmissionErrorModel
    {
        public int Id { get; set; }

        public int PacketSubmissionId { get; set; }

        public string FormKind { get; set; } = "";

        public string Message { get; set; } = "";

        public string AssignedTo { get; set; } = "";

        public M1SubmissionErrorLevel Level { get; set; }

        public string StatusChangedBy { get; set; } = "";

        public M1SubmissionErrorStatus Status { get; set; }

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
