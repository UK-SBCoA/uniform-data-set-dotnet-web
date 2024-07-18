using System;
using System.Collections.Generic;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels
{
    public interface IFormFields
    {
        IEnumerable<FormMode> FormModes { get; } // does the form support remote collection
        IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes { get; } // some forms allow 94, but most don't
        IEnumerable<RemoteModality> RemoteModalities { get; }
        string GetDescription();
        string GetVersion();
    }
}

