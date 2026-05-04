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

        private void WriteCsvHeader(CsvWriter csv)
        {
            csv.WriteField("packet");
            csv.WriteField("formver");
            csv.WriteField("adcid");
            csv.WriteField("ptid");
            csv.WriteField("visitdate");
            csv.WriteField("initials");
            csv.WriteField("changemo");
            csv.WriteField("changedy");
            csv.WriteField("changeyr");
            csv.WriteField("protocol");
            csv.WriteField("aconsent");
            csv.WriteField("recogim");
            csv.WriteField("rephyill");
            csv.WriteField("rerefuse");
            csv.WriteField("renavail");
            csv.WriteField("renurse");
            csv.WriteField("nursemo");
            csv.WriteField("nursedy");
            csv.WriteField("nurseyr");
            csv.WriteField("rejoin");
            csv.WriteField("ftlddisc");
            csv.WriteField("ftldreas");
            csv.WriteField("ftldreax");
            csv.WriteField("deceased");
            csv.WriteField("discont");
            csv.WriteField("deathmo");
            csv.WriteField("deathdy");
            csv.WriteField("deathyr");
            csv.WriteField("autopsy");
            csv.WriteField("discmo");
            csv.WriteField("discday");
            csv.WriteField("discyr");
            csv.WriteField("dropreas");
            csv.NextRecord();
        }

        private void WriteCsvRecord(CsvWriter csv, MilestoneRecord record)
        {
            csv.WriteField(record.PACKET);
            csv.WriteField(record.FORMVER);
            csv.WriteField(record.ADCID);
            csv.WriteField(record.PTID);

            string visitDate = "";
            if (record.VISITYR.HasValue && record.VISITMO.HasValue && record.VISITDAY.HasValue)
            {
                try
                {
                    visitDate = new DateTime(
                        record.VISITYR.Value,
                        record.VISITMO.Value,
                        record.VISITDAY.Value
                    ).ToString("yyyy-MM-dd");
                }
                catch
                {
                    visitDate = "";
                }
            }

            csv.WriteField(visitDate);
            csv.WriteField(record.INITIALS);
            csv.WriteField(record.CHANGEMO);
            csv.WriteField(record.CHANGEDY);
            csv.WriteField(record.CHANGEYR);
            csv.WriteField(record.PROTOCOL);
            csv.WriteField(record.ACONSENT);
            csv.WriteField(record.RECOGIM);
            csv.WriteField(record.REPHYILL);
            csv.WriteField(record.REREFUSE);
            csv.WriteField(record.RENAVAIL);
            csv.WriteField(record.RENURSE);
            csv.WriteField(record.NURSEMO);
            csv.WriteField(record.NURSEDY);
            csv.WriteField(record.NURSEYR);
            csv.WriteField(record.REJOIN);
            csv.WriteField(record.FTLDDISC);
            csv.WriteField(record.FTLDREAS);
            csv.WriteField(record.FTLDREAX);
            csv.WriteField(record.DECEASED);
            csv.WriteField(record.DISCONT);
            csv.WriteField(record.DEATHMO);
            csv.WriteField(record.DEATHDY);
            csv.WriteField(record.DEATHYR);
            csv.WriteField(record.AUTOPSY);
            csv.WriteField(record.DISCMO);
            csv.WriteField(record.DISCDAY);
            csv.WriteField(record.DISCYR);
            csv.WriteField(record.DROPREAS);
            csv.NextRecord();
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

            if (milestone.Status != "Finalized")
            {
                return BadRequest("Only finalized milestones can be exported.");
            }

            await _milestoneService.CreateSubmissionAsync(username, milestone.Id);

            string adcid = _configuration["ADRC:Id"];
            string initials = username.Substring(0, Math.Min(username.Length, 3)).ToUpper();

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false, true));
            var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            WriteCsvHeader(csv);

            var record = new MilestoneRecord(milestone, initials, adcid);

            WriteCsvRecord(csv, record);

            await csv.FlushAsync();
            await streamWriter.FlushAsync();

            memoryStream.Position = 0;

            string filename = $"M_{milestone.Participation.LegacyId}_{milestone.CreatedAt:yyMMdd}-mlst.csv";
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

            WriteCsvHeader(csv);

            foreach (var id in selectedIds)
            {
                var milestone = await _milestoneService.GetById(username, id);

                if (milestone == null || milestone.Status != "Finalized")
                {
                    continue;
                }

                string adcid = _configuration["ADRC:Id"];
                string initials = username.Substring(0, Math.Min(username.Length, 3)).ToUpper();

                await _milestoneService.CreateSubmissionAsync(username, milestone.Id);

                var record = new MilestoneRecord(milestone, initials, adcid);

                WriteCsvRecord(csv, record);

            }

            await csv.FlushAsync();
            await writer.FlushAsync();
            memoryStream.Position = 0;

            string filename = $"Milestones_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            return File(memoryStream, "text/csv", filename);
        }

    }
}
