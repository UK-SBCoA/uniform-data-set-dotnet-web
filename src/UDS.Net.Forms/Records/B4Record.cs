using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B4Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb4")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb4")]
        public string? Initials => base.InitialsExport;

        [Name("langb4")]
        public int? Lang => base.LangExport;

        [Name("modeb4")]
        public int Mode => base.ModeExport;

        [Name("rmreasb4")]
        public int? RmReas => base.RmModeExport;

        [Name("rmmodeb4")]
        public int? RmMode => base.RmModeExport;
    }
}

