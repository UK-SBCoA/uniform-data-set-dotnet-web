using System;
using System.Collections.Generic;
using System.Linq;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class PacketSubmission
    {
        public int Id { get; set; }

        public string ADRCId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int PacketId { get; set; }

        public IList<Form> Forms { get; set; } = new List<Form>();

        public int? ErrorCount { get; set; } // If null, no response was received from submission

        public List<PacketSubmissionError> Errors { get; set; } = new List<PacketSubmissionError>();

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public PacketSubmission(
            int id,
            string adrcId,
            DateTime submissionDate,
            int packetId,
            DateTime createdAt,
            string createdBy,
            string modifiedBy,
            string deletedBy,
            bool isDeleted,
            int? errorCount)
        {
            Id = id;
            ADRCId = adrcId;
            SubmissionDate = submissionDate;
            PacketId = packetId;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;
            ErrorCount = errorCount;
        }

        public PacketSubmission(
            int id,
            string adrcId,
            DateTime submissionDate,
            int packetId,
            DateTime createdAt,
            string createdBy,
            string modifiedBy,
            string deletedBy,
            bool isDeleted,
            int? errorCount,
            IList<Form> forms)
            : this(id, adrcId, submissionDate, packetId, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, errorCount)
        {
            Forms = forms ?? new List<Form>();
        }

        public PacketSubmission(
            int id,
            string adrcId,
            DateTime submissionDate,
            int packetId,
            DateTime createdAt,
            string createdBy,
            string modifiedBy,
            string deletedBy,
            bool isDeleted,
            int? errorCount,
            IList<PacketSubmissionError> errors)
            : this(id, adrcId, submissionDate, packetId, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, errorCount)
        {
            Errors = errors?.ToList() ?? new List<PacketSubmissionError>();
        }

        public PacketSubmission(
            int id,
            string adrcId,
            DateTime submissionDate,
            int packetId,
            DateTime createdAt,
            string createdBy,
            string modifiedBy,
            string deletedBy,
            bool isDeleted,
            int? errorCount,
            IList<Form> forms,
            IList<PacketSubmissionError> errors)
            : this(id, adrcId, submissionDate, packetId, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, errorCount)
        {
            Forms = forms ?? new List<Form>();
            Errors = errors?.ToList() ?? new List<PacketSubmissionError>();
        }
    }
}
