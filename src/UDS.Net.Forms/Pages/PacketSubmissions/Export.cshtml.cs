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
        protected readonly IVisitService _visitService;
        protected readonly IPacketSubmissionService _packetSubmissionService;
        protected readonly IParticipationService _participationService;

        public bool Processed { get; set; } = false;

        public ExportModel(IVisitService visitService, IPacketSubmissionService packetSubmissionService, IParticipationService participationService)
        {
            _visitService = visitService;
            _packetSubmissionService = packetSubmissionService;
            _participationService = participationService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
                return NotFound();

            // TODO use temporal tables to get the data at that point in time of the submission
            var packetSubmission = await _packetSubmissionService.GetPacketSubmissionWithForms(User.Identity.Name, id);

            var visit = await _visitService.GetById(User.Identity.Name, packetSubmission.VisitId);

            var participant = await _participationService.GetById(User.Identity.Name, visit.ParticipationId);

            var vm = packetSubmission.ToVM(); // converting to vm to get filename
            string filename = vm.GetFileName(participant.LegacyId, visit.VISIT_DATE);

            var memoryStream = new MemoryStream();

            var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);

            using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, true))
            {
                var record = new CsvRecord(packetSubmission.ADRCId, participant, visit);
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
                    csv.WriteHeader<A1FormFields>();
                }
                if (a1a != null)
                {
                    csv.WriteHeader<A1aRecord>();
                    csv.WriteHeader<A1aFormFields>();
                }
                if (a2 != null)
                {
                    csv.WriteHeader<A2Record>();
                    csv.WriteHeader<A2FormFields>();
                }
                if (a3 != null)
                {
                    csv.WriteHeader<A3Record>();
                    csv.WriteHeader<A3FormFields>();

                    // siblings
                    var siblingFields = ((A3FormFields)a3.Fields).SiblingFormFields; // we always have a list of 20 siblings
                    foreach (var siblingField in siblingFields)
                    {
                        foreach (var prop in a3FamilyProps)
                        {
                            if (prop.Name != "FamilyMemberIndex")
                                csv.WriteField($"SIB{siblingField.FamilyMemberIndex}{prop.Name}");
                        }
                    }
                    // kids
                    var kidFields = ((A3FormFields)a3.Fields).KidsFormFields; // we always have a list of 15 children
                    foreach (var kidField in kidFields)
                    {
                        foreach (var prop in a3FamilyProps)
                        {
                            if (prop.Name != "FamilyMemberIndex")
                                csv.WriteField($"KID{kidField.FamilyMemberIndex}{prop.Name}");
                        }
                    }
                }
                if (a4 != null)
                {
                    csv.WriteHeader<A4Record>();
                    csv.WriteHeader<A4GFormFields>();

                    // we need to hold 40 fields for rxnormids
                    for (int i = 1; i <= 40; i++)
                    {
                        csv.WriteField($"rxnormid{i}");
                    }
                }
                if (a4a != null)
                {
                    csv.WriteHeader<A4aRecord>();
                    csv.WriteHeader<A4aFormFields>();

                    var treatments = ((A4aFormFields)a4a.Fields).TreatmentFormFields; // we always have a list of count 8

                    foreach (var treatment in treatments)
                    {
                        foreach (var prop in a4aProps)
                        {
                            if (prop.Name != "TreatmentIndex")
                            {
                                csv.WriteField($"{prop.Name}{treatment.TreatmentIndex}");
                            }
                        }
                    }
                }
                if (a5d2 != null)
                {
                    csv.WriteHeader<A5D2Record>();
                    csv.WriteHeader<A5D2FormFields>();
                }
                if (b1 != null)
                {
                    csv.WriteHeader<B1Record>();
                    csv.WriteHeader<B1FormFields>();
                }
                if (b3 != null)
                {
                    csv.WriteHeader<B3Record>();
                    csv.WriteHeader<B3FormFields>();
                }
                if (b4 != null)
                {
                    csv.WriteHeader<B4Record>();
                    csv.WriteHeader<B4FormFields>();
                }
                if (b5 != null)
                {
                    csv.WriteHeader<B5Record>();
                    csv.WriteHeader<B5FormFields>();
                }
                if (b6 != null)
                {
                    csv.WriteHeader<B6Record>();
                    csv.WriteHeader<B6FormFields>();
                }
                if (b7 != null)
                {
                    csv.WriteHeader<B7Record>();
                    csv.WriteHeader<B7FormFields>();
                }
                if (b8 != null)
                {
                    csv.WriteHeader<B8Record>();
                    csv.WriteHeader<B8FormFields>();
                }
                if (b9 != null)
                {
                    csv.WriteHeader<B9Record>();
                    csv.WriteHeader<B9FormFields>();
                }
                if (c2 != null)
                {
                    csv.WriteHeader<C2Record>();
                    csv.WriteHeader<C2FormFields>();
                }
                if (d1a != null)
                {
                    csv.WriteHeader<D1aRecord>();
                    csv.WriteHeader<D1aFormFields>();
                }
                if (d1b != null)
                {
                    csv.WriteHeader<D1bRecord>();
                    csv.WriteHeader<D1bFormFields>();
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
    }
}

