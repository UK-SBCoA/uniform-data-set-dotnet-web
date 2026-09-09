using System;
using System.Collections.Generic;
using System.Text;

namespace UDS.Net.Forms.TagHelpers
{
    public class UIRangeBehavior
    {
        public int Low { get; set; }
        public int High { get; set; }

        public List<UIPropertyAttributes> PropertyAttributes { get; set; } = new();

        public string? InstructionalMessage { get; set; }
    }
}
