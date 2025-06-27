using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B6Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb6")]
        public string? FrmDate { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsb6")]
        public string? Initials { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.INITIALS;

        [Name("langb6")]
        public int? Lang { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : (int)form.LANG;

        [Name("modeb6")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasb6")]
        public int? RmReas { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodeb6")]
        public int? RmMode { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

        [Name("b6not")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}

