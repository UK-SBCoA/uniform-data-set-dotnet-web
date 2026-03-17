using UDS.Net.Services.DomainModels;
using CsvHelper.Configuration.Attributes;

namespace UDS.Net.Forms.Records;

public abstract record FormRecord(Form form)
{
    // DEVNOTE: Internal class necessary for proper export of columns
    internal Form form { get; init; } = form;

    [Ignore]
    public string? FrmDateExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.FRMDATE.ToString(RecordConstants.dateFormatString);

    [Ignore]
    public string? InitialsExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.INITIALS;

    [Ignore]
    public int? LangExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : (int)form.LANG;

    // If not completed, then MODE should be included in export
    [Ignore]
    public int ModeExport { get; init; } = (int)form.MODE;

    [Ignore]
    public int? RmReasExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

    [Ignore]
    public int? RmModeExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

    [Ignore]
    public int? AdminExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.ADMIN.HasValue ? (int)form.ADMIN.Value : null;

    // If not completed, then NOT should be included in export
    [Ignore]
    public int? NotExport { get; init; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
}
