using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspCoreTemplate.TagHelpers {
    public class TruncateTagHelper : TagHelper {
        public string String { get; set; }

        public int Characters { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.TagName = null;
            string outputString = String;
            if (String.Length > Characters) {
                outputString = String.Substring(0, Characters) + "...";
            }
            output.Content.SetContent(outputString);
        }
    }
}
