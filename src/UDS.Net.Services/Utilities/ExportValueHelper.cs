using System;

namespace UDS.Net.Services.Utilities
{
    public class ExportValueHelper
    {
        // Evalutate for export value (currentValue, code, or null) and use the setter method to set change property value
        public static int? GetExportValue(int? previousValue, int? currentValue, int code, Action<int?> changePropSetter)
        {
            if (previousValue == null && currentValue == null)
            {
                return null;
            }

            if (previousValue == currentValue)
            {
                return code;
            }

            //Set change property provided if change detected
            changePropSetter(1);
            return currentValue;
        }

        // Evalutate for export value (currentValue, code, or null) and use the setter method to set change property value
        public static string GetExportValue(string? previousValue, string? currentValue, string code, Action<int?> changePropSetter)
        {
            if (previousValue == null && currentValue == null)
            {
                return null;
            }

            if (previousValue == currentValue)
            {
                //Set change property provided if change detected
                return code;
            }

            changePropSetter(1);
            return currentValue;
        }
    }
}
