using System;
namespace UDS.Net.Forms.TagHelpers
{
    public class UIEnableAttribute : UIPropertyAttributes
    {
        private UIEnableAttribute(string property, Dictionary<string, string> attributes) : base(property, attributes)
        {
        }

        public UIEnableAttribute(string property)
        {
            Dictionary<string, string> disabledAttributes = new Dictionary<string, string>
            {
                { "disabled", "false" }
            };

            Property = property;
            Attributes = disabledAttributes;
        }
    }
}

