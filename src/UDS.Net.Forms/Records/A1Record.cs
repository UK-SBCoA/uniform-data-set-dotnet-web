using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Records
{
    public record A1Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea1")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsa1")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langa1")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modea1")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa1")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea1")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

        [Name("admina1")]
        public int? Admin { get; set; } = 2;
    }
}

