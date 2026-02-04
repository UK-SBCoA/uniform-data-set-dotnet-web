using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;
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
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;
        public IFormFile? ErrorFileUpload { get; set; }
        [BindProperty]
        public List<NACCErrorModel> PacketSubmissionErrors { get; set; } = new List<NACCErrorModel>();
        public CreateModel(IVisitService visitService, IParticipationService participationService, IPacketService packetService)
        {
            _visitService = visitService;
            _participationService = participationService;
            _packetService = packetService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDisplayBulkSubmission()
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

            IEnumerable<Visit> submittedPackets = await _visitService.ListByStatus(User.Identity.Name, 10, 1, [PacketStatus.Submitted.ToString()]);

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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostConfirmBulkSubmission()
        {
            //DEVNOTE: dirty approach here, reget the submitted packets for use with updating packet submission
            IEnumerable<Visit> submittedPackets = await _visitService.ListByStatus(User.Identity.Name, 10, 1, [PacketStatus.Submitted.ToString()]);

            var submittedParticipationList = new List<Participation>();

            foreach (var packet in submittedPackets)
            {
                //legacyIdsFromPackets.Add(await _participationService.GetById(User.Identity.Name, packet.ParticipationId, false));
                //DEVNOTE: getById allows "include visit" as a boolean argument. This could help?
                var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

                submittedParticipationList.Add(participation);
            }

            //DEVNOTE: Group packet submission errors by PTID
            var packetSubmissionErrorsGrouped = PacketSubmissionErrors.GroupBy(p => p.Ptid);

            //DEVNOTE: For each group of ptids update packet submissions
            foreach(var errorGroup in packetSubmissionErrorsGrouped)
            {
                var groupPtid = errorGroup.ElementAt(0).Ptid;
                var groupVisitnum = errorGroup.ElementAt(0).Visitnum;

                var groupParticipation = submittedParticipationList.Where(p => p.LegacyId == groupPtid).FirstOrDefault();

                var groupVisit = submittedPackets.Where(p => p.ParticipationId == groupParticipation?.Id).FirstOrDefault();

                var groupPacket = await _packetService.GetById(User.Identity.Name, groupVisit.Id);

                var groupSubmissionId = groupPacket.Submissions.Where(s => s.ErrorCount == null).Select(i => i.Id).FirstOrDefault();

                List<PacketSubmissionError> groupPacketSubmissionErrors = new List<PacketSubmissionError>();

                foreach(var error in errorGroup)
                {
                    PacketSubmissionError newPacketSubmissionError = new PacketSubmissionError(
                        id: 0,
                        packetSubmissionId: groupSubmissionId,
                        formKind: error.Code.Split("-")[0].ToUpper(),
                        message: error.Message,
                        assignedTo: groupPacket.CreatedBy,
                        level: GetErrorLevel(error.Type),
                        status: PacketSubmissionErrorStatus.Pending,
                        statusChangedBy: null,
                        createdAt: DateTime.Now,
                        createdBy: User.Identity.Name,
                        modifiedBy: null,
                        deletedBy: null,
                        isDeleted: false,
                        location: error.Location?.ToUpper(),
                        value: error.Value
                    );

                    groupPacketSubmissionErrors.Add(newPacketSubmissionError);
                }

                await _packetService.UpdatePacketSubmissionErrors(User.Identity.Name, groupPacket, groupSubmissionId, groupPacketSubmissionErrors);
            }


            //DEVNOTE: need to get the packetSubmissionId from the item from _packetService.GetById with submission.ErrorCount == null

            //DEVNOTE: Things I need
            //current packet (Packet type) - 
            //Packet Submission Id (int)
            //Packet submission errors (List<PacketSubmissionErrors>)

            //await _packetService.UpdatePacketSubmissionErrors(User.Identity.Name, currentPacket, PacketSubmissionId, packetSubmissionErrors);

            return Page();
        }

        //DEVNOTE: Copied from the packetSubmissionError/Create.cshtml.cs
        private static PacketSubmissionErrorLevel GetErrorLevel(string errorType)
        {
            if (errorType.Trim().ToLower() == "alert")
            {
                return PacketSubmissionErrorLevel.Information;
            }
            else if (errorType.Trim().ToLower() == "error")
            {
                return PacketSubmissionErrorLevel.Error;
            }

            //return information as default
            return PacketSubmissionErrorLevel.Information;
        }
    }
}
