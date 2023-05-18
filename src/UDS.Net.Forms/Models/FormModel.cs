using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UDS.Net.Forms.Models
{
    public class FormModel
    {
        public int Id { get; set; }

        public int VisitId { get; set; }

        public string Kind { get; set; } = "";

        public string Version { get; set; } = "";

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public string Status { get; set; } = "";

        public bool IsRequiredForVisitKind { get; set; }

        public string? Language { get; set; }

        public bool IncludeInPacketSubmission { get; set; }

        public int? ReasonCodeNotIncluded { get; set; }

        public string? ReasonNotIncluded { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new Exception("Cannot validate without full object.");
        }
    }
}

