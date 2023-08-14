using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    public class UIBehavior
    {
        public UIPropertyAttributes PropertyAttribute
        {
            set
            {
                PropertyAttributes.Add(value);
            }
        }

        public List<UIPropertyAttributes> PropertyAttributes { get; set; } = new List<UIPropertyAttributes>();

        public string InstructionalMessage { get; set; }

        public UIBehavior()
        {

        }

        public UIBehavior(UIPropertyAttributes propertyAttribute, string? instructionalMessage = "")
        {
            PropertyAttributes.Add(propertyAttribute);
            if (!String.IsNullOrWhiteSpace(instructionalMessage))
            {
                InstructionalMessage = instructionalMessage;
            }
        }

        public UIBehavior(List<UIPropertyAttributes> propertyAttributes, string? instructionalMessage = "")
        {
            PropertyAttributes = propertyAttributes;
            if (!String.IsNullOrWhiteSpace(instructionalMessage))
            {
                InstructionalMessage = instructionalMessage;
            }
        }

    }
}

