using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Models.Exports
{
    public class MilestoneRecord
    {
        public string PACKET { get; set; } = "M";
        public string FORMID { get; set; } = "M1";
        public int FORMVER { get; set; } = 3;

        public string ADCID { get; set; }
        public string PTID { get; set; }

        public int? VISITMO { get; set; }
        public int? VISITDAY { get; set; }
        public int? VISITYR { get; set; }

        public string VISITNUM { get; set; } = "";
        public string INITIALS { get; set; }

        public int? CHANGEMO { get; set; }
        public int? CHANGEDY { get; set; }
        public int? CHANGEYR { get; set; }

        public int? PROTOCOL { get; set; }
        public int? ACONSENT { get; set; }
        public int? RECOGIM { get; set; }
        public int? REPHYILL { get; set; }
        public int? REREFUSE { get; set; }
        public int? RENAVAIL { get; set; }
        public int? RENURSE { get; set; }
        public int? NURSEMO { get; set; }
        public int? NURSEDY { get; set; }
        public int? NURSEYR { get; set; }
        public int? REJOIN { get; set; }
        public int? FTLDDISC { get; set; }
        public int? FTLDREAS { get; set; }
        public string? FTLDREAX { get; set; }
        public int? DECEASED { get; set; }
        public int? DISCONT { get; set; }
        public int? DEATHMO { get; set; }
        public int? DEATHDY { get; set; }
        public int? DEATHYR { get; set; }
        public int? AUTOPSY { get; set; }
        public int? DISCMO { get; set; }
        public int? DISCDAY { get; set; }
        public int? DISCYR { get; set; }
        public int? DROPREAS { get; set; }

        public MilestoneRecord(UDS.Net.Services.DomainModels.Milestone m, string initials, string adcid)
        {
            PTID = m.Participation?.LegacyId ?? "";
            ADCID = adcid;

            if (m.CreatedAt != null)
            {
                VISITMO = m.CreatedAt.Month;
                VISITDAY = m.CreatedAt.Day;
                VISITYR = m.CreatedAt.Year;
            }

            INITIALS = m.CreatedBy.Substring(0, Math.Min(m.CreatedBy.Length, 3)).ToUpper(); ;

            CHANGEMO = m.CHANGEMO;
            CHANGEDY = m.CHANGEDY;
            CHANGEYR = m.CHANGEYR;

            PROTOCOL = m.PROTOCOL;
            ACONSENT = m.ACONSENT;
            RECOGIM = m.RECOGIM;
            REPHYILL = m.REPHYILL;
            REREFUSE = m.REREFUSE;
            RENAVAIL = m.RENAVAIL;
            RENURSE = m.RENURSE;
            NURSEMO = m.NURSEMO;
            NURSEDY = m.NURSEDY;
            NURSEYR = m.NURSEYR;
            REJOIN = m.REJOIN;
            FTLDDISC = m.FTLDDISC;
            FTLDREAS = m.FTLDREAS;
            FTLDREAX = m.FTLDREAX;
            DECEASED = m.DECEASED;
            DISCONT = m.DISCONT;
            DEATHMO = m.DEATHMO;
            DEATHDY = m.DEATHDY;
            DEATHYR = m.DEATHYR;
            AUTOPSY = m.AUTOPSY;
            DISCMO = m.DISCMO;
            DISCDAY = m.DISCDAY;
            DISCYR = m.DISCYR;
            DROPREAS = m.DROPREAS;
        }

    }

}
