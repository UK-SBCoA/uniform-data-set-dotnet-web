using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UDS.Net.Forms.TagHelpers
{
    [HtmlTargetElement("input", Attributes = "asp-for")]
    public class InputTagHelper : TagHelper
    {
        public UIRangeToggle UIRangeBehavior { get; set; } = new UIRangeToggle();

        private const string css = "block w-full max-w-lg rounded-md border-gray-400 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:max-w-xs sm:text-sm placeholder:text-gray-400 disabled:bg-slate-50 disabled:text-slate-500 disabled:border-slate-200 disabled:shadow-none";
        // validation error  "block w-full rounded-md border-0 py-1.5 pr-10 text-red-900 ring-1 ring-inset ring-red-300 placeholder:text-red-300 focus:ring-2 focus:ring-inset focus:ring-red-500 sm:text-sm sm:leading-6"
        public InputTagHelper(IHtmlGenerator generator)
        {
        }

        // block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.Attributes.Where(a => a.Name == "type").Any())
            {
                var inputType = output.Attributes.Where(a => a.Name == "type").FirstOrDefault();

                if (inputType != null && inputType.Value.ToString() != "hidden")
                    output.Attributes.Add("class", css);
            }

            if (UIRangeBehavior.Behaviors.Any())
            {
                output.Attributes.Add("data-affects", "true");

                var behaviorJson = new List<string>();

                foreach (var behavior in UIRangeBehavior.Behaviors)
                {
                    string targets = "";

                    foreach (var att in behavior.PropertyAttributes)
                    {
                        targets += att.ToJSON() + ", ";
                    }

                    targets = targets.Trim().TrimEnd(',');

                    behaviorJson.Add($$"""
                        {
                            "low": {{behavior.Low}},
                            "high": {{behavior.High}},
                            "targets": [ {{targets}} ],
                            "instruction": "{{behavior.InstructionalMessage}}"
                        }
                        """);
                }

                output.Attributes.Add(
                    "data-affects-range-behaviors",
                    "[" + string.Join(",", behaviorJson) + "]");
            }

            base.Process(context, output);
        }
    }
}

