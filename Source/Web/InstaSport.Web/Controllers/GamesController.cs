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

        public ActionResult ById(int gameId)
        {
            var game = this.games.GetById(gameId);
            var viewModel = this.Mapper.Map<GameDetailsViewModel>(game);

            return this.View(viewModel);
        }

        public ActionResult BySport(int sportId)
        {
            var games = this.games.GetBySport(sportId).To<UpcomingGameViewModel>().ToList();
            var sport = this.sports.GetById(sportId).Name;
            var viewModel = new GamesBySportViewModel()
            {
                Games = games,
                SportName = sport
            };

            return this.View(viewModel);
        }

        public ActionResult ByCity(int cityId)
        {
            var games = this.games.GetByCity(cityId).To<UpcomingGameViewModel>().ToList();
            var city = this.cities.GetById(cityId).Name;
            var viewModel = new GamesByCityViewModel()
            {
                Games = games,
                CityName = city
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new GameInputViewModel();

            viewModel.Locations = this.locations.GetAll();
            viewModel.Sports = this.sports.GetAll();

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
        public ActionResult Join(int gameId)
        {
            var usedId = this.User.Identity.GetUserId();
            var user = this.manager.Users.FirstOrDefault(u => u.Id == usedId);

            /*
            if (game.Players.Count >= game.MaxPlayers)
            {
                return;
            }*/

            var totalPlayers = this.games.AddPlayer(gameId, user);

            return this.Json(new { PlayersCount = totalPlayers });
        }
    }
}