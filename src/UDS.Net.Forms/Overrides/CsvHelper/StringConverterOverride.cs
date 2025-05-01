using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace UDS.Net.Forms.Overrides.CsvHelper
{
    // Sanitize commas from string type values. Commas in strings will be counted as column seperators in csv readers.

    // Original class can be found at: https://github.com/JoshClose/CsvHelper/blob/master/src/CsvHelper/TypeConversion/StringConverter.cs
    // ConvertToString() is inherited from DefaultTypeConverter.cs

    public class StringConverterOverride : StringConverter
    {
        //Property metadata will come through as memberMapData
        public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value == null)
            {
                if (memberMapData.TypeConverterOptions.NullValues.Count > 0)
                {
                    return memberMapData.TypeConverterOptions.NullValues.First();
                }

                return string.Empty;
            }

            if (value is IFormattable formattable)
            {
                var format = memberMapData.TypeConverterOptions.Formats?.FirstOrDefault();

                // custom code to remove commas if value is formatted
                return formattable.ToString(format, memberMapData.TypeConverterOptions.CultureInfo).Replace(",", "");
            }

            string? valueAsString = value?.ToString() ?? string.Empty;

            // custom code to remove commas from unformatted value
            if (!String.IsNullOrEmpty(valueAsString))
            {
                valueAsString = valueAsString.Replace(",", "");
            }

            return valueAsString;
        }
    }
}
