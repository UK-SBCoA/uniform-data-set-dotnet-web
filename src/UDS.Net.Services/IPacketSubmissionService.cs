using System;
using System.Threading.Tasks;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Services
{
    public interface IPacketSubmissionService : IService<PacketSubmission>
    {
        Task<PacketSubmission> GetPacketSubmissionWithForms(string username, int id);

        // TODO create packet submission error methods

    }
}

