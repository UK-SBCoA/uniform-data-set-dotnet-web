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
    public class B7Model : FormPageModel
    {
        [BindProperty]
        public B7 B7 { get; set; } = default!;
        public B7Model(IVisitService visitService) : base(visitService, "B7")
        {
        }
        public void OnGet()
        {
        }
    }
}
