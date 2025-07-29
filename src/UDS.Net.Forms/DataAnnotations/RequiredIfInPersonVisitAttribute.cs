using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    // RequiredIfInPersonVisit is primarily used in the C2 form. "InPerson" refers to both in-person visits and remote/video visits.

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfInPersonVisitAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _watchedField = "";
        private string _watchedFieldValue = "";
        private readonly bool _inPersonCheckOnly = false;

        public RequiredIfInPersonVisitAttribute(string watchedField, string value) : base()
        {
            _watchedField = watchedField;
            _watchedFieldValue = value;
        }
        public RequiredIfInPersonVisitAttribute() : base()
        {
            _inPersonCheckOnly = true;
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
                    if (_inPersonCheckOnly)
                    {
                        if (form.MODE == FormMode.InPerson || form.RMMODE == RemoteModality.Video)
                        {
                            if (value == null)
                            {
                                return new ValidationResult(this.ErrorMessage);
                            }
                        }
                    }
                    else
                    {
                        if (form.MODE == FormMode.InPerson || form.RMMODE == RemoteModality.Video)
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
                }
            }
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            if (!_inPersonCheckOnly)
            {
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
            else
            {
                MergeAttribute(context.Attributes, "data-val-required", this.ErrorMessage);

            }
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
