using System;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Records
{
    public record A1Record(Form form) : FormRecord(form)
    {
        [Name("frmdatea1")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsa1")]
        public string? Initials => base.InitialsExport;

        [Name("langa1")]
        public int? Lang => base.LangExport;

        [Name("modea1")]
        public int Mode => base.ModeExport;

        [Name("rmreasa1")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodea1")]
        public int? RmMode => base.RmModeExport;

        [Name("admina1")]
        public int? Admin => base.AdminExport;
    }
}

