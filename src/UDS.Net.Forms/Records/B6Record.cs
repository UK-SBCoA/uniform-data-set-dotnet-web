using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B6Record(Form form) : FormRecord(form)
    {
        [Name("frmdateb6")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsb6")]
        public string? Initials => base.InitialsExport;

        [Name("langb6")]
        public int? Lang => base.LangExport;

        [Name("modeb6")]
        public int Mode => base.ModeExport;

        [Name("rmreasb6")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodeb6")]
        public int? RmMode => base.RmModeExport;

        [Name("b6not")]
        public int? Not => base.NotExport;
    }
}

