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

        public async Task<IActionResult> OnGetFormPropValueAsync(int packetId, string formKind = "Form", string location = "Question")
        {
            //Set failure route message as default value
            string? propValueString = $"Unable to get current value from: {location} in {formKind}";

            if (packetId > 0)
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
