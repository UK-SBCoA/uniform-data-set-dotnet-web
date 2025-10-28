using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Records;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.DomainModels;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Overrides.CsvHelper;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class ExportModel : PageModel
    {
        protected readonly IPacketService _packetService;
        protected readonly IParticipationService _participationService;
        private readonly IConfiguration _configuration;

        public bool Processed { get; set; } = false;

        public ExportModel(IPacketService packetService, IParticipationService participationService, IConfiguration configuration)
        {
            _packetService = packetService;
            _participationService = participationService;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(int packetId)
        {
            if (packetId == 0)
                return NotFound();

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false, true));
            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, packetId);
            var participant = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);
            var packetSubmission = packet.Submissions.OrderByDescending(s => s.SubmissionDate).FirstOrDefault();

            using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, true))
            {
                // Register custom converters globally.
                // https://joshclose.github.io/CsvHelper/examples/type-conversion/custom-type-converter/
                csv.Context.TypeConverterCache.AddConverter<bool>(new BooleanConverterOverride());
                csv.Context.TypeConverterCache.AddConverter<string>(new StringConverterOverride());

                WriteHeader(csv, packetSubmission);

                WritePacketData(csv, packetSubmission, participant, packet);
            }

            memoryStream.Position = 0;

            var vm = packet.Submissions.OrderByDescending(s => s.SubmissionDate).First().ToVM();
            string filename = vm.GetFileName(participant.LegacyId, packet.VISIT_DATE);

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

                // Register custom converters globally.
                // https://joshclose.github.io/CsvHelper/examples/type-conversion/custom-type-converter/
                csv.Context.TypeConverterCache.AddConverter<bool>(new BooleanConverterOverride());
                csv.Context.TypeConverterCache.AddConverter<string>(new StringConverterOverride());
                foreach (var id in packetId)
                {
                    var packet = await _packetService.GetPacketWithForms(User.Identity.Name, id);
                    var participant = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);
                    var packetSubmission = packet.Submissions.OrderByDescending(s => s.SubmissionDate).FirstOrDefault();

                    // Create a new submission if none exist
                    var newPacketSubmission = new PacketSubmissionModel
                    {
                        PacketId = packet.Id,
                        SubmissionDate = DateTime.Now,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = User.Identity.IsAuthenticated ? User.Identity.Name : "Username"
                    };

                    packet.AddSubmission(newPacketSubmission.ToEntity());

                    await _packetService.Update(User.Identity.Name, packet);

                    var updatedPacket = await _packetService.GetPacketWithForms(User.Identity.Name, packet.Id); // get updated packet
                    packetSubmission = updatedPacket.Submissions.OrderByDescending(s => s.SubmissionDate).FirstOrDefault();
                    if (packetSubmission != null)
                    {
                        packetSubmission.Forms = updatedPacket.Forms;
                    }

                    if (!headerWritten)
                    {
                        if (packetSubmission != null)
                        {
                            WriteHeader(csv, packetSubmission);
                            headerWritten = true;
                        }
                    }
                    if (packetSubmission != null)
                    {
                        WritePacketData(csv, packetSubmission, participant, packet);
                    }
                    csv.NextRecord();
                }
            }
            memoryStream.Position = 0;

            string packetIdsExported = string.Join("-", packetId);
            string filename = $"UDS_Packets_{packetIdsExported}_{DateTime.UtcNow:yyyyMMdd}-uds.csv";

            // Sets a flag cookie so the Stimulus controller knows when the download is complete and can refresh the page.
            Response.Cookies.Append("downloadComplete", "true");
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
                csv.WriteHeaderLowercase<A3FormFields>();

                // siblings
                var siblingFields = ((A3FormFields)a3.Fields).SiblingFormFields; // we always have a list of 20 siblings
                foreach (var siblingField in siblingFields)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                            csv.WriteField($"sib{siblingField.FamilyMemberIndex}{prop.Name.ToLower()}");
                    }
                }
                // kids
                var kidFields = ((A3FormFields)a3.Fields).KidsFormFields; // we always have a list of 15 children
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

                // we need to hold 40 fields for rxnormids
                for (int i = 1; i <= 40; i++)
                {
                    csv.WriteField($"rxnormid{i}");
                }
            }
            if (a4a != null)
            {
                csv.WriteHeader<A4aRecord>();
                csv.WriteHeaderLowercase<A4aFormFields>();

                var treatments = ((A4aFormFields)a4a.Fields).TreatmentFormFields; // we always have a list of count 8

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

        private void WritePacketData(CsvWriter csv, PacketSubmission packetSubmission, Participation participant, Packet packet)
        {
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
                var a1Record = new A1Record(a1);
                csv.WriteRecord(a1Record);
                csv.WriteRecord((A1FormFields)a1.Fields);
            }
            if (a1a != null)
            {
                var a1aRecord = new A1aRecord(a1a);

                // write header values
                csv.WriteRecord(a1aRecord);

                // write remaining form values
                if (a1a.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    // If the form is not completed, everything exported should be null
                    var a1aFormFieldsProps = typeof(A1aFormFields).GetProperties().Where(p => !Enum.TryParse(p.Name, true, out IgnoredFormFieldProps ignoredFormFieldProps));

                    foreach (var prop in a1aFormFieldsProps)
                    {
                        csv.WriteField(null);
                    }
                }
                else
                {
                    // if the form is included, export all the values
                    csv.WriteRecord((A1aFormFields)a1a.Fields);
                }
            }
            if (a2 != null)
            {
                var a2Record = new A2Record(a2);
                csv.WriteRecord(a2Record);

                if (a2.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    var a2FormFieldsProps = typeof(A2FormFields).GetProperties().Where(p => !Enum.TryParse(p.Name, true, out IgnoredFormFieldProps ignoredFormFieldProps));

                    foreach (var prop in a2FormFieldsProps)
                    {
                        csv.WriteField(null);
                    }
                }
                else
                {
                    // if the form is included, export all the values
                    csv.WriteRecord((A2FormFields)a2.Fields);
                }
            }
            if (a3 != null)
            {
                var a3Record = new A3Record(a3);
                csv.WriteRecord(a3Record);
                csv.WriteRecord((A3FormFields)a3.Fields);

                // siblings
                var siblings = ((A3FormFields)a3.Fields).SiblingFormFields;
                foreach (var sibling in siblings)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                        {
                            var v = prop.GetValue(sibling, null);
                            csv.WriteField(v);
                        }
                    }
                }
                var kids = ((A3FormFields)a3.Fields).KidsFormFields;
                foreach (var kid in kids)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                        {
                            var v = prop.GetValue(kid, null);
                            csv.WriteField(v);
                        }
                    }
                }
            }
            if (a4 != null)
            {
                var a4Record = new A4Record(a4);

                csv.WriteRecord(a4Record);
                csv.WriteRecord((A4GFormFields)a4.Fields);

                var details = ((A4GFormFields)a4.Fields).A4Ds.ToArray(); // we do NOT already have a list of 40, size of this list is dynamic
                for (int i = 1; i <= 40; i++)
                {
                    if (details.Count() >= i)
                        csv.WriteField(details[i - 1].RxNormId);
                    else
                        csv.WriteField(string.Empty);
                }
            }
            if (a4a != null)
            {
                var a4aRecord = new A4aRecord(a4a);

                csv.WriteRecord(a4aRecord);
                csv.WriteRecord((A4aFormFields)a4a.Fields);

                var treatments = ((A4aFormFields)a4a.Fields).TreatmentFormFields;
                foreach (var treatment in treatments)
                {
                    foreach (var prop in a4aProps)
                    {
                        if (prop.Name != "TreatmentIndex")
                        {
                            var v = prop.GetValue(treatment, null);
                            csv.WriteField(v);
                        }
                    }
                }
            }
            if (a5d2 != null)
            {
                var a5d2Record = new A5D2Record(a5d2);
                csv.WriteRecord(a5d2Record);
                csv.WriteRecord((A5D2FormFields)a5d2.Fields);
            }
            if (b1 != null)
            {
                var b1Record = new B1Record(b1);

                // write header values
                csv.WriteRecord(b1Record);

                // write remaining form values
                if (b1.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    var b1FormFieldsProps = typeof(B1FormFields).GetProperties().Where(p => !Enum.TryParse(p.Name, true, out IgnoredFormFieldProps ignoredFormFieldProps));

                    foreach (var prop in b1FormFieldsProps)
                    {
                        csv.WriteField(null);
                    }
                }
                else
                {
                    // if the form is included, export all the values
                    csv.WriteRecord((B1FormFields)b1.Fields);
                }
            }
            if (b3 != null)
            {
                var b3Record = new B3Record(b3);

                // write header values
                csv.WriteRecord(b3Record);

                // write remaining form values
                if (b3.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    // If the form is not completed, everything exported should be null
                    var b3FormFieldsProps = typeof(B3FormFields).GetProperties().Where(p => !Enum.TryParse(p.Name, true, out IgnoredFormFieldProps ignoredFormFieldProps));

                    foreach (var prop in b3FormFieldsProps)
                    {
                        csv.WriteField(null);
                    }
                }
                else
                {
                    // if the form is included, export all the values
                    csv.WriteRecord((B3FormFields)b3.Fields);
                }
            }
            if (b4 != null)
            {
                var b4Record = new B4Record(b4);
                csv.WriteRecord(b4Record);
                csv.WriteRecord((B4FormFields)b4.Fields);
            }
            if (b5 != null)
            {
                var b5Record = new B5Record(b5);

                // write header values
                csv.WriteRecord(b5Record);

                // write remaining form values
                if (b5.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    var b5FormFieldsProps = typeof(B5FormFields).GetProperties().Where(p => !Enum.TryParse(p.Name, true, out IgnoredFormFieldProps ignoredFormFieldProps));

                    foreach (var prop in b5FormFieldsProps)
                    {
                        csv.WriteField(null);
                    }
                }
                else
                {
                    // if the form is included, export all the values
                    csv.WriteRecord((B5FormFields)b5.Fields);
                }
            }
            if (b6 != null)
            {
                var b6Record = new B6Record(b6);

                // write header values
                csv.WriteRecord(b6Record);

                // write remaining form values
                if (b6.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    var b6FormFieldsProps = typeof(B6FormFields).GetProperties().Where(p => !Enum.TryParse(p.Name, true, out IgnoredFormFieldProps ignoredFormFieldProps));

                    foreach (var prop in b6FormFieldsProps)
                    {
                        csv.WriteField(null);
                    }
                }
                else
                {
                    // if the form is included, export all the values
                    csv.WriteRecord((B6FormFields)b6.Fields);
                }
            }
            if (b7 != null)
            {
                var b7Record = new B7Record(b7);

                // write header values
                csv.WriteRecord(b7Record);

                // write remaining form values
                if (b7.MODE == Services.Enums.FormMode.NotCompleted)
                {
                    var b7FormFieldsProps = typeof(B7FormFields).GetProperties().Where(p => !Enum.TryParse(p.Name, true, out IgnoredFormFieldProps ignoredFormFieldProps));

                    foreach (var prop in b7FormFieldsProps)
                    {
                        csv.WriteField(null);
                    }
                }
                else
                {
                    // if the form is included, export all the values
                    csv.WriteRecord((B7FormFields)b7.Fields);
                }
            }
            if (b8 != null)
            {
                var b8Record = new B8Record(b8);
                csv.WriteRecord(b8Record);
                csv.WriteRecord((B8FormFields)b8.Fields);
            }
            if (b9 != null)
            {
                var b9Record = new B9Record(b9);
                csv.WriteRecord(b9Record);
                csv.WriteRecord((B9FormFields)b9.Fields);
            }
            if (c2 != null)
            {
                var c2Record = new C2Record(c2);
                csv.WriteRecord(c2Record);
                csv.WriteRecord((C2FormFields)c2.Fields);
            }
            if (d1a != null)
            {
                var d1aRecord = new D1aRecord(d1a);
                csv.WriteRecord(d1aRecord);
                csv.WriteRecord((D1aFormFields)d1a.Fields);
            }
            if (d1b != null)
            {
                var d1bRecord = new D1bRecord(d1b);
                csv.WriteRecord(d1bRecord);
                csv.WriteRecord((D1bFormFields)d1b.Fields);
            }

        } // writer flushed automatically here    

    }
}

