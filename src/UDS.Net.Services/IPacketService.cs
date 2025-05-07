using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services
{
    public interface IPacketService : IService<Packet>
    {
        Task<Packet> GetPacketWithForms(string username, int id);

        Task<List<Packet>> List(string username, List<PacketStatus> statuses, int pageSize = 10, int pageIndex = 1);

        Task<int> Count(string username, List<PacketStatus> statuses);

        Task<Packet> UpdatePacketSubmissionErrorCount(string username, Packet packetToEdit, int errorCount, int packetSubmissionId);
    }
}

