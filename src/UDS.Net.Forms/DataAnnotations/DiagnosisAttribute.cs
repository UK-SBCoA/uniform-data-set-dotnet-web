using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services.Enums;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DiagnosisAttribute : ValidationAttribute, IClientModelValidator
{
    private static string ERRORMESSAGE = "Diagnosis code invalid. Please see reference.";
    private static int[] CODES = new int[] { 40, 41, 42, 43, 44, 45, 50, 70, 80, 100, 110, 120, 130, 131, 132, 133, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 310, 320, 400, 410, 420, 421, 430, 431, 432, 433, 434, 435, 436, 439, 440, 450, 490, 999 };

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
