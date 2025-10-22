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

        public Dictionary<string, UIBehavior> UIBehaviors { get; set; } = new Dictionary<string, UIBehavior>();

        public ModelExpression For { get; set; }

        public string Id { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        private readonly IHtmlGenerator _generator;

        public RadioButtonGroupTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var items = Items ?? Enumerable.Empty<RadioListItem>();

            if (String.IsNullOrWhiteSpace(Id))
            {
                Random random = new Random();
                Id = $"RadioButtonGroup{random.Next(1, 100)}";
            }

            output.TagName = "fieldset"; // overwrites custom tag

            if (For == null)
            {
                // nothing bound
                var radios = GenerateRadioInputs(items, "");
                output.PostContent.AppendHtml(radios);
                return;
            }

            // get full name from for model property
            var expression = ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(For.Name);

            // if the radio button group has Stimulus data attributes, render them on the child inputs
            var radiosWithName = GenerateRadioInputs(items, expression, output.Attributes);
            output.PostContent.AppendHtml(radiosWithName);

            // clear any parent attributes, but save them to be rendered on child inputs
            output.Attributes.Clear();
            output.Attributes.SetAttribute("class", "mt-4 space-y-2");
        }

        private IHtmlContent GenerateRadioInputs(IEnumerable<RadioListItem> items, string name, TagHelperAttributeList? parentAttributes = null)
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
                var radio = GenerateRadioInput(item, i, name, parentAttributes);
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

        private TagBuilder GenerateRadioInput(RadioListItem item, int index, string name, TagHelperAttributeList? parentAttributes = null)
        {
            var selected = false;
            var modelValue = "";

            if (For != null && For.Model != null)
                modelValue = For.Model.ToString();

            if (item.Value == modelValue)
                selected = true;

            // DEV NOTE: Generate radio button element with IHtmlGenerator
            var radio = _generator.GenerateRadioButton(ViewContext, For.ModelExplorer, name, item.Value, selected, $"{Id}[{index}]");

            radio.Attributes["id"] = $"{Id}[{index}]";
            radio.Attributes["name"] = name;
            radio.Attributes["class"] = "h-4 border-gray-400 text-indigo-600 focus:ring-indigo-600 disabled:bg-slate-50 disabled:text-slate-500 disabled:border-slate-200 disabled:shadow-none";

            if (parentAttributes != null)
            {
                foreach (var attribute in parentAttributes)
                {
                    radio.Attributes.Add(new KeyValuePair<string, string?>(attribute.Name, attribute.Value.ToString()));
                }
            }

            if (UIBehaviors != null && UIBehaviors.Count() > 0)
            {
                foreach (var ui in UIBehaviors)
                {
                    if (ui.Key == item.Value)
                    {
                        radio.Attributes["data-affects"] = "true";
                        string json = "";
                        if (ui.Value.PropertyAttributes.Count() == 1)
                        {
                            json = ui.Value.PropertyAttributes[0].ToJSON();
                        }
                        else if (ui.Value.PropertyAttributes.Count() > 1)
                        {
                            foreach (var att in ui.Value.PropertyAttributes)
                            {
                                json += att.ToJSON();
                                if (ui.Value.PropertyAttributes.Count() > 1)
                                    json += ", ";
                            }
                            json = json.Trim().TrimEnd(',');
                        }
                        radio.Attributes["data-affects-targets"] = "[ " + json + " ]"; // js expects an array
                    }
                }
            }

            return radio;
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

