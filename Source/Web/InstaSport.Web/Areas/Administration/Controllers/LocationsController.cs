namespace InstaSport.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Controllers;
    using Infrastructure.Mapping;
    using InstaSport.Data.Common;
    using InstaSport.Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using ViewModels.Home;

    public class LocationsController : AdministrationController
    {
        public IDbRepository<Location> locations;

        public LocationsController(IDbRepository<Location> locations)
        {
            this.locations = locations;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Locations_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.locations.All()
                .To<AdminLocationViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Locations_Update([DataSourceRequest]DataSourceRequest request, AdminInputLocationViewModel location)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.locations.GetById(location.Id);
                entity.Name = location.Name;

                this.locations.Save();
            }

            var locationToDisplay = this.locations.All()
                            .To<AdminInputLocationViewModel>()
                           .FirstOrDefault(x => x.Id == location.Id);

            return this.Json(new[] { locationToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Locations_Destroy([DataSourceRequest]DataSourceRequest request, Location location)
        {
            this.locations.Delete(location);
            this.locations.Save();

            return this.Json(new[] { location }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
