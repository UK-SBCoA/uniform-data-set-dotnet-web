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
    public class A4Model : FormPageModel
    {
        [BindProperty]
        public A4 A4 { get; set; } = default!;
        public A4Model(IVisitService visitService) : base(visitService, "A4")
        {
        }
        public void OnGet()
        {
        }
    }
}
