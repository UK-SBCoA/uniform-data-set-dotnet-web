﻿using System;
using System.ComponentModel;

namespace UDS.Net.Services.Enums
{
    public enum FormStatus
    {
        [Description("Not started")]
        NotStarted,
        [Description("In progress")]
        InProgress,
        [Description("Complete")]
        Complete,
        [Description("Not included")]
        NotIncluded
    }
}

