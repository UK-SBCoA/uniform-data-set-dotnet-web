using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record C2Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatec2c2t")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString("MM-dd-yyyy");

        [Name("initialsc2c2t")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langc2c2t")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modec2c2t")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasc2c2t")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodec2c2t")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}