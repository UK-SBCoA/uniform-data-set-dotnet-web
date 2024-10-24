﻿using System;
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

        // TODO create packet submission error methods

    }
}

