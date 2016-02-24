namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using InstaSport.Services.Data;
    using Microsoft.AspNet.Identity;
    using ViewModels.Games;
    using System;
    public class GamesController : BaseController
    {
        private IGamesService games;
        private ISportsService sports;
        private ILocationsService locations;
        private IDbRepository<City> cities;
        private readonly UserManager<User> manager;

        public GamesController(
            IGamesService games,
            ISportsService sports,
            ILocationsService locations,
            IDbRepository<City> cities,
            UserManager<User> manager)
        {
            this.games = games;
            this.manager = manager;
            this.sports = sports;
            this.locations = locations;
            this.cities = cities;
        }

        public ActionResult Index()
        {
            var games = this.games.GetUpcoming()
                .To<UpcomingGameViewModel>()
                .Take(10);

            return this.View(games);
        }

        public ActionResult ById(int id)
        {
            var game = this.games.GetById(id);
            var viewModel = this.Mapper.Map<GameDetailsViewModel>(game);

            return this.View(viewModel);
        }

        public ActionResult BySport(int id)
        {
            var games = this.games.GetBySport(id).To<UpcomingGameViewModel>().ToList();
            var sport = this.sports.GetById(id).Name;
            var viewModel = new GamesBySportViewModel()
            {
                Games = games,
                SportName = sport
            };

            return this.View(viewModel);
        }

        public ActionResult ByCity(int id)
        {
            var games = this.games.GetByCity(id).To<UpcomingGameViewModel>().ToList();
            var city = this.cities.GetById(id).Name;
            var viewModel = new GamesByCityViewModel()
            {
                Games = games,
                CityName = city
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new GameInputViewModel();

            viewModel.Locations = this.locations.GetAll();
            viewModel.Sports = this.sports.GetAll();
            viewModel.StartingDateTime = DateTime.Now;

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var game = new Game()
            {
                SportId = model.SportId,
                LocationId = model.LocationId,
                MinPlayers = model.MinPlayers,
                MaxPlayers = model.MaxPlayers,
                StartingDateTime = model.StartingDateTime
            };

            var gameId = this.games.Create(game);

            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.Identity.GetUserId();
                var user = this.manager.Users.FirstOrDefault(u => u.Id == userId);

                this.games.AddPlayer(gameId, user);
            }

            this.TempData["Success"] = "Game successfully created!";
            return this.Redirect("/");
        }

        [HttpPost]
        public ActionResult Join(int id)
        {
            var usedId = this.User.Identity.GetUserId();
            var user = this.manager.Users.FirstOrDefault(u => u.Id == usedId);
            var game = this.games.GetById(id);

            var totalPlayers = this.games.AddPlayer(id, user);
            var maxPlayers = game.MinPlayers == null ? game.MaxPlayers : game.MinPlayers;
            var goalPlayers = maxPlayers == null ? 1 : maxPlayers;
            var progress = ((double)totalPlayers / goalPlayers) * 100;

            return this.Json(new { PlayersCount = totalPlayers, Progress = progress });
        }
    }
}