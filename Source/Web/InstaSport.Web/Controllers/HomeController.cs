namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;
    using System.Web;
    using System;
    public class HomeController : BaseController
    {
        private readonly ILocationsService locations;
        private readonly ISportsService sports;
        private readonly IGamesService games;

        public HomeController(
            ILocationsService locations,
            ISportsService sports,
            IGamesService games)
        {
            this.locations = locations;
            this.sports = sports;
            this.games = games;
        }

        public ActionResult Index()
        {
            var locations = this.Cache.Get(
                            "locationsCount",
                            () => this.locations.GetCount(),
                            30 * 60);
            var sports = this.Cache.Get(
                            "sportsCount",
                            () => this.sports.GetCount(),
                            30 * 60);
            var games = this.Cache.Get(
                            "gamesCount",
                            () => this.games.GetCount(),
                            30 * 60);

            var viewModel = new IndexViewModel
            {
                Locations = locations,
                Sports = sports,
                Games = games
            };

            return this.View(viewModel);
        }

        public ActionResult SetLanguage(string lang)
        {
            HttpCookie cookie = new HttpCookie("lang", lang);
            cookie.Expires = DateTime.Now.AddDays(30);
            this.HttpContext.Response.Cookies.Add(cookie);
            return this.Redirect(this.Request.UrlReferrer.LocalPath);
        }
    }
}
