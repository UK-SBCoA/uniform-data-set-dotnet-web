using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.Packets
{
    public class DetailsModel : PacketPageModel
    {
        public DetailsModel(IParticipationService participationService, IPacketService packetService) : base(participationService, packetService)
        {
        }

        public async Task<IActionResult> OnGetCurrentValue(int packetId, string formKind, string location)
        {
            var packet = await _packetService.GetPacketWithForms(User.Identity.Name, packetId);

            string? currentValue = "--";

            if (packet != null)
            {
                var packetForm = packet.Forms.Where(f => f.Kind.ToLower() == formKind.ToLower()).FirstOrDefault();

                if (packetForm != null)
                {
                    var propertyFound = packetForm.Fields.GetType().GetProperty(location);

                    try
                    {
                        currentValue = propertyFound != null ? propertyFound.GetValue(packetForm.Fields).ToString() : "--";
                    }
                    catch (Exception e)
                    {
                        //log error
                    }
                }
            }

            return Partial("_SubmissionErrorCurrentValue", currentValue);
        }
    }
}
