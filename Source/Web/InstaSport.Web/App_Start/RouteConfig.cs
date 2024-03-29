﻿namespace InstaSport.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "LocationPage",
                url: "Location/{id}",
                defaults: new { controller = "Locations", action = "ById" },
                namespaces: new[] { "InstaSport.Web.Controllers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "InstaSport.Web.Controllers" });
        }
    }
}
