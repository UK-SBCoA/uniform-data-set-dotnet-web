using System;
namespace UDS.Net.Forms.Models
{
    public class ParticipationsPaginatedModel : PaginatedModel
    {
        public List<ParticipationModel> List { get; set; } = new List<ParticipationModel>();
    }
}

