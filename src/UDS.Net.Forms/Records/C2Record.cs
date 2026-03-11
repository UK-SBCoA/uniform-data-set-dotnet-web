using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record C2Record(Form form) : FormRecord(form)
    {
        [Name("frmdatec2c2t")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsc2c2t")]
        public string? Initials => base.InitialsExport;

        [Name("langc2c2t")]
        public int? Lang => base.LangExport;

        [Name("modec2c2t")]
        public int Mode => base.ModeExport;

        [Name("rmreasc2c2t")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodec2c2t")]
        public int? RmMode => base.RmModeExport;
    }
}