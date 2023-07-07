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
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string allowableCode)
            {
                if (allowableCode.Contains("$") || allowableCode.Contains("'") || allowableCode.Contains("\"") || allowableCode.Contains("&"))
                {
                    return new ValidationResult("The field cannot contain the characters $, ', \", or &");
                }
            }

            return ValidationResult.Success;
        }
    }

}