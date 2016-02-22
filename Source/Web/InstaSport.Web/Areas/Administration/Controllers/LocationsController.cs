namespace InstaSport.Web.Areas.Administration.Controllers
{
    using System;
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
        public IDbRepository<City> cities;

        public LocationsController(IDbRepository<Location> locations,
            IDbRepository<City> cities)
        {
            this.locations = locations;
            this.cities = cities;
        }

        public ActionResult Index()
        {
            this.ViewData["cities"] = this.cities.All().To<AdminCityViewModel>().ToList();

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
        public ActionResult Locations_Create([DataSourceRequest]DataSourceRequest request, AdminInputLocationViewModel location)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Location
                {
                    Name = location.Name,
                    CityId = location.CityId
                };

                this.locations.Add(entity);
                this.locations.Save();
                newId = entity.Id;
            }

            var locationToDisplay = this.locations.All()
                .To<AdminLocationViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { locationToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Locations_Update([DataSourceRequest]DataSourceRequest request, AdminInputLocationViewModel location)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.locations.GetById(location.Id);
                entity.Name = location.Name;
                entity.CityId = location.CityId;

                this.locations.Save();
            }

            var locationToDisplay = this.locations.AllWithDeleted()
                            .To<AdminLocationViewModel>()
                           .FirstOrDefault(x => x.Id == location.Id);

            return this.Json(new[] { locationToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Locations_Destroy([DataSourceRequest]DataSourceRequest request, Location location)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.locations.GetById(location.Id);
                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;

                this.locations.Save();
            }

            var locationToDisplay = this.locations.All()
                            .To<AdminLocationViewModel>()
                           .FirstOrDefault(x => x.Id == location.Id);

            return this.Json(new[] { locationToDisplay }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
