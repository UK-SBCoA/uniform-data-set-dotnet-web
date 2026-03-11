using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A5D2Record(Form form) : FormRecord(form)
    {
        [Name("frmdatea5d2")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsa5d2")]
        public string? Initials => base.InitialsExport;

        [Name("langa5d2")]
        public int? Lang => base.LangExport;

        [Name("modea5d2")]
        public int Mode => base.ModeExport;

        [Name("rmreasa5d2")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodea5d2")]
        public int? RmMode => base.RmModeExport;
    }
}

