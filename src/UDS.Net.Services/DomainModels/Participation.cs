using System;
using System.Collections.Generic;

namespace UDS.Net.Services.DomainModels
{
    public class Participation
    {
        public int Id { get; set; }

        public string LegacyId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Visit> Visits { get; set; } = new List<Visit>();
    }
}

