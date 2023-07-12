using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class FormModel
    {
        public int Id { get; set; }

        [Required]
        public int VisitId { get; set; }

        [Required]
        public string Kind { get; set; } = "";

        [Required]
        public string Version { get; set; } = "";

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Choose whether to save in-progress or complete the form")]
        [Display(Name = "Status")]
        public FormStatus Status { get; set; }

        public bool IsRequiredForVisitKind { get; set; }

        [Display(Name = "Language")]
        public FormLanguage Language { get; set; }

        [Display(Name = "If not submitted, specify reason")]
        public ReasonCode? ReasonCodeNotIncluded { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == FormStatus.NotStarted)
            {
                yield return new ValidationResult(
                    $"Choose status to save form",
                    new[] { nameof(Status) });
            }
            else if (Status == FormStatus.NotIncluded && !ReasonCodeNotIncluded.HasValue)
            {
                yield return new ValidationResult(
                    $"Provide a reason code if form is not included",
                    new[] { nameof(ReasonCodeNotIncluded) });
            }
            else if (Status == FormStatus.Complete)
            {
                if (string.IsNullOrWhiteSpace(Kind.Trim()))
                {
                    yield return new ValidationResult(
                        $"Form kind is required",
                        new[] { nameof(ReasonCodeNotIncluded) });
                }
                if (string.IsNullOrWhiteSpace(Version.Trim()))
                {
                    yield return new ValidationResult(
                        $"Form version is required",
                        new[] { nameof(ReasonCodeNotIncluded) });
                }
                if (string.IsNullOrWhiteSpace(CreatedBy.Trim()))
                {
                    yield return new ValidationResult(
                        $"Created by is required",
                        new[] { nameof(ReasonCodeNotIncluded) });
                }
            }
        }
    }
}

