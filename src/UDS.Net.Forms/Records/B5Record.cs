using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B5Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb5")]
        public string? FrmDate { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsb5")]
        public string? Initials { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.INITIALS;

        [Name("langb5")]
        public int? Lang { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : (int)form.LANG;

        [Name("modeb5")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb5")]
        public int? RmReas { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb5")]
        public int? RmMode { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

        [Name("b5not")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}

