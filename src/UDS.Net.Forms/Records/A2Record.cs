using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A2Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea2")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsa2")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langa2")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modea2")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa2")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea2")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

        [Name("a2not")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}


