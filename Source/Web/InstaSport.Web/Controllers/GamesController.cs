namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using InstaSport.Services.Data;
    using ViewModels.Games;

    public class GamesController : BaseController
    {
        private IGamesService games;

        public GamesController(IGamesService games)
        {
            this.games = games;
        }

        public ActionResult Index()
        {
            var games = this.games.GetUpcoming()
                .To<UpcomingGameViewModel>()
                .Take(10);

            return this.View(games);
        }
    }
}