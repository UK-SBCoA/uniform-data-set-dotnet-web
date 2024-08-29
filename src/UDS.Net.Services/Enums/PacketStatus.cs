using System;
namespace UDS.Net.Services.Enums
{
    public enum PacketStatus
    {
        Unsubmitted, // no attempts made to submit
        Submitted, // submitted at least once, pending error checks from the latest submission
        FailedErrorChecks, // submitted at least once and failed error checks
        PassedErrorChecks, // submitted at least once and passed error checks
        Frozen // data freeze
    }
}

