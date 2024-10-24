using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A4Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea4")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsa4")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langa4")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modea4")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa4")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea4")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

