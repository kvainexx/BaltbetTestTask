using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TestTask.UW.Helpers
{

    public static class HtmlHelperExtensions
    {
        public static string ActiveTab(this HtmlHelper helper, string action, string controller)
        {
            string classValue = "";

            var currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            var currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            if (currentController.ToLower() == controller.ToLower() && currentAction.ToLower() == action.ToLower())
                classValue = "active";

            return classValue;
        }


        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string action, string controller, bool enabled)
        {
            if (!enabled)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", "javascript:void(0);");
                tag.SetInnerText(linkText);
                return MvcHtmlString.Create(tag.ToString());
            }

            return helper.ActionLink(linkText, action, controller);
        }


    }

}