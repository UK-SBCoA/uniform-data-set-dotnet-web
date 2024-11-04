using System;
using System.ComponentModel;

namespace UDS.Net.Services.Enums
{
    public enum PacketKind
    {
        [Description("Initial")]
        I,
        [Description("Follow-up")]
        F
    }
}

