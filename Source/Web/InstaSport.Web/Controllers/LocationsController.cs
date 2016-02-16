namespace InstaSport.Web.Controllers
{
    using System.Web.Mvc;

    using InstaSport.Services.Data;
    using InstaSport.Web.ViewModels.Home;

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
    }
}
