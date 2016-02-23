namespace InstaSport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using InstaSport.Data.Common;
    using InstaSport.Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;

    public class CitiesController : AdministrationController
    {
        public IDbRepository<City> cities;

        public CitiesController(IDbRepository<City> cities)
        {
            this.cities = cities;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Cities_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.cities.All()
                .To<AdminCityViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Create([DataSourceRequest]DataSourceRequest request, AdminInputCityViewModel city)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new City
                {
                    Name = city.Name
                };

                this.cities.Add(entity);
                this.cities.Save();
                newId = entity.Id;
            }

            var postToDisplay = this.cities.All()
                .To<AdminCityViewModel>()
                .FirstOrDefault(x => x.Id == newId);
            return this.Json(new[] { postToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Update([DataSourceRequest]DataSourceRequest request, AdminInputCityViewModel citie)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.cities.GetById(citie.Id);
                entity.Name = citie.Name;

                this.cities.Save();
            }

            var citieToDisplay = this.cities.AllWithDeleted()
                            .To<AdminCityViewModel>()
                           .FirstOrDefault(x => x.Id == citie.Id);

            return this.Json(new[] { citieToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Destroy([DataSourceRequest]DataSourceRequest request, City city)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.cities.GetById(city.Id);
                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;

                this.cities.Save();
            }

            var citieToDisplay = this.cities.All()
                            .To<AdminCityViewModel>()
                           .FirstOrDefault(x => x.Id == city.Id);

            return this.Json(new[] { citieToDisplay }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
