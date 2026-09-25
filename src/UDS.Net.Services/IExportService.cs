using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Services
{
    public interface IExportService
    {
        public Task<Byte[]> ConvertPacketToCSV(int packetId, string username);
    }
}