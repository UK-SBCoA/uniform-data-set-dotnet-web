using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredIfRangeAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _watchedField = "";
        private int _watchedFieldLowValue = int.MinValue;
        private int _watchedFieldHighValue = int.MaxValue;

        public RequiredIfRangeAttribute(string watchedField, int lowValue, int highValue) : base()
        {
            _watchedField = watchedField;
            if (lowValue > highValue)
                throw new Exception("Range validation error");

            _watchedFieldLowValue = lowValue;
            _watchedFieldHighValue = highValue;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // does the form have a status and is it attempting to be finalized?
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance;

                // only validate if the form is attempting to be completed
                if (form.Status == FormStatus.Finalized)
                {
                    // get the watched property and compare
                    var type = validationContext.ObjectType;

                    if (type != null)
                    {
                        var watchedProperty = type.GetProperty(_watchedField);

                        if (watchedProperty != null)
                        {
                            var currentValue = watchedProperty.GetValue(validationContext.ObjectInstance, null);
                            if (currentValue != null && Int32.TryParse(currentValue.ToString(), out int integerValue))
                            {
                                if (integerValue >= _watchedFieldLowValue && integerValue <= _watchedFieldHighValue)
                                {
                                    // if the watched field's value is within the range then this field requires a value
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
            MergeAttribute(context.Attributes, "data-val-requiredifrange", this.ErrorMessage);
            string watched = _watchedField;
            var containerName = context.ModelMetadata.ContainerType.Name;
            if (!String.IsNullOrEmpty(containerName))
            {
                watched = containerName + "." + _watchedField;
            }
            MergeAttribute(context.Attributes, "data-val-requiredifrange-watchedfield", watched);
            MergeAttribute(context.Attributes, "data-val-requiredifrange-lowvalue", _watchedFieldLowValue.ToString());
            MergeAttribute(context.Attributes, "data-val-requiredifrange-highvalue", _watchedFieldHighValue.ToString());
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

