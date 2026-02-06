using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    public class AllowCode777Attribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-allowcode777", GetErrorMessage());
            var containerName = context.ModelMetadata.ContainerType?.Name;
            MergeAttribute(context.Attributes, "data-val-allowcode777-packetkind", $"{containerName}.PacketKind");
        }
        public static string GetErrorMessage()
        {
            return "777 is allowed only for Packet Kind F.";
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance;

                // only validate if the form is attempting to be completed
                if (form.Status == FormStatus.Finalized)
                {
                    if (value is int)
                    {
                        int code = (int)value;
                        if (code == 777)
                        {
                            if (form.PacketKind != PacketKind.F)
                            {
                                return new ValidationResult(GetErrorMessage());
                            }
                            else
                            {
                                return ValidationResult.Success;

                            }
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
        private static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }
    }
}
