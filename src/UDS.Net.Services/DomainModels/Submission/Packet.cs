using System;
using System.Collections.Generic;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class Packet : Visit
    {
        public IList<PacketSubmission> Submissions { get; set; } = new List<PacketSubmission>();

        public Packet(int id, int number, int participationId, string version, PacketKind packet, DateTime visitDate, string initials, PacketStatus status, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<Form> existingForms, IList<PacketSubmission> packetSubmissions) : base(id, number, participationId, version, packet, visitDate, initials, status, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, existingForms)
        {
            if (packetSubmissions != null)
                Submissions = packetSubmissions;
        }

    }
}

