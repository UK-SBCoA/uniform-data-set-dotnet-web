using System;
namespace UDS.Net.Forms.Models
{
    public class DrugCodeModel
    {
        public int? Id { get; set; }

        public string DrugId { get; set; }

        public string? DrugName { get; set; }

        public string? BrandName { get; set; }

        public bool IsOverTheCounter { get; set; }

        public bool IsPopular { get; set; }

        public bool IsSelected { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public string? DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

