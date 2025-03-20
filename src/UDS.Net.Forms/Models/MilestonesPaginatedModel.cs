using System;
namespace UDS.Net.Forms.Models
{
    public class MilestonesPaginatedModel : PaginatedModel
    {
        public List<MilestoneModel> List { get; set; } = new List<MilestoneModel>();
    }
}

