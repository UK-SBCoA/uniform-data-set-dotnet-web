using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A3Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea3")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString("dd-MM-yyyy");

        [Name("initialsa3")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langa3")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modea3")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa3")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea3")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

