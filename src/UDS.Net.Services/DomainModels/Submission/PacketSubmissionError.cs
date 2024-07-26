using System;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class PacketSubmissionError
    {
        public int Id { get; set; }

        public string FormKind { get; set; }

        public string Message { get; set; }

        public string AssignedTo { get; set; }

        public PacketSubmissionErrorLevel Level { get; set; }

        public string ResolvedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public PacketSubmissionError(int id, string formKind, string message, string assignedTo, PacketSubmissionErrorLevel level, string resolvedBy, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted)
        {
            Id = id;
            FormKind = formKind;
            Message = message;
            AssignedTo = assignedTo;
            Level = level;
            ResolvedBy = resolvedBy;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;
        }
    }
}

