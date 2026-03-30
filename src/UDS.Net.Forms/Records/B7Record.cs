using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B7Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb7")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb7")]
        public string? Initials => base.InitialsExport;

        [Name("langb7")]
        public int? Lang => base.LangExport;

        [Name("modeb7")]
        public int Mode => base.ModeExport;

        [Name("rmreasb7")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodeb7")]
        public int? RmMode => base.RmModeExport;

        [Name("b7not")]
        public int? Not => base.NotExport;
    }
}

