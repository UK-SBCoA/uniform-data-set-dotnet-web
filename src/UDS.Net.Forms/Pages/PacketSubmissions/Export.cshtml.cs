using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Reflection;
using System.Text;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Overrides.CsvHelper;
using UDS.Net.Forms.Records;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

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

                WritePacketData(csv, packetSubmission, participant, packet);
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

                                WritePacketData(csv, packetSubmission, participant, packet);
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

        private void WritePacketData(CsvWriter csv, PacketSubmission packetSubmission, Participation participant, Packet packet)
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

                if (a3.Fields is A3FormFields normalA3)
                    csv.WriteRecord(normalA3);

                List<A3FamilyMemberFormFields> siblings;
                List<A3FamilyMemberFormFields> kids;

                if (a3.Fields is A3FormFields normalKids)
                {
                    siblings = normalKids.SiblingFormFields;
                    kids = normalKids.KidsFormFields;
                }
                else
                {
                    siblings = new List<A3FamilyMemberFormFields>();
                    kids = new List<A3FamilyMemberFormFields>();
                }

                // siblings
                foreach (var sibling in siblings)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                        {
                            csv.WriteField(prop.GetValue(sibling));
                        }
                    }
                }

                // kids
                foreach (var kid in kids)
                {
                    foreach (var prop in a3FamilyProps)
                    {
                        if (prop.Name != "FamilyMemberIndex")
                        {
                            csv.WriteField(prop.GetValue(kid));
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

    }
}

