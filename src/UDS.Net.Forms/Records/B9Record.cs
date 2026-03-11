using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B9Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb9")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb9")]
        public string? Initials => base.InitialsExport;

        [Name("langb9")]
        public int? Lang => base.LangExport;

        [Name("modeb9")]
        public int Mode => base.ModeExport;

        [Name("rmreasb9")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodeb9")]
        public int? RmMode => base.RmModeExport;
    }
}

