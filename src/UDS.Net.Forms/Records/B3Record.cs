using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B3Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb3")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsb3")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb3")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb3")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb3")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb3")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

