namespace InstaSport.Web.Areas.Administration.Views
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using InstaSport.Data.Common;
    using InstaSport.Data.Models;
    using InstaSport.Web.Areas.Administration.Models;
    using InstaSport.Web.Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;

    public class GamesController : Controller
    {
        public IGamesService games;
        public ILocationsService locations;

        public GamesController(
            IGamesService games,
            ILocationsService locations)
        {
            this.games = games;
            this.locations = locations;
        }

        public ActionResult Index()
        {
            this.ViewData["locations"] = this.locations.GetAll().To<AdminLocationViewModel>().ToList();

            return this.View();
        }

        public ActionResult Games_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.games.GetAll()
                .To<AdminGameViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Games_Update([DataSourceRequest]DataSourceRequest request, AdminInputGameViewModel game)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.games.GetById(game.Id);
                entity.LocationId = game.LocationId;
                entity.MinPlayers = game.MinPlayers;
                entity.MaxPlayers = game.MaxPlayers;
                entity.StartingDateTime = game.StartingDateTime;

                this.games.Save();
            }

            var gameToDisplay = this.games.GetAll()
                            .To<AdminGameViewModel>()
                           .FirstOrDefault(x => x.Id == game.Id);

            return this.Json(new[] { gameToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Games_Destroy([DataSourceRequest]DataSourceRequest request, Game game)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.games.GetById(game.Id);
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.UtcNow;

                this.games.Save();
            }

            var gameToDisplay = this.games.GetAll()
                            .To<AdminGameViewModel>()
                           .FirstOrDefault(x => x.Id == game.Id);

            return this.Json(new[] { gameToDisplay }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
