using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;


namespace UDS.Net.Forms.Pages.MilestonesSubmissionErrors
{

    public class CreateModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        public List<NACCErrorModel> M1SubmissionErrors { get; set; } = new List<NACCErrorModel>();

        public IFormFile? ErrorFileUpload { get; set; }

        public CreateModel(IVisitService visitService, IParticipationService participationService)
        {
            _visitService = visitService;
            _participationService = participationService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDisplayErrorSubmission()
        {
            if (ErrorFileUpload == null)
            {
                ModelState.AddModelError("ErrorFileUpload", "File not found");

                return Page();
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            int rowIndex = 0;

            //NACC PTID from error file will be the same as the legacy ID for a participation
            var legacyIdsFromPackets = new List<string>();



            using (var stream = ErrorFileUpload.OpenReadStream())
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, config))
            {
                try
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<NACCErrorModel>();

                        //NACC PTID from error file must have a matching legacy ID in participation tbl or the participation does not exist
                        if (record.Approved.ToLower() == "false" && legacyIdsFromPackets.Contains(record.Ptid))
                        {
                            NACCErrorModel newPacketSubmissionError = new NACCErrorModel
                            {
                                Type = record.Type,
                                Code = record.Code,
                                Location = record.Location,
                                File = record.File,
                                Value = record.Value,
                                //DEVNOTE: Trim message to avoid 500+ character truncade error
                                Message = record.Message.Length > 500 ? record.Message[..497] + "..." : record.Message,
                                Ptid = record.Ptid,
                                Visitnum = record.Visitnum,
                                Approved = record.Approved
                            };

                            M1SubmissionErrors.Add(newPacketSubmissionError);
                        }

                        rowIndex++;
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ErrorFileUpload", "An error reading the file has occured");

                    return Page();
                }
            }

            return Page();
        }

    }
}
