using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Services.Enums;

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

        public FormStatus Status { get; set; }

        public bool IsRequiredForVisitKind { get; set; }

        public FormLanguage Language { get; set; }

        public ReasonCode? ReasonCodeNotIncluded { get; set; }

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

