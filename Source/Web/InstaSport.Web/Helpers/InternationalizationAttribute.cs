namespace InstaSport.Web.Helpers
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    public class InternationalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies.Get("lang");
            string language = cookie == null ? "en" : cookie.Value;

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format(language));
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format(language));
        }
    }
}