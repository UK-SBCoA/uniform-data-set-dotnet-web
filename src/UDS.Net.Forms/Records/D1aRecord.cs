using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record D1aRecord(Form form) : FormRecord(form)
    {
        [Name("frmdated1a")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsd1a")]
        public string? Initials => base.InitialsExport;

        [Name("langd1a")]
        public int? Lang => base.LangExport;
    }
}

