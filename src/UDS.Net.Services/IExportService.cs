using System;
using System.Threading.Tasks;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services
{
    public interface IExportService : IService<Byte>
    {
        public Task<Byte[]> ConvertPacketToCSV(PacketExportItemModel packet, string username);
        public Task<Byte[]> BulkConvertPacketsToCSV(int[] packetId, string username);
    }
}