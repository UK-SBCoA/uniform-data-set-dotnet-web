using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;
using Microsoft.AspNetCore.Http;
using UDS.Net.Services.DomainModels.Submission;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using UDS.Net.Services.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Emit;
using UDS.Net.Services.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            var currentPacket = await _packetService.GetById(User.Identity.Name, PacketId);

            List<PacketSubmissionError> packetSubmissionErrors = new List<PacketSubmissionError>();
            foreach (var error in PacketSubmissionErrors)
            {
                //no id
                //form kind = error.type
                //assignedTo = packetId & visitnum & PTID of form to get assigned to - use modified by first and if null then used createdBy
                //Level = get this using the error.type
                //null resolved by
                //createdBy = packetSubmission created by? 
                //modifiedBy = null
                //Created at = needs to be datetime type

                PacketSubmissionErrorLevel errorLevel = GetErrorLevel(error.Type);
                
                string formKind = GetFormKind(error.Code);

                

                //PacketSubmissionError newPacketSubmissionError = new PacketSubmissionError(0, PacketSubmissionId, formKind, error.Message, [assignedTo], errorLevel, null, error.Timestamp, User.Identity.Name, null, null, false);
            }
            return Page();
        }

        //TODO could make these methods static methods on the packetsubmissionerror class and accept error
        private PacketSubmissionErrorLevel GetErrorLevel(string errorType)
        {
            if(errorType == "alert")
            {
                return PacketSubmissionErrorLevel.Information;
            }
            else if(errorType == "error")
            {
                return PacketSubmissionErrorLevel.Error;
            }

            //return default information level if non matching
            //TODO allow null for non matching cases
            return PacketSubmissionErrorLevel.Information;
        }

        private string GetFormKind(string errorCode)
        {
            return errorCode.Split("-")[0];
        }

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

            //TODO: Handle error for when a header is not found, use try / catch to return user to upload with error message regarding previous attempt 

            using (var stream = ErrorFileUpload.OpenReadStream())
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var record = csv.GetRecord<NACCErrorModel>();

                    //PTID of record needs to match the current PTID or ignore the record
                    //This could be the legacy ID

                    //if PTID matches, then create the packetsubmissionError object and add to the packetSubmissionErrors list
                    if (int.Parse(record.Ptid) == LegacyId && int.Parse(record.Visitnum) == VisitNum)
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

            //End ParseErrorFile method

            return Page();
        }

        private async Task<Packet> GetPacketData(int packetId)
        {
            Packet packetFound = await _packetService.GetById(User.Identity.Name, packetId);

            if (packetFound == null)
                return null;

            var packetFoundParticipation = await _participationService.GetById(User.Identity.Name, packetFound.ParticipationId);

            if (packetFoundParticipation == null)
                return null;

            packetFound.Participation = packetFoundParticipation;

            return packetFound;
        }
    }
}


