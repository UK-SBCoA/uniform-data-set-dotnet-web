using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS3
{
    public class C1Model : FormPageModel
    {
        [BindProperty]
        public C1 C1 { get; set; } = default!;
        public C1Model(IVisitService visitService) : base(visitService, "C1")
        {
        }
        public void OnGet()
        {
        }
    }
}
