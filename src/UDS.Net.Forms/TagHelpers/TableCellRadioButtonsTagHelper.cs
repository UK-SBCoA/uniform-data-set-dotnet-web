using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    [HtmlTargetElement("table-cell-radio-buttons", Attributes = "id,for,items")]
    public class TableCellRadioButtonsTagHelper : TagHelper
    {
        public IEnumerable<RadioListItem> Items { get; set; }

        public Dictionary<string, UIBehavior> UIBehaviors { get; set; } = new Dictionary<string, UIBehavior>();

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

            output.TagName = "";

            if (For == null)
            {
                // nothing bound
                var cells = GenerateTableCellRadioInputs(items, "");
                output.PostContent.SetHtmlContent(cells);// = cells;
                return;
            }

            // get full name from for model property
            var expression = For.Name;
            var prefix = ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
            if (!String.IsNullOrWhiteSpace(prefix))
                prefix = prefix + ".";

            var cellsWithName = GenerateTableCellRadioInputs(items, expression, output.Attributes);
            output.PostContent.SetHtmlContent(cellsWithName);

            output.Attributes.Clear();
            output.Attributes.SetAttribute("class", "mt-4 space-y-2");
        }

        private IHtmlContent GenerateTableCellRadioInputs(IEnumerable<RadioListItem> items, string name, TagHelperAttributeList? parentAttributes = null)
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

                var cell = new TagBuilder("td");

                //if text and value strings are null or empty, only create a <td></td>
                if (String.IsNullOrEmpty(itemsList[i].Text) && String.IsNullOrEmpty(itemsList[i].Value))
                {
                    radioButtonListBuilder.AppendLine(cell);
                }
                else
                {
                    var outerDiv = new TagBuilder("div");
                    outerDiv.Attributes["class"] = "relative flex items-start";

                    var innerDiv = new TagBuilder("div");
                    innerDiv.Attributes["class"] = "flex items-center";

                    innerDiv.InnerHtml.AppendLine(radio);
                    innerDiv.InnerHtml.AppendLine(label);

                    outerDiv.InnerHtml.AppendLine(innerDiv);
                    cell.InnerHtml.AppendLine(outerDiv);

                    radioButtonListBuilder.AppendLine(cell);
                }
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

            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes["type"] = "radio";
            tagBuilder.Attributes["id"] = $"{Id}[{index}]";
            tagBuilder.Attributes["value"] = item.Value;
            tagBuilder.Attributes["class"] = "h-4 border-gray-400 text-indigo-600 focus:ring-indigo-600 disabled:bg-slate-50 disabled:text-slate-500 disabled:border-slate-200 disabled:shadow-none";

            //if (name == "D1b.CSFAD")
            //{
            //    //tagBuilder.Attributes["asp-for"] = "D1b.CSFAD";

            //    tagBuilder.Attributes["data-val"] = "true";
            //    tagBuilder.Attributes["data-val-requiredifrange"] = "Please specify.";
            //    tagBuilder.Attributes["data-val-requiredifrange-watchedfield"] = "D1b.FLUIDBIOM";
            //    //tagBuilder.Attributes["data-val-requiredifrange-highvalue"] = "3";
            //    //tagBuilder.Attributes["data-val-requiredifrange-lowvalue"] = "2";
            //}

            if (parentAttributes != null)
            {
                foreach (var attribute in parentAttributes)
                {
                    tagBuilder.Attributes.Add(new KeyValuePair<string, string?>(attribute.Name, attribute.Value.ToString()));
                }
            }

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
            if (UIBehaviors != null && UIBehaviors.Count() > 0)
            {
                foreach (var ui in UIBehaviors)
                {
                    if (ui.Key == item.Value)
                    {
                        tagBuilder.Attributes["data-affects"] = "true";
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
                        tagBuilder.Attributes["data-affects-targets"] = "[ " + json + " ]"; // js expects an array
                    }
                }
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

            return tagBuilder;
        }
    }
}

