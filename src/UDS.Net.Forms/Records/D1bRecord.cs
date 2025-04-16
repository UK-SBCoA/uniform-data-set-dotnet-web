using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record D1bRecord(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdated1b")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsd1b")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langd1b")]
        public int Lang { get; init; } = (int)form.LANG;
    }
}

