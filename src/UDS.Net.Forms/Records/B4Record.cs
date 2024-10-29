using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B4Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb4")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsb4")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb4")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb4")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb4")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb4")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

