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
        public IActionResult OnPost()
        {


            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPostView()
        {
            if (ErrorFileUpload == null)
            {
                return NotFound("Error upload file not found");
            }
            //TODO impliment ParseErrorFile as service method. The service file does not have a namespace for the asp.net http? 
            //Start ParseErrorFile method

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

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


