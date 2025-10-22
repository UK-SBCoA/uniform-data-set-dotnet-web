using System;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class PacketSubmissionError
    {
        public int Id { get; set; }

        public int PacketSubmissionId { get; set; }

        public string FormKind { get; set; }

        public string Message { get; set; }

        public string AssignedTo { get; private set; }

        public PacketSubmissionErrorLevel Level { get; set; }

        public PacketSubmissionErrorStatus Status { get; set; }

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

        public void SetStatus(PacketSubmissionErrorStatus status, string changedBy)
        {
            Status = status;
            StatusChangedBy = changedBy;
        }

        public void Resolve(string resolvedBy)
        {
            SetStatus(PacketSubmissionErrorStatus.Resolved, resolvedBy);
        }

        public void Ignore(string ignoredBy)
        {
            SetStatus(PacketSubmissionErrorStatus.Ignored, ignoredBy);
        }

        public void Delete(string deletedBy)
        {
            DeletedBy = deletedBy;
            IsDeleted = true;
        }

        public PacketSubmissionError(
            int id,
            int packetSubmissionId,
            string formKind,
            string message,
            string assignedTo,
            PacketSubmissionErrorLevel level,
            PacketSubmissionErrorStatus status,
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
            PacketSubmissionId = packetSubmissionId;
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
