using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B1Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb1")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsb1")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb1")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb1")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb1")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb1")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

