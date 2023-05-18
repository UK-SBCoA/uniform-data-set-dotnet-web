using System;
namespace UDS.Net.Forms.Models
{
    public class VisitModel
    {
        public int Id { get; set; }

        public int ParticipationId { get; set; }

        public int Number { get; set; }

        public string Kind { get; set; } = "";

        public string Version { get; set; } = "";

        public DateTime StartDateTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = "";

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ParticipationModel? Participation { get; set; }

        public virtual IList<FormModel> Forms { get; set; } = new List<FormModel>();
    }
}

