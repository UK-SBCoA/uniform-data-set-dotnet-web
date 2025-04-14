using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B9Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb9")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString("MM-dd-yyyy");

        [Name("initialsb9")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb9")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb9")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb9")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb9")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

