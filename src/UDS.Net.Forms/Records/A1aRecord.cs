using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record A1aRecord(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatea1a")]
        public string? FrmDate { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsa1a")]
        public string? Initials { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.INITIALS;

        [Name("langa1a")]
        public int? Lang { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : (int)form.LANG;

        // If not completed, then MODE should be included in export
        [Name("modea1a")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasa1a")]
        public int? RmReas { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodea1a")]
        public int? RmMode { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

        [Name("admina1a")]
        public int? Admin { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : 2; // TODO add support for different administration types

        // If not completed, then NOT should be included in export
        [Name("a1anot")]
        public int? Not { get; init; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}

