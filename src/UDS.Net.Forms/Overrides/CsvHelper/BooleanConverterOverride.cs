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
            // test to check for a specific variable

            //if(memberMapData.Member != null)
            //{
            //    if(memberMapData.Member.Name.ToString() == "ETHGERMAN")
            //    {
            //        var test = 0;
            //    }
            //}

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
