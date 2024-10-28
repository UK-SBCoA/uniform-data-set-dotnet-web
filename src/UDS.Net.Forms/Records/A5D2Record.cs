using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A5D2Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea5d2")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsa5d2")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langa5d2")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modea5d2")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa5d2")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea5d2")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

