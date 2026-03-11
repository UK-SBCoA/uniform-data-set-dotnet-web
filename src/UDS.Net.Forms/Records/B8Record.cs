using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B8Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb8")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb8")]
        public string? Initials => base.InitialsExport;

        [Name("langb8")]
        public int? Lang => base.LangExport;

        [Name("modeb8")]
        public int Mode => base.ModeExport;

        [Name("rmreasb8")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodeb8")]
        public int? RmMode => base.RmModeExport;
    }
}

