using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class EditModel : PacketSubmissionPageModel
    {
        public EditModel(IVisitService visitService, IPacketSubmissionService packetSubmissionService) : base(visitService, packetSubmissionService)
        {
        }
    }
}

