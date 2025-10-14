using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    /// <summary>
    /// More information on tag helpers: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-7.0
    /// </summary>
    public class GuidebookTagHelper : TagHelper
    {
        private const string I = "https://files.alz.washington.edu/documentation/UDSv4_CodingGuidebook.pdf";
        private const string F = "https://files.alz.washington.edu/documentation/UDSv4_CodingGuidebook.pdf"; // There is no guidebook specifically for follow-up visits yet

        public string Kind { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            string url = I;
            if (!String.IsNullOrWhiteSpace(Kind))
            {
                if (Kind == "F")
                    url = F;
            }
            output.Attributes.SetAttribute("href", url);
            output.Attributes.SetAttribute("target", "_blank");
            output.Attributes.SetAttribute("class", "font-medium text-indigo-700 underline hover:text-indigo-600");

            string packetKindDisplay = "UDS Coding Guidebook for Visit Packet";

            if (Kind == "I")
                packetKindDisplay = "UDS Coding Guidebook for UDSv4 Initial Visit Packet";
            else if (Kind == "F")
                packetKindDisplay = "UDS Coding Guidebook for UDSv4 Follow-up Visit Packet";

            output.Content.Append($"{packetKindDisplay}");
        }
    }
}

