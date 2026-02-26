using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.API.Entities;
using UDS.Net.Forms.Models;
using UDS.Net.Services;


namespace UDS.Net.Forms.Pages.MilestonesSubmissionErrors
{

    public class CreateModel : PageModel
    {
        private readonly IVisitService _visitService;
        private readonly IParticipationService _participationService;
        private readonly IMilestoneService _milestoneService;


        public List<NACCM1ErrorModel> M1SubmissionErrors { get; set; } = new();

        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }

        public CreateModel(
            IVisitService visitService,
            IParticipationService participationService,
            IMilestoneService milestoneService)
        {
            _visitService = visitService;
            _participationService = participationService;
            _milestoneService = milestoneService;
        }


        private static M1SubmissionErrorLevel GetErrorLevel(string? errorType)
        {
            if (string.IsNullOrWhiteSpace(errorType))
                return M1SubmissionErrorLevel.Information;

            return errorType.Trim().ToLower() == "error"
                ? M1SubmissionErrorLevel.Error
                : M1SubmissionErrorLevel.Information;
        }



        List<M1SubmissionError> errorsToSave = new();


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDisplayErrorSubmission()
        {

            var username = User.Identity?.Name ?? "";

            var milestone = await _milestoneService.GetMostRecentSubmission(username);

            if (milestone == null)
            {
                ModelState.AddModelError("", "No submission found.");
                return Page();
            }

            var submission = milestone.M1Submissions
                .OrderByDescending(s => s.SubmissionDate)
                .FirstOrDefault();


            if (submission == null)
            {
                ModelState.AddModelError("", "No submission found.");
                return Page();
            }

            if (ErrorFileUpload == null || ErrorFileUpload.Length == 0)
            {
                ModelState.AddModelError("ErrorFileUpload", "File not found.");
                return Page();
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                HeaderValidated = null,
                MissingFieldFound = null,
                BadDataFound = null,
                TrimOptions = TrimOptions.Trim
            };

            try
            {
                using var stream = ErrorFileUpload.OpenReadStream();
                using var reader = new StreamReader(stream);
                using var csv = new CsvReader(reader, config);

                csv.Context.TypeConverterOptionsCache
                    .GetOptions<DateTime?>()
                    .Formats = new[] { "M/d/yyyy H:mm", "M/d/yyyy" };

                var records = csv.GetRecords<NACCM1ErrorModel>();

                foreach (var record in records)
                {
                    if (string.Equals(record.Visitnum, "null", StringComparison.OrdinalIgnoreCase))
                        record.Visitnum = null;

                    record.Message = record.Message?.Length > 500
                        ? record.Message[..497] + "..."
                        : record.Message;

                    var error = new UDS.Net.Services.DomainModels.Submission.M1SubmissionError(
                        id: 0,
                        m1SubmissionId: submission.Id,
                        formKind: record.Value ?? "",
                        message: record.Message ?? "",
                        assignedTo: "",
                        level: Services.Enums.M1SubmissionErrorLevel.Error,
                        status: Services.Enums.M1SubmissionErrorStatus.Pending,
                        statusChangedBy: "",
                        createdAt: record.Timestamp ?? DateTime.UtcNow,
                        createdBy: username,
                        modifiedBy: "",
                        deletedBy: "",
                        isDeleted: false,
                        location: record.Location ?? "",
                        value: record.Value ?? "");
                    submission.Errors.Add(error);
                }

                milestone.Status = "FailedErrorChecks";

                await _milestoneService.Update(username, milestone);
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErrorFileUpload",
                    "Error reading the file.");
                return Page();

            }

            return RedirectToPage("/Milestones/Index");
        }

    }
}