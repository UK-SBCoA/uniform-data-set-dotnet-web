using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A1aRecord(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea1a")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsa1a")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langa1a")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modea1a")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa1a")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea1a")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

        [Name("admina1a")]
        public int? Admin { get; set; } = 2;

        [Name("a1anot")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}

