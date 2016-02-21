namespace InstaSport.Services.Data
{
    using System.Linq;
    using InstaSport.Data.Models;

    public interface IRatingsService
    {
        IQueryable<PlayerRating> GetAllPlayerRatings();

        IQueryable<LocationRating> GetAllLocationRatings();
    }
}
