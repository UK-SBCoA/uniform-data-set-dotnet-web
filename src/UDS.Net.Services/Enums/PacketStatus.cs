using System;
namespace UDS.Net.Services.Enums
{
    public enum PacketStatus
    {
        Pending, // no attempts made to finalize or submit
        Finalized, // finalized entire packet since last form change
        Submitted, // submitted at least once, pending error checks from the latest submission
        FailedErrorChecks, // submitted at least once and failed error checks
        PassedErrorChecks, // submitted at least once and passed error checks
        Frozen // data freeze
    }
}

