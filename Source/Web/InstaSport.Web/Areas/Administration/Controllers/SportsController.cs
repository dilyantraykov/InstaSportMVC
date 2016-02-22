namespace InstaSport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using InstaSport.Data.Common;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;

    public class SportsController : AdministrationController
    {
        public IDbRepository<Sport> sports;

        public SportsController(IDbRepository<Sport> sports)
        {
            this.sports = sports;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Sports_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.sports.All()
                .To<AdminSportViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Sports_Create([DataSourceRequest]DataSourceRequest request, AdminInputSportViewModel sport)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Sport
                {
                    Name = sport.Name
                };

                this.sports.Add(entity);
                this.sports.Save();
                newId = entity.Id;
            }

            var postToDisplay = this.sports.All()
                .To<AdminSportViewModel>()
                .FirstOrDefault(x => x.Id == newId);
            return this.Json(new[] { postToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Sports_Update([DataSourceRequest]DataSourceRequest request, AdminInputSportViewModel sport)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.sports.GetById(sport.Id);
                entity.Name = sport.Name;

                this.sports.Save();
            }

            var sportToDisplay = this.sports.AllWithDeleted()
                            .To<AdminSportViewModel>()
                           .FirstOrDefault(x => x.Id == sport.Id);

            return this.Json(new[] { sportToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Sports_Destroy([DataSourceRequest]DataSourceRequest request, Sport sport)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.sports.GetById(sport.Id);
                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;

                this.sports.Save();
            }

            var sportToDisplay = this.sports.All()
                            .To<AdminSportViewModel>()
                           .FirstOrDefault(x => x.Id == sport.Id);

            return this.Json(new[] { sportToDisplay }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
