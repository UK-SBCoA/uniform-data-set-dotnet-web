﻿using System;
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
        public string FORMVER { get; set; } = "";

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Choose whether to save in-progress or finalize the form")]
        [Range(1, 2, ErrorMessage = "Choose whether to save in-progress or finalize the form")]
        [Display(Name = "Status")]
        public FormStatus Status { get; set; }

        public bool IsRequiredForPacketKind { get; set; }

        public bool AllowsRemote
        {
            get
            {
                if (AllowedFormModes.Contains((int)FormMode.Remote))
                    return true;
                return false;
            }
        }

        [Display(Name = "Language")]
        public FormLanguage LANG { get; set; }

        [Required]
        [Display(Name = "Mode")]
        public FormMode MODE { get; set; }

        public List<int> AllowedFormModes { get; set; } = new List<int>();

        [RequiredIf(nameof(MODE), "3", ErrorMessage = "Specify reason not completed")]
        [Display(Name = "If not completed, specify reason")]
        public NotIncludedReasonCode? NOT { get; set; }

        public List<int> AllowedNotIncludedReasonCodes { get; set; } = new List<int>();

        [RequiredIf(nameof(MODE), "2", ErrorMessage = "Specify reason for remote visit")]
        [Display(Name = "If remote, specify reason")]
        public RemoteReasonCode? RMREAS { get; set; }

        [RequiredIf(nameof(MODE), "2", ErrorMessage = "Specify remote modality")]
        [Display(Name = "If remote, specify modality")]
        public RemoteModality? RMMODE { get; set; }

        public List<int> AllowedRemoteModalities { get; set; } = new List<int>();

        [Required]
        [Display(Name = "Examiner initials")]
        [MaxLength(3)]
        public string INITIALS { get; set; } = "";

        [Required]
        [Display(Name = "Form date")]
        public DateTime FRMDATE { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        [RequiredIf(nameof(IsDeleted), "true", ErrorMessage = "Include username of who deleted the form.")]
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
            else if (Status == FormStatus.Finalized)
            {
                if (MODE == FormMode.NotCompleted && !NOT.HasValue)
                {
                    yield return new ValidationResult(
                        $"Provide a reason code if form is not completed",
                        new[] { nameof(NotIncludedReasonCode) });
                }
                if (string.IsNullOrWhiteSpace(Kind.Trim()))
                {
                    yield return new ValidationResult(
                        $"Form kind is required",
                        new[] { nameof(Kind) });
                }
                if (string.IsNullOrWhiteSpace(FORMVER.Trim()))
                {
                    yield return new ValidationResult(
                        $"Form version is required",
                        new[] { nameof(FORMVER) });
                }
                if (string.IsNullOrWhiteSpace(CreatedBy.Trim()))
                {
                    yield return new ValidationResult(
                        $"Created by is required",
                        new[] { nameof(CreatedBy) });
                }
                if (MODE == FormMode.Remote)
                {
                    if (!RMREAS.HasValue)
                    {
                        yield return new ValidationResult(
                            $"Remote reason code is required",
                            new[] { nameof(RMREAS) });
                    }
                    if (!RMMODE.HasValue)
                    {
                        yield return new ValidationResult(
                            $"Remote modality is required",
                            new[] { nameof(RMMODE) });
                    }
                }
            }
        }
    }
}

