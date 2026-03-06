using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records;

public abstract record FormRecord(Form form)
{
    public string? FrmDateExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.FRMDATE.ToString(RecordConstants.dateFormatString);

    public string? InitialsExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.INITIALS;

    public int? LangExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : (int)form.LANG;

    // If not completed, then MODE should be included in export
    public int ModeExport { get; init; } = (int)form.MODE;

    public int? RmReasExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

    public int? RmModeExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;

    public int? AdminExport { get; init; } = form.MODE == Services.Enums.FormMode.NotCompleted ? null : form.ADMIN.HasValue ? (int)form.ADMIN.Value : null;

    // If not completed, then NOT should be included in export
    public int? NotExport { get; init; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
}
