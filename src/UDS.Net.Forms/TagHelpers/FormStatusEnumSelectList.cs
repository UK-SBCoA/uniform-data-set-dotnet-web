using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using UDS.Net.Forms.Models;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.TagHelpers
{
    [HtmlTargetElement("enum-select", Attributes = "for")]
    public class FormStatusEnumSelectList : TagHelper
    {
        public IEnumerable<RadioListItem> Items { get; set; }

        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        private string _cssClass = "mt-2 block w-full rounded-md border-0 py-1.5 pl-3 pr-10 text-gray-900 ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-indigo-600 sm:text-sm sm:leading-6";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes.SetAttribute("class", _cssClass);

            string expression = "";
            if (For != null)
            {
                // get full name from for model property
                expression = For.Name;
                string prefix = ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
                if (!String.IsNullOrWhiteSpace(prefix))
                    expression = prefix + "." + expression;

                output.Attributes.SetAttribute("name", expression);
                output.Attributes.SetAttribute("id", expression.Replace(".", "_"));
            }
            output.Attributes.SetAttribute("data-val-status", expression);
            output.Attributes.SetAttribute("data-val", "true");
            output.Attributes.SetAttribute("data-val-required", "Required");

            output.PostContent.AppendHtml(GenerateOptions());

            base.Process(context, output);
        }

        private string[] SplitCamelCase(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }

        private IHtmlContent GenerateOptions()
        {
            var enumValues = Enum.GetValues(typeof(FormStatus));
            var optionsBuilder = new HtmlContentBuilder(enumValues.Length);

            foreach (int i in enumValues)
            {
                var option = new TagBuilder("option");

                string formattedName = "";
                var name = Enum.GetName(typeof(FormStatus), i);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    string[] split = SplitCamelCase(name);
                    formattedName = string.Join(" ", split);
                }

                option.InnerHtml.AppendLine(formattedName);

                var form = (FormModel)ViewContext.ViewData.Model;

                if (form != null)
                {
                    if ((int)form.Status == i)
                    {
                        option.Attributes["selected"] = "true"; // select the current status
                    }

                    // additionally, if the select option is for not started
                    if (i == (int)FormStatus.NotStarted)
                    {
                        option.Attributes["disabled"] = "disabled";
                        if (ViewContext.ViewData.Model != null && ViewContext.ViewData.Model is FormModel)
                        {
                            if (form.Id <= 0 && (form.Status == FormStatus.NotStarted))
                            {
                                option.Attributes["selected"] = "true";
                            }
                        }
                    }
                    else
                    {
                        // Only set value for statuses that should be allowed to be selected
                        // "NotStarted" should never have a value
                        // "NotIncluded" should only have a value on optional forms
                        if (i == (int)FormStatus.NotIncluded && form.IsRequiredForPacketKind)
                        {
                            option.Attributes["disabled"] = "disabled";
                        }
                        else
                            option.Attributes["value"] = i.ToString();
                    }
                }

                optionsBuilder.AppendLine(option);
            }

            return optionsBuilder;
        }
    }
}

