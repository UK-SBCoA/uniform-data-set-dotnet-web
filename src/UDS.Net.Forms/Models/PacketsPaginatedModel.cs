using System;
namespace UDS.Net.Forms.Models
{
    public class PacketsPaginatedModel : PaginatedModel
    {
        public List<PacketModel> List { get; set; } = new List<PacketModel>();
    }
}

