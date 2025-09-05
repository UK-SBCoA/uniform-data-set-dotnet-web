using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredIfRegexAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _watchedField = "";
        private string _watchedFieldRegex = "";

        public RequiredIfRegexAttribute(string watchedField, string watchedFieldRegex) : base()
        {
            _watchedField = watchedField;
            _watchedFieldRegex = watchedFieldRegex;

            //TODO: some error checking to make sure watched field regex is valid
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
                            //TODO: handle the watched property regex validation

                            var watchedValue = watchedProperty.GetValue(validationContext.ObjectInstance, null);

                            //TODO if value does not match regex return validation error
                            if (watchedValue != null)
                            {
                                var watchedRegex = new Regex(_watchedFieldRegex);

                                var watchedRegexMatch = watchedRegex.Match(watchedValue.ToString());

                                if (watchedRegexMatch.Success)
                                {
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
            MergeAttribute(context.Attributes, "data-val-requiredifregex", this.ErrorMessage);
            string watched = _watchedField;
            var containerName = context.ModelMetadata.ContainerType.Name;
            if (!String.IsNullOrEmpty(containerName))
            {
                watched = containerName + "." + _watchedField;
            }
            MergeAttribute(context.Attributes, "data-val-requiredifregex-watchedfield", watched);
            MergeAttribute(context.Attributes, "data-val-requiredifregex-regex", _watchedFieldRegex.ToString());
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
