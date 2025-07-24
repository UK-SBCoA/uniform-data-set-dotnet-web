using System;
namespace UDS.Net.Forms.Models
{
    public class DrugCodeModel
    {
        public string RxNormId { get; set; } = default!;

        public string? DrugName { get; set; }

        public string? BrandName { get; set; }

        public bool IsOverTheCounter { get; set; }

        public bool IsPopular { get; set; }
    }
}

