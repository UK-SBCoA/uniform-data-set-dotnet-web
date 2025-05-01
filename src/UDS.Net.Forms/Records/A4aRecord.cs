using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A4aRecord(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea4a")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsa4a")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langa4a")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modea4a")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa4a")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea4a")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

