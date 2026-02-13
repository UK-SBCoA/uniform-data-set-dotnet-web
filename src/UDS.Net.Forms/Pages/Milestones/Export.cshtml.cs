using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using UDS.Net.Services;
using UDS.Net.Forms.Models.Exports;
using UDS.Net.Services.DomainModels;
using System.IO;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class ExportModel : PageModel
    {
        protected readonly IMilestoneService _milestoneService;
        private readonly IConfiguration _configuration;

        public bool Processed { get; set; } = false;

        public ExportModel(IMilestoneService milestoneService, IConfiguration configuration)
        {
            _configuration = configuration;
            _milestoneService = milestoneService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("A valid milestone ID must be provided.");
            }

            string username = User.Identity?.Name ?? "system";

            var milestone = await _milestoneService.GetById(username, id);

            if (milestone == null)
            {
                return NotFound($"Milestone with ID {id} not found.");
            }

            await _milestoneService.CreateSubmissionAsync(username, milestone.Id);

            string adcid = _configuration["ADRC:Id"];
            string initials = username.Substring(0, Math.Min(username.Length, 3)).ToUpper();

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false, true));
            var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            var record = new MilestoneRecord(milestone, initials, adcid);
            csv.WriteRecord(record);
            csv.NextRecord();

            await csv.FlushAsync();
            await streamWriter.FlushAsync();

            memoryStream.Position = 0;

            string filename = $"M_{milestone.Participation.LegacyId}_{milestone.CreatedAt:yyMMdd}.csv";
            return File(memoryStream, "text/csv", filename);
        }

        public async Task<IActionResult> OnPostExportSelectedAsync(List<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                TempData["ExportError"] = "Please select at least one milestone to export.";
                return RedirectToPage("/Milestones/Index");
            }

            string username = User.Identity?.Name ?? "system";

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream, new UTF8Encoding(false, true));
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            foreach (var id in selectedIds)
            {
                var milestone = await _milestoneService.GetById(username, id);
                if (milestone != null)
                {
                    string adcid = _configuration["ADRC:Id"];
                    string initials = username.Substring(0, Math.Min(username.Length, 3)).ToUpper();

                    var record = new MilestoneRecord(milestone, initials, adcid);
                    csv.WriteRecord(record);
                    await csv.NextRecordAsync();
                    await _milestoneService.CreateSubmissionAsync(username, milestone.Id);
                }
            }

            await csv.FlushAsync();
            await writer.FlushAsync();
            memoryStream.Position = 0;

            string filename = $"Milestones_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            return File(memoryStream, "text/csv", filename);
        }

    }
}
