using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A1aRecord(Form form) : FormRecord(form)
    {
        [Name("frmdatea1a")]
        public string? FrmDate => base.FrmDateExport;

        [Name("initialsa1a")]
        public string? Initials => base.InitialsExport;

        [Name("langa1a")]
        public int? Lang => base.LangExport;

        [Name("modea1a")]
        public int Mode => base.ModeExport;

        [Name("rmreasa1a")]
        public int? RmReas => base.RmReasExport;

        [Name("rmmodea1a")]
        public int? RmMode => base.RmModeExport;

        [Name("admina1a")]
        public int? Admin => base.AdminExport;

        [Name("a1anot")]
        public int? Not => base.NotExport;
    }
}

