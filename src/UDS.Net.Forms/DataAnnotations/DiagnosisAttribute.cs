using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DiagnosisAttribute : ValidationAttribute, IClientModelValidator
    {
        private static string ERRORMESSAGE = "Diagnosis code invalid. Please see reference.";
        private static int[] CODES = new int[] { 40, 41, 42, 43, 44, 45, 50, 70, 80, 100, 110, 120, 130, 131, 132, 133, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 310, 320, 400, 410, 420, 421, 430, 431, 432, 433, 434, 435, 436, 439, 440, 450, 490, 999 };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
            {
                var form = (FormModel)validationContext.ObjectInstance;
                var a3 = (A3)validationContext.ObjectInstance;

                if (form.Status == FormStatus.Complete)
                {
                    if (((a3.MOMNEUR >= 1 && a3.MOMNEUR <= 5) || a3.MOMNEUR == 8 || a3.MOMNEUR == 9) ||
                        ((a3.DADNEUR >= 1 && a3.DADNEUR <= 5) || a3.DADNEUR == 8 || a3.DADNEUR == 9))
                    {
                        if (value is int)
                        {
                            int code = (int)value;

                            if (CODES.Contains(code))
                            {
                                return ValidationResult.Success;
                            }
                        }
                        else if (value == null)
                        {
                            return ValidationResult.Success;
                        }

                        return new ValidationResult(ERRORMESSAGE);
                    }

                    return new ValidationResult(ERRORMESSAGE);
                }
            }
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-diagnosis", ERRORMESSAGE);
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