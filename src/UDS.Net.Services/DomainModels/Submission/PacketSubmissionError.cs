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

        public string StatusChangedBy { get; private set; }

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

        public void Resolve(string statusChangedBy, string modifiedBy)
        {
            StatusChangedBy = statusChangedBy;
            ModifiedBy = modifiedBy;
        }

        public void Delete(string deletedby)
        {
            DeletedBy = deletedby;
            IsDeleted = true;
        }

        public PacketSubmissionError(int id, int packetSubmissionId, string formKind, string message, string assignedTo, PacketSubmissionErrorLevel level, string statusChangedBy, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted)
        {
            Id = id;
            PacketSubmissionId = packetSubmissionId;
            FormKind = formKind;
            Message = message;
            AssignedTo = assignedTo;
            Level = level;
            StatusChangedBy = statusChangedBy;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;
        }
    }
}

