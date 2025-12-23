using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Packets
{
    public class DetailsModel : PacketPageModel
    {
        public DetailsModel(IParticipationService participationService, IPacketService packetService) : base(participationService, packetService)
        {
        }

        public async Task<IActionResult> OnGetCurrentValue(int id)
        {
            // TODO: Create a service method that can grab the current value of a property in a form
            //       Update the arguments to accept relevant data for grabbing current form data from specific form

            // var formFound = Model.Packet.Forms.Where(f => f.Kind.ToLower() == error.FormKind.ToLower()).FirstOrDefault();
            // string currentValueString = "--";

            // if (formFound != null && !String.IsNullOrEmpty(error.Location)) {
            //     var propertyFound = formFound.GetType().GetProperty(error.Location);

            //     if(propertyFound != null)
            //     {
            //         var currentValue = propertyFound.GetValue(formFound);
            //         if(currentValue != null)
            //         {
            //             currentValueString = currentValue.ToString();
            //         }
            //     }
            // }

            return Partial("_SubmissionErrorCell", id.ToString());
        }
    }
}
