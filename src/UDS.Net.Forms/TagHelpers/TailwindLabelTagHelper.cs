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

        private const string css = "text-base font-semibold text-gray-900";
        // block text-sm font-medium leading-6 text-gray-900
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output); // use built-in tag helper to process the remainder

            output.Attributes.Add("class", css);

            // TODO check for user preferences on whether they want to see UDS variables and wrap this in a conditional
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
    }
}

