using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;
using System.Globalization;
using System.Text.RegularExpressions;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.BulkErrorImport
{
    public class CreateModel : PageModel
    {
        protected readonly IVisitService _visitService;
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;
        public IFormFile? ErrorFileUpload { get; set; }
        [BindProperty]
        //DEVNOTE: for the confirm logic, rename the type for better naming
        public List<BulkErrorSubmissionItem> BulkErrorSubmissionItems { get; set; } = new List<BulkErrorSubmissionItem>();
        public List<Packet> RemainingSubmittedPackets { get; set; } = new List<Packet>(); 
        //DEVNOTE: for the display logic rename the type for better naming
        public List<BulkErrorImportItem> PacketsToDisplay { get; set; } = new List<BulkErrorImportItem>();
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
        public async Task<IActionResult> OnPostDisplayBulkImport()
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

            //page size to 999 to retrieve maximum packets by status
            //var submittedPackets = await _visitService.ListByStatus(User.Identity.Name, 999, 1, [PacketStatus.Submitted.ToString()]);

            //DEVNOTE: Using the _packetService list method instead so I can include packetsubmissionerrors later on
            var submittedPackets = await _packetService.List(User.Identity.Name, [PacketStatus.Submitted], 999);

            //Initialize tuple for storing legacyId and visitnum paring of each submitted packet
            var legacyIdVisitnumPairs = new List<(string legacyId, int visitNum)>();

            foreach (var packet in submittedPackets)
            {
                //DEVNOTE: what if we just add the participation directly to the submitted packet? 
                packet.Participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

                //DEVNOTE: NACC PTID from error file will be the same as the legacy ID for a matching participation.
                //var participation = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

                //if (!string.IsNullOrEmpty(participation.LegacyId) && packet.VISITNUM > 0)
                //{
                //    legacyIdVisitnumPairs.Add((participation.LegacyId, packet.VISITNUM));
                //}
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

                        //DEVNOTE: Temporary name
                        var matchedSubmittedPacketForError = submittedPackets.FirstOrDefault(packet => packet.Participation.LegacyId == record.Ptid && packet.VISITNUM == int.Parse(record.Visitnum));
                        //var matchedLegacyIdVisitnumPair = legacyIdVisitnumPairs?.Where(pair => pair.legacyId == record.Ptid && pair.visitNum == int.Parse(record.Visitnum)).FirstOrDefault();

                        //if (!string.IsNullOrEmpty(matchedLegacyIdVisitnumPair?.legacyId) && record.Approved.ToLower() == "false")
                        //DEVNOTE: check for matchedSubmittedPacketForError was found isntead of using the legacy id / visitnum tuple
                        if (matchedSubmittedPacketForError != null && record.Approved.ToLower() == "false")
                        {
                            //DEVNOTE:
                            //Here I am already matching nacc errors to packets with legacyId and approved.
                            //Maybe I can just create the packetSubmission error here to connect for the view
                            //NACCErrorModel newNACCError = new NACCErrorModel
                            //{
                            //    Type = record.Type,
                            //    Code = record.Code,
                            //    Location = record.Location,
                            //    File = record.File,
                            //    Value = record.Value,
                            //    //DEVNOTE: Trim message to avoid 500+ character truncade error
                            //    Message = record.Message.Length > 500 ? record.Message[..497] + "..." : record.Message,
                            //    Ptid = record.Ptid,
                            //    Visitnum = record.Visitnum,
                            //    Approved = record.Approved
                            //};

                            //NACCSubmissionErrors.Add(newNACCError);

                            //DEVNOTE: Get the most recent submission to update
                            var matchedSubmittedPacketSubmission = matchedSubmittedPacketForError.Submissions.Last();

                            matchedSubmittedPacketSubmission.Errors.Add(new PacketSubmissionError
                            (
                                id: 0,
                                packetSubmissionId: matchedSubmittedPacketForError.Submissions.Last().Id,
                                formKind: record.Code.Split("-")[0].ToUpper(),
                                message: record.Message,
                                assignedTo: matchedSubmittedPacketForError.CreatedBy,
                                level: GetErrorLevel(record.Type),
                                status: PacketSubmissionErrorStatus.Pending,
                                statusChangedBy: null,
                                createdAt: DateTime.Now,
                                createdBy: User.Identity.Name,
                                modifiedBy: null,
                                deletedBy: null,
                                isDeleted: false,
                                location: record.Location?.ToUpper(),
                                value: record.Value
                            ));

                            
                            matchedSubmittedPacketSubmission.ErrorCount = matchedSubmittedPacketSubmission.ErrorCount == null ? 1 : matchedSubmittedPacketSubmission.ErrorCount += 1;
                        }
                    }

                    //DEVNOTE: Changing to use list of bulkErrorDiplayItemModel
                    //SubmittedPacketsToUpdate = submittedPackets;

                    foreach (var packet in submittedPackets)
                    {
                        //PacketsToUpdate.Add(singlePacket);
                        var newBulkErrorImportItem = new BulkErrorImportItem
                        {
                            PacketToImport = packet
                        };

                        PacketsToDisplay.Add(newBulkErrorImportItem);
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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostConfirmBulkImport()
        {
            //DEVNOTE: recieve submission errors from display view, use that to save new sumbmissions on packets INSTEAD using NACC errors to gather data as before

            var packetsToUpdate = new List<Packet>();

            ////Setting page size to 999 to retrieve all packets of status due to pagination
            var submittedPackets = await _packetService.List(User.Identity.Name, [PacketStatus.Submitted], 999);


            //DEVNOTE: read only packets with confirm import
            var confirmedBulkErrorSubmissionItems = BulkErrorSubmissionItems.Where(i => i.ConfirmImport).ToList();

            //loop through the packet submission errors sent from the display view
            foreach (var bulkSubmissionItemGroup in confirmedBulkErrorSubmissionItems.GroupBy(s => s.SubmissionErrors[0].PacketSubmissionId))
            {
                //Find the corrisponding packet that the submission belongs to the submission error group (search the submitted packets list)
                var matchedPacket = submittedPackets.Where(p => p.Submissions.Any(s => s.Id == bulkSubmissionItemGroup.Key)).FirstOrDefault();

                //Get the active submission from the packet (most recent submission with a NULL error count)
                var matchedActiveSubmission = matchedPacket?.Submissions.Last();

                //Add submission errors from group to the found packet and update packet
                if (matchedActiveSubmission != null && matchedPacket != null)
                {
                    //DEVNOTE: Check for if status is null (should never be with default) 
                    var updatedStatus = bulkSubmissionItemGroup.Select(group => group.PacketStatus).FirstOrDefault();

                    //Update packet status
                    if (matchedPacket.TryUpdateStatus(updatedStatus))
                    {
                        //Update packet status
                        matchedPacket.UpdateStatus(updatedStatus);

                        //Update errors
                        //DEVNOTE: packetsubmissionerror does not have a parameterless constructor, so packetsubmissionerrormodel is being used to create packetsubmissionerror objects
                        matchedActiveSubmission.Errors = CreatePacketSubmissionErrors(bulkSubmissionItemGroup, matchedActiveSubmission);

                        //Update packet error count
                        matchedActiveSubmission.ErrorCount = matchedActiveSubmission.Errors.Count;

                        packetsToUpdate.Add(matchedPacket);
                    }
                }
            }

            //run the API update method on the updated packets list
            //List<Packet> updatedPacketsReturned = await _packetService.UpdateMultiplePacketsSubmissionsErrors(User.Identity.Name, packetsToUpdate);

            return Partial("_postImportView", new PostImportViewModel
            {
                UpdatedPackets = packetsToUpdate,
                RemainingSubmittedPackets = submittedPackets.ExceptBy(packetsToUpdate.Select(u => u.Id), s => s.Id).ToList()
            });

        }

        private List<PacketSubmissionError> CreatePacketSubmissionErrors(IGrouping<int, BulkErrorSubmissionItem> bulkSubmissionItemGroup, PacketSubmission matchedActiveSubmission)
        {
            var newPacketSubmissionErrors = new List<PacketSubmissionError>();

            foreach (var item in bulkSubmissionItemGroup.SelectMany(e => e.SubmissionErrors))
            {
                //DEVNOTE: currently creating a new object. Using submission error model because submission error domain object doesn't have a null constructor to initialize
                newPacketSubmissionErrors.Add(new PacketSubmissionError
                (
                    id: 0,
                    packetSubmissionId: matchedActiveSubmission.Id,
                    formKind: item.FormKind,
                    message: item.Message,
                    assignedTo: item.AssignedTo,
                    level: item.Level,
                    status: item.Status,
                    statusChangedBy: item.StatusChangedBy,
                    createdAt: item.CreatedAt,
                    createdBy: item.CreatedBy,
                    modifiedBy: item.ModifiedBy,
                    deletedBy: item.DeletedBy,
                    isDeleted: item.IsDeleted,
                    location: item.Location,
                    value: item.Value
                ));
            }

            return newPacketSubmissionErrors;
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
