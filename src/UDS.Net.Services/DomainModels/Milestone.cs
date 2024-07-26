using System;

namespace UDS.Net.Services.DomainModels
{
    public class Milestone
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int ParticipationId { get; set; }
        public string Status { get; set; }
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
        public string FTLDREAX { get; set; }
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
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; set; }

        // TODO use Milestone constructor for mapping instead of extension method
    }
}

