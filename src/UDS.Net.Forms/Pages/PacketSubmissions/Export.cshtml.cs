using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Text;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.Exports;
using UDS.Net.Forms.Overrides.CsvHelper;
using UDS.Net.Forms.Records;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class ExportModel : PageModel
    {
        protected readonly IPacketService _packetService;
        protected readonly IParticipationService _participationService;
        private readonly IConfiguration _configuration;
        private readonly IVisitService _visitService;

        public bool Processed { get; set; } = false;

        public ExportModel(IPacketService packetService, IParticipationService participationService, IConfiguration configuration, IVisitService visitService)
        {
            _packetService = packetService;
            _participationService = participationService;
            _configuration = configuration;
            _visitService = visitService;

        }

        public async Task<IActionResult> OnGetAsync(int packetId)
        {
            if (packetId == 0)
                return NotFound();

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false, true));

            var packet = await _packetService.GetPacketWithForms(User.Identity?.Name, packetId);

            if (packet == null)
                return NotFound();

            var participant = await _participationService.GetById(User.Identity?.Name, packet.ParticipationId);
            if (participant == null)
                return NotFound();

            var packetSubmission = packet.Submissions.FirstOrDefault();
            if (packetSubmission == null)
                return NotFound();

            using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, true))
            {
                WriteHeader(csv, packetSubmission);

                await WritePacketDataAsync(csv, packetSubmission, participant, packet);
            }

            memoryStream.Position = 0;

            string filename = packetSubmission.ToVM().GetFileName(participant.LegacyId, packet.VISIT_DATE);

            Response.Headers["Content-Disposition"] = $"attachment; {filename}";
            return File(memoryStream, "text/csv", filename);
        }

        public async Task<IActionResult> OnPostExportMultiplePackets(List<int> packetId)
        {

            if (packetId == null || packetId.Count == 0)
                return NotFound();

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false, true));

            using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, true))
            {
                bool headerWritten = false;

                foreach (var id in packetId)
                {
                    var packet = await _packetService.GetPacketWithForms(User.Identity.Name, id);

                    if (packet != null)
                    {
                        var participant = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

                        var newPacketSubmission = new PacketSubmissionModel
                        {
                            PacketId = packet.Id,
                            SubmissionDate = DateTime.Now,
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Username"
                        };

                        packet.AddSubmission(newPacketSubmission.ToEntity());
                        await _packetService.Update(User.Identity.Name, packet);

                        if (packet.Submissions != null && packet.Submissions.Count > 0)
                        {
                            var packetSubmission = packet.Submissions
                                .OrderByDescending(s => s.SubmissionDate)
                                .FirstOrDefault();

                            if (packetSubmission != null)
                            {
                                packetSubmission.Forms = packet.Forms;

                                if (!headerWritten)
                                {
                                    WriteHeader(csv, packetSubmission);
                                    headerWritten = true;
                                }

                                await WritePacketDataAsync(csv, packetSubmission, participant, packet);
                                csv.NextRecord();
                            }
                        }
                    }
                }
            }
            memoryStream.Position = 0;

            string packetIdsExported = string.Join("-", packetId);
            string filename = $"UDS_Packets_{packetIdsExported}_{DateTime.UtcNow:yyyyMMdd}-uds.csv";

            // Sets a flag cookie so the Stimulus controller knows when the download is complete and can refresh the page.
            Response.Cookies.Append("udsPacketExportComplete", "true");
            Response.Headers["Content-Disposition"] = $"attachment; filename=\"{filename}\"";

            return File(memoryStream, "text/csv", filename);
        }

        private void WriteHeader(CsvWriter csv, PacketSubmission packetSubmission)
        {
            // ptid, adcid, visitnum, packet, formver, dssub, visit_date m/d/yyyy, initials, frmdatea1, initialsa1, langa1, modea1, rmreasa1
            csv.WriteHeader<CsvRecord>();

            var a1 = packetSubmission.Forms.Where(f => f.Kind == "A1").FirstOrDefault();
            var a1a = packetSubmission.Forms.Where(f => f.Kind == "A1a").FirstOrDefault();
            var a2 = packetSubmission.Forms.Where(f => f.Kind == "A2").FirstOrDefault();
            var a3 = packetSubmission.Forms.Where(f => f.Kind == "A3").FirstOrDefault();
            var a4 = packetSubmission.Forms.Where(f => f.Kind == "A4").FirstOrDefault();
            var a4a = packetSubmission.Forms.Where(f => f.Kind == "A4a").FirstOrDefault();
            var a5d2 = packetSubmission.Forms.Where(f => f.Kind == "A5D2").FirstOrDefault();
            var b1 = packetSubmission.Forms.Where(f => f.Kind == "B1").FirstOrDefault();
            var b3 = packetSubmission.Forms.Where(f => f.Kind == "B3").FirstOrDefault();
            var b4 = packetSubmission.Forms.Where(f => f.Kind == "B4").FirstOrDefault();
            var b5 = packetSubmission.Forms.Where(f => f.Kind == "B5").FirstOrDefault();
            var b6 = packetSubmission.Forms.Where(f => f.Kind == "B6").FirstOrDefault();
            var b7 = packetSubmission.Forms.Where(f => f.Kind == "B7").FirstOrDefault();
            var b8 = packetSubmission.Forms.Where(f => f.Kind == "B8").FirstOrDefault();
            var b9 = packetSubmission.Forms.Where(f => f.Kind == "B9").FirstOrDefault();
            var c2 = packetSubmission.Forms.Where(f => f.Kind == "C2").FirstOrDefault();
            var d1a = packetSubmission.Forms.Where(f => f.Kind == "D1a").FirstOrDefault();
            var d1b = packetSubmission.Forms.Where(f => f.Kind == "D1b").FirstOrDefault();

            var a4aProps = typeof(A4aTreatmentFormFields).GetProperties();
            var a3FamilyProps = typeof(A3FamilyMemberFormFields).GetProperties();

            if (a1 != null)
            {
                csv.WriteHeader<A1Record>();
                csv.WriteHeaderLowercase<A1FormFields>();
            }
            if (a1a != null)
            {
                csv.WriteHeader<A1aRecord>();
                csv.WriteHeaderLowercase<A1aFormFields>();
            }
            if (a2 != null)
            {
                csv.WriteHeader<A2Record>();
                csv.WriteHeaderLowercase<A2FormFields>();
            }
            if (a3 != null)
            {
                csv.WriteHeader<A3Record>();

                List<A3FamilyMemberFormFields> siblingFields;
                List<A3FamilyMemberFormFields> kidFields;

                csv.WriteHeaderLowercase<A3FormFields>();
                siblingFields = ((A3FormFields)a3.Fields).SiblingFormFields;
                kidFields = ((A3FormFields)a3.Fields).KidsFormFields;

                // Siblings
                foreach (var siblingField in siblingFields)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                            csv.WriteField($"sib{siblingField.FamilyMemberIndex}{prop.Name.ToLower()}");
                    }
                }

                // Kids
                foreach (var kidField in kidFields)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                            csv.WriteField($"kid{kidField.FamilyMemberIndex}{prop.Name.ToLower()}");
                    }
                }
            }
            if (a4 != null)
            {
                csv.WriteHeader<A4Record>();
                csv.WriteHeaderLowercase<A4GFormFields>();

                // hold 40 fields for rxnormids
                for (int i = 1; i <= 40; i++)
                {
                    csv.WriteField($"rxnormid{i}");
                }
            }
            if (a4a != null)
            {
                csv.WriteHeader<A4aRecord>();

                List<A4aTreatmentFormFields> treatments;

                csv.WriteHeaderLowercase<A4aFormFields>();
                treatments = ((A4aFormFields)a4a.Fields).TreatmentFormFields;
                foreach (var treatment in treatments)
                {
                    foreach (var prop in a4aProps)
                    {
                        if (prop.Name != "TreatmentIndex")
                        {
                            csv.WriteField($"{prop.Name.ToLower()}{treatment.TreatmentIndex}");
                        }
                    }
                }
            }
            if (a5d2 != null)
            {
                csv.WriteHeader<A5D2Record>();
                csv.WriteHeaderLowercase<A5D2FormFields>();
            }
            if (b1 != null)
            {
                csv.WriteHeader<B1Record>();
                csv.WriteHeaderLowercase<B1FormFields>();
            }
            if (b3 != null)
            {
                csv.WriteHeader<B3Record>();
                csv.WriteHeaderLowercase<B3FormFields>();
            }
            if (b4 != null)
            {
                csv.WriteHeader<B4Record>();
                csv.WriteHeaderLowercase<B4FormFields>();
            }
            if (b5 != null)
            {
                csv.WriteHeader<B5Record>();
                csv.WriteHeaderLowercase<B5FormFields>();
            }
            if (b6 != null)
            {
                csv.WriteHeader<B6Record>();
                csv.WriteHeaderLowercase<B6FormFields>();
            }
            if (b7 != null)
            {
                csv.WriteHeader<B7Record>();
                csv.WriteHeaderLowercase<B7FormFields>();
            }
            if (b8 != null)
            {
                csv.WriteHeader<B8Record>();
                csv.WriteHeaderLowercase<B8FormFields>();
            }
            if (b9 != null)
            {
                csv.WriteHeader<B9Record>();
                csv.WriteHeaderLowercase<B9FormFields>();
            }
            if (c2 != null)
            {
                csv.WriteHeader<C2Record>();
                csv.WriteHeaderLowercase<C2FormFields>();
            }
            if (d1a != null)
            {
                csv.WriteHeader<D1aRecord>();
                csv.WriteHeaderLowercase<D1aFormFields>();
            }
            if (d1b != null)
            {
                csv.WriteHeader<D1bRecord>();
                csv.WriteHeaderLowercase<D1bFormFields>();
            }

            csv.NextRecord(); // end of header row

        }


        private async Task WritePacketDataAsync(CsvWriter csv, PacketSubmission packetSubmission, Participation participant, Packet packet)
        {
            // Register custom converters globally.
            // https://joshclose.github.io/CsvHelper/examples/type-conversion/custom-type-converter/
            csv.Context.TypeConverterCache.AddConverter<bool>(new BooleanConverterOverride());
            csv.Context.TypeConverterCache.AddConverter<string>(new StringConverterOverride());

            var a1 = packetSubmission.Forms.Where(f => f.Kind == "A1").FirstOrDefault();
            var a1a = packetSubmission.Forms.Where(f => f.Kind == "A1a").FirstOrDefault();
            var a2 = packetSubmission.Forms.Where(f => f.Kind == "A2").FirstOrDefault();
            var a3 = packetSubmission.Forms.Where(f => f.Kind == "A3").FirstOrDefault();
            var a4 = packetSubmission.Forms.Where(f => f.Kind == "A4").FirstOrDefault();
            var a4a = packetSubmission.Forms.Where(f => f.Kind == "A4a").FirstOrDefault();
            var a5d2 = packetSubmission.Forms.Where(f => f.Kind == "A5D2").FirstOrDefault();
            var b1 = packetSubmission.Forms.Where(f => f.Kind == "B1").FirstOrDefault();
            var b3 = packetSubmission.Forms.Where(f => f.Kind == "B3").FirstOrDefault();
            var b4 = packetSubmission.Forms.Where(f => f.Kind == "B4").FirstOrDefault();
            var b5 = packetSubmission.Forms.Where(f => f.Kind == "B5").FirstOrDefault();
            var b6 = packetSubmission.Forms.Where(f => f.Kind == "B6").FirstOrDefault();
            var b7 = packetSubmission.Forms.Where(f => f.Kind == "B7").FirstOrDefault();
            var b8 = packetSubmission.Forms.Where(f => f.Kind == "B8").FirstOrDefault();
            var b9 = packetSubmission.Forms.Where(f => f.Kind == "B9").FirstOrDefault();
            var c2 = packetSubmission.Forms.Where(f => f.Kind == "C2").FirstOrDefault();
            var d1a = packetSubmission.Forms.Where(f => f.Kind == "D1a").FirstOrDefault();
            var d1b = packetSubmission.Forms.Where(f => f.Kind == "D1b").FirstOrDefault();
            var a4aProps = typeof(A4aTreatmentFormFields).GetProperties();
            var a3FamilyProps = typeof(A3FamilyMemberFormFields).GetProperties();

            var record = new CsvRecord(_configuration.GetSection("ADRC:Id").Value, participant, packet);


            csv.WriteRecord(record);

            if (a1 != null)
            {
                csv.WriteRecord(new A1Record(a1));

                if (a1.Fields is A1FormFields a1Fields)
                    csv.WriteRecord(a1Fields);

            }
            if (a1a != null)
            {
                csv.WriteRecord(new A1aRecord(a1a));

                if (a1a.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    csv.WriteRecord(new A1aFormFields());

                }
                else
                {
                    // if the form is included, export all the values
                    if (a1a.Fields is A1aFormFields normalA1a)
                        csv.WriteRecord(normalA1a);
                }
            }
            if (a2 != null)
            {
                csv.WriteRecord(new A2Record(a2));

                if (a2.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    csv.WriteRecord(new A2FormFields());
                }
                else
                {
                    if (a2.Fields is A2FormFields normalA2)
                        csv.WriteRecord(normalA2);
                }
            }
            if (a3 != null)
            {
                csv.WriteRecord(new A3Record(a3));

                Form? previousA3Base = null;

                A3FormFields? previousA3Fields = null;

                A3FormFields? currentA3Fields = a3.Fields as A3FormFields;

                //Create lists for siblings and kids by casting a3.fields data (IFormFields to A3FormFields)
                List<A3FamilyMemberFormFields> siblings = ((A3FormFields)a3.Fields).SiblingFormFields;
                List<A3FamilyMemberFormFields> kids = ((A3FormFields)a3.Fields).KidsFormFields;

                int countOfVisits = await _visitService.GetVisitCountByVersion(User.Identity!.Name!, packet.ParticipationId, "4.0.0");

                if (packet.VISITNUM >= countOfVisits && countOfVisits > 1)
                {
                    var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(User.Identity!.Name!, packet.ParticipationId, packet.VISITNUM - 1, "A3");

                    //Set previousA3Base
                    previousA3Base = previousVisit != null ? previousVisit.Forms.Where(f => f.Kind == "A3").FirstOrDefault() : null;

                    //Set previousA3Fields
                    previousA3Fields = previousA3Base != null ? previousA3Base.Fields as A3FormFields : null;
                }

                //If a previous form exists, compare and set codes for each input
                if (currentA3Fields != null && previousA3Fields != null)
                {
                    //Initialize change properties
                    currentA3Fields.NWINFPAR = 0;
                    currentA3Fields.NWINFSIB = 0;
                    currentA3Fields.NWINFKID = 0;

                    //Mother
                    //YOB
                    ExportObject momYOBExport = GetExportObject(previousA3Fields.MOMYOB, currentA3Fields.MOMYOB, 6666);
                    currentA3Fields.MOMYOB = momYOBExport.Value;
                    if (momYOBExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //AGE
                    ExportObject momDAGEExport = GetExportObject(previousA3Fields.MOMDAGE, currentA3Fields.MOMDAGE, 666);
                    currentA3Fields.MOMDAGE = momDAGEExport.Value;
                    if (momDAGEExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //ETPR
                    //Handle ETPR string type
                    int? previousMomETPR = int.TryParse(previousA3Fields.MOMETPR, out int previousMomETPRInt) ? previousMomETPRInt : null;
                    int? currentMomETPR = int.TryParse(currentA3Fields.MOMETPR, out int currentETPRInt) ? currentETPRInt : null;

                    ExportObject momETPRExport = GetExportObject(previousMomETPR, currentMomETPR, 66);
                    //Some properties are string? types and require ToString() to set the propery value
                    currentA3Fields.MOMETPR = momETPRExport.Value.ToString();
                    if (momETPRExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //ETSEC
                    //Handle ETSEC string type
                    int? previousMomETSEC = int.TryParse(previousA3Fields.MOMETSEC, out int previousMomETSECInt) ? previousMomETSECInt : null;
                    int? currentMomETSEC = int.TryParse(currentA3Fields.MOMETSEC, out int currentMomETSECInt) ? currentMomETSECInt : null;

                    ExportObject momETSECExport = GetExportObject(previousMomETSEC, currentMomETSEC, 66);
                    currentA3Fields.MOMETSEC = momETSECExport.Value.ToString();
                    if (momETSECExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //MOMMEVAL
                    ExportObject MOMMEVALExport = GetExportObject(previousA3Fields.MOMMEVAL, currentA3Fields.MOMMEVAL, 6);
                    currentA3Fields.MOMMEVAL = MOMMEVALExport.Value;
                    if (MOMMEVALExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //MOMAGEO
                    ExportObject MOMAGEOExport = GetExportObject(previousA3Fields.MOMAGEO, currentA3Fields.MOMAGEO, 6);
                    currentA3Fields.MOMAGEO = MOMAGEOExport.Value;
                    if (MOMAGEOExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //Father
                    //YOB
                    ExportObject dadYOBExport = GetExportObject(previousA3Fields.DADYOB, currentA3Fields.DADYOB, 6666);
                    currentA3Fields.DADYOB = dadYOBExport.Value;
                    if (dadYOBExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //AGE
                    ExportObject dadDAGEExport = GetExportObject(previousA3Fields.DADDAGE, currentA3Fields.DADDAGE, 666);
                    currentA3Fields.DADDAGE = dadDAGEExport.Value;
                    if (dadDAGEExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //ETPR
                    //Handle ETPR string type
                    int? previousDadETPR = int.TryParse(previousA3Fields.DADETPR, out int previousDadETPRInt) ? previousDadETPRInt : null;
                    int? currentDadETPR = int.TryParse(currentA3Fields.DADETPR, out int currentDadETPRInt) ? currentDadETPRInt : null;

                    ExportObject dadETPRExport = GetExportObject(previousDadETPR, currentDadETPR, 66);
                    currentA3Fields.DADETPR = dadETPRExport.Value.ToString();
                    if (dadETPRExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //ETSEC
                    //Handle ETSEC string type
                    int? previousDadETSEC = int.TryParse(previousA3Fields.DADETSEC, out int previousDadETSECInt) ? previousDadETSECInt : null;
                    int? currentDadETSEC = int.TryParse(currentA3Fields.DADETSEC, out int currentDadETSECInt) ? currentDadETSECInt : null;

                    ExportObject dadETSECExport = GetExportObject(previousDadETSEC, currentDadETSEC, 66);
                    currentA3Fields.DADETSEC = dadETSECExport.Value.ToString();
                    if (dadETSECExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //DADMEVAL
                    ExportObject DADMEVALExport = GetExportObject(previousA3Fields.DADMEVAL, currentA3Fields.DADMEVAL, 6);
                    currentA3Fields.DADMEVAL = DADMEVALExport.Value;
                    if (DADMEVALExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //DADAGEO
                    ExportObject DADAGEOExport = GetExportObject(previousA3Fields.DADAGEO, currentA3Fields.DADAGEO, 6);
                    currentA3Fields.DADAGEO = DADAGEOExport.Value;
                    if (DADAGEOExport.HasChanged) currentA3Fields.NWINFPAR = 1;

                    //SIBS (siblings count)
                    ExportObject sibsExport = GetExportObject(previousA3Fields.SIBS, currentA3Fields.SIBS, 66);
                    currentA3Fields.SIBS = sibsExport.Value;
                    if (sibsExport.HasChanged) currentA3Fields.NWINFSIB = 1;

                    //KIDS (kids count)
                    ExportObject kidsExport = GetExportObject(previousA3Fields.KIDS, currentA3Fields.KIDS, 66);
                    currentA3Fields.KIDS = kidsExport.Value;
                    if (kidsExport.HasChanged) currentA3Fields.NWINFKID = 1;

                    //Siblings
                    for (var siblingsIndex = 0; siblingsIndex < siblings.Count(); siblingsIndex++)
                    {
                        //YOB
                        ExportObject siblingsYOBExport = GetExportObject(previousA3Fields.SiblingFormFields[siblingsIndex].YOB, currentA3Fields.SiblingFormFields[siblingsIndex].YOB, 6666);
                        siblings[siblingsIndex].YOB = siblingsYOBExport.Value;
                        if (siblingsYOBExport.HasChanged) currentA3Fields.NWINFSIB = 1;

                        //AGD
                        ExportObject siblingsAGDExport = GetExportObject(previousA3Fields.SiblingFormFields[siblingsIndex].AGD, currentA3Fields.SiblingFormFields[siblingsIndex].AGD, 666);
                        siblings[siblingsIndex].AGD = siblingsAGDExport.Value;
                        if (siblingsAGDExport.HasChanged) currentA3Fields.NWINFSIB = 1;

                        //Handle ETPR string type
                        int? previousSibETPR = int.TryParse(previousA3Fields.SiblingFormFields[siblingsIndex].ETPR, out int previousSibETPRInt) ? previousSibETPRInt : null;
                        int? currentSibETPR = int.TryParse(currentA3Fields.SiblingFormFields[siblingsIndex].ETPR, out int currentSibETPRInt) ? currentSibETPRInt : null;
                        //ETPR
                        ExportObject siblingsETPRExport = GetExportObject(previousSibETPR, currentSibETPR, 66);
                        siblings[siblingsIndex].ETPR = siblingsETPRExport.Value.ToString();
                        if (siblingsETPRExport.HasChanged) currentA3Fields.NWINFSIB = 1;

                        //Handle ETSEC string type
                        int? previousSibETSEC = int.TryParse(previousA3Fields.SiblingFormFields[siblingsIndex].ETSEC, out int previousSibETSECInt) ? previousSibETSECInt : null;
                        int? currentSibETSEC = int.TryParse(currentA3Fields.SiblingFormFields[siblingsIndex].ETSEC, out int currentSibETSECInt) ? currentSibETSECInt : null;
                        //ETSEC
                        ExportObject siblingsETSECExport = GetExportObject(previousSibETSEC, currentSibETSEC, 66);
                        siblings[siblingsIndex].ETSEC = siblingsETSECExport.Value.ToString();
                        if (siblingsETSECExport.HasChanged) currentA3Fields.NWINFSIB = 1;

                        //MEVAL
                        ExportObject siblingsMEVALExport = GetExportObject(previousA3Fields.SiblingFormFields[siblingsIndex].MEVAL, currentA3Fields.SiblingFormFields[siblingsIndex].MEVAL, 6);
                        siblings[siblingsIndex].MEVAL = siblingsMEVALExport.Value;
                        if (siblingsMEVALExport.HasChanged) currentA3Fields.NWINFSIB = 1;

                        //AGO
                        ExportObject siblingsAGOExport = GetExportObject(previousA3Fields.SiblingFormFields[siblingsIndex].AGO, currentA3Fields.SiblingFormFields[siblingsIndex].AGO, 666);
                        siblings[siblingsIndex].AGO = siblingsAGOExport.Value;
                        if (siblingsAGOExport.HasChanged) currentA3Fields.NWINFSIB = 1;
                    };

                    //Kids
                    for (var kidsIndex = 0; kidsIndex < kids.Count(); kidsIndex++)
                    {
                        //YOB
                        ExportObject kidsYOBExport = GetExportObject(previousA3Fields.KidsFormFields[kidsIndex].YOB, currentA3Fields.KidsFormFields[kidsIndex].YOB, 6666);
                        kids[kidsIndex].YOB = kidsYOBExport.Value;
                        if (kidsYOBExport.HasChanged) currentA3Fields.NWINFKID = 1;

                        //AGD
                        ExportObject kidsAGDExport = GetExportObject(previousA3Fields.KidsFormFields[kidsIndex].AGD, currentA3Fields.KidsFormFields[kidsIndex].AGD, 666);
                        kids[kidsIndex].AGD = kidsYOBExport.Value;
                        if (kidsYOBExport.HasChanged) currentA3Fields.NWINFKID = 1;

                        //Handle ETPR string type
                        int? previousKidETPR = int.TryParse(previousA3Fields.KidsFormFields[kidsIndex].ETPR, out int previousKidETPRInt) ? previousKidETPRInt : null;
                        int? currentKidETPR = int.TryParse(currentA3Fields.KidsFormFields[kidsIndex].ETPR, out int currentKidETPRInt) ? currentKidETPRInt : null;
                        //ETPR
                        ExportObject kidsETPRExport = GetExportObject(previousKidETPR, currentKidETPR, 66);
                        kids[kidsIndex].ETPR = kidsETPRExport.Value.ToString();
                        if (kidsETPRExport.HasChanged) currentA3Fields.NWINFKID = 1;

                        //Handle ETSEC string type
                        int? previousETSEC = int.TryParse(previousA3Fields.KidsFormFields[kidsIndex].ETSEC, out int previousETSECInt) ? previousETSECInt : null;
                        int? currentETSEC = int.TryParse(currentA3Fields.KidsFormFields[kidsIndex].ETSEC, out int currentETSECInt) ? currentETSECInt : null;
                        //ETSEC
                        ExportObject kidsETSECExport = GetExportObject(previousETSEC, currentETSEC, 66);
                        kids[kidsIndex].ETSEC = kidsETSECExport.Value.ToString();
                        if (kidsETSECExport.HasChanged) currentA3Fields.NWINFKID = 1;

                        //MEVAL
                        ExportObject kidsMEVALExport = GetExportObject(previousA3Fields.KidsFormFields[kidsIndex].MEVAL, currentA3Fields.KidsFormFields[kidsIndex].MEVAL, 6);
                        kids[kidsIndex].MEVAL = kidsMEVALExport.Value;
                        if (kidsMEVALExport.HasChanged) currentA3Fields.NWINFSIB = 1;

                        //AGO
                        ExportObject kidsAGOExport = GetExportObject(previousA3Fields.KidsFormFields[kidsIndex].AGO, currentA3Fields.KidsFormFields[kidsIndex].AGO, 666);
                        kids[kidsIndex].AGO = kidsAGOExport.Value;
                        if (kidsAGOExport.HasChanged) currentA3Fields.NWINFSIB = 1;
                    };
                }

                //Loop through currentA3Fields props manually as csv.WriteRecord() does to set null when change property == 0
                if (currentA3Fields != null)
                {
                    foreach (var prop in currentA3Fields.GetType().GetProperties().Where(p => p.PropertyType == typeof(int?) || p.PropertyType == typeof(string)))
                    {
                        if (prop.Name == "SIBS")
                        {
                            csv.WriteField(currentA3Fields?.NWINFSIB == 0 ? null : prop.GetValue(currentA3Fields));
                        }
                        else if (prop.Name == "KIDS")
                        {
                            csv.WriteField(currentA3Fields?.NWINFKID == 0 ? null : prop.GetValue(currentA3Fields));
                        }
                        else
                        {
                            csv.WriteField(currentA3Fields?.NWINFPAR == 0 ? null : prop.GetValue(currentA3Fields));
                        }
                    }
                }

                //Write Sibling data
                foreach (var sibling in siblings)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                        {
                            //If NWINFSIB is 0, then the fields are nulled out
                            csv.WriteField(currentA3Fields?.NWINFSIB == 0 ? null : prop.GetValue(sibling));
                        }
                    }
                }

                //Write Kids data
                foreach (var kid in kids)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                        {
                            //If NWINFKID is 0, then the fields are nulled out
                            csv.WriteField(currentA3Fields?.NWINFKID == 0 ? null : prop.GetValue(kid));
                        }
                    }
                }
            }

            if (a4 != null)
            {
                csv.WriteRecord(new A4Record(a4));
                List<A4DFormFields> details;
                if (a4.Fields is A4GFormFields normalA4)
                {
                    csv.WriteRecord(normalA4);
                    details = normalA4.A4Ds.ToList();
                }
                else
                {
                    details = new List<A4DFormFields>();
                }

                // we do NOT already have a list of 40, size of this list is dynamic
                for (int i = 1; i <= 40; i++)
                {
                    if (details.Count >= i)
                        csv.WriteField(details[i - 1].RxNormId);
                    else
                        csv.WriteField(string.Empty);
                }
            }
            if (a4a != null)
            {
                csv.WriteRecord(new A4aRecord(a4a));

                List<A4aTreatmentFormFields> treatments;

                if (a4a.Fields is A4aFormFields normalA4a)
                {
                    csv.WriteRecord(normalA4a);
                    treatments = normalA4a.TreatmentFormFields.ToList();
                }
                else
                {
                    treatments = new List<A4aTreatmentFormFields>();
                }

                foreach (var treatment in treatments)
                {
                    foreach (var prop in a4aProps)
                    {
                        if (prop.Name != "TreatmentIndex")
                            csv.WriteField(prop.GetValue(treatment));
                    }
                }
            }
            if (a5d2 != null)
            {
                csv.WriteRecord(new A5D2Record(a5d2));
                Form? previousA5D2Base = null;

                A5D2FormFields? previousA5D2Fields = null;

                A5D2FormFields? currentA5D2Fields = a5d2.Fields as A5D2FormFields;

                int countOfVisits = await _visitService.GetVisitCountByVersion(User.Identity!.Name!, packet.ParticipationId, "4.0.0");

                if (packet.VISITNUM >= countOfVisits && countOfVisits > 1)
                {
                    var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(User.Identity!.Name!, packet.ParticipationId, packet.VISITNUM - 1, "A5D2");

                    //Set previousA5D2Base
                    previousA5D2Base = previousVisit != null ? previousVisit.Forms.Where(f => f.Kind == "A5D2").FirstOrDefault() : null;

                    //Set previousA5D2Fields
                    previousA5D2Fields = previousA5D2Base != null ? previousA5D2Base.Fields as A5D2FormFields : null;
                }
                //If a previous form exists, compare and set codes for each input
                if (currentA5D2Fields != null && previousA5D2Fields != null)
                {
                    var encodedFollowUpFields = A5D2FormFields.EncodedFollowUpVariables();

                    var fields = typeof(A5D2FormFields)
                        .GetProperties()
                        .Where(p => encodedFollowUpFields.Contains(p.Name));

                    foreach (var field in fields)
                    {
                        var previousValue = (int?)field.GetValue(previousA5D2Fields);
                        var currentValue = (int?)field.GetValue(currentA5D2Fields);
                        var result = GetExportObject(previousValue, currentValue, 777);
                        field.SetValue(currentA5D2Fields, result.Value);
                    }
                }
                if (a5d2.Fields is A5D2FormFields normalA5D2)
                    csv.WriteRecord(normalA5D2);
            }
            if (b1 != null)
            {
                csv.WriteRecord(new B1Record(b1));

                // write remaining form values
                if (b1.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    csv.WriteRecord(new B1FormFields());
                }
                else
                {
                    // if the form is included, export all the values
                    if (b1.Fields is B1FormFields normalB1)
                        csv.WriteRecord(normalB1);
                }
            }
            if (b3 != null)
            {
                csv.WriteRecord(new B3Record(b3));

                // write remaining form values
                if (b3.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    csv.WriteRecord(new B3FormFields());

                }
                else
                {
                    // if the form is included, export all the values
                    if (b3.Fields is B3FormFields normalB3)
                        csv.WriteRecord(normalB3);
                }
            }
            if (b4 != null)
            {
                csv.WriteRecord(new B4Record(b4));
                if (b4.Fields is B4FormFields normalB4)
                    csv.WriteRecord(normalB4);
            }
            if (b5 != null)
            {
                csv.WriteRecord(new B5Record(b5));

                if (b5.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    csv.WriteRecord(new B5FormFields());
                }
                else
                {
                    // if the form is included, export all the values
                    if (b5.Fields is B5FormFields normalB5)
                        csv.WriteRecord(normalB5);
                }
            }
            if (b6 != null)
            {
                csv.WriteRecord(new B6Record(b6));

                // write remaining form values
                if (b6.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    csv.WriteRecord(new B6FormFields());
                }
                else
                {
                    // if the form is included, export all the values
                    if (b6.Fields is B6FormFields normalB6)
                        csv.WriteRecord(normalB6);
                }
            }
            if (b7 != null)
            {
                // write header values
                csv.WriteRecord(new B7Record(b7));

                // write remaining form values
                if (b7.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    csv.WriteRecord(new B7FormFields());
                }
                else
                {
                    // if the form is included, export all the values
                    if (b7.Fields is B7FormFields normalB7)
                        csv.WriteRecord(normalB7);
                }
            }
            if (b8 != null)
            {
                csv.WriteRecord(new B8Record(b8));
                if (b8.Fields is B8FormFields normalB8)
                    csv.WriteRecord(normalB8);
            }
            if (b9 != null)
            {
                csv.WriteRecord(new B9Record(b9));
                Form? previousB9Base = null;

                B9FormFields? previousB9Fields = null;

                B9FormFields? currentB9Fields = b9.Fields as B9FormFields;

                int countOfVisits = await _visitService.GetVisitCountByVersion(User.Identity!.Name!, packet.ParticipationId, "4.0.0");

                if (packet.VISITNUM >= countOfVisits && countOfVisits > 1)
                {
                    var previousVisit = await _visitService.GetWithFormByParticipantAndVisitNumber(User.Identity!.Name!, packet.ParticipationId, packet.VISITNUM - 1, "B9");

                    //Set previousB9Base
                    previousB9Base = previousVisit != null ? previousVisit.Forms.Where(f => f.Kind == "B9").FirstOrDefault() : null;

                    //Set previousB9Fields
                    previousB9Fields = previousB9Base != null ? previousB9Base.Fields as B9FormFields : null;
                }
                //If a previous form exists, compare and set codes for each input
                if (currentB9Fields != null && previousB9Fields != null)
                {
                    var encodedFollowUpFields = B9FormFields.EncodedFollowUpVariables();

                    var fields = typeof(B9FormFields)
                        .GetProperties()
                        .Where(p => encodedFollowUpFields.Contains(p.Name));

                    foreach (var field in fields)
                    {
                        var previousValue = (int?)field.GetValue(previousB9Fields);
                        var currentValue = (int?)field.GetValue(currentB9Fields);
                        var result = GetExportObject(previousValue, currentValue, 777);
                        field.SetValue(currentB9Fields, result.Value);
                    }
                }
                if (b9.Fields is B9FormFields normalB9)
                    csv.WriteRecord(normalB9);
            }
            if (c2 != null)
            {
                csv.WriteRecord(new C2Record(c2));
                if (c2.Fields is C2FormFields normalC2)
                    csv.WriteRecord(normalC2);
            }
            if (d1a != null)
            {
                csv.WriteRecord(new D1aRecord(d1a));
                if (d1a.Fields is D1aFormFields normalD1a)
                    csv.WriteRecord(normalD1a);
            }
            if (d1b != null)
            {
                csv.WriteRecord(new D1bRecord(d1b));
                if (d1b.Fields is D1bFormFields normalD1b)
                    csv.WriteRecord(normalD1b);
            }

        } // writer flushed automatically here

        private ExportObject GetExportObject(int? previousValue, int? currentValue, int code)
        {
            ExportObject newExportValue = new() { HasChanged = false };

            if (previousValue == null && currentValue == null)
            {
                newExportValue.Value = null;
                return newExportValue;
            }

            if (previousValue == currentValue)
            {
                newExportValue.Value = code;
                return newExportValue;
            }

            newExportValue.Value = currentValue;
            newExportValue.HasChanged = true;

            return newExportValue;
        }
    }
}

