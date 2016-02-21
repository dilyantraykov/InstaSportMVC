namespace InstaSport.Services.Data
{
    using System.Linq;
    using InstaSport.Data.Models;

    public interface IGamesService
    {
        IQueryable<Game> GetUpcoming();

        IQueryable<Game> GetByCity(int cityId);
    }
}
