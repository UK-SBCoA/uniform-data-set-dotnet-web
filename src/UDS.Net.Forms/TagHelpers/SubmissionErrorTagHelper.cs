using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Forms.Models;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.TagHelpers
{
    [HtmlTargetElement("submission-error")]
    public class SubmissionErrorTagHelper : TagHelper
    {
        [HtmlAttributeName("location")]
        public string Location { get; set; }

        [HtmlAttributeName("errors")]
        public IEnumerable<PacketSubmissionErrorModel> Errors { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            if (Errors == null || string.IsNullOrWhiteSpace(Location))
                return;

            var errorsForField = Errors
                .Where(e => string.Equals(e.Location, Location, StringComparison.OrdinalIgnoreCase) &&
                            !e.IsDeleted && string.IsNullOrEmpty(e.ResolvedBy));

            foreach (var error in errorsForField)
            {
                string colorClass = error.Level switch
                {
                    PacketSubmissionErrorLevel.Critical => "text-red-600",
                    PacketSubmissionErrorLevel.Error => "text-red-600",
                    PacketSubmissionErrorLevel.Warning => "text-yellow-600",
                    PacketSubmissionErrorLevel.Information => "text-blue-600",
                    _ => "text-gray-600"
                };

                var span = $@"<span class=""block mt-2 text-sm {colorClass}"">{error.Message}</span>";

                output.Content.AppendHtml(span);
            }
        }
    }
}
