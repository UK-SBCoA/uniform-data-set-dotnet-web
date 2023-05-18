using System;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    /// <summary>
    /// More info on tag helpers: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-7.0
    /// </summary>
    [HtmlTargetElement("radio-button-group", Attributes = "id,for,items")]
    public class RadioButtonGroupTagHelper : TagHelper
    {
        public IEnumerable<RadioListItem> Items { get; set; }

        public ModelExpression For { get; set; }

        public string Id { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var items = Items ?? Enumerable.Empty<RadioListItem>();

            if (String.IsNullOrWhiteSpace(Id))
            {
                Random random = new Random();
                Id = $"RadioButtonGroup{random.Next(1, 100)}";
            }

            output.TagName = "fieldset"; // overwrites custom tag
            output.Attributes.SetAttribute("class", "mt-4 space-y-2");

            if (For == null)
            {
                // nothing bound
                var radios = GenerateRadioInputs(items, "");
                output.PostContent.AppendHtml(radios);
                return;
            }

            // get full name from for model property
            var expression = For.Name;
            var prefix = ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
            if (!String.IsNullOrWhiteSpace(prefix))
                prefix = prefix + ".";

            var radiosWithName = GenerateRadioInputs(items, expression);
            output.PostContent.AppendHtml(radiosWithName);
        }

        private IHtmlContent GenerateRadioInputs(IEnumerable<RadioListItem> items, string name)
        {
            if (!(items is IList<RadioListItem> itemsList))
            {
                itemsList = items.ToList();
            }
            var count = itemsList.Count;

            if (count == 0)
                return HtmlString.Empty;

            var radioButtonListBuilder = new HtmlContentBuilder(count);

            // add radio inputs inside of fieldset
            for (var i = 0; i < itemsList.Count; i++)
            {
                var item = itemsList[i];
                var radio = GenerateRadioInput(item, i, name);
                var label = GenerateLabel(item, i);


                var outerDiv = new TagBuilder("div");
                outerDiv.Attributes["class"] = "relative flex items-start";

                var innerDiv = new TagBuilder("div");
                innerDiv.Attributes["class"] = "flex items-center";

                innerDiv.InnerHtml.AppendLine(radio);
                innerDiv.InnerHtml.AppendLine(label);

                outerDiv.InnerHtml.AppendLine(innerDiv);

                radioButtonListBuilder.AppendLine(outerDiv);
            }

            return radioButtonListBuilder;
        }

        private TagBuilder GenerateRadioInput(RadioListItem item, int index, string name)
        {
            var selected = false;
            var modelValue = "";

            if (For != null && For.Model != null)
                modelValue = For.Model.ToString();

            if (item.Value == modelValue)
                selected = true;

            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes["type"] = "radio";
            tagBuilder.Attributes["id"] = $"{Id}[{index}]";
            tagBuilder.Attributes["value"] = item.Value;
            tagBuilder.Attributes["class"] = "h-4 border-gray-300 text-indigo-600 focus:ring-indigo-600";

            if (!String.IsNullOrWhiteSpace(name))
            {
                tagBuilder.Attributes["name"] = name;
            }
            if (selected)
            {
                tagBuilder.Attributes["checked"] = "checked";
            }
            if (item.Disabled)
            {
                tagBuilder.Attributes["disabled"] = "disabled";
            }
            if (item.IfSelectedAffects != null && item.IfSelectedAffects.Count > 0)
            {
                // TODO render data attributes
            }
            return tagBuilder;
        }

        private TagBuilder GenerateLabel(RadioListItem item, int index)
        {
            var tagBuilder = new TagBuilder("label");
            tagBuilder.Attributes["for"] = $"{Id}[{index}]";
            tagBuilder.Attributes["class"] = "ml-3 block text-sm font-medium leading-6 text-gray-900";

            var span = new TagBuilder("span");
            span.Attributes["class"] = "inline-flex items-center rounded-full bg-gray-100 px-2.5 py-0.5 text-xs font-medium text-gray-800";
            span.InnerHtml.SetContent(item.Value);

            tagBuilder.InnerHtml.AppendLine(span);
            tagBuilder.InnerHtml.AppendLine(item.Text);

            return tagBuilder;
        }
    }
}

