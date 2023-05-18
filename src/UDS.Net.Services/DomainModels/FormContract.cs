using System;
namespace UDS.Net.Services.DomainModels
{
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

