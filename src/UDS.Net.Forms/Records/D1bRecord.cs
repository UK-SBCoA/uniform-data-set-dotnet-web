using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record D1bRecord(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdated1b")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsd1b")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langd1b")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("moded1b")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasd1b")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmoded1b")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

