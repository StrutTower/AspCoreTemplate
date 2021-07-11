using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace AspCoreTemplate.TagHelpers {
    [HtmlTargetElement("a", Attributes = "asp-enabled")]
    public class AnchorEnabledTagHelper : TagHelper {
        [HtmlAttributeName("asp-enabled")]
        public bool Enabled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            base.Process(context, output);

            if (!Enabled) {
                output.AddClass("disable-link", HtmlEncoder.Default);
            }
        }
    }
}