﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspCoreTemplate.TagHelpers {
    [HtmlTargetElement("*", Attributes = "asp-visible")]
    public class VisibleTagHelper : TagHelper {
        [HtmlAttributeName("asp-visible")]
        public bool Visible { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            base.Process(context, output);

            if (!Visible) output.Attributes.Add("hidden", "");
        }
    }
}