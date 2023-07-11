using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.DataAnnotations
{
    public class SpecialCharacterAttribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-specialcharacter", GetErrorMessage());
        }
        public static string GetErrorMessage()
        {
            return "Single quotes ('), double quotes (\"), ampersands (&) and percentage signs (%) are not allowed";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string allowableCode)
            {
                if (allowableCode.Contains("'") || allowableCode.Contains("\"") || allowableCode.Contains("&") || allowableCode.Contains("%"))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// See https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0#iclientmodelvalidator-for-client-side-validation
        /// </summary>
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