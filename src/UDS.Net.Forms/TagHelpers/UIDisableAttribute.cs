﻿using System;

namespace UDS.Net.Forms.TagHelpers
{
    public class UIDisableAttribute : UIPropertyAttributes
    {
        private UIDisableAttribute(string property, Dictionary<string, string> attributes) : base(property, attributes)
        {
        }

        public UIDisableAttribute(string property)
        {
            if(property == "A5D2.IMPAMFOOT")
            {

            }

            Dictionary<string, string> disabledAttributes = new Dictionary<string, string>
            {
                { "disabled", "true" }
            };

            Property = property;
            Attributes = disabledAttributes;
        }
    }
}

