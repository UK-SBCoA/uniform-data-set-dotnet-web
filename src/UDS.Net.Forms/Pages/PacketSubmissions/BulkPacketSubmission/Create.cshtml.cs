using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.PacketSubmissions.BulkPacketSubmission
{
    public class CreateModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IPacketService _packetService;
        protected readonly IParticipationService _participationService;
        public IFormFile? ErrorFileUpload { get; set; }
        public List<NACCErrorModel> PacketSubmissionErrors { get; set; } = new List<NACCErrorModel>();

        public CreateModel(IVisitService visitService, IPacketService packetService, IParticipationService participationService)
        {
            _visitService = visitService;
            _packetService = packetService;
            _participationService = participationService;
        }

        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostUploadBulkSubmission()
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

            //DEVNOTE: variables for submitted packets to filter the CSV data
            //Ptid must == legacyId, visitNum must match, and the alert must not have been previously accepted

            //DEVNOTE: We only want to get errors for packets that are in the submitted status as well
            //1. Get all packets with status = 2 (submitted)
            //2. Create list of participation ids of packets returned
            //3. in the if, check if the PTID is in the list of participation Ids

            var submittedPackets = await _visitService.ListByStatus(User.Identity.Name, 10, 1, [PacketStatus.Submitted.ToString()]);
            //DEVNOTE: can get legacyId (PTID) from participation
            //ParticipationId and legacyId are NOT always equal
            var legacyIdsFromPackets = new List<string>();

            foreach (var submittedPacket in submittedPackets)
            {
                //legacyIdsFromPackets.Add(await _participationService.GetById(User.Identity.Name, submittedPacket.ParticipationId, false));
                //DEVNOTE: getById allows "include visit" as a boolean argument. This could help?
                var participation = await _participationService.GetById(User.Identity.Name, submittedPacket.ParticipationId);
                var legacyId = participation.LegacyId;

                //DEVNOTE: legacyId is a string
                legacyIdsFromPackets.Add(legacyId);
            }

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

                        if (record.Approved.ToLower() == "false" && legacyIdsFromPackets.Contains(record.Ptid))
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

                        //Update current packet with newPacketSubmissionError list
                        //await _packetService.UpdatePacketSubmissionErrors(User.Identity.Name, currentPacket, PacketSubmissionId, packetSubmissionErrors);

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
}
