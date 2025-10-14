using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace UDS.Net.Forms.Overrides.CsvHelper
{
    // Override boolean converter to return boolean values as 1 & 0 instead of "True" & "False"

    // Original class can be found at: https://github.com/JoshClose/CsvHelper/blob/master/src/CsvHelper/TypeConversion/BooleanConverter.cs

    public class BooleanConverterOverride : BooleanConverter
    {
        //Property metadata will come through as memberMapData
        public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            var boolValue = value as bool?;

            if (boolValue == true)
            {
                return "1";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
