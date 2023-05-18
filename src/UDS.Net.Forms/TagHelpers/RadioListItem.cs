using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace UDS.Net.Forms.TagHelpers
{
    public class RadioListItem : SelectListItem
    {
        /// <summary>
        /// If this radio item is selected, it affects these other inputs in a specific way
        /// </summary>
        public Dictionary<string, string> IfSelectedAffects { get; set; }

        public RadioListItem(string text, string value) : base(text, value)
        {
        }

        public RadioListItem(string text, string value, Dictionary<string, string> ifSelectedAffects) : base(text, value)
        {
            IfSelectedAffects = ifSelectedAffects;
        }
    }
}

