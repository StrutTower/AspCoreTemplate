﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;

namespace AspCoreTemplate.Utilities {
    public static class HtmlHelperExtensions {
        #region DisplayFor TagHelper Helpers
        public static IHtmlContent Display(this IHtmlHelper htmlHelper, ModelExpression modelExpression, string templateName) {
            if (htmlHelper is HtmlHelper htmlHelperConcrete) {
                if (_getDisplayThunk == null) {
                    var methodInfo = typeof(HtmlHelper).GetTypeInfo().GetMethod("GenerateDisplay", BindingFlags.NonPublic | BindingFlags.Instance);
                    _getDisplayThunk = (Func<HtmlHelper, ModelExplorer, string, string, object, IHtmlContent>)methodInfo
                        .CreateDelegate(typeof(Func<HtmlHelper, ModelExplorer, string, string, object, IHtmlContent>));
                }
                return _getDisplayThunk(htmlHelperConcrete, modelExpression.ModelExplorer, GetExpressionText(modelExpression.Name), templateName, null);
            }
            return htmlHelper.Display(GetExpressionText(modelExpression.Name), templateName);
        }

        private static Func<HtmlHelper, ModelExplorer, string, string, object, IHtmlContent> _getDisplayThunk;

        private static string GetExpressionText(string expression) {
            // If it's exactly "model", then give them an empty string, to replicate the lambda behavior.
            return string.Equals(expression, "model", StringComparison.OrdinalIgnoreCase) ? string.Empty : expression;
        }
        #endregion

        internal static string ToRawString(this IHtmlContent htmlContent) {
            using (StringWriter writer = new StringWriter()) {
                htmlContent.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
