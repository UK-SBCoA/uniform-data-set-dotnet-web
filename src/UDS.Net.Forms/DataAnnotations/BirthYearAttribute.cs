using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class BirthYearAttribute : ValidationAttribute, IClientModelValidator
    {
        public int Minimum { get; set; } = 1850; // A1 minimum is default
        public int Maximum { get; } = DateTime.Now.Year - 15; // Maximum for A1 or A2 is always current year minus 15
        public bool Parent { get; set; } = false;
        public int ParentMaximum { get; } = DateTime.Now.Year - 20; // Maximum for parent in A3
        public bool AllowUnknown { get; set; } = false;

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-birthyear", GetErrorMessage());
            MergeAttribute(context.Attributes, "data-val-birthyear-minimum", Minimum.ToString(CultureInfo.InvariantCulture));
            MergeAttribute(context.Attributes, "data-val-birthyear-maximum", Maximum.ToString(CultureInfo.InvariantCulture));
            MergeAttribute(context.Attributes, "data-val-birthyear-allowunknown", AllowUnknown.ToString().ToLower());
            MergeAttribute(context.Attributes, "data-val-birthyear-parent", Parent.ToString().ToLower());
        }

        public string GetErrorMessage()
        {
            if (Parent && AllowUnknown)
                return $"Birth year must be between {Minimum} and {ParentMaximum}, or 9999 (unknown).";
            else if (AllowUnknown)
                return $"Birth year must be between {Minimum} and {Maximum}, or 9999 (unknown).";
            else
                return $"Birth year must be between {Minimum} and {Maximum}.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance;

                if (form.Status == FormStatus.Finalized)
                {
                    // Only validate on the server if form is attempting to be completed
                    var year = (int)value;

                    if (AllowUnknown && year == 9999)
                    {
                        return ValidationResult.Success;
                    }

                    if (Parent)
                    {
                        if (year < Minimum || year > DateTime.Now.Year - 20)
                        {
                            return new ValidationResult(GetErrorMessage());
                        }
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

