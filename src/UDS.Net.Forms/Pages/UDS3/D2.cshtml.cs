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
    public class D2Model : FormPageModel
    {
        [BindProperty]
        public D2 D2 { get; set; } = default!;
        public D2Model(IVisitService visitService) : base(visitService, "D2")
        {
        }
        public void OnGet()
        {
        }
    }
}
