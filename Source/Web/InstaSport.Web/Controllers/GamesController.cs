namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using InstaSport.Services.Data;
    using Microsoft.AspNet.Identity;
    using ViewModels.Games;

    public class GamesController : BaseController
    {
        private IGamesService games;
        private readonly UserManager<User> manager;

        public GamesController(
            IGamesService games,
            UserManager<User> manager)
        {
            this.games = games;
            this.manager = manager;
        }

        public ActionResult Index()
        {
            var games = this.games.GetUpcoming()
                .To<UpcomingGameViewModel>()
                .Take(10);

            return this.View(games);
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