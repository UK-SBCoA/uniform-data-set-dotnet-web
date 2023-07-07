using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.DataAnnotations
{
    public class SpecialCharacterAttribute : ValidationAttribute
    {
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
                    return new ValidationResult (GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }
    } 
}