using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B3Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb3")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb3")]
        public string? Initials => base.InitialsExport;

        [Name("langb3")]
        public int? Lang => base.LangExport;

        [Name("modeb3")]
        public int Mode => base.ModeExport;

        [Name("b3not")]
        public int? Not => base.NotExport;
    }
}

