using System;
using System.ComponentModel;

namespace UDS.Net.Services.Enums
{
    public enum PacketKind
    {
        [Description("Initial for new participants")]
        I,
        [Description("Follow-up")]
        F,
        [Description("Initial for existing participants")]
        I4
    }
}

