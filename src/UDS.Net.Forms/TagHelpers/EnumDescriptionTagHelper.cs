using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc.Rendering;
using UDS.Net.Forms.Extensions;

namespace UDS.Net.Forms.TagHelpers
{
    [HtmlTargetElement(Attributes = DescriptionForAttributeName)]
    public class EnumDescriptionTagHelper : TagHelper
    {
        private const string DescriptionForAttributeName = "enum-description-for";

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected IHtmlGenerator Generator { get; }

        [HtmlAttributeName(DescriptionForAttributeName)]
        public ModelExpression DescriptionFor { get; set; }

        public EnumDescriptionTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var metadata = DescriptionFor.Metadata;

            if (metadata == null)
            {
                throw new InvalidOperationException(string.Format("No property provided ({0})", DescriptionForAttributeName));
            }

            string description = metadata.Description; // value if there is a display-for

            if (metadata.IsEnum)
            {
                if (DescriptionFor.ModelExplorer.Model != null)
                    description = ((Enum)DescriptionFor.ModelExplorer.Model).GetDescription();
            }

            output.Attributes.SetAttribute("id", metadata.PropertyName + "-description");

            if (!string.IsNullOrWhiteSpace(description))
            {
                output.Content.SetContent(description);
                output.TagMode = TagMode.StartTagAndEndTag;
            }
        }
    }
}

