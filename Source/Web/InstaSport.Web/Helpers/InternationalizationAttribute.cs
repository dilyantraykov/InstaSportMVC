namespace InstaSport.Web.Helpers
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    public class InternationalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string language = (string)filterContext.HttpContext.Session["language"] ?? "en";

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format(language));
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format(language));
        }
    }
}