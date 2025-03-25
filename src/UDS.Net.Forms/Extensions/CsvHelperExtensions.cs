using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Extensions
{
    public static class CsvHelperExtensions
    {
        public static void WriteHeaderLowercase<T>(this CsvWriter csv)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                if (property != null)
                {
                    if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(int?) || property.PropertyType == typeof(bool?) || property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?) || property.PropertyType == typeof(double?) || property.PropertyType == typeof(string))
                    {
                        csv.WriteField(property.Name.ToLower());
                    }
                }
            }
        }
    }
}