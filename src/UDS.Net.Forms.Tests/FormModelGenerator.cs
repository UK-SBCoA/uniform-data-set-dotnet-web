using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace UDS.Net.Forms.Tests
{
    public static class FormModelGenerator
    {
        public static T CreateFormModel<T>() where T : new()
        {
            var model = new T();
            var random = new Random();

            foreach (var property in typeof(T).GetProperties())
            {
                if (!property.CanWrite)
                    continue;

                var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                var regexAttr = property.GetCustomAttribute<RegularExpressionAttribute>();

                if (type == typeof(int))
                {
                    int value;
                    if (regexAttr != null)
                    {
                        var regex = new Regex(regexAttr.Pattern);
                        var attempts = 0;
                        do
                        {
                            value = Random.Shared.Next(0, 1000);
                            attempts++;
                            if (attempts > 5000)
                                throw new InvalidOperationException($"Could not generate integer matching regex '{regexAttr.Pattern}' for property '{property.Name}'");
                        } while (!regex.IsMatch(value.ToString()));
                    }
                    else
                    {
                        value = Random.Shared.Next(1, 100);
                    }

                    property.SetValue(model, value);
                }
                else if (type == typeof(string))
                {
                    property.SetValue(model, $"Test{random.Next(1, 100)}");
                }
                else if (type == typeof(bool))
                {
                    property.SetValue(model, random.Next(0, 2) == 0);
                }
            }
            return model;
        }
    }
}
