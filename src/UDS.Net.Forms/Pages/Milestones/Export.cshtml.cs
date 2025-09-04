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

            int adcid = 19;
            string initials = username.Substring(0, Math.Min(username.Length, 3)).ToUpper();

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false, true));
            var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csv.WriteHeader<MilestoneRecord>();
            csv.NextRecord();

            var record = new MilestoneRecord(milestone, initials, adcid);
            csv.WriteRecord(record);
            csv.NextRecord();

            await csv.FlushAsync();
            await streamWriter.FlushAsync();

            memoryStream.Position = 0;

            string filename = $"Milestone_{milestone.Id}_{DateTime.Now:yyyyMMdd}.csv";
            return File(memoryStream, "text/csv", filename);
        }
    }
}
