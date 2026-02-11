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

        public List<NACCM1ErrorModel> M1SubmissionErrors { get; set; } = new();

        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }

        public CreateModel(
            IVisitService visitService,
            IParticipationService participationService)
        {
            _visitService = visitService;
            _participationService = participationService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        private static M1SubmissionErrorLevel GetErrorLevel(string errorType)
        {
            return errorType.Trim().ToLower() == "error"
                ? M1SubmissionErrorLevel.Error
                : M1SubmissionErrorLevel.Information;
        }

        int submissionId = 123;
        List<M1SubmissionError> errorsToSave = new();


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDisplayErrorSubmission()
        {
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
                    if (record.Visitnum?.ToLower() == "null")
                        record.Visitnum = null;

                    if (!string.Equals(record.Type, "error", StringComparison.OrdinalIgnoreCase))
                        continue;

                    record.Message = record.Message?.Length > 500
                        ? record.Message[..497] + "..."
                        : record.Message;

                    M1SubmissionErrors.Add(record);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErrorFileUpload",
                    "Error reading the file.");
                return Page();

            }

            return Page();
        }

    }
}
