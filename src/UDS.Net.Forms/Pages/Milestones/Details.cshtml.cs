using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Milestones
{
    public class DetailsModel : EditModel
    {
        public DetailsModel(IParticipationService participationService) : base(participationService)
        {
        }
    }
}
