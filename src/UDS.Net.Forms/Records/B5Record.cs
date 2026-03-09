using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B5Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb5")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb5")]
        public string? Initials => base.InitialsExport;

        [Name("langb5")]
        public int? Lang => base.LangExport;

        [Name("modeb5")]
        public int Mode => base.ModeExport;

        [Name("rmreasb5")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodeb5")]
        public int? RmMode => base.RmModeExport;

        [Name("b5not")]
        public int? Not => base.NotExport;
    }
}

