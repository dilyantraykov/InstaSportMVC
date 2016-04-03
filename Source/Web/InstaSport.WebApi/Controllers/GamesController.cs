using InstaSport.Data.Models;
using InstaSport.Services.Data;
using InstaSport.Web.Infrastructure.Mapping;
using InstaSport.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace InstaSport.WebApi.Controllers
{
    public class GamesController : ApiController
    {
        private IGamesService games;
        
        public GamesController(IGamesService games)
        {
            this.games = games;
        }

        public IEnumerable<GameDetailsViewModel> Get()
        {
            var games = this.games.GetAll().To<GameDetailsViewModel>().ToList();
            return games;
        }
    }
}
