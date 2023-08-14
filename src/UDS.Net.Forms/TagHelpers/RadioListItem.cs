using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace UDS.Net.Forms.TagHelpers
{
    public class RadioListItem : SelectListItem
    {
        public RadioListItem(string text, string value) : base(text, value)
        {
        }
    }
}

