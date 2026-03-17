using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B1Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb1")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb1")]
        public string? Initials => base.InitialsExport;

        [Name("langb1")]
        public int? Lang => base.LangExport;

        [Name("modeb1")]
        public int Mode => base.ModeExport;

        [Name("b1not")]
        public int? Not => base.NotExport;
    }
}

