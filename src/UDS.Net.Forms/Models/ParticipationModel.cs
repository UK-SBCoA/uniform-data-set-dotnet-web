using System;
using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models
{
    public class ParticipationModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Legacy Id")]
        public string LegacyId { get; set; } = "";

        public int VisitCount { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public IList<VisitModel> Visits { get; set; } = new List<VisitModel>();

        public int LastVisitNumber { get; set; }
    }
}

