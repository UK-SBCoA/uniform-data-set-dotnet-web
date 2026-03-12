using System;
using System.Collections.Generic;
using System.Reflection;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Extensions
{
    /// <summary>
    /// Extension methods for comparing form fields and encoding follow-up values
    /// </summary>
    public static class FormComparisonExtensions
    {
        /// <summary>
        /// Represents a field comparison configuration
        /// </summary>
        public class FieldComparisonConfig
        {
            public string PropertyName { get; set; } = "";
            public object EncodingValue { get; set; }
            public FieldComparisonConfig(string propertyName, object encodingValue)
            {
                PropertyName = propertyName;
                EncodingValue = encodingValue;
            }
        }

        /// <summary>
        /// Compares two forms and encodes changed fields in the current form
        /// </summary>
        public static void EncodeFollowUpFields<T>(
            this T currentFields,
            T? previousFields,
            IEnumerable<FieldComparisonConfig> fieldConfigs) where T : class
        {
            if (currentFields == null || previousFields == null)
                return;

            var type = typeof(T);

            foreach (var config in fieldConfigs)
            {
                var property = type.GetProperty(config.PropertyName, 
                    BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);

                if (property == null || !property.CanRead || !property.CanWrite)
                    continue;

                try
                {
                    var previousValue = property.GetValue(previousFields);
                    var currentValue = property.GetValue(currentFields);

                    // If values are the same, encode with the specified value
                    if (ValuesAreEqual(previousValue, currentValue))
                    {
                        property.SetValue(currentFields, config.EncodingValue);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exceptions as needed
                    System.Diagnostics.Debug.WriteLine($"Error comparing field {config.PropertyName}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Safely compares two values, handling null cases
        /// </summary>
        private static bool ValuesAreEqual(object? previousValue, object? currentValue)
        {
            if (previousValue == null && currentValue == null)
                return true;

            if (previousValue == null || currentValue == null)
                return false;

            return previousValue.Equals(currentValue);
        }
    }
}