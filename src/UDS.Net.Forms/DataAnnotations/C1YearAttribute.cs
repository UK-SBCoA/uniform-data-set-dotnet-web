using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UDS.Net.Forms.Models;


namespace UDS.Net.Forms.DataAnnotations
{
    public class C1YearAttribute : ValidationAttribute, IClientModelValidator
    {
        public int Minimum { get; set; } = DateTime.Now.Year - 1;
        public int Maximum { get; } = DateTime.Now.Year;
        public int Month { get; } = DateTime.Now.Month;
        public bool AllowUnknown { get; set; } = false;

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-year", GetErrorMessage());
            MergeAttribute(context.Attributes, "data-val-year-minimum", Minimum.ToString(CultureInfo.InvariantCulture));
            MergeAttribute(context.Attributes, "data-val-year-maximum", Maximum.ToString(CultureInfo.InvariantCulture));
            MergeAttribute(context.Attributes, "data-val-year-allowunknown", AllowUnknown.ToString().ToLower());
        }

        public string GetErrorMessage()
        {
            if (AllowUnknown)
                return $"Year of test previously administered must be {Minimum} or {Maximum}, or 8888 (unknown).";
            else
                return $"Year of test previously administered must be {Minimum} or {Maximum}.";
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

                    if (AllowUnknown && year == 8888)
                    {
                        return ValidationResult.Success;
                    }

                    if (Month >= 1 && Month <= 3 && year == Minimum)
                    {
                        return ValidationResult.Success;
                    }

                    if (Month > 3 && year == Minimum)
                    {
                        return new ValidationResult(GetErrorMessage());
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
