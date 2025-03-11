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
    }
}

