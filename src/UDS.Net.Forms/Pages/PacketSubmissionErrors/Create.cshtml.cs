﻿using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Models;
using UDS.Net.Services;
using Microsoft.AspNetCore.Http;
using UDS.Net.Services.DomainModels.Submission;
using Microsoft.CodeAnalysis;
using UDS.Net.Services.Enums;
using UDS.Net.Forms.Extensions;
using Microsoft.AspNetCore.Routing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using UDS.Net.Forms.Pages.PacketSubmissions;
namespace UDS.Net.Forms.Pages.PacketSubmissionErrors
{
    public class CreateModel : PageModel
    {
        protected readonly IParticipationService _participationService;
        protected readonly IPacketService _packetService;

        [BindProperty]
        public int PacketSubmissionId { get; set; }

        [BindProperty]
        public int PacketId { get; set; }

        [BindProperty]
        public int LegacyId { get; set; }

        [BindProperty]
        public int PacketStatus { get; set; }

        [BindProperty]
        public int VisitNum { get; set; }

        [BindProperty]
        public IFormFile? ErrorFileUpload { get; set; }

        [BindProperty]
        public List<NACCErrorModel> PacketSubmissionErrors { get; set; }

        public CreateModel(IParticipationService participationService, IPacketService packetService)
        {
            _participationService = participationService;
            _packetService = packetService;
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            Packet currentPacket = await _packetService.GetById(User.Identity.Name, PacketId);

            List<PacketSubmissionError> packetSubmissionErrors = new List<PacketSubmissionError>();

            foreach (var error in PacketSubmissionErrors)
            {
                //Collect PacketSubmissionError data for creating new PacketSubmissionError object
                PacketSubmissionErrorLevel errorLevel = GetErrorLevel(error.Type);

                string formKind = error.Code.Split("-")[0].ToUpper();

                var formData = currentPacket.Forms.Where(f => f.Kind == formKind);

                string formModifiedBy = formData.Select(a => a.ModifiedBy).FirstOrDefault();

                string formAssignedTo = formData.Select(a => a.CreatedBy).FirstOrDefault();

                //formAsignee will first attempt to be last modified and if null, set it to createdBy
                string formAssignee = formModifiedBy;

                if (string.IsNullOrEmpty(formModifiedBy))
                {
                    formAssignee = formAssignedTo;
                }

                DateTime createdAt = formData.Select(a => a.CreatedAt).FirstOrDefault();

                //Create new PacketSubmissionError object with collected data
                PacketSubmissionError newPacketSubmissionError = new PacketSubmissionError(0, PacketSubmissionId, formKind, error.Message, formAssignee, errorLevel, User.Identity.Name, createdAt, User.Identity.Name, null, null, false);

                packetSubmissionErrors.Add(newPacketSubmissionError);
            }

            //Update currentPacket status
            if (currentPacket.TryUpdateStatus((PacketStatus)PacketStatus))
            {
                currentPacket.UpdateStatus((PacketStatus)PacketStatus);
            }
            else
            {
                return NotFound($"Unable to set packet Id ${currentPacket.Id} status to: {PacketStatus}");
            }

            //Update current packet with newPacketSubmissionError list
            await _packetService.UpdatePacketSubmissionErrors(User.Identity.Name, currentPacket, PacketSubmissionId, packetSubmissionErrors);

            //Create packetModel for use in packetSubmission/_Index partial
            PacketModel currentPacketModel = currentPacket.ToVM();
            currentPacketModel.Participation = currentPacket.Participation.ToVM();

            return Partial("../PacketSubmissions/_Index", currentPacketModel);
        }


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

        // Form submission from packetSubmissions/_Edit partial is posted here to display file data

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
                    }
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
    }
}


