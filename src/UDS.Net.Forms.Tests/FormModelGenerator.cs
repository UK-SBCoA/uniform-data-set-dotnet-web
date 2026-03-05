
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

                if (type == typeof(int))
                {
                    property.SetValue(model, random.Next(1, 100));

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
