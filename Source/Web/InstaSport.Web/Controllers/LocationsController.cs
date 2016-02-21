namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using InstaSport.Services.Data;
    using InstaSport.Web.ViewModels.Home;
    using Microsoft.AspNet.Identity;

    public class LocationsController : BaseController
    {
        private readonly ILocationsService locations;

        public LocationsController(
            ILocationsService locations)
        {
            this.locations = locations;
        }

        public ActionResult Index()
        {
            var locations = this.locations.GetAll();
            var viewModel = locations.To<LocationViewModel>().ToList();

            return this.View(viewModel);
        }

        public ActionResult ById(string id)
        {
            var location = this.locations.GetById(id);
            var viewModel = this.Mapper.Map<LocationViewModel>(location);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Rate(int locationId, int rating)
        {
            var userId = this.User.Identity.GetUserId();
            var newRating = this.locations.Rate(userId, locationId, rating);

            return this.Json(new { Rating = newRating });
        }
    }
}
