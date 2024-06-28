using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.TagHelpers
{
    // https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.TagHelpers/src/SelectTagHelper.cs
    // decorating a class with multiple HtmlTargetElement attributes results in a logical-OR
    [HtmlTargetElement("enum-select")]
    [HtmlTargetElement("enum-select", Attributes = EnabledValuesAttributeName)]
    public class EnumSelectList : TagHelper
    {
        private const string ForAttributeName = "for";
        private const string ItemsAttributeName = "items";
        private const string EnabledValuesAttributeName = "enabled-values";

        public ModelExpression For { get; set; }

        public IEnumerable<SelectListItem> Items { get; set; } = new List<SelectListItem>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected IHtmlGenerator Generator { get; }


        /// <summary>
        /// A collection of values that should be enabled
        /// </summary>
        [HtmlAttributeName(EnabledValuesAttributeName)]
        public IEnumerable<int> EnabledValues { get; set; } = new List<int>();

        public EnumSelectList(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(output);

            output.TagName = "select";

            output.Attributes.SetAttribute("data-val", "true");
            output.Attributes.SetAttribute("data-val-required", "Required");


            //// Pass through attribute that is also a well-known HTML attribute. Must be done prior to any copying
            //// from a TagBuilder.
            //if (Name != null)
            //{
            //    output.CopyHtmlAttribute(nameof(Name), context);
            //}

            // Ensure GenerateSelect() _never_ looks anything up in ViewData.
            var items = Items ?? Enumerable.Empty<SelectListItem>();

            // Set disabled attribute and use description for text
            if (EnabledValues != null)
            {
                foreach (var item in items)
                {

                    if (EnabledValues.Count() == 0) // if there are no enabled values all are disabled
                        item.Disabled = true;
                    else if (!EnabledValues.Contains(Int32.Parse(item.Value)))
                        item.Disabled = true;

                }
            }

            if (For == null)
            {
                var options = Generator.GenerateGroupsAndOptions(optionLabel: null, selectList: items);
                output.PostContent.AppendHtml(options);
                return;
            }

            // Ensure Generator does not throw due to empty "fullName" if user provided a name attribute.
            //IDictionary<string, object> htmlAttributes = null;
            //if (string.IsNullOrEmpty(For.Name) &&
            //    string.IsNullOrEmpty(ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix) &&
            //    !string.IsNullOrEmpty(Name))
            //{
            //    htmlAttributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            //    {
            //        { "name", Name },
            //    };
            //}

            var tagBuilder = Generator.GenerateSelect(
                ViewContext,
                For.ModelExplorer,
                optionLabel: null,
                expression: For.Name,
                selectList: items,
                allowMultiple: false,
                htmlAttributes: new Dictionary<string, object>());

            if (tagBuilder != null)
            {
                output.MergeAttributes(tagBuilder); // keep attributes from view

                if (tagBuilder.HasInnerHtml)
                {
                    output.PostContent.AppendHtml(tagBuilder.InnerHtml);
                }
            }
        }
    }
}

