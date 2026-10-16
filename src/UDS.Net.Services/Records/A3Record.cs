using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services.Records
{
    public record A3Record(Form FormRecord) : FormRecord(FormRecord)
    {
        [Name("frmdatea3")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsa3")]
        public string? Initials => base.InitialsExport;

        [Name("langa3")]
        public int? Lang => base.LangExport;

        [Name("modea3")]
        public int Mode => base.ModeExport;

        [Name("rmreasa3")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodea3")]
        public int? RmMode => base.RmModeExport;
    }
}

