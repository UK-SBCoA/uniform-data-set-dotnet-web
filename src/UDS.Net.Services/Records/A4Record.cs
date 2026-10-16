using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Services.Records
{
    public record A4Record(Form FormRecord) : FormRecord(FormRecord)
    {
        [Name("frmdatea4")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsa4")]
        public string? Initials => base.InitialsExport;

        [Name("langa4")]
        public int? Lang => base.LangExport;

        [Name("modea4")]
        public int Mode => base.ModeExport;

        [Name("rmreasa4")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodea4")]
        public int? RmMode => base.RmModeExport;
    }
}

