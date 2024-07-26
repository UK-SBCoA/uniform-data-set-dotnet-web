using System;
using System.Collections.Generic;
using System.Linq;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class PacketSubmission
    {
        public int Id { get; set; }

        public DateTime SubmissionDate { get; set; }

        public Visit Visit { get; set; } = default!;

        public int VisitId { get; set; }

        public List<PacketSubmissionError> Errors { get; set; } = new List<PacketSubmissionError>();

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public PacketSubmission(int id, DateTime submissionDate, int visitId, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted)
        {
            Id = id;
            SubmissionDate = submissionDate;
            VisitId = visitId;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = IsDeleted;
        }

        public PacketSubmission(int id, DateTime submissionDate, int visitId, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<PacketSubmissionError> errors) : this(id, submissionDate, visitId, createdAt, createdBy, modifiedBy, deletedBy, isDeleted)
        {
            if (errors != null)
            {
                Errors = errors.ToList();
            }
        }
    }
}

