﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.PacketSubmissions
{
    public class DetailsModel : PacketSubmissionPageModel
    {
        public DetailsModel(IVisitService visitService, IPacketSubmissionService packetSubmissionService) : base(visitService, packetSubmissionService)
        {
        }
    }
}
