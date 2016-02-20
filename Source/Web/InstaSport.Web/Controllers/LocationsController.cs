namespace InstaSport.Web.Controllers
{
    using System.Web.Mvc;

    using InstaSport.Services.Data;
    using InstaSport.Web.ViewModels.Home;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using Data.Models;
    public class LocationsController : BaseController
    {
        private readonly ILocationsService locations;

        public LocationsController(
            ILocationsService locations)
        {
            this.locations = locations;
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
