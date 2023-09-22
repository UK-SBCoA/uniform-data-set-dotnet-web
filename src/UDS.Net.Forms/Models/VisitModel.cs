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
        public int Number { get; set; }

        [Required]
        [Display(Name = "Type")]
        public VisitKind Kind { get; set; }

        [Required]
        public string Version { get; set; } = "";

        [Required]
        [Display(Name = "Date of visit")]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ParticipationModel? Participation { get; set; }

        public virtual IList<FormModel> Forms { get; set; } = new List<FormModel>();

    }
}

