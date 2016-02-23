namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using InstaSport.Data.Common;
    using InstaSport.Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;
    using InstaSport.Web.ViewModels.Cities;

    public class CitiesController : BaseController
    {
        private IDbRepository<City> cities;

        public CitiesController(IDbRepository<City> cities)
        {
            this.cities = cities;
        }

        public ActionResult Index()
        {
            var cities = this.Cache.Get(
                            "cities",
                            () => this.cities.All().To<CityViewModel>().ToList(),
                            30 * 60);

            return this.View(cities);
        }
    }
}