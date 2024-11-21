using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record D1aRecord(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdated1a")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsd1a")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langd1a")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("moded1a")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasd1a")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmoded1a")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

