using System;
namespace UDS.Net.Forms.Models
{
    public class VisitsPaginatedModel : PaginatedModel
    {
        public List<VisitModel> List { get; set; } = new List<VisitModel>();
    }
}

