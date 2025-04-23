using System.ComponentModel;

namespace UDS.Net.Services.Enums
{
    public enum FormMode
    {
        [Description("In-person")]
        InPerson = 1,
        [Description("Remote")]
        Remote = 2,
        [Description("Not completed")]
        NotCompleted = 3
    }
}

