using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UDS.Net.Forms.Models;

namespace UDS.Net.Forms.DataAnnotations
{
    public class BirthYearAttribute : ValidationAttribute, IClientModelValidator
    {
        public int Minimum { get; set; } = 1875; // A1 minimum is default
        public int Maximum { get; } = DateTime.Now.Year - 15; // Maximum for A1 or A2 is always current year minus 15
        public bool AllowUnknown { get; set; } = false;

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-birthyear", GetErrorMessage());
            MergeAttribute(context.Attributes, "data-val-birthyear-minimum", Minimum.ToString(CultureInfo.InvariantCulture));
            MergeAttribute(context.Attributes, "data-val-birthyear-maximum", Maximum.ToString(CultureInfo.InvariantCulture));
            MergeAttribute(context.Attributes, "data-val-birthyear-allowunknown", AllowUnknown.ToString().ToLower());
        }

        public string GetErrorMessage()
        {
            if (AllowUnknown)
                return $"Birth year must be between {Minimum} and {Maximum}, or 9999 (unknown).";
            else
                return $"Birth year must be between {Minimum} and {Maximum}.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance;

                if (form.Status == "2") // TODO fix statuses
                {
                    // Only validate on the server if form is attempting to be completed
                    var year = (int)value;

                    if (AllowUnknown && year == 9999)
                    {
                        return ValidationResult.Success;
                    }

                    if (year < Minimum || year > Maximum)
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

