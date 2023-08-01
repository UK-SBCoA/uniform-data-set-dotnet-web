using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _watchedField = "";
        private string _watchedFieldValue = "";

        public RequiredIfAttribute(string watchedField, string value) : base()
        {
            _watchedField = watchedField;
            _watchedFieldValue = value;
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
                    // get the watched property and compare
                    var type = validationContext.ObjectType;

                    if (type != null)
                    {
                        var watchedProperty = type.GetProperty(_watchedField);

                        if (watchedProperty != null)
                        {
                            var currentValue = watchedProperty.GetValue(validationContext.ObjectInstance, null);
                            if (currentValue != null)
                            {
                                if (currentValue.ToString() == _watchedFieldValue)
                                {
                                    // if the watched field's value matches what we're looking for then this field requires a value
                                    if (value == null)
                                        return new ValidationResult(this.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }


            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-requiredif", this.ErrorMessage);
            string watched = _watchedField;
            var containerName = context.ModelMetadata.ContainerType.Name;
            if (!String.IsNullOrEmpty(containerName))
            {
                watched = containerName + "." + _watchedField;
            }
            MergeAttribute(context.Attributes, "data-val-requiredif-watchedfield", watched);
            MergeAttribute(context.Attributes, "data-val-requiredif-watchedfieldvalue", _watchedFieldValue);
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

