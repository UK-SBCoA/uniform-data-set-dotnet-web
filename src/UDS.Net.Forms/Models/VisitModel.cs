using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models
{
    public class VisitModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Participation")]
        public int ParticipationId { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int VISITNUM { get; set; }

        [Required(ErrorMessage = "Please select a visit type")]
        [Display(Name = "Type")]
        public PacketKind PACKET { get; set; }

        [Required]
        public string FORMVER { get; set; } = "";

        [Required]
        [Display(Name = "Date of visit")]
        public DateTime VISIT_DATE { get; set; }

        [Required]
        [Display(Name = "Examiner initials")]
        [MaxLength(3)]
        public string INITIALS { get; set; } = "";

        [Display(Name = "Status")]
        public PacketStatus Status { get; set; }

        public bool CanBeFinalized { get; set; } = false;

        public int? TotalUnresolvedErrorCount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ParticipationModel? Participation { get; set; }

        public virtual IList<FormModel> Forms { get; set; } = new List<FormModel>();

        public virtual IList<PacketSubmissionErrorModel> UnresolvedErrors { get; set; } = new List<PacketSubmissionErrorModel>();
    }
}

