using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;


namespace UDS.Net.Forms.Pages.Milestones
{
    public class CreateModel : MilestonePageModel
    {
        public CreateModel(IMilestoneService milestoneService, IParticipationService participationService) : base(milestoneService, participationService)
        {
        }
    }
}
