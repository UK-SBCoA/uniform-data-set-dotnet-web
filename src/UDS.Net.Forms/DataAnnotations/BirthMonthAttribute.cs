using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UDS.Net.Forms.Models;

namespace UDS.Net.Forms.DataAnnotations
{
    public class BirthMonthAttribute : ValidationAttribute, IClientModelValidator
    {
        public bool AllowUnknown { get; set; } = false;

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-birthmonth", GetErrorMessage());
            MergeAttribute(context.Attributes, "data-val-birthmonth-minimum", "1");
            MergeAttribute(context.Attributes, "data-val-birthmonth-maximum", "12");
            MergeAttribute(context.Attributes, "data-val-birthmonth-allowunknown", AllowUnknown.ToString().ToLower());
        }

        public string GetErrorMessage()
        {
            if (AllowUnknown)
                return "Birth month must be within 1 and 12, or 99 (unknown).";
            else
                return "Birth month must be within 1 and 12.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance;

                if (form.Status == "2") // TODO fix statuses
                {
                    // Only validate on the server if form is attempting to be completed
                    var month = (int)value;

                    if (AllowUnknown && month == 99)
                    {
                        return ValidationResult.Success;
                    }

                    if (month < 1 || month > 12)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
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

