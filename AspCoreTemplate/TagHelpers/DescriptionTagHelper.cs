using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspCoreTemplate.TagHelpers {
    [HtmlTargetElement("description")]
    public class DescriptionTagHelper : TagHelper {

        [HtmlAttributeName("asp-for")]
        public ModelExpression Model { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.Attributes.Add("class", "form-help-text");
            var prop = Model.Metadata.ContainerType.GetProperty(Model.Name);
            if (prop != null) {
                object descAttr = prop.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault();
                if (descAttr != null) {
                    DescriptionAttribute attr = (DescriptionAttribute)descAttr;
                    output.Content.SetContent(attr.Description);
                }

                object disAttr = prop.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
                if (disAttr != null) {
                    DisplayAttribute attr = (DisplayAttribute)disAttr;
                    output.Content.SetContent(attr.Description);
                }
            }
        }
    }
}