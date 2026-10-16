using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services.Records
{
    public record A4aRecord(Form FormRecord) : FormRecord(FormRecord)
    {
        [Name("frmdatea4a")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsa4a")]
        public string? Initials => base.InitialsExport;

        [Name("langa4a")]
        public int? Lang => base.LangExport;

        [Name("modea4a")]
        public int Mode => base.ModeExport;

        [Name("rmreasa4a")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodea4a")]
        public int? RmMode => base.RmModeExport;
    }
}

