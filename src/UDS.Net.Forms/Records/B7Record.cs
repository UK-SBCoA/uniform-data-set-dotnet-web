using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B7Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb7")]
        public string? FrmDate { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsb7")]
        public string? Initials { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.INITIALS;

        [Name("langb7")]
        public int? Lang { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : (int)form.LANG;

        [Name("modeb7")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb7")]
        public int? RmReas { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb7")]
        public int? RmMode { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

        [Name("b7not")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}

