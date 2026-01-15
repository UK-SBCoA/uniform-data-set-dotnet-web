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

        public async Task<IActionResult> OnGetFormPropValueAsync(int packetId, string formKind, string location)
        {
            //Set failure route message as default value
            string? propValueString = $"Unable to get current value from: {(string.IsNullOrEmpty(location) ? "Property" : location)} in {(string.IsNullOrEmpty(formKind) ? "Form" : formKind)}";

            if (packetId > 0 && !string.IsNullOrEmpty(formKind) && !string.IsNullOrEmpty(location))
            {
                var packet = await _packetService.GetPacketWithForms(User.Identity.Name, packetId);

                if (packet != null)
                {
                    var packetForm = packet.Forms.Where(f => f.Kind.ToLower() == formKind.ToLower()).FirstOrDefault();

                    if (packetForm != null)
                    {
                        var propertyFound = packetForm.Fields.GetType().GetProperty(location);

                        if (propertyFound != null)
                        {
                            //All required values have been confirmed to be found, valueFound == NULL means no value provided in form
                            var valueFound = propertyFound.GetValue(packetForm.Fields);

                            propValueString = valueFound != null ? valueFound.ToString() : "--";
                        }
                    }
                }
            }

            return Partial("_FormPropValue", propValueString);
        }
    }
}
