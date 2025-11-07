using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    public class RequiredOnFinalizedAttribute : RequiredAttribute
    {
        private readonly PacketKind[]? _packetKinds;

        public RequiredOnFinalizedAttribute(params PacketKind[] packetKinds)
        {
            _packetKinds = packetKinds.Length > 0 ? packetKinds : null;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // does the form have a status and is it attempting to be finalized?
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance as FormModel;

                // only validate if the form is attempting to be finalized and mode is NOT not completed
                if (form != null && form.Status == FormStatus.Finalized && form.MODE != FormMode.NotCompleted)
                {
                    if (_packetKinds != null)
                    {
                        var packetKindProperty = validationContext.ObjectType.GetProperty("PacketKind");
                        if (packetKindProperty != null)
                        {
                            var valueObj = packetKindProperty.GetValue(form);
                            PacketKind? currentKind = valueObj != null ? (PacketKind?)valueObj : null;

                            if (!currentKind.HasValue || Array.IndexOf(_packetKinds, currentKind.Value) < 0)
                            {
                                return ValidationResult.Success;
                            }
                        }
                    }

                    return base.IsValid(value, validationContext);
                }
            }

            return ValidationResult.Success;
        }
    }
}
