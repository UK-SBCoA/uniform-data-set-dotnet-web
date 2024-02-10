using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    /// <summary>
    /// More information on tag helpers: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-7.0
    /// </summary>
    public class GuidebookTagHelper : TagHelper
    {
        private const string IVP = "https://github.com/naccdata/uniform-data-set";
        private const string FVP = "https://github.com/naccdata/uniform-data-set";
        private const string TIP = "https://github.com/naccdata/uniform-data-set";
        private const string TFP = "https://github.com/naccdata/uniform-data-set";

        public string Kind { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            string url = IVP;
            if (!String.IsNullOrWhiteSpace(Kind))
            {
                if (Kind == "FVP")
                    url = FVP;
                else if (Kind == "TIP")
                    url = TIP;
                else if (Kind == "TFP")
                    url = TFP;
            }
            output.Attributes.SetAttribute("href", url);
            output.Attributes.SetAttribute("target", "_blank");
            output.Attributes.SetAttribute("class", "font-medium text-indigo-700 underline hover:text-indigo-600");

            string packetKindDisplay = "UDS Coding Guidebook for Visit Packet";

            if (Kind == "IVP")
                packetKindDisplay = "UDS Coding Guidebook for In-person Initial Visit Packet";
            else if (Kind == "FVP")
                packetKindDisplay = "UDS Coding Guidebook for Follow-up Visit Packet";
            else if (Kind == "TIP")
                packetKindDisplay = "UDS Coding Guidebook for Telephone Initial Visit Packet";
            else if (Kind == "TFP")
                packetKindDisplay = "UDS Coding Guidebook for Telephone Follow-up Visit Packet";

            output.Content.Append($"{packetKindDisplay}");
        }
    }
}

