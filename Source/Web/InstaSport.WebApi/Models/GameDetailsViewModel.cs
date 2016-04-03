using InstaSport.Data.Models;
using InstaSport.Web.Infrastructure.Mapping;

namespace InstaSport.WebApi.Models
{
    public class GameDetailsViewModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }
    }
}