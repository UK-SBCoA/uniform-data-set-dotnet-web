using System;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class M1SubmissionError
    {
        public int Id { get; set; }

        public int M1SubmissionId { get; set; }

        public string FormKind { get; set; }

        public string Message { get; set; }

        public string AssignedTo { get; private set; }

        public M1SubmissionErrorLevel Level { get; set; }

        public M1SubmissionErrorStatus Status { get; set; }

        public string StatusChangedBy { get; private set; }

        public string Location { get; set; }

        public string Value { get; set; }

        public DateTime CreatedAt { get; private set; }

        public string CreatedBy { get; private set; }

        public string ModifiedBy { get; private set; }

        public string DeletedBy { get; private set; }

        public bool IsDeleted { get; private set; }

        public void Assign(string assignedTo, string modifiedBy)
        {
            AssignedTo = assignedTo;
            ModifiedBy = modifiedBy;
        }

        public void SetStatus(M1SubmissionErrorStatus status, string changedBy)
        {
            Status = status;
            StatusChangedBy = changedBy;
        }

        public void Resolve(string resolvedBy)
        {
            SetStatus(M1SubmissionErrorStatus.Resolved, resolvedBy);
        }

        public void Ignore(string ignoredBy)
        {
            SetStatus(M1SubmissionErrorStatus.Ignored, ignoredBy);
        }

        public void Delete(string deletedBy)
        {
            DeletedBy = deletedBy;
            IsDeleted = true;
        }

        public M1SubmissionError(
            int id,
            int m1SubmissionId,
            string formKind,
            string message,
            string assignedTo,
            M1SubmissionErrorLevel level,
            M1SubmissionErrorStatus status,
            string statusChangedBy,
            DateTime createdAt,
            string createdBy,
            string modifiedBy,
            string deletedBy,
            bool isDeleted,
            string location,
            string value)
        {
            Id = id;
            M1SubmissionId = m1SubmissionId;
            FormKind = formKind;
            Message = message;
            AssignedTo = assignedTo;
            Level = level;
            Status = status;
            StatusChangedBy = statusChangedBy;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;
            Location = location;
            Value = value;
        }
    }
}
