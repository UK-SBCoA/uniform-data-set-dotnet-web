using System;
using System.Collections.Generic;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels
{
    // Allows different contracts for different packet kinds
    // Initial visits may require more forms than follow-ups
    public class FormContract
    {
        public string Abbreviation { get; set; }

        public bool IsRequredForVisitKind { get; set; }

        public FormContract(string abbreviation, bool isRequired)
        {
            Abbreviation = abbreviation;
            IsRequredForVisitKind = isRequired;
        }
    }
}

