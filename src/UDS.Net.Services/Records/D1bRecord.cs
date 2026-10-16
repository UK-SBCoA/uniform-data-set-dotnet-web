using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services.Records
{
    public record D1bRecord(Form FormRecord) : FormRecord(FormRecord)
    {
        [Name("frmdated1b")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsd1b")]
        public string? Initials => base.InitialsExport;

        [Name("langd1b")]
        public int? Lang => base.LangExport;
    }
}

