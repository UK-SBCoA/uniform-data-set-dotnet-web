using System;

namespace UDS.Net.Services.Utilities
{
    public static class ExportHelper
    {
        public static int? GetEncodedValue(int? previousValue, int? currentValue, int code, Action<int?> changePropSetter)
        {
            if (previousValue == null && currentValue == null)
            {
                return null;
            }

            if (previousValue == currentValue)
            {
                return code;
            }

            changePropSetter(1);
            return currentValue;
        }

        public static string GetEncodedValue(string previousValue, string currentValue, string code, Action<int?> changePropSetter)
        {
            if (previousValue == null && currentValue == null)
            {
                return null;
            }

            if (previousValue == currentValue)
            {
                return code;
            }

            changePropSetter(1);
            return currentValue;
        }
    }
}
