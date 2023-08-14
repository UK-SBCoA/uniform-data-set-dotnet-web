using System;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    public class RequiredOnCompleteAttribute : RequiredAttribute
    {
        public RequiredOnCompleteAttribute() : base()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // does the form have a status and is it attempting to be finalized?
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance;

                // only validate if the form is attempting to be completed
                if (form.Status == FormStatus.Complete)
                {
                    return base.IsValid(value, validationContext);
                }
            }
            return ValidationResult.Success;
        }
    }
}

