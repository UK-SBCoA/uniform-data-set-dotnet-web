using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Reflection;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.Records;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class ExportModel : PageModel
    {
        protected readonly IPacketService _packetService;
        protected readonly IParticipationService _participationService;

        public bool Processed { get; set; } = false;

        public ExportModel(IPacketService packetService, IParticipationService participationService)
        {
            _packetService = packetService;
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGetAsync(int packetId)
        {
            if (packetId == 0)
                return NotFound();

            // TODO use temporal tables to get the data at that point in time of the submission and eventually use the packet submission id here
            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, packetId);

            var participant = await _participationService.GetById(User.Identity.Name, packet.ParticipationId);

            if (packet != null && packet.Submissions != null && packet.Submissions.Count() > 0)
            {
                var packetSubmission = packet.Submissions.OrderByDescending(s => s.SubmissionDate).FirstOrDefault();

                var vm = packetSubmission.ToVM(); // converting to vm to get filename
                string filename = vm.GetFileName(participant.LegacyId, packet.VISIT_DATE);

                var memoryStream = new MemoryStream();

                var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);

                using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, true))
                {
                    var record = new CsvRecord(packetSubmission.ADRCId, participant, packet);
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

                    // ptid, adcid, visitnum, packet, formver, dssub, visit_date m/d/yyyy, initials, frmdatea1, initialsa1, langa1, modea1, rmreasa1
                    csv.WriteHeader<CsvRecord>();

                    if (a1 != null)
                    {
                        csv.WriteHeader<A1Record>();
                        WriteFormFields(new A1FormFields(), csv);
                    }
                    if (a1a != null)
                    {
                        csv.WriteHeader<A1aRecord>();
                        WriteFormFields(new A1aFormFields(), csv);
                    }
                    if (a2 != null)
                    {
                        csv.WriteHeader<A2Record>();
                        WriteFormFields(new A2FormFields(), csv);
                    }
                    if (a3 != null)
                    {
                        csv.WriteHeader<A3Record>();
                        WriteFormFields(new A3FormFields(), csv);

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
                        WriteFormFields(new A4GFormFields(), csv);

                        // we need to hold 40 fields for rxnormids
                        for (int i = 1; i <= 40; i++)
                        {
                            csv.WriteField($"rxnormid{i}");
                        }
                    }
                    if (a4a != null)
                    {
                        csv.WriteHeader<A4aRecord>();
                        WriteFormFields(new A4aFormFields(), csv);

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
                        WriteFormFields(new A5D2FormFields(), csv);
                    }
                    if (b1 != null)
                    {
                        csv.WriteHeader<B1Record>();
                        WriteFormFields(new B1FormFields(), csv);
                    }
                    if (b3 != null)
                    {
                        csv.WriteHeader<B3Record>();
                        WriteFormFields(new B3FormFields(), csv);
                    }
                    if (b4 != null)
                    {
                        csv.WriteHeader<B4Record>();
                        WriteFormFields(new B4FormFields(), csv);
                    }
                    if (b5 != null)
                    {
                        csv.WriteHeader<B5Record>();
                        WriteFormFields(new B5FormFields(), csv);
                    }
                    if (b6 != null)
                    {
                        csv.WriteHeader<B6Record>();
                        WriteFormFields(new B6FormFields(), csv);
                    }
                    if (b7 != null)
                    {
                        csv.WriteHeader<B7Record>();
                        WriteFormFields(new B7FormFields(), csv);
                    }
                    if (b8 != null)
                    {
                        csv.WriteHeader<B8Record>();
                        WriteFormFields(new B8FormFields(), csv);
                    }
                    if (b9 != null)
                    {
                        csv.WriteHeader<B9Record>();
                        WriteFormFields(new B9FormFields(), csv);
                    }
                    if (c2 != null)
                    {
                        csv.WriteHeader<C2Record>();
                        WriteFormFields(new C2FormFields(), csv);
                    }
                    if (d1a != null)
                    {
                        csv.WriteHeader<D1aRecord>();
                        WriteFormFields(new D1aFormFields(), csv);
                    }
                    if (d1b != null)
                    {
                        csv.WriteHeader<D1bRecord>();
                        WriteFormFields(new D1bFormFields(), csv);
                    }

                    csv.NextRecord(); // end of header row

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
                        csv.WriteRecord(a1aRecord);
                        csv.WriteRecord((A1aFormFields)a1a.Fields);
                    }
                    if (a2 != null)
                    {
                        var a2Record = new A2Record(a2);
                        csv.WriteRecord(a2Record);
                        csv.WriteRecord((A2FormFields)a2.Fields);
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
                        csv.WriteRecord(b1Record);
                        csv.WriteRecord((B1FormFields)b1.Fields);
                    }
                    if (b3 != null)
                    {
                        var b3Record = new B3Record(b3);
                        csv.WriteRecord(b3Record);
                        csv.WriteRecord((B3FormFields)b3.Fields);
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
                        csv.WriteRecord(b5Record);
                        csv.WriteRecord((B5FormFields)b5.Fields);
                    }
                    if (b6 != null)
                    {
                        var b6Recrod = new B6Record(b6);
                        csv.WriteRecord(b6Recrod);
                        csv.WriteRecord((B6FormFields)b6.Fields);
                    }
                    if (b7 != null)
                    {
                        var b7Record = new B7Record(b7);
                        csv.WriteRecord(b7Record);
                        csv.WriteRecord((B7FormFields)b7.Fields);
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


                Processed = true;

                memoryStream.Position = 0;
                Response.Headers["Content-Disposition"] = $"attachment; {filename}";
                return File(memoryStream, "text/csv", filename);
            }
            return null;
        }

        private void WriteFormFields<T>(T formFields, CsvWriter csv)
        {
            foreach (var property in typeof(T).GetProperties())
            {

                string propertyName = property.Name.ToLower();

                csv.WriteField(propertyName);
            }
        }
    }
}

