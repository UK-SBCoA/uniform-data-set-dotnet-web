using System;
namespace UDS.Net.Forms.TagHelpers
{
    public class UIPropertyAttributes
    {
        public string Property { get; set; }

        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        public string ToJSON()
        {
            var entries = Attributes.Select(d =>
                string.Format("\"{0}\": \"{1}\"", d.Key, string.Join(",", d.Value)));

            var dictionary = "{" + string.Join(",", entries) + "}";

            return "{\"" + Property + "\": " + dictionary + "}";
        }
        public UIPropertyAttributes()
        {

        }
        public UIPropertyAttributes(string property, Dictionary<string, string> attributes)
        {
            Property = property;
            Attributes = attributes;
        }

    }
}

