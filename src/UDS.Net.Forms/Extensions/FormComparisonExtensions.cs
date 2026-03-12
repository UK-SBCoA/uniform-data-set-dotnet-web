using System;
using System.Collections.Generic;
using System.Linq;
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
        public record FieldComparisonConfig(string FieldName, int EncodingValue);

        /// <summary>
        /// Applies follow-up encoding to fields by comparing against previous visit values.
        /// Unchanged fields are encoded with their specified encoding value.
        /// </summary>
        public static void EncodeFollowUpFields(this B9FormFields current, B9FormFields previous, IEnumerable<FieldComparisonConfig> fieldConfigs)
        {
            if (current == null || previous == null)
                return;

            foreach (var config in fieldConfigs)
            {
                var property = typeof(B9FormFields).GetProperty(config.FieldName);
                if (property == null)
                    continue;

                var previousValue = property.GetValue(previous);
                var currentValue = property.GetValue(current);

                // If values are null or equal, encode the current value
                if ((previousValue == null && currentValue == null) ||
                    (previousValue != null && previousValue.Equals(currentValue)))
                {
                    property.SetValue(current, config.EncodingValue);
                }
            }
        }

        /// <summary>
        /// Prepares follow-up encoding configuration with encoding value
        /// </summary>
        public static IEnumerable<FieldComparisonConfig> GetFollowUpEncodingConfig(this B9FormFields fields, int encodingValue)
        {
            return B9FormFields.EncodedFollowUpVariables()
                .Select(fieldName => new FieldComparisonConfig(fieldName, encodingValue));
        }
    }
}