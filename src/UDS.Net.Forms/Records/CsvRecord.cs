using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record CsvRecord(string adcid, Participation participation, Visit visit)
    {
        internal Participation participation { get; init; }
        internal Visit visit { get; init; }

        [Index(0)]
        [Name("ptid")]
        public string PTID { get; init; } = participation.LegacyId;

        [Index(1)]
        [Name("adcid")]
        public string adcid { get; init; } = adcid;

        [Index(2)]
        [Name("visitnum")]
        public int Visitnum { get; init; } = visit.VISITNUM;

        [Index(3)]
        [Name("packet")]
        public string Packet { get; init; } = visit.PACKET.ToString();

        [Index(4)]
        [Name("formver")]
        public string FormVer { get; init; } = "4";

        [Index(6)]
        [Name("visitdate")]
        public string VisitDate { get; init; } = visit.VISIT_DATE.ToString(RecordConstants.dateFormatString);
    }
}

