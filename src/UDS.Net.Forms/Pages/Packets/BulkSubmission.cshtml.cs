using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Models;

namespace UDS.Net.Forms.Pages.Packets
{
    public class BulkSubmissionModel : PageModel
    {
        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }
        public List<NACCErrorModel> PacketSubmissionErrors { get; set; } = new List<NACCErrorModel>();

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if (ErrorFileUpload == null)
            {
                return NotFound("Error upload file not found");
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            int rowIndex = 0;
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

                        //Ptid must == legacyId, visitNum must match, and the alert must not have been previously accepted
                        if (record.Approved.ToLower() == "false")
                        {
                            NACCErrorModel newPacketSubmissionError = new NACCErrorModel
                            {
                                Type = record.Type,
                                Code = record.Code,
                                Location = record.Location,
                                File = record.File,
                                Value = record.Value,
                                Message = record.Message,
                                Ptid = record.Ptid,
                                Visitnum = record.Visitnum,
                                Approved = record.Approved
                            };

                            PacketSubmissionErrors.Add(newPacketSubmissionError);
                        }
                        rowIndex++;
                    }
                }
                catch (FormatException e)
                {
                    //TempData["fileError"] = "Row " + rowIndex.ToString() + " format contains invalid characters " + e.Message;

                    //PacketSubmissionErrors = new List<NACCErrorModel>();

                    return Page();
                }
                catch (Exception e)
                {
                    //On failure, dispay temp error and empty PacketSubmissionErrors list before returning page
                    //TempData["fileError"] = "Uploaded file is invalid, please submit a valid file";

                    //PacketSubmissionErrors = new List<NACCErrorModel>();

                    return Page();
                }
            }

            return Page();
        }

    }
    /*
     [ValidateAntiForgeryToken]
        public IActionResult OnPostView()
        {
            if (ErrorFileUpload == null)
            {
                return NotFound("Error upload file not found");
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            int rowIndex = 0;
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

                        //Ptid must == legacyId, visitNum must match, and the alert must not have been previously accepted
                        if (int.Parse(record.Ptid) == LegacyId && int.Parse(record.Visitnum) == VisitNum && record.Approved.ToLower() == "false")
                        {
                            NACCErrorModel newPacketSubmissionError = new NACCErrorModel
                            {
                                Type = record.Type,
                                Code = record.Code,
                                Location = record.Location,
                                File = record.File,
                                Value = record.Value,
                                Message = record.Message,
                                Ptid = record.Ptid,
                                Visitnum = record.Visitnum,
                                Approved = record.Approved
                            };

                            PacketSubmissionErrors.Add(newPacketSubmissionError);
                        }
                        rowIndex++;
                    }
                }
                catch (FormatException e)
                {
                    TempData["fileError"] = "Row " + rowIndex.ToString() + " format contains invalid characters " + e.Message;

                    PacketSubmissionErrors = new List<NACCErrorModel>();

                    return Page();
                }
                catch (Exception e)
                {
                    //On failure, dispay temp error and empty PacketSubmissionErrors list before returning page
                    TempData["fileError"] = "Uploaded file is invalid, please submit a valid file";

                    PacketSubmissionErrors = new List<NACCErrorModel>();

                    return Page();
                }
            }

            return Page();
        } 
    */
}
