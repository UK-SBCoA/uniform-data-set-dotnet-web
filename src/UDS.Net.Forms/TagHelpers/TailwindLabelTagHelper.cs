using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class TailwindLabelTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public bool ShowPropertyName { get; set; } = true;

        private const string css = "text-base font-semibold text-gray-900";
        // block text-sm font-medium leading-6 text-gray-900
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output); // use built-in tag helper to process the remainder

            output.Attributes.Add("class", css);

            if (ShowPropertyName)
            {
                string propertyName = "";

                propertyName = this.For.Name; // TODO there is a way to get the property name without a prefix, do it

                if (!String.IsNullOrEmpty(propertyName))
                {
                    TagBuilder tag = new TagBuilder("p");
                    tag.AddCssClass("mt-1 text-sm leading-6 text-gray-400");

                    tag.InnerHtml.Append(propertyName);
                    output.Content.AppendHtml(tag);
                }
            }
            else if (!ShowPropertyName)
            {
                base.Process(context, output);

                output.Attributes.Add("class", css);
            }
        }
    }
}

