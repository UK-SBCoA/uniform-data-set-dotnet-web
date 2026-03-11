using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A2Record(Form form) : FormRecord(form)
    {
        [Name("frmdatea2")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsa2")]
        public string? Initials => base.InitialsExport;

        [Name("langa2")]
        public int? Lang => base.LangExport;

        [Name("modea2")]
        public int Mode => base.ModeExport;

        [Name("rmreasa2")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodea2")]
        public int? RmMode => base.RmModeExport;

        [Name("a2not")]
        public int? Not => base.NotExport;
    }
}


