using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B8Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb8")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsb8")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb8")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb8")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb8")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb8")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

