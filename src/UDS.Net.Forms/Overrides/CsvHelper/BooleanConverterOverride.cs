using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace UDS.Net.Forms.Overrides.CsvHelper
{
    // Override boolean converter to return boolean values as 1 & 0 instead of "True" & "False"
    public class BoolStringToIntConverter : BooleanConverter
    {
        public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            var b = value as bool?;

            if (b == true)
            {
                return "1";
            }
            else if (b == false)
            {
                return "0";
            }

            return base.ConvertToString(value, row, memberMapData);
        }
    }
}
