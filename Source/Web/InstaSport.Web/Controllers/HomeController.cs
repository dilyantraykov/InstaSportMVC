namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ILocationsService locations;
        private readonly ISportsService sports;

        public HomeController(
            ILocationsService locations,
            ISportsService sports)
        {
            this.locations = locations;
            this.sports = sports;
        }

        public ActionResult Index()
        {
            var locations = this.locations.GetAll().To<LocationViewModel>().ToList();
            var sports =
                this.Cache.Get(
                    "sports",
                    () => this.sports.GetAll().To<SportsViewModel>().ToList(),
                    30 * 60);
            var viewModel = new IndexViewModel
            {
                Locations = locations,
                Sports = sports
            };

            return this.View(viewModel);
        }
    }
}
