using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    public class UIBehavior
    {
        public string Value { get; set; }

        public UIBehaviorCondition Condition { get; set; }

        public UIPropertyAttributes PropertyAttributes { get; set; }

        public UIBehavior(string value, UIBehaviorCondition condition, UIPropertyAttributes propertyAttributes)
        {
            Value = value;
            Condition = condition;
            PropertyAttributes = propertyAttributes;
        }
    }
}

