using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DiagnosisAttribute : ValidationAttribute, IClientModelValidator
{
    private static string ERRORMESSAGE = "Diagnosis code invalid. Please see reference.";
    private static int[] CODES = new int[] { 00,01,02,03,04,05,06,07,08,09,10,11,12,88,99 };

    public bool AllowUnknown { get; set; } = false;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (validationContext.ObjectType.IsSubclassOf(typeof(FormModel)))
        {
            var form = (FormModel)validationContext.ObjectInstance;

            // Only validate if the form is attempting to be completed
            if (form.Status == FormStatus.Complete)
            {
                if (value is int)
                {
                    int code = (int)value;
                    if (CODES.Contains(code))
                    {
                        return ValidationResult.Success;
                    }
                }

                if (AllowUnknown && value == null)
                {
                    return ValidationResult.Success;
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
